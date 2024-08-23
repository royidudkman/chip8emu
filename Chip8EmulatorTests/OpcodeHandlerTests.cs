using Microsoft.VisualStudio.TestTools.UnitTesting;
using chip8emu.Utils;
using chip8emu.Chip8;
using System.Runtime.CompilerServices;

namespace Chip8EmulatorTests
{
	[TestClass]
	public class OpcodeHandlerTests
	{
		public Cpu cpu { get; set; }
		public chipGraphics graphics { get; set; }
		public Input input { get; set; }

		private OpcodeHandler handler;

		[TestInitialize]
		public void Setup()
		{
			cpu = new Cpu();
			graphics = new chipGraphics();
			input = new Input();
			cpu.Graphics = graphics;
			cpu.input = input;
			handler = new OpcodeHandler(cpu);
		}

		[TestMethod] //00E0
		public void TestClearScreenOpcode()
		{
			cpu.Opcode = 0x00E0;
			handler.HandleOpcode();

			bool isScreenCleared = cpu.Graphics.gfx.All(v => v == 0);
			Assert.IsTrue(isScreenCleared, "The screen should be cleared.");
		}

		[TestMethod] //00EE
		public void TestReturnFromSubroutine()
		{
			ushort sp = 5;
			cpu.pc = 0x200;
			cpu.sp = sp;
			cpu.Stack[cpu.sp] = 0;
			
			cpu.Opcode = 0x00EE;
			handler.HandleOpcode();

			Assert.AreEqual( cpu.Stack[cpu.sp], cpu.pc, "The program counter should be set to the return address from the stack.");
			Assert.AreEqual( sp - 1, cpu.sp ,"the stack pointer should decrease by 1");
		}

		[TestMethod] //1NNN
		public void TestJumpToAddress()
		{
			cpu.pc = 0x200;

			cpu.Opcode = 0x1354;
			handler.HandleOpcode();

			Assert.AreEqual( 0x354, cpu.pc, "the program counter should be equal to the address NNN of the opcode");
		}

		[TestMethod] //2NNN
		public void TestCallSubroutine()
		{
			ushort pc = 0x300;
			ushort sp = 5;
			cpu.sp = sp;
			cpu.Stack[cpu.sp] = 0x200;
			cpu.pc = pc;

			cpu.Opcode = 0x2756;
			handler.HandleOpcode();

			Assert.AreEqual(sp + 1, cpu.sp,  "the stack pointer should increase by 1");
			Assert.AreEqual(cpu.Stack[sp], pc,  "the current pc should be on top of the stack");
			Assert.AreEqual(0x756, cpu.pc,  "the pc need to be set to NNN");
		}

		[TestMethod] //3XNN //4XNN
		public void TestSkipTheNextInstructionVXNN()
		{
			//3XNN

			cpu.V[0x5] = 0x48;
			cpu.pc = 0;
			
			cpu.Opcode = 0x3548;
			handler.HandleOpcode();

			Assert.AreEqual(4, cpu.pc, "pc should increase by 4 because Vx = NN");

			cpu.V[0x5] = 0x50;
			cpu.pc = 0;

			cpu.Opcode = 0x3548;
			handler.HandleOpcode();

			Assert.AreEqual(2, cpu.pc, "pc should increase by 2 because Vx != NN");

			//4XNN

			cpu.V[0x5] = 0x50;
			cpu.pc = 0;

			cpu.Opcode = 0x4548;
			handler.HandleOpcode();

			Assert.AreEqual(4, cpu.pc,  "pc should increase by 4 because Vx != NN");

			cpu.V[0x5] = 0x48;
			cpu.pc = 0;

			cpu.Opcode = 0x4548;
			handler.HandleOpcode();

			Assert.AreEqual(2, cpu.pc, "pc should increase by 2 because Vx = NN");	
		}

		[TestMethod] // 5XY0 9XY0
		public void TestSkipTheNextInstructionVXVY()
		{
			// 5XY0

			cpu.V[0x5] = 0x72;
			cpu.V[0x7] = 0x72;
			cpu.pc = 0;

			cpu.Opcode = 0x5570;
			handler.HandleOpcode();

			Assert.AreEqual(4, cpu.pc, "pc should increase by 4 because Vx=Vy");

			cpu.V[0x5] = 0x62;
			cpu.V[0x7] = 0x72;
			cpu.pc = 0;

			cpu.Opcode = 0x5570;
			handler.HandleOpcode();

			Assert.AreEqual(2, cpu.pc, "pc should increase by 2 because Vx!=Vy");

			//9XY0

			cpu.V[0x5] = 0x60;
			cpu.V[0x7] = 0x72;
			cpu.pc = 0;

			cpu.Opcode = 0x9570;
			handler.HandleOpcode();

			Assert.AreEqual(4, cpu.pc, "pc should increase by 4 because Vx!=Vy");


			cpu.V[0x5] = 0x60;
			cpu.V[0x7] = 0x60;
			cpu.pc = 0;

			cpu.Opcode = 0x9570;
			handler.HandleOpcode();

			Assert.AreEqual(2, cpu.pc, "pc should increase by 2 because Vx=Vy");
		}

