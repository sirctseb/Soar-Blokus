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
		}

		private void runAgentButton_Click(object sender, EventArgs e)
		{
			// TODO put stuff on input-link
			foreach (var entry in changes)
			{
				// create an ID on input link
				sml.Identifier squareID = agent.GetInputLink().CreateIdWME("square");
				// add x, y, and color
				squareID.CreateIntWME("x", entry.Key.Item2);
				squareID.CreateIntWME("y", 19 - entry.Key.Item1);
				squareID.CreateStringWME("color", entry.Value.ToString().ToLower());
			}
			// clear color changes
			changes.Clear();
			// TODO run agent
			agent.RunSelf(1);
			
			// TODO get stuff from output-link
		}

		private void boardView_SelectionChanged(object sender, EventArgs e)
		{
			boardView.ClearSelection();
		}
	}
}
