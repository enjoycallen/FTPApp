namespace FTPClient
{
    public partial class FileListItem
    {
        #region 静态属性
        //文件类型后缀
        public static string FileTypeSuffix { get; } = "文件";

        //目录类型
        public static string DirectoryType { get; } = "文件夹";

        //驱动器类型
        public static string DriveType { get; } = "本地磁盘";

        //上级目录
        public static FileListItem ParentDirectory { get; } = new("..", "", 0, DirectoryType);
        #endregion

        public string Name { get; set; }

        public string FullName { get; set; }

        public size_type Size { get; set; }

        public string ReadableSize => IsDirectory || IsDrive ? "" : Size.ToReadableSize();

        public string Type { get; set; }

        public Icon Icon
        {
            get
            {
                if (IsDrive) return FileListIcon.GetFileIcon(FullName);
                if (IsDirectory) return FileListIcon.GetDirectoryIcon();
                return FileListIcon.GetFileIcon(Name);
            }
        }

        public bool IsDirectory => Type == DirectoryType;

        public bool IsDrive => Type == DriveType;

        public FileListItem(string name, string fullname, size_type size, string type)
        {
            Name = name;
            FullName = fullname;
            Size = size;
            Type = type;
        }

        public static FileListItem File(string name, string fullname, size_type size) => new(name, fullname, size, name.GetFileType());

        public static FileListItem Directory(string name, string fullname) => new(name, fullname, 0, DirectoryType);

        public static FileListItem Drive(string name, string fullname) => new(name, fullname, 0, DriveType);
    }
}