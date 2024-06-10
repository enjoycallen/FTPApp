global using size_type = long;

namespace FTPClient
{
    internal static class ExtensionMethods
    {
        public static string GetFileType(this string name)
        {
            var i = name.LastIndexOf('.');
            return (i == -1 ? "" : name[(i + 1)..]) + FileListItem.FileTypeSuffix;
        }

        public static string ToReadableSize(this size_type size, int precision = 1)
        {
            string[] unit = { "B", "KB", "MB", "GB" };
            double s = size;
            int i = 0;
            while (s >= 1024)
            {
                s /= 1024;
                ++i;
            }
            return Math.Round(s, precision).ToString() + unit[i];
        }
    }
}