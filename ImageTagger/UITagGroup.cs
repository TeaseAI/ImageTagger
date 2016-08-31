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
		/// <summary> Prefixes all tags with "Tag" for use in Tease AI. </summary>
		public static bool PrefixWithTag = true;

		public delegate void TagChanged_Delegate(string tag, string text, CheckState state);

		private TagChanged_Delegate onTagChanged;
		private bool single;
		private bool hasText;

		private Dictionary<string, tagInfo> tags = new Dictionary<string, tagInfo>();

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
					Controls.Add(t);
				}

				this.tags[tag] = new tagInfo(c, t);
			}
			ResumeLayout(true);
		}

		private void tag_TextChanged(object sender, EventArgs e)
		{
			var t = (TextBox)sender;
			var tag = (string)t.Tag;
			var info = tags[tag];

			info.CheckBox.CheckState = CheckState.Indeterminate;
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

		public void BeginAdjust()
		{
			foreach (var t in tags.Values)
			{
				if (t.TextBox != null)
					t.TextBox.Text = "";
				t.State = CheckState.Unchecked;
				t.Unset = true;
			}
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
					if (TextBox != null)
						return TextBox.Text;
					return "";
				}
			}

			public readonly CheckBox CheckBox;
			public readonly TextBox TextBox;

			public tagInfo(CheckBox c, TextBox t) { CheckBox = c; TextBox = t; }
			public void AppendText(string text)
			{
				if (TextBox.Text == "")
					TextBox.Text = text;
				else
					TextBox.Text += "&" + text;
			}
		}
	}
}