		[TestMethod] //6XNN
		public void TestSetVXtoNN()
		{
			cpu.V[0x5] = 0x60;
			ushort value = 0x22;

			cpu.Opcode = 0x6522;
			handler.HandleOpcode();

			Assert.AreEqual(0x22, cpu.V[0x5], "Vx should be the value 0x22");
		}

		[TestMethod] //7XNN
		public void TestAddNNtoVX()
		{
			cpu.V[0x4] = 0x34;		

			cpu.Opcode = 0x7411;
			handler.HandleOpcode();

			Assert.AreEqual(0x45, cpu.V[0x4], "Vx should be the value of Vx += 0x11");
		}

		[TestMethod] //8XY0
		public void TestSetVXtoVY()
		{
			cpu.V[0x4] = 0x22;
			cpu.V[0x7] = 0x33;

			cpu.Opcode = 0x8470;
			handler.HandleOpcode();

			Assert.AreEqual(0x33, cpu.V[0x4], "the value of Vx should be the value of Vy");
		}

		[TestMethod] //8XY1 8XY2 8XY3 8XY6 8XYE
		public void TestSetVXtoVXBitwiseOperatationVY()
		{
			//8XY1 OR
			cpu.V[0x2] = 0x54;
			cpu.V[0x5] = 0x7A;

			cpu.Opcode = 0x8251;
			handler.HandleOpcode();

			Assert.AreEqual(0x7E, cpu.V[0x2], "Vx should be Vx OR Vy");

			//8XY2 AND
			cpu.V[0x2] = 0x54;
			cpu.V[0x5] = 0x7A;

			cpu.Opcode = 0x8252;
			handler.HandleOpcode();

			Assert.AreEqual(0x50, cpu.V[0x2], "Vx should be Vx AND Vy");

			//8XY3 XOR
			cpu.V[0x2] = 0x54;
			cpu.V[0x5] = 0x7A;

			cpu.Opcode = 0x8253;
			handler.HandleOpcode();

			Assert.AreEqual(0x2E, cpu.V[0x2], "Vx should be Vx XOR Vy");

			//8XY6 >>=1
			//test case 1 for VF change from 1 to 0
			cpu.V[0x2] = 0x54; //0101 0100
			cpu.V[0xF] = 1;
		
			cpu.Opcode = 0x8256;
			handler.HandleOpcode(); //should be 0010 1010

			Assert.AreEqual(0x2A, cpu.V[0x2], "V[0x2] should be shifted right and result in 0x2A.");
			Assert.AreEqual(0x0, cpu.V[0xF], "Carry register should be 0 for this operation.");

			//test case 2 for VF change from 0 to 1

			cpu.V[0x2] = 0xFD; //1111 1101
			cpu.V[0xF] = 0;

			cpu.Opcode = 0x8256;
			handler.HandleOpcode(); //should be 0111 1110

			Assert.AreEqual(0x7E, cpu.V[0x2], "V[0x2] should be shifted right and result in 0x7E.");
			Assert.AreEqual(0x1, cpu.V[0xF], "Carry register should be 1 after shifting right.");


			//8XYE <<=1
			//test case 1 for VF change from 1 to 0

			cpu.V[0x2] = 0x54; //0101 0100
			cpu.V[0xF] = 1;

			cpu.Opcode = 0x825E;
			handler.HandleOpcode();//1010 1000

			Assert.AreEqual(0xA8, cpu.V[0x2], "V[0x2] should be shifted left and result in 0xA8.");
			Assert.AreEqual(0x0, cpu.V[0xF], "Carry register should be 0 for this operation.");

			//test case 2 for VF change from 0 to 1

			cpu.V[0x2] = 0xFD; //1111 1101
			cpu.V[0xF] = 0;

			cpu.Opcode = 0x825E;
			handler.HandleOpcode();//1111 1010

			Assert.AreEqual(0xFA, cpu.V[0x2], "V[0x2] should be shifted left and result in 0xFA.");
			Assert.AreEqual(0x1, cpu.V[0xF], "Carry register should be 1 after shifting left.");

		}



