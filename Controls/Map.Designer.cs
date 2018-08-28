namespace Pen_and_Paper_Visualator.Controls
{
    partial class Map
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
            this.mapMenuStrip = new System.Windows.Forms.MenuStrip();
            this.imageToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.browseToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.closeToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.ofdMapFile = new System.Windows.Forms.OpenFileDialog();
            this.btnCenter = new System.Windows.Forms.Button();
            this.btnZoomOut = new System.Windows.Forms.Button();
            this.btnZoomIn = new System.Windows.Forms.Button();
            this.mapMenuStrip.SuspendLayout();
            this.SuspendLayout();
            // 
            // mapMenuStrip
            // 
            this.mapMenuStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.imageToolStripMenuItem});
            this.mapMenuStrip.Location = new System.Drawing.Point(0, 0);
            this.mapMenuStrip.Name = "mapMenuStrip";
            this.mapMenuStrip.Size = new System.Drawing.Size(720, 24);
            this.mapMenuStrip.TabIndex = 0;
            this.mapMenuStrip.Text = "menuStrip1";
            // 
            // imageToolStripMenuItem
            // 
            this.imageToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.browseToolStripMenuItem,
            this.closeToolStripMenuItem});
            this.imageToolStripMenuItem.Name = "imageToolStripMenuItem";
            this.imageToolStripMenuItem.Size = new System.Drawing.Size(52, 20);
            this.imageToolStripMenuItem.Text = "Image";
            // 
            // browseToolStripMenuItem
            // 
            this.browseToolStripMenuItem.Name = "browseToolStripMenuItem";
            this.browseToolStripMenuItem.Size = new System.Drawing.Size(112, 22);
            this.browseToolStripMenuItem.Text = "Browse";
            this.browseToolStripMenuItem.Click += new System.EventHandler(this.browseToolStripMenuItem_Click);
            // 
            // closeToolStripMenuItem
            // 
            this.closeToolStripMenuItem.Name = "closeToolStripMenuItem";
            this.closeToolStripMenuItem.Size = new System.Drawing.Size(112, 22);
            this.closeToolStripMenuItem.Text = "Close";
            this.closeToolStripMenuItem.Click += new System.EventHandler(this.closeToolStripMenuItem_Click);
            // 
            // ofdMapFile
            // 
            this.ofdMapFile.FileName = "ofdMapFile";
            // 
            // btnCenter
            // 
            this.btnCenter.BackgroundImage = global::Pen_and_Paper_Visualator.Properties.Resources.center;
            this.btnCenter.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnCenter.Location = new System.Drawing.Point(637, 297);
            this.btnCenter.Name = "btnCenter";
            this.btnCenter.Size = new System.Drawing.Size(32, 32);
            this.btnCenter.TabIndex = 3;
            this.btnCenter.UseVisualStyleBackColor = true;
            this.btnCenter.Click += new System.EventHandler(this.btnCenter_Click);
            // 
            // btnZoomOut
            // 
            this.btnZoomOut.BackgroundImage = global::Pen_and_Paper_Visualator.Properties.Resources.zoom_out;
            this.btnZoomOut.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnZoomOut.Location = new System.Drawing.Point(675, 297);
            this.btnZoomOut.Name = "btnZoomOut";
            this.btnZoomOut.Size = new System.Drawing.Size(32, 32);
            this.btnZoomOut.TabIndex = 2;
            this.btnZoomOut.UseVisualStyleBackColor = true;
            this.btnZoomOut.Click += new System.EventHandler(this.btnZoomOut_Click);
            // 
            // btnZoomIn
            // 
            this.btnZoomIn.BackgroundImage = global::Pen_and_Paper_Visualator.Properties.Resources.zoom_in;
            this.btnZoomIn.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnZoomIn.Location = new System.Drawing.Point(675, 259);
            this.btnZoomIn.Name = "btnZoomIn";
            this.btnZoomIn.Size = new System.Drawing.Size(32, 32);
            this.btnZoomIn.TabIndex = 1;
            this.btnZoomIn.UseVisualStyleBackColor = true;
            this.btnZoomIn.Click += new System.EventHandler(this.btnZoomIn_Click);
            // 
            // Map
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Black;
            this.Controls.Add(this.btnCenter);
            this.Controls.Add(this.btnZoomOut);
            this.Controls.Add(this.btnZoomIn);
            this.Controls.Add(this.mapMenuStrip);
            this.Name = "Map";
            this.Size = new System.Drawing.Size(720, 340);
            this.Paint += new System.Windows.Forms.PaintEventHandler(this.Map_Paint);
            this.MouseDown += new System.Windows.Forms.MouseEventHandler(this.Map_MouseDown);
            this.MouseMove += new System.Windows.Forms.MouseEventHandler(this.Map_MouseMove);
            this.MouseUp += new System.Windows.Forms.MouseEventHandler(this.Map_MouseUp);
            this.mapMenuStrip.ResumeLayout(false);
            this.mapMenuStrip.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip mapMenuStrip;
        private System.Windows.Forms.ToolStripMenuItem imageToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem browseToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem closeToolStripMenuItem;
        private System.Windows.Forms.OpenFileDialog ofdMapFile;
        private System.Windows.Forms.Button btnZoomIn;
        private System.Windows.Forms.Button btnZoomOut;
        private System.Windows.Forms.Button btnCenter;
    }
}
