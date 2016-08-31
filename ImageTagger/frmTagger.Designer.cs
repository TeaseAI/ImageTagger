namespace ImageTagger
{
	partial class frmTagger
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
			this.lst = new System.Windows.Forms.ListView();
			this.imageList = new System.Windows.Forms.ImageList(this.components);
			this.txtPath = new System.Windows.Forms.TextBox();
			this.buttonLoad = new System.Windows.Forms.Button();
			this.panelTop = new System.Windows.Forms.Panel();
			this.btnPickPath = new System.Windows.Forms.Button();
			this.buttonSave = new System.Windows.Forms.Button();
			this.panelRight = new System.Windows.Forms.Panel();
			this.listExtraTags = new System.Windows.Forms.ListBox();
			this.radioButton6 = new System.Windows.Forms.RadioButton();
			this.radioButton5 = new System.Windows.Forms.RadioButton();
			this.radioButton4 = new System.Windows.Forms.RadioButton();
			this.radioButton3 = new System.Windows.Forms.RadioButton();
			this.radioButton2 = new System.Windows.Forms.RadioButton();
			this.radioButton1 = new System.Windows.Forms.RadioButton();
			this.checkBox14 = new System.Windows.Forms.CheckBox();
			this.checkBox13 = new System.Windows.Forms.CheckBox();
			this.checkBox12 = new System.Windows.Forms.CheckBox();
			this.checkBox11 = new System.Windows.Forms.CheckBox();
			this.checkBox10 = new System.Windows.Forms.CheckBox();
			this.checkBox9 = new System.Windows.Forms.CheckBox();
			this.checkBox8 = new System.Windows.Forms.CheckBox();
			this.checkBox7 = new System.Windows.Forms.CheckBox();
			this.checkBox6 = new System.Windows.Forms.CheckBox();
			this.checkBox5 = new System.Windows.Forms.CheckBox();
			this.checkBox4 = new System.Windows.Forms.CheckBox();
			this.checkBox3 = new System.Windows.Forms.CheckBox();
			this.checkBox2 = new System.Windows.Forms.CheckBox();
			this.checkBox1 = new System.Windows.Forms.CheckBox();
			this.panelTop.SuspendLayout();
			this.panelRight.SuspendLayout();
			this.SuspendLayout();
			// 
			// lst
			// 
			this.lst.Dock = System.Windows.Forms.DockStyle.Fill;
			this.lst.GridLines = true;
			this.lst.HideSelection = false;
			this.lst.LabelWrap = false;
			this.lst.LargeImageList = this.imageList;
			this.lst.Location = new System.Drawing.Point(0, 27);
			this.lst.Name = "lst";
			this.lst.ShowGroups = false;
			this.lst.Size = new System.Drawing.Size(810, 654);
			this.lst.TabIndex = 0;
			this.lst.TileSize = new System.Drawing.Size(128, 128);
			this.lst.UseCompatibleStateImageBehavior = false;
			this.lst.ItemSelectionChanged += new System.Windows.Forms.ListViewItemSelectionChangedEventHandler(this.lst_ItemSelectionChanged);
			this.lst.SelectedIndexChanged += new System.EventHandler(this.lst_SelectedIndexChanged);
			this.lst.KeyDown += new System.Windows.Forms.KeyEventHandler(this.lst_KeyDown);
			// 
			// imageList
			// 
			this.imageList.ColorDepth = System.Windows.Forms.ColorDepth.Depth24Bit;
			this.imageList.ImageSize = new System.Drawing.Size(128, 128);
			this.imageList.TransparentColor = System.Drawing.Color.Transparent;
			// 
			// txtPath
			// 
			this.txtPath.Location = new System.Drawing.Point(3, 3);
			this.txtPath.Name = "txtPath";
			this.txtPath.Size = new System.Drawing.Size(393, 20);
			this.txtPath.TabIndex = 1;
			// 
			// buttonLoad
			// 
			this.buttonLoad.Location = new System.Drawing.Point(449, 3);
			this.buttonLoad.Name = "buttonLoad";
			this.buttonLoad.Size = new System.Drawing.Size(41, 20);
			this.buttonLoad.TabIndex = 2;
			this.buttonLoad.Text = "Load";
			this.buttonLoad.UseVisualStyleBackColor = true;
			this.buttonLoad.Click += new System.EventHandler(this.buttonLoad_Click);
			// 
			// panelTop
			// 
			this.panelTop.Controls.Add(this.btnPickPath);
			this.panelTop.Controls.Add(this.buttonSave);
			this.panelTop.Controls.Add(this.txtPath);
			this.panelTop.Controls.Add(this.buttonLoad);
			this.panelTop.Dock = System.Windows.Forms.DockStyle.Top;
			this.panelTop.Location = new System.Drawing.Point(0, 0);
			this.panelTop.Name = "panelTop";
			this.panelTop.Size = new System.Drawing.Size(810, 27);
			this.panelTop.TabIndex = 3;
			// 
			// btnPickPath
			// 
			this.btnPickPath.Location = new System.Drawing.Point(402, 3);
			this.btnPickPath.Name = "btnPickPath";
			this.btnPickPath.Size = new System.Drawing.Size(41, 20);
			this.btnPickPath.TabIndex = 4;
			this.btnPickPath.Text = "...";
			this.btnPickPath.UseVisualStyleBackColor = true;
			this.btnPickPath.Click += new System.EventHandler(this.btnPickPath_Click);
			// 
			// buttonSave
			// 
			this.buttonSave.Location = new System.Drawing.Point(496, 4);
			this.buttonSave.Name = "buttonSave";
			this.buttonSave.Size = new System.Drawing.Size(41, 20);
			this.buttonSave.TabIndex = 3;
			this.buttonSave.Text = "Save";
			this.buttonSave.UseVisualStyleBackColor = true;
			this.buttonSave.Click += new System.EventHandler(this.buttonSave_Click);
			// 
			// panelRight
			// 
			this.panelRight.Controls.Add(this.listExtraTags);
			this.panelRight.Controls.Add(this.radioButton6);
			this.panelRight.Controls.Add(this.radioButton5);
			this.panelRight.Controls.Add(this.radioButton4);
			this.panelRight.Controls.Add(this.radioButton3);
			this.panelRight.Controls.Add(this.radioButton2);
			this.panelRight.Controls.Add(this.radioButton1);
			this.panelRight.Controls.Add(this.checkBox14);
			this.panelRight.Controls.Add(this.checkBox13);
			this.panelRight.Controls.Add(this.checkBox12);
			this.panelRight.Controls.Add(this.checkBox11);
			this.panelRight.Controls.Add(this.checkBox10);
			this.panelRight.Controls.Add(this.checkBox9);
			this.panelRight.Controls.Add(this.checkBox8);
			this.panelRight.Controls.Add(this.checkBox7);
			this.panelRight.Controls.Add(this.checkBox6);
			this.panelRight.Controls.Add(this.checkBox5);
			this.panelRight.Controls.Add(this.checkBox4);
			this.panelRight.Controls.Add(this.checkBox3);
			this.panelRight.Controls.Add(this.checkBox2);
			this.panelRight.Controls.Add(this.checkBox1);
			this.panelRight.Dock = System.Windows.Forms.DockStyle.Right;
			this.panelRight.Location = new System.Drawing.Point(810, 0);
			this.panelRight.Name = "panelRight";
			this.panelRight.Size = new System.Drawing.Size(258, 681);
			this.panelRight.TabIndex = 4;
			this.panelRight.Paint += new System.Windows.Forms.PaintEventHandler(this.panelRight_Paint);
			// 
			// listExtraTags
			// 
			this.listExtraTags.FormattingEnabled = true;
			this.listExtraTags.Location = new System.Drawing.Point(6, 313);
			this.listExtraTags.Name = "listExtraTags";
			this.listExtraTags.Size = new System.Drawing.Size(244, 173);
			this.listExtraTags.TabIndex = 16;
			// 
			// radioButton6
			// 
			this.radioButton6.AutoSize = true;
			this.radioButton6.Location = new System.Drawing.Point(143, 121);
			this.radioButton6.Name = "radioButton6";
			this.radioButton6.Size = new System.Drawing.Size(57, 17);
			this.radioButton6.TabIndex = 14;
			this.radioButton6.TabStop = true;
			this.radioButton6.Text = "Naked";
			this.radioButton6.UseVisualStyleBackColor = true;
			this.radioButton6.CheckedChanged += new System.EventHandler(this.tagChanged_CheckedChanged);
			// 
			// radioButton5
			// 
			this.radioButton5.AutoSize = true;
			this.radioButton5.Location = new System.Drawing.Point(143, 102);
			this.radioButton5.Name = "radioButton5";
			this.radioButton5.Size = new System.Drawing.Size(84, 17);
			this.radioButton5.TabIndex = 14;
			this.radioButton5.TabStop = true;
			this.radioButton5.Text = "SeeThrough";
			this.radioButton5.UseVisualStyleBackColor = true;
			this.radioButton5.CheckedChanged += new System.EventHandler(this.tagChanged_CheckedChanged);
			// 
			// radioButton4
			// 
			this.radioButton4.AutoSize = true;
			this.radioButton4.Location = new System.Drawing.Point(143, 83);
			this.radioButton4.Name = "radioButton4";
			this.radioButton4.Size = new System.Drawing.Size(98, 17);
			this.radioButton4.TabIndex = 14;
			this.radioButton4.TabStop = true;
			this.radioButton4.Text = "HandsCovering";
			this.radioButton4.UseVisualStyleBackColor = true;
			this.radioButton4.CheckedChanged += new System.EventHandler(this.tagChanged_CheckedChanged);
			// 
			// radioButton3
			// 
			this.radioButton3.AutoSize = true;
			this.radioButton3.Location = new System.Drawing.Point(143, 64);
			this.radioButton3.Name = "radioButton3";
			this.radioButton3.Size = new System.Drawing.Size(107, 17);
			this.radioButton3.TabIndex = 14;
			this.radioButton3.TabStop = true;
			this.radioButton3.Text = "GarmentCovering";
			this.radioButton3.UseVisualStyleBackColor = true;
			this.radioButton3.CheckedChanged += new System.EventHandler(this.tagChanged_CheckedChanged);
			// 
			// radioButton2
			// 
			this.radioButton2.AutoSize = true;
			this.radioButton2.Location = new System.Drawing.Point(143, 45);
			this.radioButton2.Name = "radioButton2";
			this.radioButton2.Size = new System.Drawing.Size(83, 17);
			this.radioButton2.TabIndex = 14;
			this.radioButton2.TabStop = true;
			this.radioButton2.Text = "HalfDressed";
			this.radioButton2.UseVisualStyleBackColor = true;
			this.radioButton2.CheckedChanged += new System.EventHandler(this.tagChanged_CheckedChanged);
			// 
			// radioButton1
			// 
			this.radioButton1.AutoSize = true;
			this.radioButton1.Location = new System.Drawing.Point(143, 26);
			this.radioButton1.Name = "radioButton1";
			this.radioButton1.Size = new System.Drawing.Size(85, 17);
			this.radioButton1.TabIndex = 14;
			this.radioButton1.TabStop = true;
			this.radioButton1.Text = "FullyDressed";
			this.radioButton1.UseVisualStyleBackColor = true;
			this.radioButton1.CheckedChanged += new System.EventHandler(this.tagChanged_CheckedChanged);
			// 
			// checkBox14
			// 
			this.checkBox14.AutoSize = true;
			this.checkBox14.Location = new System.Drawing.Point(143, 196);
			this.checkBox14.Name = "checkBox14";
			this.checkBox14.Size = new System.Drawing.Size(70, 17);
			this.checkBox14.TabIndex = 13;
			this.checkBox14.Text = "SideView";
			this.checkBox14.UseVisualStyleBackColor = true;
			this.checkBox14.CheckedChanged += new System.EventHandler(this.tagChanged_CheckedChanged);
			// 
			// checkBox13
			// 
			this.checkBox13.AutoSize = true;
			this.checkBox13.Location = new System.Drawing.Point(143, 217);
			this.checkBox13.Name = "checkBox13";
			this.checkBox13.Size = new System.Drawing.Size(66, 17);
			this.checkBox13.TabIndex = 12;
			this.checkBox13.Text = "CloseUp";
			this.checkBox13.UseVisualStyleBackColor = true;
			this.checkBox13.CheckedChanged += new System.EventHandler(this.tagChanged_CheckedChanged);
			// 
			// checkBox12
			// 
			this.checkBox12.AutoSize = true;
			this.checkBox12.Location = new System.Drawing.Point(143, 238);
			this.checkBox12.Name = "checkBox12";
			this.checkBox12.Size = new System.Drawing.Size(63, 17);
			this.checkBox12.TabIndex = 11;
			this.checkBox12.Text = "AllFours";
			this.checkBox12.UseVisualStyleBackColor = true;
			this.checkBox12.CheckedChanged += new System.EventHandler(this.tagChanged_CheckedChanged);
			// 
			// checkBox11
			// 
			this.checkBox11.AutoSize = true;
			this.checkBox11.Location = new System.Drawing.Point(143, 259);
			this.checkBox11.Name = "checkBox11";
			this.checkBox11.Size = new System.Drawing.Size(64, 17);
			this.checkBox11.TabIndex = 10;
			this.checkBox11.Text = "Piercing";
			this.checkBox11.UseVisualStyleBackColor = true;
			this.checkBox11.CheckedChanged += new System.EventHandler(this.tagChanged_CheckedChanged);
			// 
			// checkBox10
			// 
			this.checkBox10.AutoSize = true;
			this.checkBox10.Location = new System.Drawing.Point(6, 259);
			this.checkBox10.Name = "checkBox10";
			this.checkBox10.Size = new System.Drawing.Size(59, 17);
			this.checkBox10.TabIndex = 9;
			this.checkBox10.Text = "Glaring";
			this.checkBox10.UseVisualStyleBackColor = true;
			this.checkBox10.CheckedChanged += new System.EventHandler(this.tagChanged_CheckedChanged);
			// 
			// checkBox9
			// 
			this.checkBox9.AutoSize = true;
			this.checkBox9.Location = new System.Drawing.Point(6, 238);
			this.checkBox9.Name = "checkBox9";
			this.checkBox9.Size = new System.Drawing.Size(59, 17);
			this.checkBox9.TabIndex = 8;
			this.checkBox9.Text = "Smiling";
			this.checkBox9.UseVisualStyleBackColor = true;
			this.checkBox9.CheckedChanged += new System.EventHandler(this.tagChanged_CheckedChanged);
			// 
			// checkBox8
			// 
			this.checkBox8.AutoSize = true;
			this.checkBox8.Location = new System.Drawing.Point(6, 217);
			this.checkBox8.Name = "checkBox8";
			this.checkBox8.Size = new System.Drawing.Size(65, 17);
			this.checkBox8.TabIndex = 7;
			this.checkBox8.Text = "Sucking";
			this.checkBox8.UseVisualStyleBackColor = true;
			this.checkBox8.CheckedChanged += new System.EventHandler(this.tagChanged_CheckedChanged);
			// 
			// checkBox7
			// 
			this.checkBox7.AutoSize = true;
			this.checkBox7.Location = new System.Drawing.Point(6, 196);
			this.checkBox7.Name = "checkBox7";
			this.checkBox7.Size = new System.Drawing.Size(87, 17);
			this.checkBox7.TabIndex = 6;
			this.checkBox7.Text = "Masturbating";
			this.checkBox7.UseVisualStyleBackColor = true;
			this.checkBox7.CheckedChanged += new System.EventHandler(this.tagChanged_CheckedChanged);
			// 
			// checkBox6
			// 
			this.checkBox6.AutoSize = true;
			this.checkBox6.Location = new System.Drawing.Point(6, 127);
			this.checkBox6.Name = "checkBox6";
			this.checkBox6.Size = new System.Drawing.Size(47, 17);
			this.checkBox6.TabIndex = 5;
			this.checkBox6.Text = "Feet";
			this.checkBox6.UseVisualStyleBackColor = true;
			this.checkBox6.CheckedChanged += new System.EventHandler(this.tagChanged_CheckedChanged);
			// 
			// checkBox5
			// 
			this.checkBox5.AutoSize = true;
			this.checkBox5.Location = new System.Drawing.Point(6, 107);
			this.checkBox5.Name = "checkBox5";
			this.checkBox5.Size = new System.Drawing.Size(49, 17);
			this.checkBox5.TabIndex = 4;
			this.checkBox5.Text = "Legs";
			this.checkBox5.UseVisualStyleBackColor = true;
			this.checkBox5.CheckedChanged += new System.EventHandler(this.tagChanged_CheckedChanged);
			// 
			// checkBox4
			// 
			this.checkBox4.AutoSize = true;
			this.checkBox4.Location = new System.Drawing.Point(6, 87);
			this.checkBox4.Name = "checkBox4";
			this.checkBox4.Size = new System.Drawing.Size(43, 17);
			this.checkBox4.TabIndex = 3;
			this.checkBox4.Text = "Ass";
			this.checkBox4.UseVisualStyleBackColor = true;
			this.checkBox4.CheckedChanged += new System.EventHandler(this.tagChanged_CheckedChanged);
			// 
			// checkBox3
			// 
			this.checkBox3.AutoSize = true;
			this.checkBox3.Location = new System.Drawing.Point(6, 67);
			this.checkBox3.Name = "checkBox3";
			this.checkBox3.Size = new System.Drawing.Size(54, 17);
			this.checkBox3.TabIndex = 2;
			this.checkBox3.Text = "Pussy";
			this.checkBox3.UseVisualStyleBackColor = true;
			this.checkBox3.CheckedChanged += new System.EventHandler(this.tagChanged_CheckedChanged);
			// 
			// checkBox2
			// 
			this.checkBox2.AutoSize = true;
			this.checkBox2.Location = new System.Drawing.Point(6, 47);
			this.checkBox2.Name = "checkBox2";
			this.checkBox2.Size = new System.Drawing.Size(56, 17);
			this.checkBox2.TabIndex = 1;
			this.checkBox2.Text = "Boobs";
			this.checkBox2.UseVisualStyleBackColor = true;
			this.checkBox2.CheckedChanged += new System.EventHandler(this.tagChanged_CheckedChanged);
			// 
			// checkBox1
			// 
			this.checkBox1.AutoSize = true;
			this.checkBox1.Location = new System.Drawing.Point(6, 27);
			this.checkBox1.Name = "checkBox1";
			this.checkBox1.Size = new System.Drawing.Size(50, 17);
			this.checkBox1.TabIndex = 0;
			this.checkBox1.Text = "Face";
			this.checkBox1.UseVisualStyleBackColor = true;
			this.checkBox1.CheckedChanged += new System.EventHandler(this.tagChanged_CheckedChanged);
			// 
			// frmTagger
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(1068, 681);
			this.Controls.Add(this.lst);
			this.Controls.Add(this.panelTop);
			this.Controls.Add(this.panelRight);
			this.Name = "frmTagger";
			this.Text = "Form1";
			this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.frmTagger_FormClosing);
			this.Load += new System.EventHandler(this.frmTagger_Load);
			this.panelTop.ResumeLayout(false);
			this.panelTop.PerformLayout();
			this.panelRight.ResumeLayout(false);
			this.panelRight.PerformLayout();
			this.ResumeLayout(false);

		}

		#endregion

		private System.Windows.Forms.ListView lst;
		private System.Windows.Forms.TextBox txtPath;
		private System.Windows.Forms.Button buttonLoad;
		private System.Windows.Forms.ImageList imageList;
		private System.Windows.Forms.Panel panelTop;
		private System.Windows.Forms.Panel panelRight;
		private System.Windows.Forms.CheckBox checkBox14;
		private System.Windows.Forms.CheckBox checkBox13;
		private System.Windows.Forms.CheckBox checkBox12;
		private System.Windows.Forms.CheckBox checkBox11;
		private System.Windows.Forms.CheckBox checkBox10;
		private System.Windows.Forms.CheckBox checkBox9;
		private System.Windows.Forms.CheckBox checkBox8;
		private System.Windows.Forms.CheckBox checkBox7;
		private System.Windows.Forms.CheckBox checkBox6;
		private System.Windows.Forms.CheckBox checkBox5;
		private System.Windows.Forms.CheckBox checkBox4;
		private System.Windows.Forms.CheckBox checkBox3;
		private System.Windows.Forms.CheckBox checkBox2;
		private System.Windows.Forms.CheckBox checkBox1;
		private System.Windows.Forms.RadioButton radioButton6;
		private System.Windows.Forms.RadioButton radioButton5;
		private System.Windows.Forms.RadioButton radioButton4;
		private System.Windows.Forms.RadioButton radioButton3;
		private System.Windows.Forms.RadioButton radioButton2;
		private System.Windows.Forms.RadioButton radioButton1;
		private System.Windows.Forms.ListBox listExtraTags;
		private System.Windows.Forms.Button buttonSave;
		private System.Windows.Forms.Button btnPickPath;
	}
}

