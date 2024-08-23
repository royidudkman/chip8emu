using Microsoft.VisualStudio.TestTools.UnitTesting;
using chip8emu.Utils;
using chip8emu.Chip8;


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

			Assert.AreEqual(cpu.pc, cpu.Stack[cpu.sp], "The program counter should be set to the return address from the stack.");
			Assert.AreEqual(cpu.sp, sp - 1, "the stack pointer should decrease by 1");
		}

		[TestMethod] //1NNN
		public void TestJumpToAddress()
		{
			cpu.pc = 0x200;

			cpu.Opcode = 0x1354;
			handler.HandleOpcode();

			Assert.AreEqual(cpu.pc, 0x354, "the program counter should be equal to the address NNN of the opcode");
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

			Assert.AreEqual(cpu.sp, sp +1, "the stack pointer should increase by 1");
			Assert.AreEqual(pc, cpu.Stack[sp], "the current pc should be on top of the stack");
			Assert.AreEqual(cpu.pc, 0x756, "the pc need to be set to NNN");
		}

		[TestMethod] //3XNN //4XNN
		public void TestSkipTheNextInstructionVXNN()
		{
			//3XNN

			cpu.V[0x5] = 0x48;
			cpu.pc = 0;
			
			cpu.Opcode = 0x3548;
			handler.HandleOpcode();

			Assert.AreEqual(cpu.pc, 4, "pc should increase by 4 because Vx = NN");

			cpu.V[0x5] = 0x50;
			cpu.pc = 0;

			cpu.Opcode = 0x3548;
			handler.HandleOpcode();

			Assert.AreEqual(cpu.pc, 2, "pc should increase by 2 because Vx != NN");

			//4XNN

			cpu.V[0x5] = 0x50;
			cpu.pc = 0;

			cpu.Opcode = 0x4548;
			handler.HandleOpcode();

			Assert.AreEqual(cpu.pc, 4, "pc should increase by 4 because Vx != NN");

			cpu.V[0x5] = 0x48;
			cpu.pc = 0;

			cpu.Opcode = 0x4548;
			handler.HandleOpcode();

			Assert.AreEqual(cpu.pc, 2, "pc should increase by 2 because Vx = NN");	
		}
	}
}
