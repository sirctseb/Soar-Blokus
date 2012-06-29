using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using SMLExtension;

namespace SoarBlokus
{
	public partial class BlokusGUI : Form
	{
		sml.Kernel kernel = null;
		sml.Agent agent = null;
		public BlokusModel model = new BlokusModel();
		public Dictionary<Tuple<int, int>, BlokusColor> changes = new Dictionary<Tuple<int, int>, BlokusColor>();

		public BlokusGUI()
		{
			InitializeComponent();
			InitializeGridView();
		}

		private void InitializeGridView()
		{
			boardView.ColumnHeadersVisible = false;
			boardView.RowHeadersVisible = false;
			boardView.ColumnCount = 20;
			for (int i = 0; i < 20; i++)
			{
				boardView.Rows.Add(model.boardModel.GetRow(i));
			}
			boardView.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
			boardView.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.None;
		}

		private void boardView_CellContentClick(object sender, DataGridViewCellEventArgs e)
		{
			// cycle color of square on click
			Square square = ((Square)boardView[e.ColumnIndex, e.RowIndex].Value);
			square.color += 1;
			if ((int)square.color >= Enum.GetValues(square.color.GetType()).Length)
			{
				square.color = 0;
			}

			Console.WriteLine("cycling square color");
			// TODO update view to force formatting?
			// store the new color of the square in the changes dict
			changes[Tuple.Create(e.ColumnIndex, e.RowIndex)] = square.color;
		}

		private void boardView_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
		{
			// set background color from data
			switch (((Square)boardView[e.ColumnIndex, e.RowIndex].Value).color)
			{
				case BlokusColor.Blue:
					e.CellStyle.BackColor = Color.Blue;
				break;
				case BlokusColor.Green:
					e.CellStyle.BackColor = Color.Green;
				break;
				case BlokusColor.Red:
					e.CellStyle.BackColor = Color.Red;
				break;
				case BlokusColor.Yellow:
					e.CellStyle.BackColor = Color.Yellow;
				break;
				default:
				break;
			}
		}
		private sml.Kernel.UpdateEventCallback handleOutput;
		private void startKernelButton_Click(object sender, EventArgs e)
		{
			// create kernel
			kernel = sml.Kernel.CreateKernelInNewThread();

			// TODO handle error
			if (kernel.HadError())
			{
				return;
			}

			// create agent
			agent = kernel.CreateAgent("blue");
			if (agent.HadError())
			{
				return;
			}
			// load rules
			agent.LoadProductions(@"..\..\..\..\soar-blokus.soar");

			// register for output
			handleOutput = new sml.Kernel.UpdateEventCallback(HandleAgentOuput);
			kernel.RegisterForUpdateEvent(sml.smlUpdateEventId.smlEVENT_AFTER_ALL_OUTPUT_PHASES, handleOutput, null);
		}

		private void runAgentButton_Click(object sender, EventArgs e)
		{
			// TODO put stuff on input-link
			// TODO this should also be in output handler
			foreach (var entry in changes)
			{
				// create an ID on input link
				sml.Identifier squareID = agent.GetInputLink().CreateIdWME("square");
				// add x, y, and color
				squareID.CreateIntWME("x", entry.Key.Item1);
				squareID.CreateIntWME("y", 19 - entry.Key.Item2);
				squareID.CreateStringWME("color", entry.Value.ToString().ToLower());
			}
			// clear color changes
			changes.Clear();
			// TODO run agent
			agent.RunSelf(1);
		}
		//public delegate void UpdateEventCallback(smlUpdateEventId eventID, IntPtr callbackData, IntPtr kernel, smlRunFlags runFlags);
		public void HandleAgentOuput(sml.smlUpdateEventId eventID, IntPtr data, IntPtr kernel, sml.smlRunFlags runFlags)
		{
			// get stuff from output-link
			sml.Identifier moveCommand = agent.GetCommand("move");
			if (moveCommand != null)
			{
				// get placement info
				sml.Identifier placement = moveCommand.FindIDByAttribute("placement");
				if (placement != null)
				{
					// iterate over squares
					foreach (sml.Identifier squareID in placement.GetIDChildren("square"))
					{
						// get x,y from command
						int x = (int)squareID.FindIntByAttribute("x");
						int y = (int)squareID.FindIntByAttribute("y");

						// color square in board view
						((Square)boardView[x, 19 - y].Value).color = BlokusColor.Blue;
						boardView.InvalidateCell(x, 19 - y);

						// put change in change list to send back to agent
						changes[Tuple.Create(x, 19 - y)] = BlokusColor.Blue;
					}

					// clear output changes
					agent.ClearOutputLinkChanges();
					// mark command as complete
					moveCommand.AddStatusComplete();
					agent.Commit();
				}
				else
				{
					Console.WriteLine("Error getting placement info: placement attribute DNE");
				}
			}
		}

		private void boardView_SelectionChanged(object sender, EventArgs e)
		{
			boardView.ClearSelection();
		}
	}
}
