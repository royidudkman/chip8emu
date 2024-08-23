using chip8emu.Chip8;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.LinkLabel;

namespace chip8emu.Utils
{
	public class OpcodeHandler
	{
		private Cpu cpu;

        public OpcodeHandler(Cpu cpu)
        {
            this.cpu = cpu;
        }

        public void HandleOpcode()
        {
			bool equal = true;
			bool pressed = true;

			switch (cpu.Opcode & 0xF000)
			{
				case 0x0000:
					switch (cpu.Opcode & 0x000F)
					{
						case 0x0000:
							clearScreen();
							break;
						case 0x000E:
							returnFromSubroutine();
							break;
						default:
							Console.WriteLine($"Unknown opcode [0x0000]: 0x{cpu.Opcode}\n");
							break;
					}
					break;
				case 0x1000:
					jumpToAddress();
					break;
				case 0x2000:
					callSubroutine();
					break;
				case 0x3000:
					skipTheNextInstructionVXNN(equal);
					break;
				case 0x4000:
					skipTheNextInstructionVXNN(!equal);
					break;
				case 0x5000:
					skipTheNextInstructionVXVY(equal);
					break;
				case 0x6000:
					setVXtoNN();
					break;
				case 0x7000:
					addNNtoVX();
					break;
				case 0x8000:
					switch (cpu.Opcode & 0x000F)
					{
						case 0x0000:
							setVXtoVY();
							break;
						case 0x0001:
							setVXtoVXorVY();
							break;
						case 0x0002:
							setVXtoVXandVY();
							break;
						case 0x0003:
							setVXtoVXxorVY();
							break;
						case 0x0004:
							addVYtoVX();
							break;
						case 0x0005:
							subVYfromVX();
							break;
						case 0x0006:
							shiftVXtoRight();
							break;
						case 0x0007:
							setVXtoVYminusVX();
							break;
						case 0x000E:
							shiftVXtoLeft();
							break;
						default:
							Console.WriteLine($"Unknown opcode : 0x{cpu.Opcode}\n");
							break;
					}
					break;
				case 0x9000:
					skipTheNextInstructionVXVY(!equal);
					break;
				case 0xA000:
					setItoAddressNNN();
					break;
				case 0xB000:
					jumpToAddressNNNplusV0();
					break;
				case 0xC000:
					setVXtoRandomAndNN();
					break;
				case 0xD000:
					drawSpriteAtVXVY();
					break;
				case 0xE000:
					switch (cpu.Opcode & 0x000F)
					{
						case 0x000E:
							skipIfKeyPressed(pressed);
							break;
						case 0x0001:
							skipIfKeyPressed(!pressed);
							break;
						default:
							Console.WriteLine($"Unknown opcode : 0x{cpu.Opcode}\n");
							break;
					}
					break;
				case 0xF000:
					switch (cpu.Opcode & 0x00FF)
					{
						case 0x0007:
							setVXtoDelayTimer();
							break;
						case 0x000A:
							waitForKeyPress();
							break;
						case 0x0015:
							setDelayTimertoVX();
							break;
						case 0x0018:
							setSoundTimertoVX();
							break;
						case 0x001E:
							addVXtoI();
							break;
						case 0x0029:
							setSpriteLocation();
							break;
						case 0x0033:
							storeBCDofVX();
							break;
						case 0x0055:
							storeRegistersInMemory();
							break;
						case 0x0065:
							loadRegistersFromMemory();
							break;
						default:
							Console.WriteLine($"Unknown opcode : 0x{cpu.Opcode}\n");
							break;
					}
					break;

				default:
					Console.WriteLine($"Unknown opcode : 0x{cpu.Opcode}\n");
					break;

			}
		}

		//FX65
		private void loadRegistersFromMemory()
		{
			byte xIndex = (byte)((cpu.Opcode & 0x0F00) >> 8);

			if (xIndex < cpu.V.Length)
			{
				for (byte i = 0; i <= xIndex; i++)
				{
					cpu.V[i] = cpu.Memory[cpu.I + i];
				}
			}

			cpu.pc += 2;
		}

