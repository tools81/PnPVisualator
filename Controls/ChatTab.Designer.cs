namespace Pen_and_Paper_Visualator.Controls
{
    partial class ChatTab
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
            this.txtChat = new System.Windows.Forms.RichTextBox();
            this.SuspendLayout();
            // 
            // txtChat
            // 
            this.txtChat.BackColor = System.Drawing.Color.Black;
            this.txtChat.Cursor = System.Windows.Forms.Cursors.Arrow;
            this.txtChat.ForeColor = System.Drawing.Color.White;
            this.txtChat.Location = new System.Drawing.Point(4, 4);
            this.txtChat.Name = "txtChat";
            this.txtChat.ReadOnly = true;
            this.txtChat.ScrollBars = System.Windows.Forms.RichTextBoxScrollBars.ForcedVertical;
            this.txtChat.Size = new System.Drawing.Size(442, 206);
            this.txtChat.TabIndex = 0;
            this.txtChat.TabStop = false;
            this.txtChat.Text = "";
            // 
            // ChatTab
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.txtChat);
            this.Name = "ChatTab";
            this.Size = new System.Drawing.Size(449, 235);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.RichTextBox txtChat;

    }
}
