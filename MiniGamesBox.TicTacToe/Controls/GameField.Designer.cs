namespace MiniGamesBox.TicTacToe.Controls
{
    partial class GameField
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
            this.FieldDrawer = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.FieldDrawer)).BeginInit();
            this.SuspendLayout();
            // 
            // FieldDrawer
            // 
            this.FieldDrawer.Dock = System.Windows.Forms.DockStyle.Fill;
            this.FieldDrawer.Location = new System.Drawing.Point(0, 0);
            this.FieldDrawer.Name = "FieldDrawer";
            this.FieldDrawer.Size = new System.Drawing.Size(150, 150);
            this.FieldDrawer.TabIndex = 0;
            this.FieldDrawer.TabStop = false;
            this.FieldDrawer.Click += new System.EventHandler(this.FieldDrawerClick);
            this.FieldDrawer.Paint += new System.Windows.Forms.PaintEventHandler(this.FieldDrawerPaint);
            this.FieldDrawer.MouseDown += new System.Windows.Forms.MouseEventHandler(this.FieldDrawerMouseDown);
            this.FieldDrawer.MouseMove += new System.Windows.Forms.MouseEventHandler(this.FieldDrawerMouseMove);
            // 
            // GameField
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.FieldDrawer);
            this.Name = "GameField";
            ((System.ComponentModel.ISupportInitialize)(this.FieldDrawer)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.PictureBox FieldDrawer;
    }
}
