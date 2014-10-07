namespace LocalIM.Tester
{
    partial class b
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

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.edtUsername = new System.Windows.Forms.TextBox();
            this.btnSendIAmHere = new System.Windows.Forms.Button();
            this.btnSendWhoIsThere = new System.Windows.Forms.Button();
            this.btnSendMessage = new System.Windows.Forms.Button();
            this.btnSendMessageConfirm = new System.Windows.Forms.Button();
            this.edtMessageText = new System.Windows.Forms.TextBox();
            this.edtMessageTargetAddress = new System.Windows.Forms.TextBox();
            this.edtMessageConfirmGuid = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // edtUsername
            // 
            this.edtUsername.Location = new System.Drawing.Point(21, 12);
            this.edtUsername.Name = "edtUsername";
            this.edtUsername.Size = new System.Drawing.Size(175, 20);
            this.edtUsername.TabIndex = 0;
            this.edtUsername.Text = "TestUser";
            // 
            // btnSendIAmHere
            // 
            this.btnSendIAmHere.Location = new System.Drawing.Point(202, 12);
            this.btnSendIAmHere.Name = "btnSendIAmHere";
            this.btnSendIAmHere.Size = new System.Drawing.Size(132, 23);
            this.btnSendIAmHere.TabIndex = 1;
            this.btnSendIAmHere.Text = "Send I am Here";
            this.btnSendIAmHere.UseVisualStyleBackColor = true;
            this.btnSendIAmHere.Click += new System.EventHandler(this.btnSendIAmHere_Click);
            // 
            // btnSendWhoIsThere
            // 
            this.btnSendWhoIsThere.Location = new System.Drawing.Point(202, 42);
            this.btnSendWhoIsThere.Name = "btnSendWhoIsThere";
            this.btnSendWhoIsThere.Size = new System.Drawing.Size(132, 23);
            this.btnSendWhoIsThere.TabIndex = 2;
            this.btnSendWhoIsThere.Text = "Send Who is there";
            this.btnSendWhoIsThere.UseVisualStyleBackColor = true;
            this.btnSendWhoIsThere.Click += new System.EventHandler(this.btnSendWhoIsThere_Click);
            // 
            // btnSendMessage
            // 
            this.btnSendMessage.Location = new System.Drawing.Point(202, 72);
            this.btnSendMessage.Name = "btnSendMessage";
            this.btnSendMessage.Size = new System.Drawing.Size(132, 23);
            this.btnSendMessage.TabIndex = 3;
            this.btnSendMessage.Text = "Send Message";
            this.btnSendMessage.UseVisualStyleBackColor = true;
            this.btnSendMessage.Click += new System.EventHandler(this.btnSendMessage_Click);
            // 
            // btnSendMessageConfirm
            // 
            this.btnSendMessageConfirm.Location = new System.Drawing.Point(202, 101);
            this.btnSendMessageConfirm.Name = "btnSendMessageConfirm";
            this.btnSendMessageConfirm.Size = new System.Drawing.Size(132, 23);
            this.btnSendMessageConfirm.TabIndex = 4;
            this.btnSendMessageConfirm.Text = "Send Message Confirm";
            this.btnSendMessageConfirm.UseVisualStyleBackColor = true;
            // 
            // edtMessageText
            // 
            this.edtMessageText.Location = new System.Drawing.Point(21, 72);
            this.edtMessageText.Name = "edtMessageText";
            this.edtMessageText.Size = new System.Drawing.Size(175, 20);
            this.edtMessageText.TabIndex = 5;
            this.edtMessageText.Text = "Message Text";
            // 
            // edtMessageTargetAddress
            // 
            this.edtMessageTargetAddress.Location = new System.Drawing.Point(340, 75);
            this.edtMessageTargetAddress.Name = "edtMessageTargetAddress";
            this.edtMessageTargetAddress.Size = new System.Drawing.Size(165, 20);
            this.edtMessageTargetAddress.TabIndex = 6;
            // 
            // edtMessageConfirmGuid
            // 
            this.edtMessageConfirmGuid.Location = new System.Drawing.Point(21, 103);
            this.edtMessageConfirmGuid.Name = "edtMessageConfirmGuid";
            this.edtMessageConfirmGuid.Size = new System.Drawing.Size(175, 20);
            this.edtMessageConfirmGuid.TabIndex = 7;
            // 
            // b
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(708, 432);
            this.Controls.Add(this.edtMessageConfirmGuid);
            this.Controls.Add(this.edtMessageTargetAddress);
            this.Controls.Add(this.edtMessageText);
            this.Controls.Add(this.btnSendMessageConfirm);
            this.Controls.Add(this.btnSendMessage);
            this.Controls.Add(this.btnSendWhoIsThere);
            this.Controls.Add(this.btnSendIAmHere);
            this.Controls.Add(this.edtUsername);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "b";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "LocalIM Tester";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox edtUsername;
        private System.Windows.Forms.Button btnSendIAmHere;
        private System.Windows.Forms.Button btnSendWhoIsThere;
        private System.Windows.Forms.Button btnSendMessage;
        private System.Windows.Forms.Button btnSendMessageConfirm;
        private System.Windows.Forms.TextBox edtMessageText;
        private System.Windows.Forms.TextBox edtMessageTargetAddress;
        private System.Windows.Forms.TextBox edtMessageConfirmGuid;
    }
}

