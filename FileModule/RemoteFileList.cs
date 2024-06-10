namespace FTPClient
{
    public class RemoteFileList : FileList, IConnectionRelated
    {
        public RemoteFileList(string root = "/") : base("远程站点：", root, "/")
        {
            Caption = "未连接到服务器";
            传输ToolStripMenuItem.Text = "下载";
        }

        public void Connect()
        {
            Refresh();
        }

        public void Disconnect()
        {
            CurrentDirectory = pathBox.Text = Root;
            Clear();
            Caption = "未连接到服务器";
        }

        public override void BackToParent()
        {
            if (!IsRoot)
            {
                var index = CurrentDirectory[..^Seperator.Length].LastIndexOf(Seperator) + 1;
                var parent = CurrentDirectory[..index];
                ChangeDirectory(parent);
            }
        }

        public override List<FileListItem> LoadItems()
        {
            if (Client == null) throw new NullClient("RemoteFileList.LoadItems");
            if (!Client.IsConnected) throw new ConnectionNotExisted("RemoteFileList.LoadItems");

            List<FileListItem> list = [];
            var formats = Client.List(CurrentDirectory);
            var argsArray = formats.Select(x => x.Split('|')).ToArray();
            foreach (var args in argsArray.Where(x => x[2][0] == 'd'))
            {
                list.Add(FileListItem.Directory(args[0], CurrentDirectory + args[0] + Seperator));
            }
            foreach (var args in argsArray.Where(x => x[2][0] != 'd'))
            {
                list.Add(FileListItem.File(args[0], CurrentDirectory + args[0], size_type.Parse(args[1])));
            }
            return list;
        }

        public override void Transfer(FileListItem item)
        {
            if (Client == null) throw new NullClient("RemoteFileList.Tranfer");
            if (!Client.IsConnected) throw new ConnectionNotExisted("RemoteFileList.Transfer");
            Client.Download(item);
        }

        public override void Remove(FileListItem item)
        {
            if (Client == null) throw new NullClient("RemoteFileList.Remove");
            if (!Client.IsConnected) throw new ConnectionNotExisted("RemoteFileList.Remove");
            Client.Remove(item);
        }
    }
}