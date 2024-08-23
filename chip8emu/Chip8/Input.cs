using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace chip8emu.Chip8
{
	public class Input
	{
		public byte[] Key { get; set; }

        public Input()
        {
			Key = new byte[16];
        }
    }
}