		//FX55
		private void storeRegistersInMemory()
		{
			byte xIndex = (byte)((cpu.Opcode & 0x0F00) >> 8);

			if (xIndex < cpu.V.Length)
			{
				for(byte i= 0; i < xIndex; i++)
				{
					cpu.Memory[cpu.I + i] = cpu.V[i];
				}
			}

			cpu.pc += 2;
		}

		//FX33
		private void storeBCDofVX()
		{
			byte xIndex = (byte)((cpu.Opcode & 0x0F00) >> 8);
			if (xIndex < cpu.V.Length)
			{
				byte value = cpu.V[xIndex];

				cpu.Memory[cpu.I] = (byte)(value / 100);
				cpu.Memory[cpu.I + 1] = (byte)((value / 10) % 10);
				cpu.Memory[cpu.I + 2] = (byte)(value % 10);
			}

			cpu.pc += 2;
		}

		//FX29
		private void setSpriteLocation()
		{
			byte xIndex = (byte)((cpu.Opcode & 0x0F00) >> 8);
			byte character = cpu.V[xIndex];

			ushort fontStartAddress = 0x000;

			cpu.I = (ushort)(fontStartAddress + (character * 5));

			cpu.pc += 2;
		}

		//FX1E
		private void addVXtoI()
		{
			byte xIndex = (byte)((cpu.Opcode & 0x0F00) >> 8);
			if (xIndex < cpu.V.Length)
			{
				cpu.I += cpu.V[xIndex];
			}

			cpu.pc += 2;
		}

		//FX18
		private void setSoundTimertoVX()
		{
			byte xIndex = (byte)((cpu.Opcode & 0x0F00) >> 8);
			if (xIndex < cpu.V.Length)
			{
				cpu.SoundTimer = cpu.V[xIndex];
			}

			cpu.pc += 2;
		}

		//FX15
		private void setDelayTimertoVX()
		{
			byte xIndex = (byte)((cpu.Opcode & 0x0F00) >> 8);
			if (xIndex < cpu.V.Length)
			{
				cpu.DelayTimer = cpu.V[xIndex];
			}

			cpu.pc += 2;
		}

		//FX0A
		private void waitForKeyPress()
		{
			byte xIndex = (byte)((cpu.Opcode & 0x0F00) >> 8);
			bool keyPressed = false;

			for(byte i =0; i< cpu.input.Key.Length; i++)
			{
				if (cpu.input.Key[i] !=0)
				{
					cpu.V[xIndex] = i;

					keyPressed = true;

					cpu.pc += 2;
					break;
				}
			}

			if(!keyPressed)
			{
				
			}
		}

		//FX07
		private void setVXtoDelayTimer()
		{
			byte xIndex = (byte)((cpu.Opcode & 0x0F00) >> 8);
			if (xIndex < cpu.V.Length)
			{
				cpu.V[xIndex] = cpu.DelayTimer;
			}

			cpu.pc += 2;
		}

		//EX9E EXA1
		private void skipIfKeyPressed(bool skipOnPressed)
		{
			byte xIndex = (byte)((cpu.Opcode & 0x0F00) >> 8);

			if (xIndex < cpu.V.Length)
			{
				bool condition = (cpu.input.Key[cpu.V[xIndex]] != 0);

				if ((skipOnPressed && condition) || (!skipOnPressed && !condition))
				{
					cpu.pc += 4;
				}

				else
				{
					cpu.pc += 2;
				}
			}
		}

		//DXYN
		private void drawSpriteAtVXVY()
		{
			byte xIndex = (byte)((cpu.Opcode & 0x0F00) >> 8);
			byte yIndex = (byte)((cpu.Opcode & 0x00F0) >> 4);
			byte height = (byte)((cpu.Opcode & 0x000F));
			byte x = cpu.V[xIndex];
			byte y = cpu.V[yIndex];
			byte pixel;

			cpu.V[0xF] = 0;

			for(int yLine = 0; yLine < height; yLine++)
			{
				pixel = cpu.Memory[cpu.I + yLine];

				for(int xLine = 0; xLine < 8; xLine++)
				{
					if ((pixel & (0x80 >> xLine)) != 0)
					{
						if (cpu.Graphics.gfx[(x + xLine + ((y + yLine) * 64))] == 1)
						{
							cpu.V[0xF] = 1;
						}

						cpu.Graphics.gfx[x + xLine + ((y + yLine) * 64)] ^= 1;
					}
				}
			}
			cpu.DrawFlag = true; 
			cpu.pc += 2;
		}

