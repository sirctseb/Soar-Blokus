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
		public BlokusGUI()
		{
			InitializeComponent();
		}

		private void boardView_CellContentClick(object sender, DataGridViewCellEventArgs e)
		{
			// TODO cycle color of square on click

		}
	}
}
