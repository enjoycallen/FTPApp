namespace FTPClient
{
    partial class Connector
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
            label1 = new Label();
            label2 = new Label();
            hostTextBox = new TextBox();
            portTextBox = new TextBox();
            connectButton = new Button();
            disconnectButton = new Button();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(12, 12);
            label1.Name = "label1";
            label1.Size = new Size(61, 17);
            label1.TabIndex = 0;
            label1.Text = "主机(H)：";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(319, 12);
            label2.Name = "label2";
            label2.Size = new Size(59, 17);
            label2.TabIndex = 0;
            label2.Text = "端口(P)：";
            // 
            // hostTextBox
            // 
            hostTextBox.Location = new Point(79, 9);
            hostTextBox.Name = "hostTextBox";
            hostTextBox.Size = new Size(200, 23);
            hostTextBox.TabIndex = 1;
            hostTextBox.Text = "192.168.43.105";
            // 
            // portTextBox
            // 
            portTextBox.Location = new Point(384, 9);
            portTextBox.Name = "portTextBox";
            portTextBox.Size = new Size(100, 23);
            portTextBox.TabIndex = 1;
            portTextBox.Text = "12345";
            // 
            // connectButton
            // 
            connectButton.Location = new Point(536, 5);
            connectButton.Name = "connectButton";
            connectButton.Size = new Size(148, 30);
            connectButton.TabIndex = 2;
            connectButton.Text = "连接到服务器";
            connectButton.UseVisualStyleBackColor = true;
            connectButton.Click += connectButton_Click;
            // 
            // disconnectButton
            // 
            disconnectButton.Location = new Point(536, 5);
            disconnectButton.Name = "disconnectButton";
            disconnectButton.Size = new Size(148, 30);
            disconnectButton.TabIndex = 2;
            disconnectButton.Text = "断开连接";
            disconnectButton.UseVisualStyleBackColor = true;
            disconnectButton.Visible = false;
            disconnectButton.Click += disconnectButton_Click;
            // 
            // Connector
            // 
            AutoScaleDimensions = new SizeF(7F, 17F);
            AutoScaleMode = AutoScaleMode.Font;
            Controls.Add(disconnectButton);
            Controls.Add(connectButton);
            Controls.Add(portTextBox);
            Controls.Add(hostTextBox);
            Controls.Add(label2);
            Controls.Add(label1);
            Name = "Connector";
            Size = new Size(1280, 40);
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label1;
        private Label label2;
        private TextBox portTextBox;
        private TextBox hostTextBox;
        private Button connectButton;
        private Button disconnectButton;
    }
}
