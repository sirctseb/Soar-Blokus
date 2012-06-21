using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace SoarBlokus
{
	public partial class BlokusGUI : Form
	{
		public BlokusModel model = new BlokusModel();

		public BlokusGUI()
		{
			InitializeComponent();
			InitializeGridView();
		}

		private void InitializeGridView()
		{
			boardView.ColumnCount = 20;
			for (int i = 0; i < 20; i++)
			{
				//boardView.Columns.Add(new DataGridViewColumn();
				boardView.Rows.Add(model.boardModel.squares[i]);
			}
		}

		private void boardView_CellContentClick(object sender, DataGridViewCellEventArgs e)
		{
			// TODO cycle color of square on click
		}

		private void boardView_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
		{
			// TODO set background color from data
		}
	}
}
