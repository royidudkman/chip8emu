using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace chip8emu.Chip8
{
	public class chipGraphics
	{
		public byte[] gfx { get; set; }
		private const int DisplayWidth = 64;
		private const int DisplayHeight = 32;
		private const int ScaleFactor = 10;
			

		public chipGraphics()
        {
            gfx = new byte[DisplayWidth * DisplayHeight];
        }

        public void ClearScreen()
        {
            Array.Clear(gfx, 0, gfx.Length);
        }

		public Bitmap GetBitmap()
		{
			// Create a new bitmap with the original dimensions
			Bitmap originalBitmap = new Bitmap(DisplayWidth, DisplayHeight);

			for (int y = 0; y < DisplayHeight; y++)
			{
				for (int x = 0; x < DisplayWidth; x++)
				{
					Color color = gfx[y * DisplayWidth + x] == 0 ? Color.Black : Color.White;
					originalBitmap.SetPixel(x, y, color);
				}
			}

			Bitmap scaledBitmap = new Bitmap(DisplayWidth * ScaleFactor, DisplayHeight * ScaleFactor);

			using (Graphics g = Graphics.FromImage(scaledBitmap))
			{
				g.DrawImage(originalBitmap, 0, 0, scaledBitmap.Width, scaledBitmap.Height);
			}

			return scaledBitmap;
		}

	}
}
