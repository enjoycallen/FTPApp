namespace FTPClient
{
    partial class FileList
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Component Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            components = new System.ComponentModel.Container();
            iconList = new ImageList(components);
            fileListView = new ListView();
            name = new ColumnHeader();
            size = new ColumnHeader();
            type = new ColumnHeader();
            rightClickMenuStrip = new ContextMenuStrip(components);
            传输ToolStripMenuItem = new ToolStripMenuItem();
            删除ToolStripMenuItem = new ToolStripMenuItem();
            pathBox = new TextBox();
            panel = new Panel();
            hostLabel = new Label();
            captionLabel = new Label();
            infoLabel = new Label();
            rightClickMenuStrip.SuspendLayout();
            panel.SuspendLayout();
            SuspendLayout();
            // 
            // iconList
            // 
            iconList.ColorDepth = ColorDepth.Depth32Bit;
            iconList.ImageSize = new Size(16, 16);
            iconList.TransparentColor = Color.Transparent;
            // 
            // fileListView
            // 
            fileListView.Columns.AddRange(new ColumnHeader[] { name, size, type });
            fileListView.Dock = DockStyle.Fill;
            fileListView.FullRowSelect = true;
            fileListView.LargeImageList = iconList;
            fileListView.Location = new Point(0, 23);
            fileListView.MultiSelect = false;
            fileListView.Name = "fileListView";
            fileListView.Size = new Size(360, 360);
            fileListView.SmallImageList = iconList;
            fileListView.TabIndex = 2;
            fileListView.UseCompatibleStateImageBehavior = false;
            fileListView.View = View.Details;
            fileListView.ItemActivate += fileListView_ItemActivate;
            fileListView.KeyDown += fileListView_KeyDown;
            fileListView.MouseUp += fileListView_MouseUp;
            // 
            // name
            // 
            name.Text = "文件名";
            name.Width = 150;
            // 
            // size
            // 
            size.Text = "大小";
            size.Width = 100;
            // 
            // type
            // 
            type.Text = "文件类型";
            type.Width = 100;
            // 
            // rightClickMenuStrip
            // 
            rightClickMenuStrip.Items.AddRange(new ToolStripItem[] { 传输ToolStripMenuItem, 删除ToolStripMenuItem });
            rightClickMenuStrip.Name = "rightclickMenuStrip";
            rightClickMenuStrip.Size = new Size(101, 48);
            // 
            // 传输ToolStripMenuItem
            // 
            传输ToolStripMenuItem.Name = "传输ToolStripMenuItem";
            传输ToolStripMenuItem.Size = new Size(100, 22);
            传输ToolStripMenuItem.Text = "传输";
            传输ToolStripMenuItem.Click += 传输ToolStripMenuItem_Click;
            // 
            // 删除ToolStripMenuItem
            // 
            删除ToolStripMenuItem.Name = "删除ToolStripMenuItem";
            删除ToolStripMenuItem.Size = new Size(100, 22);
            删除ToolStripMenuItem.Text = "删除";
            删除ToolStripMenuItem.Click += 删除ToolStripMenuItem_Click;
            // 
            // pathBox
            // 
            pathBox.Dock = DockStyle.Fill;
            pathBox.Location = new Point(70, 0);
            pathBox.Name = "pathBox";
            pathBox.ReadOnly = true;
            pathBox.Size = new Size(290, 23);
            pathBox.TabIndex = 1;
            // 
            // panel
            // 
            panel.Controls.Add(pathBox);
            panel.Controls.Add(hostLabel);
            panel.Dock = DockStyle.Top;
            panel.Location = new Point(0, 0);
            panel.Name = "panel";
            panel.Size = new Size(360, 23);
            panel.TabIndex = 3;
            // 
            // hostLabel
            // 
            hostLabel.BorderStyle = BorderStyle.FixedSingle;
            hostLabel.Dock = DockStyle.Left;
            hostLabel.Location = new Point(0, 0);
            hostLabel.Name = "hostLabel";
            hostLabel.Size = new Size(70, 23);
            hostLabel.TabIndex = 2;
            hostLabel.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // captionLabel
            // 
            captionLabel.AutoSize = true;
            captionLabel.BackColor = Color.White;
            captionLabel.Location = new Point(80, 80);
            captionLabel.Name = "captionLabel";
            captionLabel.Size = new Size(0, 17);
            captionLabel.TabIndex = 4;
            captionLabel.Visible = false;
            // 
            // infoLabel
            // 
            infoLabel.BorderStyle = BorderStyle.FixedSingle;
            infoLabel.Dock = DockStyle.Bottom;
            infoLabel.Location = new Point(0, 383);
            infoLabel.Name = "infoLabel";
            infoLabel.Size = new Size(360, 23);
            infoLabel.TabIndex = 3;
            infoLabel.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // FileList
            // 
            AutoScaleDimensions = new SizeF(7F, 17F);
            AutoScaleMode = AutoScaleMode.Font;
            Controls.Add(captionLabel);
            Controls.Add(fileListView);
            Controls.Add(infoLabel);
            Controls.Add(panel);
            MinimumSize = new Size(0, 200);
            Name = "FileList";
            Size = new Size(360, 406);
            Resize += FileList_Resize;
            rightClickMenuStrip.ResumeLayout(false);
            panel.ResumeLayout(false);
            panel.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion
        private ImageList iconList;
        private ListView fileListView;
        private ColumnHeader name;
        private ColumnHeader size;
        private ColumnHeader type;
        private Panel panel;
        private Label hostLabel;
        private Label captionLabel;
        private Label infoLabel;
        public ContextMenuStrip rightClickMenuStrip;
        public ToolStripMenuItem 传输ToolStripMenuItem;
        public ToolStripMenuItem 删除ToolStripMenuItem;
        public TextBox pathBox;
    }
}
