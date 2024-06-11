using System.Xml.Linq;

namespace FTPClient
{
    public partial class TransferList : UserControl, IConnectionRelated
    {
        public Client? Client { get; set; }

        public TransferList()
        {
            InitializeComponent();
        }

        public void Connect()
        {

        }

        public void Disconnect()
        {

        }


        public ListViewItem AddItem(string localFile, string direction, string remoteFile, string size, string status)
        {
            var item = transferListView.Items.Add(localFile);
            item.SubItems.Add(direction);
            item.SubItems.Add(remoteFile);
            item.SubItems.Add(size);
            item.SubItems.Add(status);
            return item;
        }


        public async void Upload(string localFile, string remoteFile, size_type size, Action update)
        {
            var item = AddItem(localFile, "->", remoteFile, size.ToString(), "上传中");
            var result = await Task.Run(() =>
            {
                var process = new ClientProcess($"upload {localFile} {remoteFile}");
                process.Start();
                while (true)
                {
                    var str = process.ReceiveResponse();
                    if (str == "Success" || str == "Failed") return str;
                }
            });
            if (result == "Success")
            {
                item.SubItems[4].Text = "上传成功";
            }
            else if (result == "Failed")
            {
                item.SubItems[4].Text = "上传失败";
            }
            update();
        }

        public async void Download(string localFile, string remoteFile, size_type size, Action update)
        {
            var item = AddItem(localFile, "<-", remoteFile, size.ToString(), "下载中");
            var result = await Task.Run(() =>
            {
                var process = new ClientProcess($"download {localFile} {remoteFile}");
                process.Start();
                while (true)
                {
                    var str = process.ReceiveResponse();
                    if (str == "Success" || str == "Failed") return str;
                }
            });
            if (result == "Success")
            {
                item.SubItems[4].Text = "下载成功";
            }
            else if (result == "Failed")
            {
                item.SubItems[4].Text = "下载失败";
            }
            update();
        }

        public async void Remove(string remoteFile, Action update)
        {
            await Task.Run(() =>
            {
                var process = new ClientProcess($"delete {remoteFile}");
                process.Start();
                while (true)
                {
                    var str = process.ReceiveResponse();
                    if (str == "Success" || str == "Failed") return str;
                }
            });
            update();
        }

        public void Clear()
        {
            foreach (ListViewItem item in transferListView.Items)
            {
                var status = item.SubItems[4].Text;
                if (status != "上传中" && status != "下载中")
                {
                    transferListView.Items.Remove(item);
                }
            }
        }

        private void 清空已完成任务ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Clear();
        }
    }
}