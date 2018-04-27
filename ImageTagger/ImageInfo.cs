using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Windows.Forms;
using System.Drawing;
using ImageTagger.Properties;

namespace ImageTagger
{
	public class ImageInfo : ListViewItem
	{
		public static HashSet<string> TextTags = new HashSet<string>();

		public bool Empty { get { return Tags.Count == 0; } }
		public string Key { get { return ImageKey; } }
		public string File;
		public Dictionary<string, string> Tags = new Dictionary<string, string>();
		public Bitmap Bitmap;
		public ImageInfo() { }
		public ImageInfo(string str)
		{
			int ext = str.LastIndexOf('.');
			ImageKey = str.Substring(0, ext + 4).ToLower();
			var tags = str.Substring(ext + 4).Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);

			for (int i = 0; i < tags.Length; ++i)
			{
				string text = "";
				string tag = tags[i];
				// if tag is text tag, split the tag and the text.
				foreach (string t in TextTags)
				{
					if (tag.Contains(t))
					{
						text = tag.Remove(0, t.Length);
						tag = t;
						break;
					}
				}
				Tags[tag] = text; // If format allows, tag should be all lower or upper case.
			}
		}
		public override string ToString()
		{
			return File + " " + string.Join(" ", toArray());
		}
		public string ToFileString()
		{
			return Path.GetFileName(File) + " " + string.Join(" ", toArray());
		}
		private string[] toArray()
		{
			var array = Tags.Keys.ToArray();
			for (int i = 0; i < array.Length; ++i)
				array[i] = array[i] + Tags[array[i]];
			return array;
		}

		public void Draw(Graphics g, Rectangle bounds)
		{
			g.DrawImage(Bitmap, bounds);

			// ToDo: Make generic, load from file.
			if (Tags.ContainsKey("TagFace"))
				g.DrawImage(Resources.Face, new Point(bounds.X, bounds.Y + 16 * 1));
			if (Tags.ContainsKey("TagBoobs"))
				g.DrawImage(Resources.Boobs, new Point(bounds.X, bounds.Y + 16 * 2));
			if (Tags.ContainsKey("TagAss"))
				g.DrawImage(Resources.Ass, new Point(bounds.X, bounds.Y + 16 * 3));
			if (Tags.ContainsKey("TagFeet"))
				g.DrawImage(Resources.Feet, new Point(bounds.X, bounds.Y + 16 * 4));
			if (Tags.ContainsKey("TagLegs"))
				g.DrawImage(Resources.Legs, new Point(bounds.X, bounds.Y + 16 * 5));
			if (Tags.ContainsKey("TagNaked"))
				g.DrawImage(Resources.Naked, new Point(bounds.X, bounds.Y + 16 * 6));
			if (Tags.ContainsKey("TagPussy"))
				g.DrawImage(Resources.Pussy, new Point(bounds.X, bounds.Y + 16 * 7));
		}
	}
}
