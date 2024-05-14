using System.Text.RegularExpressions;
using size_type = uint;

namespace FTPClient
{
    internal class File
    {
        string name;
        size_type size;
        bool isDirectory;
        bool readable;
        bool writable;
        
        public string Name
        {
            get => name;
            set
            {
                var pattern = @"^(?!(con|prn|aux|nul|com[1-9]|lpt[1-9])(\..*|)$)(^[^\\\/\:\*\?\""\<\>\|]{1,255})$";
                if (!Regex.IsMatch(value, pattern))
                {
                    throw new Exception("文件名非法。");
                }
                name = value;
            }
        }

        public size_type Size
        {
            get => size;
            set
            {
                const size_type MAXSIZE = 1 << 30;      //1GB
                if (value < 0 || value > MAXSIZE)
                {
                    throw new Exception("文件大小超出限制。");
                }
                size = value;
            }
        }

        public string Property
        {
            get
            {
                var p = "";
                p += isDirectory ? 'd' : '-';
                p += readable ? 'r' : '-';
                p += writable ? "w" : "-";
                return p;
            }
            set
            {
                string pattern = @"^[d\-][r\-][w\-]$";
                if (!Regex.IsMatch(value, pattern))
                {
                    throw new Exception("属性串格式错误。");
                }
                isDirectory = value[0] == 'd';
                readable = value[1] == 'r';
                writable = value[2] == 'w';
            }
        }

        public bool IsDirectory => IsDirectory;
        public bool Readable => readable;
        public bool Writable => writable;
        
        public string Type
        {
            get
            {
                if (isDirectory) return "文件夹";
                var i = name.LastIndexOf('.');
                if (i == -1) return "";
                return name[(i + 1)..] + "文件";
            }
        }

        public File() { }

        public File(string str)
        {
            try
            {
                var words = str.Split('|');
                if (words.Length != 3)
                {
                    throw new Exception("参数个数错误。");
                }
                Name = words[0];
                Size = size_type.Parse(words[1]);
                Property = words[2];
            }
            catch (Exception ex)
            {
                MessageBox.Show("In " + GetType().FullName + ":\n" + ex.Message);
            }
        }

        public static IEnumerable<File> GetFiles(string str)
        {
            foreach (var s in str.Split('\n'))
            {
                yield return new File(s);
            }
        }

#if DEBUG
        public void ShowInfo()
        {
            var msg = "name: " + name + '\n' +
                "size: " + size + '\n' +
                "isDirectory: " + isDirectory + '\n' +
                "readable: " + readable + "\n" +
                "writable: " + writable;
            MessageBox.Show(msg);
        }
#endif
    }
}