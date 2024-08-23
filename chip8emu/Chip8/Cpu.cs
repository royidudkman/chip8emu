using chip8emu.Utils;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace chip8emu.Chip8
{
	public class Cpu
	{
		public ushort Opcode { get; set; }
		public byte[] Memory { get; set; }
        public byte[] V { get; set; } // registers
        public ushort I { get; set; } // index register
        public ushort pc { get; set; } //program counter
        public byte DelayTimer { get; set; }
        public byte SoundTimer { get; set; }
		public ushort[] Stack { get; set; }
		public ushort sp { get; set; } //stack pointer


        public bool DrawFlag { get; set; }  

        public chipGraphics Graphics { get; set; }
        public Input input { get; set; }

        private OpcodeHandler opcodeHandler;

		public Cpu()
        {
            initialize();
        }

        private void initialize()
        {
			Memory = new byte[4096];
			V = new byte[16];
			Stack = new ushort[16];
			pc = 0x200;
			Opcode = 0;
			I = 0;
			sp = 0;
			DelayTimer = 0;
			SoundTimer = 0;
			Array.Clear(Memory, 0, 4096);
			loadFontSet();
            opcodeHandler = new OpcodeHandler(this);
		}

        public void FetchOpcode()
        {
            Opcode = (ushort)(Memory[pc] << 8 | Memory[pc + 1]);
        }

        public void DecodeOpcode()
        {
            opcodeHandler.HandleOpcode();
        }


        private void loadFontSet()
        {
			byte[] chip8_fontset = new byte[80]
            {
                0xF0, 0x90, 0x90, 0x90, 0xF0, // 0
                0x20, 0x60, 0x20, 0x20, 0x70, // 1
                0xF0, 0x10, 0xF0, 0x80, 0xF0, // 2
                0xF0, 0x10, 0xF0, 0x10, 0xF0, // 3
                0x90, 0x90, 0xF0, 0x10, 0x10, // 4
                0xF0, 0x80, 0xF0, 0x10, 0xF0, // 5
                0xF0, 0x80, 0xF0, 0x90, 0xF0, // 6
                0xF0, 0x10, 0x20, 0x40, 0x40, // 7
                0xF0, 0x90, 0xF0, 0x90, 0xF0, // 8
                0xF0, 0x90, 0xF0, 0x10, 0xF0, // 9
                0xF0, 0x90, 0xF0, 0x90, 0x90, // A
                0xE0, 0x90, 0xE0, 0x90, 0xE0, // B
                0xF0, 0x80, 0x80, 0x80, 0xF0, // C
                0xE0, 0x90, 0x90, 0x90, 0xE0, // D
                0xF0, 0x80, 0xF0, 0x80, 0xF0, // E
                0xF0, 0x80, 0xF0, 0x80, 0x80  // F
            };

			for (int i = 0; i < 80; i++)
            {
                Memory[i] = chip8_fontset[i];
            }
        }

		public event PropertyChangedEventHandler PropertyChanged;

    


	}
}
