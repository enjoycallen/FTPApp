using System.Diagnostics;

namespace FTPClient
{
    public class ClientProcess
    {
        public Process Process;

        public ClientProcess(string cmd)
        {
            Process = new()
            {
                StartInfo = new ProcessStartInfo()
                {
                    FileName = "python",
                    Arguments = $"client.py {cmd}",
                    RedirectStandardOutput = true,
                    UseShellExecute = false,
                    CreateNoWindow = true
                }
            };

            using (StreamWriter log = new("client.log", true))
            {
                log.WriteLine($"{DateTime.Now}:\nCommand: python client.py {cmd}");
            }
        }

        public void Start() => Process.Start();

        public void SendRequest(string mes) => Process.StandardInput.WriteLine(mes);

        public string ReceiveResponse() => Process.StandardOutput.ReadLine() ?? "";
    }
}
