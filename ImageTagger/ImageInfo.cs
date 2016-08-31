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
		public string Key { get { return ImageKey; } }
		public string File;
		public HashSet<string> Tags = new HashSet<string>();
		public Bitmap Bitmap;
		public ImageInfo() { }
		public ImageInfo(string str)
		{
			int ext = str.LastIndexOf('.');
			ImageKey = str.Substring(0, ext + 4).ToLower();
			var tags = str.Substring(ext + 4).Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
			foreach (string tag in tags)
				Tags.Add(tag); // If format allows should be all lower or upper case.
		}
		public override string ToString()
		{
			return File + " " + string.Join(" ", Tags.ToArray());
		}
		public string ToFileString()
		{
			return Path.GetFileName(File) + " " + string.Join(" ", Tags.ToArray());
		}
	}
}
