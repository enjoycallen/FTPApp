namespace FTPClient
{
    partial class TransferList
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
            transferListView = new ListView();
            localFile = new ColumnHeader();
            direction = new ColumnHeader();
            remoteFile = new ColumnHeader();
            size = new ColumnHeader();
            status = new ColumnHeader();
            contextMenuStrip1 = new ContextMenuStrip(components);
            清空已完成任务ToolStripMenuItem = new ToolStripMenuItem();
            contextMenuStrip1.SuspendLayout();
            SuspendLayout();
            // 
            // transferListView
            // 
            transferListView.Columns.AddRange(new ColumnHeader[] { localFile, direction, remoteFile, size, status });
            transferListView.ContextMenuStrip = contextMenuStrip1;
            transferListView.Dock = DockStyle.Fill;
            transferListView.FullRowSelect = true;
            transferListView.Location = new Point(0, 0);
            transferListView.Name = "transferListView";
            transferListView.Size = new Size(800, 306);
            transferListView.TabIndex = 0;
            transferListView.UseCompatibleStateImageBehavior = false;
            transferListView.View = View.Details;
            // 
            // localFile
            // 
            localFile.Text = "本地文件";
            localFile.Width = 250;
            // 
            // direction
            // 
            direction.Text = "方向";
            direction.Width = 50;
            // 
            // remoteFile
            // 
            remoteFile.Text = "远程文件";
            remoteFile.Width = 250;
            // 
            // size
            // 
            size.Text = "大小";
            size.Width = 120;
            // 
            // status
            // 
            status.Text = "状态";
            status.Width = 100;
            // 
            // contextMenuStrip1
            // 
            contextMenuStrip1.Items.AddRange(new ToolStripItem[] { 清空已完成任务ToolStripMenuItem });
            contextMenuStrip1.Name = "contextMenuStrip1";
            contextMenuStrip1.Size = new Size(181, 48);
            // 
            // 清空已完成任务ToolStripMenuItem
            // 
            清空已完成任务ToolStripMenuItem.Name = "清空已完成任务ToolStripMenuItem";
            清空已完成任务ToolStripMenuItem.Size = new Size(180, 22);
            清空已完成任务ToolStripMenuItem.Text = "清空已完成的任务";
            清空已完成任务ToolStripMenuItem.Click += 清空已完成任务ToolStripMenuItem_Click;
            // 
            // TransferList
            // 
            AutoScaleDimensions = new SizeF(7F, 17F);
            AutoScaleMode = AutoScaleMode.Font;
            Controls.Add(transferListView);
            Name = "TransferList";
            Size = new Size(800, 306);
            contextMenuStrip1.ResumeLayout(false);
            ResumeLayout(false);
        }

        #endregion

        private ListView transferListView;
        private ColumnHeader localFile;
        private ColumnHeader direction;
        private ColumnHeader remoteFile;
        private ColumnHeader status;
        private ColumnHeader size;
        private ContextMenuStrip contextMenuStrip1;
        private ToolStripMenuItem 清空已完成任务ToolStripMenuItem;
    }
}
