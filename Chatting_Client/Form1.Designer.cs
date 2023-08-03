namespace Chatting_Client
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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

        #region Windows Form Designer generated code

        /// <summary>
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            label1 = new Label();
            txtName = new TextBox();
            btnConnect = new Button();
            txtChatMsg = new TextBox();
            txtMsg = new TextBox();
            btnSend = new Button();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(26, 29);
            label1.Name = "label1";
            label1.Size = new Size(43, 15);
            label1.TabIndex = 0;
            label1.Text = "대화명";
            // 
            // txtName
            // 
            txtName.Location = new Point(75, 26);
            txtName.Name = "txtName";
            txtName.Size = new Size(198, 23);
            txtName.TabIndex = 1;
            // 
            // btnConnect
            // 
            btnConnect.Location = new Point(308, 26);
            btnConnect.Name = "btnConnect";
            btnConnect.Size = new Size(107, 23);
            btnConnect.TabIndex = 2;
            btnConnect.Text = "입장";
            btnConnect.UseVisualStyleBackColor = true;
            btnConnect.Click += btnConnect_Click;
            // 
            // txtChatMsg
            // 
            txtChatMsg.Location = new Point(26, 71);
            txtChatMsg.Multiline = true;
            txtChatMsg.Name = "txtChatMsg";
            txtChatMsg.ScrollBars = ScrollBars.Vertical;
            txtChatMsg.Size = new Size(389, 288);
            txtChatMsg.TabIndex = 3;
            // 
            // txtMsg
            // 
            txtMsg.Location = new Point(26, 380);
            txtMsg.Multiline = true;
            txtMsg.Name = "txtMsg";
            txtMsg.Size = new Size(328, 39);
            txtMsg.TabIndex = 4;
            txtMsg.KeyPress += txtMsg_KeyPress;
            // 
            // btnSend
            // 
            btnSend.Location = new Point(360, 380);
            btnSend.Name = "btnSend";
            btnSend.Size = new Size(55, 39);
            btnSend.TabIndex = 5;
            btnSend.Text = "전송";
            btnSend.UseVisualStyleBackColor = true;
            btnSend.Click += btnSend_Click;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(443, 431);
            Controls.Add(btnSend);
            Controls.Add(txtMsg);
            Controls.Add(txtChatMsg);
            Controls.Add(btnConnect);
            Controls.Add(txtName);
            Controls.Add(label1);
            Name = "Form1";
            Text = "Form1";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label1;
        private TextBox txtName;
        private Button btnConnect;
        private TextBox txtChatMsg;
        private TextBox txtMsg;
        private Button btnSend;
    }
}