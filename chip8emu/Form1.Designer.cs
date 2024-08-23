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
			System.Windows.Forms.Label iLabel;
			System.Windows.Forms.Label pcLabel;
			System.Windows.Forms.Label spLabel;
			System.Windows.Forms.Label delayTimerLabel;
			System.Windows.Forms.Label opcodeLabel;
			System.Windows.Forms.Label soundTimerLabel;
			System.Windows.Forms.Label drawFlagLabel;
			this.emulationTimer = new System.Windows.Forms.Timer(this.components);
			this.pictureBoxDisplay = new System.Windows.Forms.PictureBox();
			this.loadProgramToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.openToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.menuStrip1 = new System.Windows.Forms.MenuStrip();
			this.delayTimerLabel1 = new System.Windows.Forms.Label();
			this.iLabel1 = new System.Windows.Forms.Label();
			this.opcodeLabel1 = new System.Windows.Forms.Label();
			this.pcLabel1 = new System.Windows.Forms.Label();
			this.soundTimerLabel1 = new System.Windows.Forms.Label();
			this.spLabel1 = new System.Windows.Forms.Label();
			this.drawFlagLabel1 = new System.Windows.Forms.Label();
			this.label1 = new System.Windows.Forms.Label();
			this.V0Value = new System.Windows.Forms.Label();
			this.V1Value = new System.Windows.Forms.Label();
			this.label4 = new System.Windows.Forms.Label();
			this.V2Value = new System.Windows.Forms.Label();
			this.label6 = new System.Windows.Forms.Label();
			this.V5Value = new System.Windows.Forms.Label();
			this.label8 = new System.Windows.Forms.Label();
			this.V4Value = new System.Windows.Forms.Label();
			this.label10 = new System.Windows.Forms.Label();
			this.V3Value = new System.Windows.Forms.Label();
			this.label12 = new System.Windows.Forms.Label();
			this.VBValue = new System.Windows.Forms.Label();
			this.label14 = new System.Windows.Forms.Label();
			this.VAValue = new System.Windows.Forms.Label();
			this.label16 = new System.Windows.Forms.Label();
			this.V9Value = new System.Windows.Forms.Label();
			this.label18 = new System.Windows.Forms.Label();
			this.V8Value = new System.Windows.Forms.Label();
			this.label20 = new System.Windows.Forms.Label();
			this.V7Value = new System.Windows.Forms.Label();
			this.label22 = new System.Windows.Forms.Label();
			this.V6Value = new System.Windows.Forms.Label();
			this.label24 = new System.Windows.Forms.Label();
			this.VFValue = new System.Windows.Forms.Label();
			this.label26 = new System.Windows.Forms.Label();
			this.VEValue = new System.Windows.Forms.Label();
			this.label28 = new System.Windows.Forms.Label();
			this.VDValue = new System.Windows.Forms.Label();
			this.label30 = new System.Windows.Forms.Label();
			this.VCValue = new System.Windows.Forms.Label();
			this.label32 = new System.Windows.Forms.Label();
			this.panel1 = new System.Windows.Forms.Panel();
			this.panel2 = new System.Windows.Forms.Panel();
			this.cpuBindingSource = new System.Windows.Forms.BindingSource(this.components);
			iLabel = new System.Windows.Forms.Label();
			pcLabel = new System.Windows.Forms.Label();
			spLabel = new System.Windows.Forms.Label();
			delayTimerLabel = new System.Windows.Forms.Label();
			opcodeLabel = new System.Windows.Forms.Label();
			soundTimerLabel = new System.Windows.Forms.Label();
			drawFlagLabel = new System.Windows.Forms.Label();
			((System.ComponentModel.ISupportInitialize)(this.pictureBoxDisplay)).BeginInit();
			this.menuStrip1.SuspendLayout();
			this.panel1.SuspendLayout();
			this.panel2.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.cpuBindingSource)).BeginInit();
			this.SuspendLayout();
			// 
			// iLabel
			// 
			iLabel.AutoSize = true;
			iLabel.Location = new System.Drawing.Point(14, 94);
			iLabel.Name = "iLabel";
			iLabel.Size = new System.Drawing.Size(13, 13);
			iLabel.TabIndex = 9;
			iLabel.Text = "I:";
			// 
			// pcLabel
			// 
			pcLabel.AutoSize = true;
			pcLabel.Location = new System.Drawing.Point(5, 117);
			pcLabel.Name = "pcLabel";
			pcLabel.Size = new System.Drawing.Size(22, 13);
			pcLabel.TabIndex = 16;
			pcLabel.Text = "pc:";
			// 
			// spLabel
			// 
			spLabel.AutoSize = true;
			spLabel.Location = new System.Drawing.Point(6, 71);
			spLabel.Name = "spLabel";
			spLabel.Size = new System.Drawing.Size(21, 13);
			spLabel.TabIndex = 20;
			spLabel.Text = "sp:";
			// 
			// delayTimerLabel
			// 
			delayTimerLabel.AutoSize = true;
			delayTimerLabel.Location = new System.Drawing.Point(3, 13);
			delayTimerLabel.Name = "delayTimerLabel";
			delayTimerLabel.Size = new System.Drawing.Size(66, 13);
			delayTimerLabel.TabIndex = 3;
			delayTimerLabel.Text = "Delay Timer:";
			// 
			// opcodeLabel
			// 
			opcodeLabel.AutoSize = true;
			opcodeLabel.Location = new System.Drawing.Point(149, 42);
			opcodeLabel.Name = "opcodeLabel";
			opcodeLabel.Size = new System.Drawing.Size(48, 13);
			opcodeLabel.TabIndex = 14;
			opcodeLabel.Text = "Opcode:";
			// 
			// soundTimerLabel
			// 
			soundTimerLabel.AutoSize = true;
			soundTimerLabel.Location = new System.Drawing.Point(7, 36);
			soundTimerLabel.Name = "soundTimerLabel";
			soundTimerLabel.Size = new System.Drawing.Size(70, 13);
			soundTimerLabel.TabIndex = 18;
			soundTimerLabel.Text = "Sound Timer:";
			// 
			// drawFlagLabel
			// 
			drawFlagLabel.AutoSize = true;
			drawFlagLabel.Location = new System.Drawing.Point(149, 13);
			drawFlagLabel.Name = "drawFlagLabel";
			drawFlagLabel.Size = new System.Drawing.Size(58, 13);
			drawFlagLabel.TabIndex = 21;
			drawFlagLabel.Text = "Draw Flag:";
			// 
			// emulationTimer
			// 
			this.emulationTimer.Interval = 1;
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
			this.menuStrip1.Size = new System.Drawing.Size(688, 24);
			this.menuStrip1.TabIndex = 2;
			this.menuStrip1.Text = "menuStrip1";
			// 
			// delayTimerLabel1
			// 
			this.delayTimerLabel1.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.cpuBindingSource, "DelayTimer", true));
			this.delayTimerLabel1.Location = new System.Drawing.Point(72, 13);
			this.delayTimerLabel1.Name = "delayTimerLabel1";
			this.delayTimerLabel1.Size = new System.Drawing.Size(100, 23);
			this.delayTimerLabel1.TabIndex = 4;
			this.delayTimerLabel1.Text = "label1";
			// 
			// iLabel1
			// 
			this.iLabel1.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.cpuBindingSource, "I", true));
			this.iLabel1.Location = new System.Drawing.Point(33, 94);
			this.iLabel1.Name = "iLabel1";
			this.iLabel1.Size = new System.Drawing.Size(100, 23);
			this.iLabel1.TabIndex = 10;
			this.iLabel1.Text = "label1";
			// 
			// opcodeLabel1
			// 
			this.opcodeLabel1.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.cpuBindingSource, "Opcode", true));
			this.opcodeLabel1.Location = new System.Drawing.Point(203, 42);
			this.opcodeLabel1.Name = "opcodeLabel1";
			this.opcodeLabel1.Size = new System.Drawing.Size(100, 23);
			this.opcodeLabel1.TabIndex = 15;
			this.opcodeLabel1.Text = "label1";
			// 
			// pcLabel1
			// 
			this.pcLabel1.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.cpuBindingSource, "pc", true));
			this.pcLabel1.Location = new System.Drawing.Point(33, 117);
			this.pcLabel1.Name = "pcLabel1";
			this.pcLabel1.Size = new System.Drawing.Size(100, 23);
			this.pcLabel1.TabIndex = 17;
			this.pcLabel1.Text = "label1";
			// 
			// soundTimerLabel1
			// 
			this.soundTimerLabel1.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.cpuBindingSource, "SoundTimer", true));
			this.soundTimerLabel1.Location = new System.Drawing.Point(83, 36);
			this.soundTimerLabel1.Name = "soundTimerLabel1";
			this.soundTimerLabel1.Size = new System.Drawing.Size(100, 23);
			this.soundTimerLabel1.TabIndex = 19;
			this.soundTimerLabel1.Text = "label1";
			// 
			// spLabel1
			// 
			this.spLabel1.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.cpuBindingSource, "sp", true));
			this.spLabel1.Location = new System.Drawing.Point(33, 71);
			this.spLabel1.Name = "spLabel1";
			this.spLabel1.Size = new System.Drawing.Size(100, 23);
			this.spLabel1.TabIndex = 21;
			this.spLabel1.Text = "label1";
			// 
			// drawFlagLabel1
			// 
			this.drawFlagLabel1.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.cpuBindingSource, "DrawFlag", true));
			this.drawFlagLabel1.Location = new System.Drawing.Point(203, 13);
			this.drawFlagLabel1.Name = "drawFlagLabel1";
			this.drawFlagLabel1.Size = new System.Drawing.Size(100, 23);
			this.drawFlagLabel1.TabIndex = 22;
			this.drawFlagLabel1.Text = "label1";
			// 
			// label1
			// 
			this.label1.AutoSize = true;
			this.label1.Location = new System.Drawing.Point(46, 7);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(26, 13);
			this.label1.TabIndex = 23;
			this.label1.Text = "V[0]";
			// 
			// V0Value
			// 
			this.V0Value.AutoSize = true;
			this.V0Value.Location = new System.Drawing.Point(106, 7);
			this.V0Value.Name = "V0Value";
			this.V0Value.Size = new System.Drawing.Size(35, 13);
			this.V0Value.TabIndex = 24;
			this.V0Value.Text = "label2";
			// 
			// V1Value
			// 
			this.V1Value.AutoSize = true;
			this.V1Value.Location = new System.Drawing.Point(106, 34);
			this.V1Value.Name = "V1Value";
			this.V1Value.Size = new System.Drawing.Size(35, 13);
			this.V1Value.TabIndex = 26;
			this.V1Value.Text = "label3";
			// 
			// label4
			// 
			this.label4.AutoSize = true;
			this.label4.Location = new System.Drawing.Point(46, 34);
			this.label4.Name = "label4";
			this.label4.Size = new System.Drawing.Size(26, 13);
			this.label4.TabIndex = 25;
			this.label4.Text = "V[1]";
			// 
			// V2Value
			// 
			this.V2Value.AutoSize = true;
			this.V2Value.Location = new System.Drawing.Point(106, 60);
			this.V2Value.Name = "V2Value";
			this.V2Value.Size = new System.Drawing.Size(35, 13);
			this.V2Value.TabIndex = 28;
			this.V2Value.Text = "label5";
			// 
			// label6
			// 
			this.label6.AutoSize = true;
			this.label6.Location = new System.Drawing.Point(46, 60);
			this.label6.Name = "label6";
			this.label6.Size = new System.Drawing.Size(26, 13);
			this.label6.TabIndex = 27;
			this.label6.Text = "V[2]";
			// 
			// V5Value
			// 
			this.V5Value.AutoSize = true;
			this.V5Value.Location = new System.Drawing.Point(106, 139);
			this.V5Value.Name = "V5Value";
			this.V5Value.Size = new System.Drawing.Size(35, 13);
			this.V5Value.TabIndex = 34;
			this.V5Value.Text = "label7";
			// 
			// label8
			// 
			this.label8.AutoSize = true;
			this.label8.Location = new System.Drawing.Point(46, 139);
			this.label8.Name = "label8";
			this.label8.Size = new System.Drawing.Size(26, 13);
			this.label8.TabIndex = 33;
			this.label8.Text = "V[5]";
			// 
			// V4Value
			// 
			this.V4Value.AutoSize = true;
			this.V4Value.Location = new System.Drawing.Point(106, 113);
			this.V4Value.Name = "V4Value";
			this.V4Value.Size = new System.Drawing.Size(35, 13);
			this.V4Value.TabIndex = 32;
			this.V4Value.Text = "label9";
			// 
			// label10
			// 
			this.label10.AutoSize = true;
			this.label10.Location = new System.Drawing.Point(46, 113);
			this.label10.Name = "label10";
			this.label10.Size = new System.Drawing.Size(26, 13);
			this.label10.TabIndex = 31;
			this.label10.Text = "V[4]";
			// 
			// V3Value
			// 
			this.V3Value.AutoSize = true;
			this.V3Value.Location = new System.Drawing.Point(106, 86);
			this.V3Value.Name = "V3Value";
			this.V3Value.Size = new System.Drawing.Size(41, 13);
			this.V3Value.TabIndex = 30;
			this.V3Value.Text = "label11";
			// 
			// label12
			// 
			this.label12.AutoSize = true;
			this.label12.Location = new System.Drawing.Point(46, 86);
			this.label12.Name = "label12";
			this.label12.Size = new System.Drawing.Size(26, 13);
			this.label12.TabIndex = 29;
			this.label12.Text = "V[3]";
			// 
			// VBValue
			// 
			this.VBValue.AutoSize = true;
			this.VBValue.Location = new System.Drawing.Point(106, 292);
			this.VBValue.Name = "VBValue";
			this.VBValue.Size = new System.Drawing.Size(41, 13);
			this.VBValue.TabIndex = 46;
			this.VBValue.Text = "label13";
			// 
			// label14
			// 
			this.label14.AutoSize = true;
			this.label14.Location = new System.Drawing.Point(46, 292);
			this.label14.Name = "label14";
			this.label14.Size = new System.Drawing.Size(27, 13);
			this.label14.TabIndex = 45;
			this.label14.Text = "V[B]";
			// 
			// VAValue
			// 
			this.VAValue.AutoSize = true;
			this.VAValue.Location = new System.Drawing.Point(106, 266);
			this.VAValue.Name = "VAValue";
			this.VAValue.Size = new System.Drawing.Size(41, 13);
			this.VAValue.TabIndex = 44;
			this.VAValue.Text = "label15";
			// 
			// label16
			// 
			this.label16.AutoSize = true;
			this.label16.Location = new System.Drawing.Point(46, 266);
			this.label16.Name = "label16";
			this.label16.Size = new System.Drawing.Size(27, 13);
			this.label16.TabIndex = 43;
			this.label16.Text = "V[A]";
			// 
			// V9Value
			// 
			this.V9Value.AutoSize = true;
			this.V9Value.Location = new System.Drawing.Point(106, 239);
			this.V9Value.Name = "V9Value";
			this.V9Value.Size = new System.Drawing.Size(41, 13);
			this.V9Value.TabIndex = 42;
			this.V9Value.Text = "label17";
			// 
			// label18
			// 
			this.label18.AutoSize = true;
			this.label18.Location = new System.Drawing.Point(46, 239);
			this.label18.Name = "label18";
			this.label18.Size = new System.Drawing.Size(26, 13);
			this.label18.TabIndex = 41;
			this.label18.Text = "V[9]";
			// 
			// V8Value
			// 
			this.V8Value.AutoSize = true;
			this.V8Value.Location = new System.Drawing.Point(106, 215);
			this.V8Value.Name = "V8Value";
			this.V8Value.Size = new System.Drawing.Size(41, 13);
			this.V8Value.TabIndex = 40;
			this.V8Value.Text = "label19";
			// 
			// label20
			// 
			this.label20.AutoSize = true;
			this.label20.Location = new System.Drawing.Point(46, 215);
			this.label20.Name = "label20";
			this.label20.Size = new System.Drawing.Size(26, 13);
			this.label20.TabIndex = 39;
			this.label20.Text = "V[8]";
			// 
			// V7Value
			// 
			this.V7Value.AutoSize = true;
			this.V7Value.Location = new System.Drawing.Point(106, 189);
			this.V7Value.Name = "V7Value";
			this.V7Value.Size = new System.Drawing.Size(41, 13);
			this.V7Value.TabIndex = 38;
			this.V7Value.Text = "label21";
			// 
			// label22
			// 
			this.label22.AutoSize = true;
			this.label22.Location = new System.Drawing.Point(46, 189);
			this.label22.Name = "label22";
			this.label22.Size = new System.Drawing.Size(26, 13);
			this.label22.TabIndex = 37;
			this.label22.Text = "V[7]";
			// 
			// V6Value
			// 
			this.V6Value.AutoSize = true;
			this.V6Value.Location = new System.Drawing.Point(106, 162);
			this.V6Value.Name = "V6Value";
			this.V6Value.Size = new System.Drawing.Size(41, 13);
			this.V6Value.TabIndex = 36;
			this.V6Value.Text = "label23";
			// 
			// label24
			// 
			this.label24.AutoSize = true;
			this.label24.Location = new System.Drawing.Point(46, 162);
			this.label24.Name = "label24";
			this.label24.Size = new System.Drawing.Size(26, 13);
			this.label24.TabIndex = 35;
			this.label24.Text = "V[6]";
			// 
			// VFValue
			// 
			this.VFValue.AutoSize = true;
			this.VFValue.Location = new System.Drawing.Point(106, 400);
			this.VFValue.Name = "VFValue";
			this.VFValue.Size = new System.Drawing.Size(41, 13);
			this.VFValue.TabIndex = 54;
			this.VFValue.Text = "label25";
			// 
			// label26
			// 
			this.label26.AutoSize = true;
			this.label26.Location = new System.Drawing.Point(46, 400);
			this.label26.Name = "label26";
			this.label26.Size = new System.Drawing.Size(26, 13);
			this.label26.TabIndex = 53;
			this.label26.Text = "V[F]";
			// 
			// VEValue
			// 
			this.VEValue.AutoSize = true;
			this.VEValue.Location = new System.Drawing.Point(106, 374);
			this.VEValue.Name = "VEValue";
			this.VEValue.Size = new System.Drawing.Size(41, 13);
			this.VEValue.TabIndex = 52;
			this.VEValue.Text = "label27";
			// 
			// label28
			// 
			this.label28.AutoSize = true;
			this.label28.Location = new System.Drawing.Point(46, 374);
			this.label28.Name = "label28";
			this.label28.Size = new System.Drawing.Size(27, 13);
			this.label28.TabIndex = 51;
			this.label28.Text = "V[E]";
			// 
			// VDValue
			// 
			this.VDValue.AutoSize = true;
			this.VDValue.Location = new System.Drawing.Point(106, 347);
			this.VDValue.Name = "VDValue";
			this.VDValue.Size = new System.Drawing.Size(41, 13);
			this.VDValue.TabIndex = 50;
			this.VDValue.Text = "label29";
			// 
			// label30
			// 
			this.label30.AutoSize = true;
			this.label30.Location = new System.Drawing.Point(46, 347);
			this.label30.Name = "label30";
			this.label30.Size = new System.Drawing.Size(28, 13);
			this.label30.TabIndex = 49;
			this.label30.Text = "V[D]";
			// 
			// VCValue
			// 
			this.VCValue.AutoSize = true;
			this.VCValue.Location = new System.Drawing.Point(106, 320);
			this.VCValue.Name = "VCValue";
			this.VCValue.Size = new System.Drawing.Size(41, 13);
			this.VCValue.TabIndex = 48;
			this.VCValue.Text = "label31";
			// 
			// label32
			// 
			this.label32.AutoSize = true;
			this.label32.Location = new System.Drawing.Point(46, 320);
			this.label32.Name = "label32";
			this.label32.Size = new System.Drawing.Size(27, 13);
			this.label32.TabIndex = 47;
			this.label32.Text = "V[C]";
			// 
			// panel1
			// 
			this.panel1.Controls.Add(this.label1);
			this.panel1.Controls.Add(this.VFValue);
			this.panel1.Controls.Add(this.V0Value);
			this.panel1.Controls.Add(this.label26);
			this.panel1.Controls.Add(this.label4);
			this.panel1.Controls.Add(this.VEValue);
			this.panel1.Controls.Add(this.V1Value);
			this.panel1.Controls.Add(this.label28);
			this.panel1.Controls.Add(this.label6);
			this.panel1.Controls.Add(this.VDValue);
			this.panel1.Controls.Add(this.V2Value);
			this.panel1.Controls.Add(this.label30);
			this.panel1.Controls.Add(this.label12);
			this.panel1.Controls.Add(this.VCValue);
			this.panel1.Controls.Add(this.V3Value);
			this.panel1.Controls.Add(this.label32);
			this.panel1.Controls.Add(this.label10);
			this.panel1.Controls.Add(this.VBValue);
			this.panel1.Controls.Add(this.V4Value);
			this.panel1.Controls.Add(this.label14);
			this.panel1.Controls.Add(this.label8);
			this.panel1.Controls.Add(this.VAValue);
			this.panel1.Controls.Add(this.V5Value);
			this.panel1.Controls.Add(this.label16);
			this.panel1.Controls.Add(this.label24);
			this.panel1.Controls.Add(this.V9Value);
			this.panel1.Controls.Add(this.V6Value);
			this.panel1.Controls.Add(this.label18);
			this.panel1.Controls.Add(this.label22);
			this.panel1.Controls.Add(this.V8Value);
			this.panel1.Controls.Add(this.V7Value);
			this.panel1.Controls.Add(this.label20);
			this.panel1.Location = new System.Drawing.Point(1075, 200);
			this.panel1.Name = "panel1";
			this.panel1.Size = new System.Drawing.Size(189, 426);
			this.panel1.TabIndex = 55;
			// 
			// panel2
			// 
			this.panel2.Controls.Add(delayTimerLabel);
			this.panel2.Controls.Add(this.delayTimerLabel1);
			this.panel2.Controls.Add(drawFlagLabel);
			this.panel2.Controls.Add(this.drawFlagLabel1);
			this.panel2.Controls.Add(this.iLabel1);
			this.panel2.Controls.Add(opcodeLabel);
			this.panel2.Controls.Add(iLabel);
			this.panel2.Controls.Add(this.opcodeLabel1);
			this.panel2.Controls.Add(spLabel);
			this.panel2.Controls.Add(this.pcLabel1);
			this.panel2.Controls.Add(this.spLabel1);
			this.panel2.Controls.Add(pcLabel);
			this.panel2.Controls.Add(soundTimerLabel);
			this.panel2.Controls.Add(this.soundTimerLabel1);
			this.panel2.Location = new System.Drawing.Point(996, 37);
			this.panel2.Name = "panel2";
			this.panel2.Size = new System.Drawing.Size(268, 142);
			this.panel2.TabIndex = 56;
			// 
			// cpuBindingSource
			// 
			this.cpuBindingSource.DataSource = typeof(chip8emu.Chip8.Cpu);
			// 
			// Form1
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(688, 406);
			this.Controls.Add(this.panel2);
			this.Controls.Add(this.panel1);
			this.Controls.Add(this.pictureBoxDisplay);
			this.Controls.Add(this.menuStrip1);
			this.MainMenuStrip = this.menuStrip1;
			this.MinimumSize = new System.Drawing.Size(704, 445);
			this.Name = "Form1";
			this.Text = "Chip8Emulator";
			((System.ComponentModel.ISupportInitialize)(this.pictureBoxDisplay)).EndInit();
			this.menuStrip1.ResumeLayout(false);
			this.menuStrip1.PerformLayout();
			this.panel1.ResumeLayout(false);
			this.panel1.PerformLayout();
			this.panel2.ResumeLayout(false);
			this.panel2.PerformLayout();
			((System.ComponentModel.ISupportInitialize)(this.cpuBindingSource)).EndInit();
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.Timer emulationTimer;
		private System.Windows.Forms.PictureBox pictureBoxDisplay;
		private System.Windows.Forms.ToolStripMenuItem loadProgramToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem openToolStripMenuItem;
		private System.Windows.Forms.MenuStrip menuStrip1;
		private System.Windows.Forms.BindingSource cpuBindingSource;
		private System.Windows.Forms.Label delayTimerLabel1;
		private System.Windows.Forms.Label iLabel1;
		private System.Windows.Forms.Label opcodeLabel1;
		private System.Windows.Forms.Label pcLabel1;
		private System.Windows.Forms.Label soundTimerLabel1;
		private System.Windows.Forms.Label spLabel1;
		private System.Windows.Forms.Label drawFlagLabel1;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.Label V0Value;
		private System.Windows.Forms.Label V1Value;
		private System.Windows.Forms.Label label4;
		private System.Windows.Forms.Label V2Value;
		private System.Windows.Forms.Label label6;
		private System.Windows.Forms.Label V5Value;
		private System.Windows.Forms.Label label8;
		private System.Windows.Forms.Label V4Value;
		private System.Windows.Forms.Label label10;
		private System.Windows.Forms.Label V3Value;
		private System.Windows.Forms.Label label12;
		private System.Windows.Forms.Label VBValue;
		private System.Windows.Forms.Label label14;
		private System.Windows.Forms.Label VAValue;
		private System.Windows.Forms.Label label16;
		private System.Windows.Forms.Label V9Value;
		private System.Windows.Forms.Label label18;
		private System.Windows.Forms.Label V8Value;
		private System.Windows.Forms.Label label20;
		private System.Windows.Forms.Label V7Value;
		private System.Windows.Forms.Label label22;
		private System.Windows.Forms.Label V6Value;
		private System.Windows.Forms.Label label24;
		private System.Windows.Forms.Label VFValue;
		private System.Windows.Forms.Label label26;
		private System.Windows.Forms.Label VEValue;
		private System.Windows.Forms.Label label28;
		private System.Windows.Forms.Label VDValue;
		private System.Windows.Forms.Label label30;
		private System.Windows.Forms.Label VCValue;
		private System.Windows.Forms.Label label32;
		private System.Windows.Forms.Panel panel1;
		private System.Windows.Forms.Panel panel2;
	}
}

