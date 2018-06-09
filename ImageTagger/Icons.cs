using System;
using System.IO;
using System.Drawing;
using System.Collections.Generic;
using ImageTagger.Properties;
using System.Drawing.Imaging;

namespace ImageTagger
{
	public static class Icons
	{
		private struct IconInfo
		{
			public Bitmap Bitmap;
			public int X, Y;
		}

		public static int IconSize = 16;
		public static bool DropShadow = true;
		private static Dictionary<string, IconInfo> icons;

		private static ImageAttributes imageAttributes_makeWhite;

		public static void Load()
		{
			// set shadow image attribute
			if (imageAttributes_makeWhite == null)
			{
				imageAttributes_makeWhite = new ImageAttributes();
				var colorMatrix = new ColorMatrix(new float[][]
				{
					new float[] {0, 0, 0, 0, 0}, // red   scaling
					new float[] {0, 0, 0, 0, 0}, // green scaling
					new float[] {0, 0, 0, 0, 0}, // blue  scaling
					new float[] {0, 0, 0, 1, 0}, // alpha scaling
					new float[] {1, 1, 1, 0, 1}, // translations
				});
				imageAttributes_makeWhite.SetColorMatrix(colorMatrix, ColorMatrixFlag.Default, ColorAdjustType.Bitmap);
			}

			// Create or empty 'list' of icons.
			if (icons == null)
				icons = new Dictionary<string, IconInfo>();
			else
				icons.Clear();

			// Fill 'list' of icons from resources.
			Add("face", Resources.Face);
			Add("boobs", Resources.Boobs);
			Add("ass", Resources.Ass);
			Add("feet", Resources.Feet);
			Add("legs", Resources.Legs);
			Add("naked", Resources.Naked);
			Add("pussy", Resources.Pussy);

			// Load from file.
			if (Directory.Exists("icons/"))
			{
				var files = Directory.GetFiles("icons/", "*.png", SearchOption.TopDirectoryOnly);
				foreach (var file in files)
					Add(Path.GetFileNameWithoutExtension(file).ToLowerInvariant(), (Bitmap)Image.FromFile(file));
			}
		}

		private static void Add(string tag, Bitmap icon)
		{
			// Set position of icon. Note: Could use actual math, but it works.
			int imageSize = frmTagger.ImageSize;
			int x = 0;
			int y = icons.Count * IconSize;
			while (y > imageSize)
			{
				y -= imageSize;
				x += IconSize;
			}

			Bitmap bitmap;
			// Create drop shadow
			if (DropShadow)
			{
				int width = icon.Size.Width;
				int height = icon.Size.Height;
				bitmap = new Bitmap(width, height);
				using (var g = Graphics.FromImage(bitmap))
				{
					g.DrawImage(icon, new Rectangle(1, 1, width, height), 0, 0, width, height, GraphicsUnit.Pixel, imageAttributes_makeWhite);
					g.DrawImage(icon, 0, 0);
				}
			}
			else
				bitmap = icon;

			// Add the info to the 'list'.
			icons[tag] = new IconInfo()
			{
				Bitmap = bitmap,
				X = x,
				Y = y
			};
		}

		public static void DrawAll(Graphics g, Rectangle bounds, Dictionary<string, string> Tags)
		{
			if (icons == null || icons.Count == 0)
				return;

			foreach (var kvp in Tags)
				Draw(g, bounds, kvp.Key);
		}

		public static void Draw(Graphics g, Rectangle bounds, string tag)
		{
			if (icons == null || icons.Count == 0)
				return;

			tag = tag.ToLowerInvariant().Replace("tag", "");

			if (!icons.TryGetValue(tag, out var icon))
				return;

			g.DrawImage(icon.Bitmap, new Point(bounds.X + icon.X, bounds.Y + icon.Y));
		}
	}
}
