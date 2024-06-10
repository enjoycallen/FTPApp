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
            transferListView = new ListView();
            localFile = new ColumnHeader();
            direction = new ColumnHeader();
            remoteFile = new ColumnHeader();
            size = new ColumnHeader();
            status = new ColumnHeader();
            SuspendLayout();
            // 
            // transferListView
            // 
            transferListView.Columns.AddRange(new ColumnHeader[] { localFile, direction, remoteFile, size, status });
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
            // TransferList
            // 
            AutoScaleDimensions = new SizeF(7F, 17F);
            AutoScaleMode = AutoScaleMode.Font;
            Controls.Add(transferListView);
            Name = "TransferList";
            Size = new Size(800, 306);
            ResumeLayout(false);
        }

        #endregion

        private ListView transferListView;
        private ColumnHeader localFile;
        private ColumnHeader direction;
        private ColumnHeader remoteFile;
        private ColumnHeader status;
        private ColumnHeader size;
    }
}
