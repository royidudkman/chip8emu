using chip8emu.Chip8;
using chip8emu.Utils;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace chip8emu
{
	public partial class Form1 : Form
	{
		private Chip8.Chip8Emulator myChip8;
	
		public Form1()
		{
			InitializeComponent();
            myChip8 = new Chip8.Chip8Emulator();	
			cpuBindingSource.DataSource = myChip8.cpu;
		}

		private void openToolStripMenuItem_Click(object sender, EventArgs e)
		{
			OpenFileDialog openFileDialog = new OpenFileDialog
			{
				Filter = "Chip8 Files (*.ch8, *.bin, *.rom)|*.ch8;*.bin;*.rom|All Files (*.*)|*.*",
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
			cpuBindingSource.ResetBindings(false);
			UpdateDisplay();
		}

		private void UpdateDisplay()
		{
			pictureBoxDisplay.Image = myChip8.GetScreenBitmap();
			DisplayRegisters();			
		}

		private void DisplayRegisters()
		{
			V0Value.Text = myChip8.cpu.V[0x0].ToString();
			V1Value.Text = myChip8.cpu.V[0x1].ToString();
			V2Value.Text = myChip8.cpu.V[0x2].ToString();
			V3Value.Text = myChip8.cpu.V[0x3].ToString();
			V4Value.Text = myChip8.cpu.V[0x4].ToString();
			V5Value.Text = myChip8.cpu.V[0x5].ToString();
			V6Value.Text = myChip8.cpu.V[0x6].ToString();
			V7Value.Text = myChip8.cpu.V[0x7].ToString();
			V8Value.Text = myChip8.cpu.V[0x8].ToString();
			V9Value.Text = myChip8.cpu.V[0x9].ToString();
			VAValue.Text = myChip8.cpu.V[0xA].ToString();
			VBValue.Text = myChip8.cpu.V[0xB].ToString();
			VCValue.Text = myChip8.cpu.V[0xC].ToString();
			VDValue.Text = myChip8.cpu.V[0xD].ToString();
			VEValue.Text = myChip8.cpu.V[0xE].ToString();
			VFValue.Text = myChip8.cpu.V[0xF].ToString();
		}

		protected override void OnKeyDown(KeyEventArgs e)
		{
			myChip8.input.Clear();
			base.OnKeyDown(e);
			switch(e.KeyCode)
			{
				case Keys.D1:
					myChip8.cpu.input.Key[1] = 1;
					break;
				case Keys.D2:
					myChip8.cpu.input.Key[2] = 1;
					break;
				case Keys.D3:
					myChip8.cpu.input.Key[3] = 1;
					break;
				
				case Keys.Q:
					myChip8.cpu.input.Key[4] = 1;
					break;
				case Keys.W:
					myChip8.cpu.input.Key[5] = 1;
					break;
				case Keys.E:
					myChip8.cpu.input.Key[6] = 1;
					break;

				case Keys.A:
					myChip8.cpu.input.Key[7] = 1;
					break;
				case Keys.S:
					myChip8.cpu.input.Key[8] = 1;
					break;
				case Keys.D:
					myChip8.cpu.input.Key[9] = 1;
					break;

				case Keys.Z:
					myChip8.cpu.input.Key[10] = 1;
					break;
				case Keys.X:
					myChip8.cpu.input.Key[0] = 1;
					break;
				case Keys.C:
					myChip8.cpu.input.Key[11] = 1;
					break;

				case Keys.D4:
					myChip8.cpu.input.Key[12] = 1;
					break;
				case Keys.R:
					myChip8.cpu.input.Key[13] = 1;
					break;
				case Keys.F:
					myChip8.cpu.input.Key[14] = 1;
					break;
				case Keys.V:
					myChip8.cpu.input.Key[15] = 1;
					break;

			}
		}
	}
}