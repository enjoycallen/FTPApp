namespace FTPClient
{
    public partial class MainForm : Form
    {
        public Client Client;

        private Connector connector;
        private LocalFileList localFileList;
        private RemoteFileList remoteFileList;
        private TransferList transferList;

        public string LocalPath
        {
            get
            {
                var str = localFileList.CurrentDirectory;
                if (str == "" || str[^1] == '\\') return str;
                return str + '\\';
            }
        }

        public string RemotePath => remoteFileList.CurrentDirectory;

        public MainForm()
        {
            InitializeComponent();

            connector = new() { Dock = DockStyle.Fill };
            splitContainer3.Panel1.Controls.Add(connector);

            
            localFileList = new()
            {
                Dock = DockStyle.Fill,
            };
            splitContainer1.Panel1.Controls.Add(localFileList);

            remoteFileList = new()
            {
                Dock = DockStyle.Fill,
            };
            splitContainer1.Panel2.Controls.Add(remoteFileList);

            transferList = new()
            {
                Dock = DockStyle.Fill,
            };
            splitContainer2.Panel2.Controls.Add(transferList);

            Client = new()
            {
                Connector = connector,
                LocalFileList = localFileList,
                RemoteFileList = remoteFileList,
                TransferList = transferList
            };
        }
    }
}