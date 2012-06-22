namespace SoarBlokus
{
	partial class BlokusGUI
	{
		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.IContainer components = null;

		/// <summary>
		/// Clean up any resources being used.
		/// </summary>
		/// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
		protected override void Dispose(bool disposing)
		{
			if (disposing && (components != null))
			{
				components.Dispose();
			}
			base.Dispose(disposing);
		}

		#region Windows Form Designer generated code

		/// <summary>
		/// Required method for Designer support - do not modify
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{
			this.boardView = new System.Windows.Forms.DataGridView();
			((System.ComponentModel.ISupportInitialize)(this.boardView)).BeginInit();
			this.SuspendLayout();
			// 
			// boardView
			// 
			this.boardView.AllowUserToAddRows = false;
			this.boardView.AllowUserToDeleteRows = false;
			this.boardView.AllowUserToResizeColumns = false;
			this.boardView.AllowUserToResizeRows = false;
			this.boardView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
			this.boardView.Location = new System.Drawing.Point(40, 30);
			this.boardView.Name = "boardView";
			this.boardView.Size = new System.Drawing.Size(540, 445);
			this.boardView.TabIndex = 0;
			this.boardView.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.boardView_CellContentClick);
			this.boardView.CellFormatting += new System.Windows.Forms.DataGridViewCellFormattingEventHandler(this.boardView_CellFormatting);
			// 
			// BlokusGUI
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(609, 513);
			this.Controls.Add(this.boardView);
			this.Name = "BlokusGUI";
			this.Text = "Form1";
			((System.ComponentModel.ISupportInitialize)(this.boardView)).EndInit();
			this.ResumeLayout(false);

		}

		#endregion

		private System.Windows.Forms.DataGridView boardView;
	}
}