		//CXNN
		private void setVXtoRandomAndNN()
		{
			byte xIndex = (byte)((cpu.Opcode & 0x0F00) >> 8);
			byte nnValue = (byte)(cpu.Opcode & 0x00FF);
			Random random = new Random();
			byte randomValue = (byte)random.Next(0, 256);

			if(xIndex < cpu.V.Length)
			{
				cpu.V[xIndex] = (byte)(nnValue & randomValue);
			}

			cpu.pc += 2;
		}

		//BNNN
		private void jumpToAddressNNNplusV0()
		{
			byte address = (byte)((cpu.Opcode & 0x0FFF));
			cpu.pc = (ushort)(address + cpu.V[0x0]);
		}

		//ANNN
		private void setItoAddressNNN()
		{
			byte address = (byte)((cpu.Opcode & 0x0FFF));
			cpu.I = address;
			cpu.pc += 2;
		}

		//8XYE
		private void shiftVXtoLeft()
		{
			byte xIndex = (byte)((cpu.Opcode & 0x0F00) >> 8);

			if (xIndex < cpu.V.Length)
			{
				cpu.V[0xF] = (byte)(cpu.V[xIndex] & 0x80 >> 7);
				cpu.V[xIndex] <<= 1;
			}

			cpu.pc += 2;
		}

		//8XY7
		private void setVXtoVYminusVX()
		{
			byte xIndex = (byte)((cpu.Opcode & 0x0F00) >> 8);
			byte yIndex = (byte)((cpu.Opcode & 0x00F0) >> 4);

			if (xIndex < cpu.V.Length && yIndex < cpu.V.Length)
			{
				if (cpu.V[yIndex] >= cpu.V[xIndex])
				{
					cpu.V[0xF] = 1;
				}
				else
				{
					cpu.V[0xF] = 0;
				}

				cpu.V[xIndex] = (byte)(cpu.V[yIndex] - cpu.V[xIndex]);	
			}

			cpu.pc += 2;
		}

		//8XY6
		private void shiftVXtoRight()
		{
			byte xIndex = (byte)((cpu.Opcode & 0x0F00) >> 8);
			
			if(xIndex < cpu.V.Length)
			{
				cpu.V[0xF] = (byte)(cpu.V[xIndex] & 0x01);
				cpu.V[xIndex] >>= 1;
			}

			cpu.pc += 2;
		}

		//8XY5
		private void subVYfromVX()
		{
			byte xIndex = (byte)((cpu.Opcode & 0x0F00) >> 8);
			byte yIndex = (byte)((cpu.Opcode & 0x00F0) >> 4);

			if (xIndex < cpu.V.Length && yIndex < cpu.V.Length)
			{
				if (cpu.V[xIndex] >= cpu.V[yIndex])
				{
					cpu.V[0xF] = 1;
				}
				else
				{
					cpu.V[0xF] = 0;
				}

				cpu.V[xIndex] -= cpu.V[yIndex];
			}

			cpu.pc += 2;
		}

		//8XY4
		private void addVYtoVX()
		{
			byte xIndex = (byte)((cpu.Opcode & 0x0F00) >> 8);
			byte yIndex = (byte)((cpu.Opcode & 0x00F0) >> 4);

			if (xIndex < cpu.V.Length && yIndex < cpu.V.Length)
			{
				int sum = cpu.V[xIndex] + cpu.V[yIndex];
				cpu.V[0xF] = (byte)(sum > 255 ? 1 : 0);
				cpu.V[xIndex] = (byte)(sum & 0xFF);
			}

			cpu.pc += 2;
		}

		//8XY3
		private void setVXtoVXxorVY()
		{
			byte xIndex = (byte)((cpu.Opcode & 0x0F00) >> 8);
			byte yIndex = (byte)((cpu.Opcode & 0x00F0) >> 4);

			if (xIndex < cpu.V.Length && yIndex < cpu.V.Length)
			{
				cpu.V[xIndex] ^= cpu.V[yIndex];
			}

			cpu.pc += 2;
		}

