namespace FTPClient
{
    public class LocalFileList : FileList
    {
        public LocalFileList(string root = "") : base("本地站点", root, @"\")
        {
            传输ToolStripMenuItem.Text = "上传";
            Refresh();
        }

        public override List<FileListItem> LoadItems()
        {
            List<FileListItem> itemList = [];
            if (CurrentDirectory == "")
            {
                foreach (var drive in DriveInfo.GetDrives())
                {
                    itemList.Add(FileListItem.Drive(drive.Name[..^2] + "（" + drive.VolumeLabel + "）", drive.Name));
                }
            }
            else
            {
                foreach (var directory in Directory.GetDirectories(CurrentDirectory))
                {
                    var info = new DirectoryInfo(directory);
                    itemList.Add(FileListItem.Directory(info.Name, info.FullName));
                }
                foreach (var file in Directory.GetFiles(CurrentDirectory))
                {
                    var info = new FileInfo(file);
                    itemList.Add(FileListItem.File(info.Name, info.FullName, info.Length));
                }
            }
            return itemList;
        }

        public override void BackToParent()
        {
            var parent = Directory.GetParent(CurrentDirectory)?.FullName ?? "";
            ChangeDirectory(parent);
        }

        public override void Transfer(FileListItem item)
        {
            if (Client == null) throw new NullClient("LocalFileList.Transfer");
            if (!Client.IsConnected) throw new ConnectionNotExisted("LocalFileList.Transfer");
            Client.Upload(item);
        }

        public override void Remove(FileListItem item)
        {
            File.Delete(item.FullName);
            Refresh();
        }
    }
}