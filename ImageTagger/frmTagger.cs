using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;
using System.Threading;
using System.Drawing.Drawing2D;

namespace ImageTagger
{
	public partial class frmTagger : Form
	{
		private Dictionary<string, ImageInfo> images = new Dictionary<string, ImageInfo>();

		private int imageSize = 256;

		private bool PauseChanged = false;

		private string path = "";

		private ThreadPool threadPool = new ThreadPool(Environment.ProcessorCount);

		private List<UITagGroup> tagGroups = new List<UITagGroup>();

		public frmTagger()
		{
			InitializeComponent();

			imageList.ImageSize = new Size(imageSize, imageSize);
			lst.TileSize = imageList.ImageSize;

			addGroup(new UITagGroup("Viable Body Parts", false, false, onTagChanged, "&Face", "&Boobs", "&Pussy", "&Ass", "&Legs", "F&eet"));
			addGroup(new UITagGroup("Covering", true, false, onTagChanged, "Fully&Dressed", "HalfD&ressed", "GarmentCovering", "&HandsCovering", "See&Through", "&Naked"));
			addGroup(new UITagGroup("Action", false, false, onTagChanged, "&Masturbating", "Su&cking", "&Smiling", "&Glaring"));
			addGroup(new UITagGroup("Other", false, false, onTagChanged, "SideView", "CloseUp", "AllFours", "Piercing"));
			addGroup(new UITagGroup("Text", false, true, onTagChanged, "Garment", "Underwear", "Tattoo", "SexToy", "Furniture"));

		}

		private void addGroup(UITagGroup group)
		{
			tagGroups.Add(group);
			panelRight.Controls.Add(group);
		}

		private void frmTagger_Load(object sender, EventArgs e)
		{
			ActiveControl = txtPath;
		}

		private void frmTagger_FormClosing(object sender, FormClosingEventArgs e)
		{
			buttonSave_Click(sender, e);
		}


		private void buttonLoad_Click(object sender, EventArgs e)
		{
			buttonSave_Click(sender, e);

			path = txtPath.Text;
			if (path.Length == 0 || !Directory.Exists(path))
				return;

			lst.SuspendLayout();
			images.Clear();
			lst.Clear();
			imageList.Images.Clear();

			if (File.Exists(path + "/ImageTags.txt"))
			{
				using (var sr = new StreamReader(path + "/ImageTags.txt"))
				{
					while (!sr.EndOfStream)
					{
						string line = sr.ReadLine();
						if (line.Length == 0)
							continue;
						var info = new ImageInfo(line);
						images.Add(info.Key, info);
					}
				}
			}

			var files = new List<string>();
			files.AddRange(Directory.GetFiles(txtPath.Text, "*.png", SearchOption.TopDirectoryOnly));
			files.AddRange(Directory.GetFiles(txtPath.Text, "*.jpg", SearchOption.TopDirectoryOnly));
			files.AddRange(Directory.GetFiles(txtPath.Text, "*.gif", SearchOption.TopDirectoryOnly));

			foreach (var file in files)
			{
				var key = Path.GetFileName(file).ToLower();

				ImageInfo info;
				if (!images.TryGetValue(key, out info))
					info = images[key] = new ImageInfo() { ImageKey = key }; ;

				info.File = file;

				threadPool.RunOrWait(() =>
				{
					// get image thumbnail and resize it.
					var img = Image.FromFile(file);
					int w = imageSize, h = imageSize;
					if (img.Width > img.Height)
						h = (int)((float)img.Height / (float)img.Width * imageSize);
					else if (img.Height > img.Width)
						w = (int)((float)img.Width / (float)img.Height * imageSize);
					var thumb = img.GetThumbnailImage(imageSize, imageSize, null, IntPtr.Zero);
					info.Bitmap = new Bitmap(imageSize, imageSize);
					var g = Graphics.FromImage(info.Bitmap);
					// ToDo : center after resize.
					g.FillRectangle(Brushes.Transparent, 0, 0, imageSize, imageSize);
					g.DrawImage(thumb, 0, 0, w, h);
					g.Dispose();
					thumb.Dispose();
					img.Dispose();

					imageList.Images.Add(info.Key, info.Bitmap);
				});
			}
			threadPool.WaitForAll();

			var imgs = from pair in images orderby pair.Key select pair.Value;
			lst.Items.AddRange(imgs.ToArray());

			lst.ResumeLayout(true);
		}