		//8XY2
		private void setVXtoVXandVY()
		{
			byte xIndex = (byte)((cpu.Opcode & 0x0F00) >> 8);
			byte yIndex = (byte)((cpu.Opcode & 0x00F0) >> 4);

			if (xIndex < cpu.V.Length && yIndex < cpu.V.Length)
			{
				cpu.V[xIndex] &= cpu.V[yIndex];
			}

			cpu.pc += 2;
		}

		//8XY1
		private void setVXtoVXorVY()
		{
			byte xIndex = (byte)((cpu.Opcode & 0x0F00) >> 8);
			byte yIndex = (byte)((cpu.Opcode & 0x00F0) >> 4);

			if (xIndex < cpu.V.Length && yIndex < cpu.V.Length)
			{
				cpu.V[xIndex] |= cpu.V[yIndex];
			}
			
			cpu.pc += 2;
		}

		//8XY0
		private void setVXtoVY()
		{
			byte xIndex = (byte)((cpu.Opcode & 0x0F00) >> 8);
			byte yIndex = (byte)((cpu.Opcode & 0x00F0) >> 4);

			if(xIndex < cpu.V.Length && yIndex < cpu.V.Length)
			{
				cpu.V[xIndex] = cpu.V[yIndex];
			}

			cpu.pc += 2;
		}

		//7XNN
		private void addNNtoVX()
		{
			byte xIndex = (byte)((cpu.Opcode & 0x0F00) >> 8);
			byte nnValue = (byte)(cpu.Opcode & 0x00FF);

			if (xIndex < cpu.V.Length)
			{
				cpu.V[xIndex] += nnValue;
			}
			cpu.pc += 2;
		}

		//6XNN
		private void setVXtoNN()
		{
			byte xIndex = (byte)((cpu.Opcode & 0x0F00) >> 8);
			byte nnValue = (byte)(cpu.Opcode & 0x00FF);

			if(xIndex < cpu.V.Length)
			{
				cpu.V[xIndex] = nnValue;	
			}

			cpu.pc += 2;
		}

		//5XY0 9XY0
		private void skipTheNextInstructionVXVY(bool skipOnEqual)
		{
			byte xIndex = (byte)((cpu.Opcode & 0x0F00) >> 8);
			byte yIndex = (byte)((cpu.Opcode & 0x00F0) >> 4);

			if(xIndex < cpu.V.Length && yIndex < cpu.V.Length)
			{
				bool condition = (cpu.V[xIndex] == cpu.V[yIndex]);

				if ((skipOnEqual && condition) || (!skipOnEqual && !condition))
				{
					cpu.pc += 4;
				}

				else
				{
					cpu.pc += 2;
				}
			}
		}

		//3XNN 4XNN
		private void skipTheNextInstructionVXNN(bool skipOnEqual)
		{
			byte xIndex = (byte)((cpu.Opcode & 0x0F00) >> 8);
			byte nnValue = (byte)(cpu.Opcode & 0x00FF);

			if (xIndex < cpu.V.Length)
			{
				bool condition = (cpu.V[xIndex] == nnValue);

				if ((skipOnEqual && condition) || (!skipOnEqual && !condition))
				{
					cpu.pc += 4; 
				}
				else
				{
					cpu.pc += 2; 
				}
			}
			else
			{
				Console.WriteLine($"Invalid register index: {xIndex}");
				cpu.pc += 2; 
			}
		}

		//2NNN
		private void callSubroutine()
		{
			if(cpu.sp< cpu.Stack.Length)
			{
				cpu.Stack[cpu.sp] = cpu.pc;
				cpu.sp++;
				cpu.pc = (ushort)(cpu.Opcode & 0x0FFF);
			}
			
		}

		//1NNN
		private void jumpToAddress()
		{
			ushort address = (ushort)(cpu.Opcode & 0x0FFF);
			cpu.pc = address;
		}

		//00EE
		private void returnFromSubroutine()
		{
			if(cpu.sp > 0)
			{
				cpu.sp--;
				cpu.pc = cpu.Stack[cpu.sp];
			}
			
		}

		//00E0
		private void clearScreen()
		{
			cpu.Graphics.ClearScreen();
			cpu.pc += 2;
		}
	}
}
