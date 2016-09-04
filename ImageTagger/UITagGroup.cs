using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace ImageTagger
{
	public partial class UITagGroup : UserControl
	{
		private static HashSet<Keys> shortcutDuplcate = new HashSet<Keys>();

		/// <summary> Prefixes all tags with "Tag" for use in Tease AI. </summary>
		public static bool PrefixWithTag = true;

		public delegate void TagChanged_Delegate(string tag, string text, CheckState state);

		private TagChanged_Delegate onTagChanged;
		private bool single;
		private bool hasText;

		private Dictionary<string, tagInfo> tags = new Dictionary<string, tagInfo>();
		private Dictionary<Keys, tagInfo> shortcuts = new Dictionary<Keys, tagInfo>();

		public UITagGroup(string title, bool singleSelection, bool hasText, TagChanged_Delegate onTagChanged, params string[] tags)
		{
			InitializeComponent();
			SuspendLayout();

			lblTitle.Text = title;
			this.onTagChanged = onTagChanged;
			single = singleSelection;
			this.hasText = hasText;

			// add all of the tags.
			for (int i = 0; i < tags.Length; ++i)
			{
				string tag = tags[i];
				if (PrefixWithTag)
					tag = "Tag" + tag;

				// Get shortcut key from the tag.
				int mneIndex = tag.IndexOf('&');
				Keys shortcut = Keys.None;
				if (mneIndex > -1)
				{
					shortcut = (Keys)Enum.Parse(typeof(Keys), tag.Substring(mneIndex + 1, 1), true);
					if (shortcutDuplcate.Contains(shortcut))
						MessageBox.Show("Shortcut :" + shortcut.ToString() + " is a duplicate!", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
					shortcutDuplcate.Add(shortcut);

					tag = tag.Remove(mneIndex, 1);
				}

				if (hasText)
					ImageInfo.TextTags.Add(tag);

				var c = new CheckBox();
				c.Text = tags[i];
				c.Height = 20;
				c.Top = lblTitle.Bottom + 5 + (c.Height * i);
				c.Tag = tag;
				c.CheckStateChanged += tag_CheckStateChanged;
				Controls.Add(c);

				TextBox t = null;
				if (hasText)
				{
					t = new TextBox();
					t.Top = c.Top;
					t.Left = c.Right;
					t.Height = c.Height;
					t.Tag = tag;
					t.TextChanged += tag_TextChanged;
					t.KeyDown += tag_TextBox_KeyDown;
					Controls.Add(t);
				}

				this.tags[tag] = new tagInfo(c, t);
				if (shortcut != Keys.None)
					shortcuts[shortcut] = this.tags[tag];
			}
			ResumeLayout(true);
		}

		private void tag_TextBox_KeyDown(object sender, KeyEventArgs e)
		{
			if (e.KeyCode == Keys.Enter)
			{
				var t = (TextBox)sender;
				var tag = (string)t.Tag;
				var info = tags[tag];

				info.State = CheckState.Checked;

				e.Handled = true;
				e.SuppressKeyPress = true;
			}
		}

		private void tag_TextChanged(object sender, EventArgs e)
		{
			var t = (TextBox)sender;
			var tag = (string)t.Tag;
			var info = tags[tag];
			if (info.PauseText)
				return;

			info.State = CheckState.Indeterminate;
		}

		private void tag_CheckStateChanged(object sender, EventArgs e)
		{
			var c = (CheckBox)sender;
			var tag = (string)c.Tag;
			var info = tags[tag];

			if (single && c.CheckState == CheckState.Checked)
			{
				foreach (var other in tags.Values)
					if (!ReferenceEquals(c, other.CheckBox))
						other.State = CheckState.Unchecked;
			}

			onTagChanged(tag, info.Text, c.CheckState);
		}

		public void Shortcut_Down(KeyEventArgs e)
		{
			tagInfo info;
			if (shortcuts.TryGetValue(e.KeyCode, out info))
			{
				if (info.State == CheckState.Checked)
					info.State = CheckState.Unchecked;
				else
					info.State = CheckState.Checked;
				e.Handled = true;
				e.SuppressKeyPress = true;
			}
		}

		public void BeginAdjust()
		{
			foreach (var t in tags.Values)
				t.Reset();
		}

		public void AdjustTags(Dictionary<string, string> imgTags)
		{
			tagInfo c;
			string txt;
			foreach (var kvp in tags)
			{
				c = kvp.Value;
				CheckState goal = imgTags.ContainsKey(kvp.Key) ? CheckState.Checked : CheckState.Unchecked;
				if (c.State == CheckState.Indeterminate)
				{
					if (hasText)
					{
						if (imgTags.TryGetValue(kvp.Key, out txt) && txt != "")
							c.AppendText(txt);
					}
					continue;
				}

				if (hasText && goal == CheckState.Checked)
				{
					if (imgTags.TryGetValue(kvp.Key, out txt) && txt != "")
					{
						c.AppendText(txt);
					}
					else
						goal = CheckState.Unchecked;
				}

				if (c.Unset)
					c.State = goal;
				else if (c.State != goal)
					c.State = CheckState.Indeterminate;

			}
		}

		private class tagInfo
		{
			public bool Unset;

			public CheckState State
			{
				get { return CheckBox.CheckState; }
				set
				{
					Unset = false;
					if (CheckBox.CheckState != value)
						CheckBox.CheckState = value;
				}
			}

			public string Text
			{
				get
				{
					if (textBox != null)
						return textBox.Text;
					return "";
				}
			}

			public readonly CheckBox CheckBox;
			private readonly TextBox textBox;
			private HashSet<string> text;

			public bool PauseText { get { return pauseEvent; } }
			private bool pauseEvent = false;

			public tagInfo(CheckBox c, TextBox t)
			{
				CheckBox = c;
				textBox = t;
				if (textBox != null)
				{
					text = new HashSet<string>();
					textBox.TextChanged += TextBox_TextChanged;
				}
			}

			private void TextBox_TextChanged(object sender, EventArgs e)
			{
				if (PauseText)
					return;
				text.Clear();
			}

			public void Reset()
			{
				if (textBox != null)
					textBox.Text = "";
				State = CheckState.Unchecked;
				Unset = true;
			}

			public void AppendText(string txt)
			{
				if (text.Contains(txt))
					return;
				if (text.Count == 1)
					State = CheckState.Indeterminate;
				text.Add(txt);
				pauseEvent = true;
				textBox.Text = string.Join(" & ", text.ToArray());
				pauseEvent = false;
			}
		}
	}
}