		private void buttonSave_Click(object sender, EventArgs e)
		{
			if (path.Length == 0 || !Directory.Exists(path))
				return;

			var sb = new StringBuilder();
			foreach (var image in images)
				if (!image.Value.Empty)
					sb.AppendLine(image.Value.ToFileString());

			using (var sw = new StreamWriter(path + "/ImageTags.txt"))
				sw.Write(sb.ToString());
		}

		private void panelRight_Paint(object sender, PaintEventArgs e)
		{

		}

		public void onTagChanged(string tag, string text, CheckState state)
		{
			if (PauseChanged)
				return;

			// remove or add the tag for all the selected items.
			var items = lst.SelectedItems;
			if (state == CheckState.Checked)
				foreach (ImageInfo item in items)
					item.Tags[tag] = text;
			else if (state == CheckState.Unchecked)
				foreach (ImageInfo item in items)
					item.Tags.Remove(tag);
		}

		private void lst_SelectedIndexChanged(object sender, EventArgs e)
		{
			PauseChanged = true;

			foreach (var group in tagGroups)
				group.BeginAdjust();

			var items = lst.SelectedItems;
			foreach (ListViewItem item in items)
			{
				foreach (var group in tagGroups)
					group.AdjustTags(images[item.ImageKey].Tags);
			}

			PauseChanged = false;
		}

		private void lst_ItemSelectionChanged(object sender, ListViewItemSelectionChangedEventArgs e)
		{

		}

		private void lst_KeyDown(object sender, KeyEventArgs e)
		{
			if (e.Control && e.KeyCode == Keys.A)
			{
				foreach (ImageInfo info in lst.Items)
				{
					info.Selected = true;
				}
			}
			else
				foreach (var grp in tagGroups)
					grp.Shortcut_Down(e);
		}

		private void btnPickPath_Click(object sender, EventArgs e)
		{
			OpenFileDialog openFileDialog = new OpenFileDialog();
			if (txtPath.Text.Length > 0)
				openFileDialog.InitialDirectory = txtPath.Text;

			openFileDialog.FileName = "Filename will be ignored";
			openFileDialog.CheckPathExists = true;
			openFileDialog.CheckFileExists = false;
			openFileDialog.ValidateNames = false;

			if (openFileDialog.ShowDialog() == DialogResult.OK)
			{
				txtPath.Text = Path.GetDirectoryName(openFileDialog.FileName);
				buttonLoad_Click(sender, e);
			}
		}

		private void txtPath_KeyDown(object sender, KeyEventArgs e)
		{
			if (e.KeyCode == Keys.Enter)
			{
				buttonLoad_Click(sender, e);
				e.SuppressKeyPress = true;
			}
		}

		private void lst_DrawItem(object sender, DrawListViewItemEventArgs e)
		{
			if (e.Item.Selected)
				e.Graphics.FillRectangle(Brushes.LightBlue, e.Bounds);
			else
				e.Graphics.FillRectangle(Brushes.LightGray, e.Bounds);


			var item = e.Item as ImageInfo;
			if (item.Bitmap != null)
			{
				// ToDo: Center image
				//int x = item.Position.X + (item.Bounds.Width - item.Bitmap.Size.Width) / 2;
				//int y = item.Position.Y + 0;
				//e.Graphics.DrawImage(item.Bitmap, x, y, new Rectangle(Point.Empty, item.Bitmap.Size), GraphicsUnit.Pixel);
				e.Graphics.DrawImage(item.Bitmap, e.Bounds);
			}
			else
				e.Graphics.DrawString("Loading", DefaultFont, Brushes.Black, Point.Empty);
		}
	}
}
