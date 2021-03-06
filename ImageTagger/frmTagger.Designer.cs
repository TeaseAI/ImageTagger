﻿namespace ImageTagger
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
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmTagger));
			this.txtPath = new System.Windows.Forms.TextBox();
			this.buttonLoad = new System.Windows.Forms.Button();
			this.panelTop = new System.Windows.Forms.Panel();
			this.standardShortcuts = new System.Windows.Forms.CheckBox();
			this.btnPickPath = new System.Windows.Forms.Button();
			this.buttonSave = new System.Windows.Forms.Button();
			this.panelRight = new System.Windows.Forms.FlowLayoutPanel();
			this.btnNextSet = new System.Windows.Forms.Button();
			this.btnPreviousSet = new System.Windows.Forms.Button();
			this.lst = new ImageTagger.ListViewDB();
			this.panelTop.SuspendLayout();
			this.SuspendLayout();
			// 
			// txtPath
			// 
			this.txtPath.Location = new System.Drawing.Point(3, 3);
			this.txtPath.Name = "txtPath";
			this.txtPath.Size = new System.Drawing.Size(393, 20);
			this.txtPath.TabIndex = 0;
			this.txtPath.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtPath_KeyDown);
			// 
			// buttonLoad
			// 
			this.buttonLoad.Location = new System.Drawing.Point(449, 3);
			this.buttonLoad.Name = "buttonLoad";
			this.buttonLoad.Size = new System.Drawing.Size(59, 20);
			this.buttonLoad.TabIndex = 2;
			this.buttonLoad.Text = "Reload";
			this.buttonLoad.UseVisualStyleBackColor = true;
			this.buttonLoad.Click += new System.EventHandler(this.buttonLoad_Click);
			// 
			// panelTop
			// 
			this.panelTop.Controls.Add(this.btnPreviousSet);
			this.panelTop.Controls.Add(this.btnNextSet);
			this.panelTop.Controls.Add(this.standardShortcuts);
			this.panelTop.Controls.Add(this.btnPickPath);
			this.panelTop.Controls.Add(this.buttonSave);
			this.panelTop.Controls.Add(this.txtPath);
			this.panelTop.Controls.Add(this.buttonLoad);
			this.panelTop.Dock = System.Windows.Forms.DockStyle.Top;
			this.panelTop.Location = new System.Drawing.Point(0, 0);
			this.panelTop.Name = "panelTop";
			this.panelTop.Size = new System.Drawing.Size(961, 27);
			this.panelTop.TabIndex = 3;
			// 
			// standardShortcuts
			// 
			this.standardShortcuts.AutoSize = true;
			this.standardShortcuts.Checked = true;
			this.standardShortcuts.CheckState = System.Windows.Forms.CheckState.Checked;
			this.standardShortcuts.Location = new System.Drawing.Point(838, 6);
			this.standardShortcuts.Name = "standardShortcuts";
			this.standardShortcuts.Size = new System.Drawing.Size(117, 17);
			this.standardShortcuts.TabIndex = 0;
			this.standardShortcuts.Text = "Standard Shortcuts";
			this.standardShortcuts.UseVisualStyleBackColor = true;
			this.standardShortcuts.CheckedChanged += new System.EventHandler(this.standardShortcuts_CheckedChanged);
			// 
			// btnPickPath
			// 
			this.btnPickPath.Location = new System.Drawing.Point(402, 3);
			this.btnPickPath.Name = "btnPickPath";
			this.btnPickPath.Size = new System.Drawing.Size(41, 20);
			this.btnPickPath.TabIndex = 1;
			this.btnPickPath.Text = "...";
			this.btnPickPath.UseVisualStyleBackColor = true;
			this.btnPickPath.Click += new System.EventHandler(this.btnPickPath_Click);
			// 
			// buttonSave
			// 
			this.buttonSave.Location = new System.Drawing.Point(514, 3);
			this.buttonSave.Name = "buttonSave";
			this.buttonSave.Size = new System.Drawing.Size(41, 20);
			this.buttonSave.TabIndex = 3;
			this.buttonSave.Text = "Save";
			this.buttonSave.UseVisualStyleBackColor = true;
			this.buttonSave.Click += new System.EventHandler(this.buttonSave_Click);
			// 
			// panelRight
			// 
			this.panelRight.Dock = System.Windows.Forms.DockStyle.Right;
			this.panelRight.Location = new System.Drawing.Point(961, 0);
			this.panelRight.Name = "panelRight";
			this.panelRight.Size = new System.Drawing.Size(215, 681);
			this.panelRight.TabIndex = 4;
			this.panelRight.Paint += new System.Windows.Forms.PaintEventHandler(this.panelRight_Paint);
			// 
			// btnNextSet
			// 
			this.btnNextSet.Location = new System.Drawing.Point(608, 3);
			this.btnNextSet.Name = "btnNextSet";
			this.btnNextSet.Size = new System.Drawing.Size(41, 20);
			this.btnNextSet.TabIndex = 4;
			this.btnNextSet.Text = ">set>";
			this.btnNextSet.UseVisualStyleBackColor = true;
			this.btnNextSet.Click += new System.EventHandler(this.btnNextSet_Click);
			// 
			// btnPreviousSet
			// 
			this.btnPreviousSet.Location = new System.Drawing.Point(561, 3);
			this.btnPreviousSet.Name = "btnPreviousSet";
			this.btnPreviousSet.Size = new System.Drawing.Size(41, 20);
			this.btnPreviousSet.TabIndex = 5;
			this.btnPreviousSet.Text = "<set<";
			this.btnPreviousSet.UseVisualStyleBackColor = true;
			this.btnPreviousSet.Click += new System.EventHandler(this.btnPreviousSet_Click);
			// 
			// lst
			// 
			this.lst.Dock = System.Windows.Forms.DockStyle.Fill;
			this.lst.GridLines = true;
			this.lst.HideSelection = false;
			this.lst.LabelWrap = false;
			this.lst.Location = new System.Drawing.Point(0, 27);
			this.lst.Name = "lst";
			this.lst.OwnerDraw = true;
			this.lst.ShowGroups = false;
			this.lst.Size = new System.Drawing.Size(961, 654);
			this.lst.TabIndex = 0;
			this.lst.TileSize = new System.Drawing.Size(128, 128);
			this.lst.UseCompatibleStateImageBehavior = false;
			this.lst.View = System.Windows.Forms.View.Tile;
			this.lst.DrawItem += new System.Windows.Forms.DrawListViewItemEventHandler(this.lst_DrawItem);
			this.lst.ItemSelectionChanged += new System.Windows.Forms.ListViewItemSelectionChangedEventHandler(this.lst_ItemSelectionChanged);
			this.lst.SelectedIndexChanged += new System.EventHandler(this.lst_SelectedIndexChanged);
			this.lst.KeyDown += new System.Windows.Forms.KeyEventHandler(this.lst_KeyDown);
			this.lst.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.lst_MouseDoubleClick);
			// 
			// frmTagger
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(1176, 681);
			this.Controls.Add(this.lst);
			this.Controls.Add(this.panelTop);
			this.Controls.Add(this.panelRight);
			this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
			this.Name = "frmTagger";
			this.Text = "ImageTagger";
			this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.frmTagger_FormClosing);
			this.Load += new System.EventHandler(this.frmTagger_Load);
			this.panelTop.ResumeLayout(false);
			this.panelTop.PerformLayout();
			this.ResumeLayout(false);

		}

		#endregion

		private ImageTagger.ListViewDB lst;
		private System.Windows.Forms.TextBox txtPath;
		private System.Windows.Forms.Button buttonLoad;
		private System.Windows.Forms.Panel panelTop;
		private System.Windows.Forms.FlowLayoutPanel panelRight;
		private System.Windows.Forms.Button buttonSave;
		private System.Windows.Forms.Button btnPickPath;
		private System.Windows.Forms.CheckBox standardShortcuts;
		private System.Windows.Forms.Button btnPreviousSet;
		private System.Windows.Forms.Button btnNextSet;
	}
}

