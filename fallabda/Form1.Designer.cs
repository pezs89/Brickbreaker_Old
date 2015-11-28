namespace fallabda
{
    partial class Form1
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
            this.components = new System.ComponentModel.Container();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.játékToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.újJátékToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.könnyűToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.közepesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.nehézToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.beállításokToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.kilépésToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.névjegyToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.pontlistaToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // timer1
            // 
            this.timer1.Interval = 40;
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.játékToolStripMenuItem,
            this.névjegyToolStripMenuItem,
            this.pontlistaToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(354, 24);
            this.menuStrip1.TabIndex = 0;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // játékToolStripMenuItem
            // 
            this.játékToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.újJátékToolStripMenuItem,
            this.beállításokToolStripMenuItem,
            this.kilépésToolStripMenuItem});
            this.játékToolStripMenuItem.Name = "játékToolStripMenuItem";
            this.játékToolStripMenuItem.Size = new System.Drawing.Size(45, 20);
            this.játékToolStripMenuItem.Text = "Játék";
            // 
            // újJátékToolStripMenuItem
            // 
            this.újJátékToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.könnyűToolStripMenuItem,
            this.közepesToolStripMenuItem,
            this.nehézToolStripMenuItem});
            this.újJátékToolStripMenuItem.Name = "újJátékToolStripMenuItem";
            this.újJátékToolStripMenuItem.Size = new System.Drawing.Size(130, 22);
            this.újJátékToolStripMenuItem.Text = "Új Játék";
            // 
            // könnyűToolStripMenuItem
            // 
            this.könnyűToolStripMenuItem.Name = "könnyűToolStripMenuItem";
            this.könnyűToolStripMenuItem.Size = new System.Drawing.Size(117, 22);
            this.könnyűToolStripMenuItem.Text = "Könnyű";
            this.könnyűToolStripMenuItem.Click += new System.EventHandler(this.könnyűToolStripMenuItem_Click);
            // 
            // közepesToolStripMenuItem
            // 
            this.közepesToolStripMenuItem.Name = "közepesToolStripMenuItem";
            this.közepesToolStripMenuItem.Size = new System.Drawing.Size(117, 22);
            this.közepesToolStripMenuItem.Text = "Közepes";
            this.közepesToolStripMenuItem.Click += new System.EventHandler(this.közepesToolStripMenuItem_Click);
            // 
            // nehézToolStripMenuItem
            // 
            this.nehézToolStripMenuItem.Name = "nehézToolStripMenuItem";
            this.nehézToolStripMenuItem.Size = new System.Drawing.Size(117, 22);
            this.nehézToolStripMenuItem.Text = "Nehéz";
            this.nehézToolStripMenuItem.Click += new System.EventHandler(this.nehézToolStripMenuItem_Click);
            // 
            // beállításokToolStripMenuItem
            // 
            this.beállításokToolStripMenuItem.Name = "beállításokToolStripMenuItem";
            this.beállításokToolStripMenuItem.Size = new System.Drawing.Size(130, 22);
            this.beállításokToolStripMenuItem.Text = "Beállítások";
            this.beállításokToolStripMenuItem.Click += new System.EventHandler(this.beállításokToolStripMenuItem_Click);
            // 
            // kilépésToolStripMenuItem
            // 
            this.kilépésToolStripMenuItem.Name = "kilépésToolStripMenuItem";
            this.kilépésToolStripMenuItem.Size = new System.Drawing.Size(130, 22);
            this.kilépésToolStripMenuItem.Text = "Kilépés";
            this.kilépésToolStripMenuItem.Click += new System.EventHandler(this.kilépésToolStripMenuItem_Click);
            // 
            // névjegyToolStripMenuItem
            // 
            this.névjegyToolStripMenuItem.Name = "névjegyToolStripMenuItem";
            this.névjegyToolStripMenuItem.Size = new System.Drawing.Size(62, 20);
            this.névjegyToolStripMenuItem.Text = "Névjegy";
            this.névjegyToolStripMenuItem.Click += new System.EventHandler(this.névjegyToolStripMenuItem_Click);
            // 
            // pontlistaToolStripMenuItem
            // 
            this.pontlistaToolStripMenuItem.Name = "pontlistaToolStripMenuItem";
            this.pontlistaToolStripMenuItem.Size = new System.Drawing.Size(65, 20);
            this.pontlistaToolStripMenuItem.Text = "Pontlista";
            this.pontlistaToolStripMenuItem.Click += new System.EventHandler(this.pontlistaToolStripMenuItem_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(354, 350);
            this.Controls.Add(this.menuStrip1);
            this.DoubleBuffered = true;
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "Form1";
            this.Text = "Form1";
            this.Paint += new System.Windows.Forms.PaintEventHandler(this.Form1_Paint);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.Form1_KeyDown);
            this.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.Form1_KeyPress);
            this.MouseClick += new System.Windows.Forms.MouseEventHandler(this.Form1_MouseClick);
            this.MouseMove += new System.Windows.Forms.MouseEventHandler(this.Form1_MouseMove);
            this.Resize += new System.EventHandler(this.Form1_Resize);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem játékToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem újJátékToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem beállításokToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem kilépésToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem könnyűToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem közepesToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem nehézToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem névjegyToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem pontlistaToolStripMenuItem;
    }
}

