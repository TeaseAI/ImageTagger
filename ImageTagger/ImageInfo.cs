using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Windows.Forms;
using System.Drawing;

namespace ImageTagger
{
	public class ImageInfo : ListViewItem
	{
		public static HashSet<string> TextTags = new HashSet<string>();

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
	}
}
