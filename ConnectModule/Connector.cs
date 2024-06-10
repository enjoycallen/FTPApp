namespace FTPClient
{
    public partial class Connector : UserControl
    {
        public Client? Client;

        public Connector() => InitializeComponent();

        private async void connectButton_Click(object sender, EventArgs e)
        {
            if (Client == null) throw new NullClient("Connector.connectButton_Click");
            if(Client.IsConnected) throw new ConnectionNotExisted("Connector.connectButton_Click: Connection existed.");

            var result = await Task.Run(() =>
            {
                var process = new ClientProcess($"init {hostTextBox.Text} {portTextBox.Text}");
                process.Start();

                while (true)
                {
                    var str = process.ReceiveResponse();
                    if (str == "Success" || str == "Failed") return str;
                }
            });

            if (result == "Success")
            {
                Client.Connect();
                connectButton.Visible = false;
                disconnectButton.Visible = true;
                hostTextBox.ReadOnly = true;
                portTextBox.ReadOnly = true;
                MessageBox.Show("服务器连接成功", "FTPClient");
            }
            else
            {
                MessageBox.Show("服务器连接失败", "FTPClient");
            }
        }


        private void disconnectButton_Click(object sender, EventArgs e)
        {
            if (Client == null) throw new NullClient("Connector.disconnectButton_Click");
            if (!Client.IsConnected) throw new ConnectionNotExisted("Connector.disconnectButton_Click");

            Client.Disconnect();
            connectButton.Visible = true;
            disconnectButton.Visible = false;
            hostTextBox.ReadOnly = false;
            portTextBox.ReadOnly = false;
            MessageBox.Show("服务器已断开连接", "FTPClient");
        }
    }
}