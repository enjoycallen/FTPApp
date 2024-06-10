namespace FTPClient
{
    public class Client : IConnectionRelated
    {
        private Connector connector;
        public Connector Connector
        {
            get => connector;
            set
            {
                connector = value;
                connector.Client = this;
            }
        }

        private LocalFileList localFileList;
        public LocalFileList LocalFileList
        {
            get => localFileList;
            set
            {
                localFileList = value;
                localFileList.Client = this;
            }
        }

        private RemoteFileList remoteFileList;
        public RemoteFileList RemoteFileList
        {
            get => remoteFileList;
            set
            {
                remoteFileList = value;
                remoteFileList.Client = this;
            }
        }

        private TransferList transferList;
        public TransferList TransferList
        {
            get => transferList;
            set
            {
                transferList = value;
                transferList.Client = this;
            }
        }

        public bool IsConnected { get; set; }

        public Client()
        {
            IsConnected = false;
        }


        public void Connect()
        {
            IsConnected = true;
            remoteFileList?.Connect();
        }

        public void Disconnect()
        {
            IsConnected = false;
            remoteFileList?.Disconnect();
        }

        public List<string> List(string remotePath)
        {
            if (!IsConnected) throw new ConnectionNotExisted("Client.List");

            var process = new ClientProcess($"list {remotePath}");
            process.Start();

            List<string> list = [];
            while (true)
            {
                var str = process.ReceiveResponse();
                if (str == "Over") break;
                list.Add(str);
            }
            return list;
        }

        public void Upload(FileListItem item)
        {
            var remotePath = remoteFileList.CurrentDirectory;
            transferList.Upload(item.FullName, remotePath + item.Name, item.Size, remoteFileList.Refresh);
        }

        public void Download(FileListItem item)
        {
            var localPath = localFileList.CurrentDirectory;
            if (localPath[^1] != '\\') localPath += '\\';
            transferList.Download(localPath + item.Name, item.FullName, item.Size, localFileList.Refresh);
        }

        public void Remove(FileListItem item)
        {
            transferList.Remove(item.FullName, remoteFileList.Refresh);
        }
    }
}