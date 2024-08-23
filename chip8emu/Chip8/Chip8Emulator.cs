using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace chip8emu.Chip8
{
	public class Chip8Emulator
	{
        public Cpu cpu { get;set; }
        public chipGraphics graphics { get; set; }
        public Input input { get; set; }
	

		public Chip8Emulator()
        {
            initialize();
        }

        private void initialize()
        {
            cpu = new Cpu();
            graphics = new chipGraphics();
            input = new Input();    
            cpu.Graphics = graphics;
            cpu.input = input;
		}

       

        public void EmulateCycle()
        {
            
            cpu.FetchOpcode();

            cpu.DecodeOpcode();

            if (cpu.DelayTimer > 0)
            {
                cpu.DelayTimer--;
            }

			if (cpu.SoundTimer > 0)
			{
				if (cpu.SoundTimer == 1)
				{
					// Play sound or trigger some sound event
				}
				cpu.SoundTimer--;
			}

			if (cpu.DrawFlag)
			{

				// Update the graphics
				// e.g., refresh the display in your form
				cpu.DrawFlag = false; // Reset the flag after updating
			}
		}

        public void LoadProgram(string filePath)
        {
            byte[] buffer = File.ReadAllBytes(filePath);
            int bufferSize = buffer.Length;

            for(int i = 0; i < bufferSize; ++i)
            {
                cpu.Memory[i + 512] = buffer[i];
            }
        }

		internal System.Drawing.Image GetScreenBitmap()
		{
            return graphics.GetBitmap();
		}
	}
}
