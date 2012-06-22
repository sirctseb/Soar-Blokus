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
			this.startKernelButton = new System.Windows.Forms.Button();
			this.runAgentButton = new System.Windows.Forms.Button();
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
			this.boardView.SelectionChanged += new System.EventHandler(this.boardView_SelectionChanged);
			// 
			// startKernelButton
			// 
			this.startKernelButton.Location = new System.Drawing.Point(598, 30);
			this.startKernelButton.Name = "startKernelButton";
			this.startKernelButton.Size = new System.Drawing.Size(75, 23);
			this.startKernelButton.TabIndex = 1;
			this.startKernelButton.Text = "Start Kernel";
			this.startKernelButton.UseVisualStyleBackColor = true;
			this.startKernelButton.Click += new System.EventHandler(this.startKernelButton_Click);
			// 
			// runAgentButton
			// 
			this.runAgentButton.Location = new System.Drawing.Point(598, 59);
			this.runAgentButton.Name = "runAgentButton";
			this.runAgentButton.Size = new System.Drawing.Size(75, 23);
			this.runAgentButton.TabIndex = 2;
			this.runAgentButton.Text = "Run Agent";
			this.runAgentButton.UseVisualStyleBackColor = true;
			this.runAgentButton.Click += new System.EventHandler(this.runAgentButton_Click);
			// 
			// BlokusGUI
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(763, 513);
			this.Controls.Add(this.runAgentButton);
			this.Controls.Add(this.startKernelButton);
			this.Controls.Add(this.boardView);
			this.Name = "BlokusGUI";
			this.Text = "Form1";
			((System.ComponentModel.ISupportInitialize)(this.boardView)).EndInit();
			this.ResumeLayout(false);

		}

		#endregion

		private System.Windows.Forms.DataGridView boardView;
		private System.Windows.Forms.Button startKernelButton;
		private System.Windows.Forms.Button runAgentButton;
	}
}

