namespace Pen_and_Paper_Visualator.Controls
{
    partial class CombatChatTab
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
            this.txtCombatChat = new System.Windows.Forms.RichTextBox();
            this.SuspendLayout();
            // 
            // txtCombatChat
            // 
            this.txtCombatChat.BackColor = System.Drawing.Color.Black;
            this.txtCombatChat.Cursor = System.Windows.Forms.Cursors.Arrow;
            this.txtCombatChat.ForeColor = System.Drawing.Color.White;
            this.txtCombatChat.Location = new System.Drawing.Point(3, 3);
            this.txtCombatChat.Name = "txtCombatChat";
            this.txtCombatChat.ReadOnly = true;
            this.txtCombatChat.ScrollBars = System.Windows.Forms.RichTextBoxScrollBars.ForcedVertical;
            this.txtCombatChat.Size = new System.Drawing.Size(442, 206);
            this.txtCombatChat.TabIndex = 1;
            this.txtCombatChat.TabStop = false;
            this.txtCombatChat.Text = "";
            // 
            // CombatChatTab
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.txtCombatChat);
            this.Name = "CombatChatTab";
            this.Size = new System.Drawing.Size(449, 235);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.RichTextBox txtCombatChat;
    }
}
