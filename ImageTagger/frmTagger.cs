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

namespace ImageTagger
{
	public partial class frmTagger : Form
	{
		private Dictionary<string, ImageInfo> images = new Dictionary<string, ImageInfo>();
		private Dictionary<string, Control> tagControls = new Dictionary<string, Control>();

		private int imageSize = 256;

		private bool PauseChanged = false;

		private string path = "";

		public frmTagger()
		{
			InitializeComponent();

			imageList.ImageSize = new Size(imageSize, imageSize);
			lst.TileSize = imageList.ImageSize;

			foreach (Control c in panelRight.Controls)
				tagControls["Tag" + c.Text] = c;
		}

		private void frmTagger_Load(object sender, EventArgs e)
		{
			buttonLoad_Click(sender, e);
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


			lst.SuspendLayout();
			foreach (var file in files)
			{
				var key = Path.GetFileName(file).ToLower();

				ImageInfo info;
				if (!images.TryGetValue(key, out info))
					info = images[key] = new ImageInfo() { ImageKey = key }; ;

				info.File = file;

				// Note: This is not how you are suppose to do threading.
				new Thread(() =>
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

					Invoke(new addImage(addimg), info);
				}).Start();
			}
			lst.ResumeLayout(true);
		}

		public delegate void addImage(ImageInfo info);
		private void addimg(ImageInfo info)
		{
			imageList.Images.Add(info.Key, info.Bitmap);
			lst.Items.Add(info);
		}

		private void buttonSave_Click(object sender, EventArgs e)
		{
			if (path.Length == 0 || !Directory.Exists(path))
				return;

			var sb = new StringBuilder();
			foreach (var image in images)
				sb.AppendLine(image.Value.ToFileString());

			using (var sw = new StreamWriter(path + "/ImageTags.txt"))
				sw.Write(sb.ToString());
		}

		private void panelRight_Paint(object sender, PaintEventArgs e)
		{

		}

		private void tagChanged_CheckedChanged(object sender, EventArgs e)
		{
			if (PauseChanged)
				return;

			bool enabled = false;
			string tag = "Tag" + (sender as Control).Text;

			var chk = sender as CheckBox;
			var rad = sender as RadioButton;
			if (rad != null)
				enabled = rad.Checked;
			if (chk != null)
				enabled = chk.Checked;

			// remove or add the tag for all the selected items.
			var items = lst.SelectedItems;
			if (enabled)
				foreach (ListViewItem item in items)
					images[item.ImageKey].Tags.Add(tag);
			else
				foreach (ListViewItem item in items)
					images[item.ImageKey].Tags.Remove(tag);
		}

		private void lst_SelectedIndexChanged(object sender, EventArgs e)
		{
			PauseChanged = true;

			listExtraTags.Items.Clear();
			foreach (Control c in panelRight.Controls)
				setChecked(c, false);


			var items = lst.SelectedItems;
			foreach (ListViewItem item in items)
				foreach (string t in images[item.ImageKey].Tags)
				{
					Control c;
					if (tagControls.TryGetValue(t, out c))
						setChecked(c, true);
					else if (!listExtraTags.Items.Contains(t))
						listExtraTags.Items.Add(t);
				}

			PauseChanged = false;
		}

		private void setChecked(Control control, bool state)
		{
			var chk = control as CheckBox;
			if (chk != null)
				chk.Checked = state;
			var rad = control as RadioButton;
			if (rad != null)
				rad.Checked = state;
		}

		private void lst_ItemSelectionChanged(object sender, ListViewItemSelectionChangedEventArgs e)
		{

		}

	}
}
