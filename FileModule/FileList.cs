using System.Runtime.CompilerServices;

namespace FTPClient
{
    public abstract partial class FileList : UserControl
    {
        #region 字段和属性
        public Client? Client;

        public string Root { get; init; }

        public string Seperator { get; init; }

        public string CurrentDirectory;

        public List<FileListItem> itemList;
        #endregion

        public bool IsRoot => CurrentDirectory == Root;

        #region 方法
        public FileList(string host, string root, string sep)
        {
            InitializeComponent();
            hostLabel.Text = host;
            Root = CurrentDirectory = root;
            Seperator = sep;
        }

        public string Caption
        {
            get => captionLabel.Text;
            set
            {
                captionLabel.Visible = value != "";
                captionLabel.Text = value;
                captionLabel.Left = (Width - captionLabel.Width) / 2;
            }
        }

        public void ChangeDirectory(string directory)
        {
            Clear();
            CurrentDirectory = pathBox.Text = directory;
            Caption = "列表加载中";

            try
            {
                itemList = LoadItems();
                Caption = "";
            }
            catch (UnauthorizedAccessException)
            {
                itemList = [];
                Caption = "您没有权限列出该目录内容";
            }
            catch
            {
                throw;
            }

            if (!IsRoot) AddParent();
            size_type total_size = 0;
            foreach (var item in itemList)
            {
                AddItem(item);
                total_size += item.Size;
            }
            infoLabel.Text = $"{itemList.Count}个目录/文件。总大小：{total_size.ToReadableSize()}。";
        }

        public void AddItem(FileListItem fileListItem)
        {
            var item = fileListView.Items.Add(fileListItem.Name);
            item.SubItems.Add(fileListItem.ReadableSize);
            item.SubItems.Add(fileListItem.Type);
            item.Tag = fileListItem;
            iconList.Images.Add(fileListItem.Icon);
            item.ImageIndex = item.Index;
        }

        public void Clear()
        {
            fileListView.Items.Clear();
            iconList.Images.Clear();
        }

        public void AddParent() => AddItem(FileListItem.ParentDirectory);

        public new void Refresh() => ChangeDirectory(CurrentDirectory);
        #endregion

        #region 抽象方法
        public abstract void BackToParent();

        public abstract List<FileListItem> LoadItems();

        public abstract void Transfer(FileListItem item);

        public abstract void Remove(FileListItem item);
        #endregion

        private void FileList_Resize(object sender, EventArgs e)
        {
            captionLabel.Left = (Width - captionLabel.Width) / 2;
        }

        public void 传输ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                var item = fileListView.SelectedItems[0].Tag as FileListItem ?? throw new Exception();
                Transfer(item);
            }
            catch (ConnectionNotExisted)
            {
                MessageBox.Show("未连接到服务器！", "FTPClient");
            }
        }

        public void 删除ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var item = fileListView.SelectedItems[0].Tag as FileListItem ?? throw new Exception();
            Remove(item);
        }

        private void fileListView_MouseUp(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                var listViewItem = fileListView.GetItemAt(e.X, e.Y);
                if (listViewItem == null) return;
                var item = listViewItem.Tag as FileListItem ?? throw new Exception();
                if (!item.IsDirectory && !item.IsDrive)
                {
                    rightClickMenuStrip.Show(fileListView, e.Location);
                }
            }
        }

        private void fileListView_ItemActivate(object sender, EventArgs e)
        {
            var selectedItems = fileListView.SelectedItems;
            if (selectedItems.Count == 0) return;

            var item = selectedItems[0].Tag as FileListItem ?? throw new Exception();
            if (item == FileListItem.ParentDirectory)
            {
                BackToParent();
            }
            else if (item.IsDirectory || item.IsDrive)
            {
                ChangeDirectory(item.FullName);
            }
            else
            {
                try
                {
                    Transfer(item);
                }
                catch (ConnectionNotExisted)
                {
                    MessageBox.Show("未连接到服务器！", "FTPClient");
                }
            }
        }

        private void fileListView_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Back)
            {
                BackToParent();
            }
            else if (e.KeyCode == Keys.F5)
            {
                Refresh();
            }
            else if (e.KeyCode == Keys.Delete)
            {
                var selectedItems = fileListView.SelectedItems;
                if (selectedItems.Count == 0) return;

                var item = selectedItems[0].Tag as FileListItem ?? throw new Exception();
                Remove(item);
            }
        }
    }
}