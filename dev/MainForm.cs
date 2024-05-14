using System.Net.Sockets;
using System.Text;

namespace FTPClient
{
    public partial class MainForm : Form
    {
        readonly string server_ip = "127.0.0.1";
        readonly int port = 24601;
        readonly Encoding encoding = Encoding.Unicode;

        public MainForm()
        {
            InitializeComponent();
            
        }

        private async void form1Load(object sender, EventArgs e)
        {
            try
            {
                TcpClient client = new();
                await client.ConnectAsync(server_ip, port);
                var stream = client.GetStream();
                await stream.WriteAsync(encoding.GetBytes("list /\0"));

                var buffer = new byte[1024];
                int len = await stream.ReadAsync(buffer);
                var str = encoding.GetString(buffer, 0, len);

                foreach (var file in File.GetFiles(str))
                {
                    var subItems = listView1.Items.Add(file.Name).SubItems;
                    subItems.Add(file.Size.ToString());
                    subItems.Add(file.Type);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}