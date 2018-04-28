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
		private UITagGroup selectedGroup;

		public frmTagger()
		{
			InitializeComponent();

			lst.TileSize = new Size(imageSize, imageSize);

			ChangeTagLayout(standardShortcuts.Checked);
		}

		public void ChangeTagLayout(bool standardShortcuts)
		{
			clearGroups();
			UITagGroup.shortcutDuplcate.Clear();
			if (standardShortcuts)
			{
				addGroup(new UITagGroup("Viable Body Parts", false, false, onTagChanged, "&Face", "&Boobs", "&Pussy", "&Ass", "&Legs", "F&eet"));
				addGroup(new UITagGroup("Covering", true, false, onTagChanged, "Fully&Dressed", "HalfD&ressed", "GarmentCovering", "&HandsCovering", "See&Through", "&Naked"));
				addGroup(new UITagGroup("Action", false, false, onTagChanged, "&Masturbating", "Su&cking", "&Smiling", "&Glaring"));
				addGroup(new UITagGroup("Other", false, false, onTagChanged, "SideView", "CloseUp", "AllFours", "Piercing"));
				addGroup(new UITagGroup("Text", false, true, onTagChanged, "Garment", "Underwear", "Tattoo", "SexToy", "Furniture"));
			}
			else
			{
				addGroup(new UITagGroup("&r Viable Body Parts", false, false, false, onTagChanged, "&q Face", "&a Boobs", "&z Pussy", "&w Ass", "&s Legs", "&x Feet"));
				addGroup(new UITagGroup("&f Covering", true, false, false, onTagChanged, "&q FullyDressed", "&a HalfDressed", "&z GarmentCovering", "&w HandsCovering", "&s SeeThrough", "&x Naked"));
				addGroup(new UITagGroup("&v Action", false, false, false, onTagChanged, "&q Masturbating", "&a Sucking", "&z Smiling", "&w Glaring"));
				addGroup(new UITagGroup("&t Other", false, false, false, onTagChanged, "&q SideView", "&a CloseUp", "&z AllFours", "&w Piercing"));
				addGroup(new UITagGroup("&g Text", false, true, false, onTagChanged, "&q Garment", "&a Underwear", "&z Tattoo", "&w SexToy", "&s Furniture"));
			}
		}

		private void clearGroups()
		{
			tagGroups.Clear();
			panelRight.Controls.Clear();
			selectedGroup = null;
		}

		private void addGroup(UITagGroup group)
		{
			tagGroups.Add(group);
			panelRight.Controls.Add(group);
			if (selectedGroup == null)
			{
				selectedGroup = group;
				group.SelectedChanged(true);
			}
		}

		private void frmTagger_Load(object sender, EventArgs e)
		{
			ActiveControl = txtPath;
		}

		private void frmTagger_FormClosing(object sender, FormClosingEventArgs e)
		{
			threadPool.Run = false;
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


				threadPool.Encueue(() =>
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
					g.FillRectangle(Brushes.Transparent, 0, 0, imageSize, imageSize);
					int x = (imageSize - w) / 2;
					int y = (imageSize - h) / 2;
					g.DrawImage(thumb, x, y, w, h);
					g.Dispose();
					thumb.Dispose();
					img.Dispose();

					Invoke(new Action(() =>
					{
						if (info.ListView != null)
							info.ListView.RedrawItems(info.Index, info.Index, false);
						else
							lst.Invalidate();
					}));
				});
			}

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
			if (PauseChanged || lst.SelectedItems.Count == 0)
				return;

			// remove or add the tag for all the selected items.
			var items = lst.SelectedItems;
			if (state == CheckState.Checked)
				foreach (ImageInfo item in items)
					item.Tags[tag] = text;
			else if (state == CheckState.Unchecked)
				foreach (ImageInfo item in items)
					item.Tags.Remove(tag);


			// redraw selected items
			int start = lst.Items.Count - 1;
			int last = 0;
			int index;
			foreach (ImageInfo item in items)
			{
				index = item.Index;
				if (index < start)
					start = index;
				if (index > last)
					last = index;
			}
			lst.RedrawItems(start, last, false);
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
				e.Handled = true;
				e.SuppressKeyPress = true;
			}
			else
			{
				// standard shortcuts
				if (standardShortcuts.Checked)
					foreach (var grp in tagGroups)
						grp.Shortcut_Down(e);
				// alt shortcuts
				else
				{
					// select group
					foreach (var grp in tagGroups)
					{
						if (grp.SelectKey == e.KeyCode)
						{
							if (selectedGroup != null)
								selectedGroup.SelectedChanged(false);
							selectedGroup = grp;
							grp.SelectedChanged(true);
							e.Handled = true;
							e.SuppressKeyPress = true;
							return;
						}
					}
					// else send key to selected group
					if (selectedGroup != null)
						selectedGroup.Shortcut_Down(e);
				}
			}
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
				item.Draw(e.Graphics, e.Bounds);
			else
				e.Graphics.DrawString("Loading", DefaultFont, Brushes.Black, e.Bounds.X + imageSize / 2, e.Bounds.Y + imageSize / 2);
		}

		private void lst_MouseDoubleClick(object sender, MouseEventArgs e)
		{
			if (lst.FocusedItem == null)
				return;
			System.Diagnostics.Process.Start(((ImageInfo)lst.FocusedItem).File);
		}

		private void standardShortcuts_CheckedChanged(object sender, EventArgs e)
		{
			ChangeTagLayout(standardShortcuts.Checked);
		}
	}
}
