﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;

namespace ImageTagger
{
	public class ImageInfo
	{
		public string Key;
		public string File;
		public HashSet<string> Tags = new HashSet<string>();
		public ImageInfo() { }
		public ImageInfo(string str)
		{
			int ext = str.LastIndexOf('.');
			Key = str.Substring(0, ext + 4).ToLower();
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