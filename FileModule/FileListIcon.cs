using System.Runtime.InteropServices;

namespace FTPClient
{
    internal class FileListIcon
    {
        [DllImport("shell32.dll")]
        private static extern nint SHGetFileInfo(string pszPath, uint dwFileAttributes, ref SHFILEINFO psfi, uint cbFileInfo, uint uFlags);

        [DllImport("shell32.dll")]
        private static extern int SHGetStockIconInfo(SHSTOCKICONID siid, uint uFlags, ref SHSTOCKICONINFO psii);

        [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Unicode)]
        private struct SHSTOCKICONINFO
        {
            public uint cbSize;
            public nint hIcon;
            public int iSysIconIndex;
            public int iIcon;
            [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 260)]
            public string szPath;
        }

        [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Auto)]
        private struct SHFILEINFO
        {
            public nint hIcon;
            public int iIcon;
            public uint dwAttributes;
            [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 260)]
            public string szDisplayName;
            [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 80)]
            public string szTypeName;
        }

        private enum SHSTOCKICONID : uint
        {
            SIID_FOLDER = 0x0004,
            SIID_DRIVEFIXED = 0x0003
        }

        private const uint SHGFI_ICON = 0x100;
        private const uint SHGFI_LARGEICON = 0x0;
        private const uint SHGFI_USEFILEATTRIBUTES = 0x10;
        private const uint SHGSI_ICON = 0x100;

        public static Icon GetFileIcon(string name)
        {
            var shinfo = new SHFILEINFO();
            uint flags = SHGFI_ICON | SHGFI_LARGEICON | SHGFI_USEFILEATTRIBUTES;
            SHGetFileInfo(name, 0, ref shinfo, (uint)Marshal.SizeOf(shinfo), flags);
            return Icon.FromHandle(shinfo.hIcon);
        }

        public static Icon GetDirectoryIcon()
        {
            var shinfo = new SHSTOCKICONINFO();
            shinfo.cbSize = (uint)Marshal.SizeOf(typeof(SHSTOCKICONINFO));
            SHGetStockIconInfo(SHSTOCKICONID.SIID_FOLDER, SHGSI_ICON | SHGFI_LARGEICON, ref shinfo);
            return Icon.FromHandle(shinfo.hIcon);
        }
    }
}