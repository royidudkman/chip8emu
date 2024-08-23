using chip8emu.Utils;

namespace chip8emu
{
	partial class Form1
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
			this.components = new System.ComponentModel.Container();
			this.emulationTimer = new System.Windows.Forms.Timer(this.components);
			this.pictureBoxDisplay = new System.Windows.Forms.PictureBox();
			this.loadProgramToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.openToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.menuStrip1 = new System.Windows.Forms.MenuStrip();
			((System.ComponentModel.ISupportInitialize)(this.pictureBoxDisplay)).BeginInit();
			this.menuStrip1.SuspendLayout();
			this.SuspendLayout();
			// 
			// emulationTimer
			// 
			this.emulationTimer.Interval = 16;
			this.emulationTimer.Tick += new System.EventHandler(this.emulationTimer_Tick);
			// 
			// pictureBoxDisplay
			// 
			this.pictureBoxDisplay.Location = new System.Drawing.Point(22, 57);
			this.pictureBoxDisplay.Name = "pictureBoxDisplay";
			this.pictureBoxDisplay.Size = new System.Drawing.Size(640, 320);
			this.pictureBoxDisplay.TabIndex = 1;
			this.pictureBoxDisplay.TabStop = false;
			// 
			// loadProgramToolStripMenuItem
			// 
			this.loadProgramToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.openToolStripMenuItem});
			this.loadProgramToolStripMenuItem.Name = "loadProgramToolStripMenuItem";
			this.loadProgramToolStripMenuItem.Size = new System.Drawing.Size(37, 20);
			this.loadProgramToolStripMenuItem.Text = "File";
			// 
			// openToolStripMenuItem
			// 
			this.openToolStripMenuItem.Name = "openToolStripMenuItem";
			this.openToolStripMenuItem.Size = new System.Drawing.Size(103, 22);
			this.openToolStripMenuItem.Text = "Open";
			this.openToolStripMenuItem.Click += new System.EventHandler(this.openToolStripMenuItem_Click);
			// 
			// menuStrip1
			// 
			this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.loadProgramToolStripMenuItem});
			this.menuStrip1.Location = new System.Drawing.Point(0, 0);
			this.menuStrip1.Name = "menuStrip1";
			this.menuStrip1.Size = new System.Drawing.Size(683, 24);
			this.menuStrip1.TabIndex = 2;
			this.menuStrip1.Text = "menuStrip1";
			// 
			// Form1
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(683, 397);
			this.Controls.Add(this.pictureBoxDisplay);
			this.Controls.Add(this.menuStrip1);
			this.MainMenuStrip = this.menuStrip1;
			this.Name = "Form1";
			this.Text = "Form1";
			((System.ComponentModel.ISupportInitialize)(this.pictureBoxDisplay)).EndInit();
			this.menuStrip1.ResumeLayout(false);
			this.menuStrip1.PerformLayout();
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.Timer emulationTimer;
		private System.Windows.Forms.PictureBox pictureBoxDisplay;
		private System.Windows.Forms.ToolStripMenuItem loadProgramToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem openToolStripMenuItem;
		private System.Windows.Forms.MenuStrip menuStrip1;
	}
}

