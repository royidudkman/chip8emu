using chip8emu.Chip8;
using chip8emu.Utils;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace chip8emu
{
	public partial class Form1 : Form
	{
		private Chip8Emulator myChip8;
	
		public Form1()
		{
			InitializeComponent();
			myChip8 = new Chip8Emulator();
			startTestProgram();
		

		}

		private void startTestProgram()
		{
			string testPath = @"C:\\Users\\royi5\\Desktop\\chip8emu\\chip8emu\\chip8emu\\tests\\test_opcode.ch8";
			myChip8.LoadProgram(testPath);
			emulationTimer.Start();
		}

		private void openToolStripMenuItem_Click(object sender, EventArgs e)
		{
			OpenFileDialog openFileDialog = new OpenFileDialog
			{
				Filter = "Chip8 Files (*.ch8, *.bin)|*.ch8;*.bin|All Files (*.*)|*.*",
				FilterIndex = 1,
				Title = "Open Chip8 Program"
			};

			if (openFileDialog.ShowDialog() == DialogResult.OK)
			{
				string filePath = openFileDialog.FileName;
				myChip8.LoadProgram(filePath);
				emulationTimer.Start();
			}
		}

		private void emulationTimer_Tick(object sender, EventArgs e)
		{
			myChip8.EmulateCycle();
			UpdateDisplay();
			pictureBoxDisplay.Refresh();

			

		}

		private void UpdateDisplay()
		{
			pictureBoxDisplay.Image = myChip8.GetScreenBitmap();
			pictureBoxDisplay.Refresh();

		}
	}
}