		[TestMethod] //8XY4 8XY5 8XY7
		public void TestSetVXtoVXMathOperatationVY()
		{
			// 8XY4 (Addition)
			cpu.V[0x2] = 0xFF; // 1111 1111
			cpu.V[0x5] = 0x01; // 0000 0001
			cpu.V[0xF] = 0;

			cpu.Opcode = 0x8254;
			handler.HandleOpcode();

			// 1000 0000 + 0111 0000 = 1111 0000
			// Overflow occurs, so VF should be set to 1
			Assert.AreEqual(0x00, cpu.V[0x2], "V[0x2] should be 0x00 after addition.");
			Assert.AreEqual(0x1, cpu.V[0xF], "Carry register should be 1 after addition with overflow.");

			cpu.V[0x2] = 0x50; // 0101 0000
			cpu.V[0x5] = 0x30; // 0011 0000

			cpu.Opcode = 0x8254;
			handler.HandleOpcode();

			// 0101 0000 + 0011 0000 = 0110 0000
			// No overflow occurs, so VF should be set to 0
			Assert.AreEqual(0x80, cpu.V[0x2], "V[0x2] should be 0x80 after addition without overflow.");
			Assert.AreEqual(0x0, cpu.V[0xF], "Carry register should be 0 after addition without overflow.");

			// 8XY5 (Subtraction)
			cpu.V[0x2] = 0x80; // 1000 0000
			cpu.V[0x5] = 0x70; // 0111 0000

			cpu.Opcode = 0x8255;
			handler.HandleOpcode();

			// 1000 0000 - 0111 0000 = 0001 0000
			// No underflow occurs, so VF should be set to 1
			Assert.AreEqual(0x10, cpu.V[0x2], "V[0x2] should be 0x10 after subtraction.");
			Assert.AreEqual(0x1, cpu.V[0xF], "Carry register should be 1 after subtraction without underflow.");

			cpu.V[0x2] = 0x30; // 0011 0000
			cpu.V[0x5] = 0x80; // 1000 0000

			cpu.Opcode = 0x8255;
			handler.HandleOpcode();

			// 0011 0000 - 1000 0000 = (underflow) = 0000 0000 (wrapped around in 8-bit)
			// Underflow occurs, so VF should be set to 0
			Assert.AreEqual(0xB0, cpu.V[0x2], "V[0x2] should be 0xB0 after subtraction with underflow.");
			Assert.AreEqual(0x0, cpu.V[0xF], "Carry register should be 0 after subtraction with underflow.");

			// 8XY7 (Reverse Subtraction)
			cpu.V[0x2] = 0x30; // 0011 0000
			cpu.V[0x5] = 0x80; // 1000 0000

			cpu.Opcode = 0x8257;
			handler.HandleOpcode();

			// 1000 0000 - 0011 0000 = 0111 0000
			// No underflow occurs, so VF should be set to 1
			Assert.AreEqual(0x50, cpu.V[0x2], "V[0x2] should be 0x50 after reverse subtraction.");
			Assert.AreEqual(0x1, cpu.V[0xF], "Carry register should be 1 after reverse subtraction without underflow.");

			cpu.V[0x2] = 0x80; // 1000 0000
			cpu.V[0x5] = 0x30; // 0011 0000

			cpu.Opcode = 0x8257;
			handler.HandleOpcode();

			// 0011 0000 - 1000 0000 = (underflow) = 0000 0000 (wrapped around in 8-bit)
			// Underflow occurs, so VF should be set to 0
			Assert.AreEqual(0xB0, cpu.V[0x2], "V[0x2] should be 0xB0 after reverse subtraction with underflow.");
			Assert.AreEqual(0x0, cpu.V[0xF], "Carry register should be 0 after reverse subtraction with underflow.");
		}

		[TestMethod] // ANNN
		public void TestSetItoNNN()
		{
			cpu.I = 0;

			cpu.Opcode = 0xA345;
			handler.HandleOpcode();

			Assert.AreEqual(0x0345, cpu.I, "register I should have the Value of NNN");
		}

		[TestMethod] //BNNN
		public void TestJumpToAddressNNNplusV0()
		{
			cpu.V[0x0] = 0x11;
			cpu.pc = 0;

			cpu.Opcode = 0xB345;
			handler.HandleOpcode();

			Assert.AreEqual(0x356, cpu.pc, "pc should be the sum of V0 and NNN");
		}

	}
}
