namespace Lab5_Graphics
{
    partial class Form1
    {
        private System.ComponentModel.IContainer components = null;
        private System.Windows.Forms.ComboBox comboBox1;
        private System.Windows.Forms.Button button1;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null)) components.Dispose();
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            this.comboBox1 = new System.Windows.Forms.ComboBox();
            this.button1 = new System.Windows.Forms.Button();
            this.SuspendLayout();

            // comboBox1
            this.comboBox1.FormattingEnabled = true;
            this.comboBox1.Items.AddRange(new object[] {
            "Крива Ерміта",
            "Хмарне небо"});
            this.comboBox1.Location = new System.Drawing.Point(12, 12);
            this.comboBox1.Name = "comboBox1";
            this.comboBox1.Size = new System.Drawing.Size(200, 21);
            this.comboBox1.TabIndex = 0;
            this.comboBox1.SelectedIndex = 0;

            // button1
            this.button1.Location = new System.Drawing.Point(230, 12);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 21);
            this.button1.TabIndex = 1;
            this.button1.Text = "Малювати";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);

            // Form1
            this.ClientSize = new System.Drawing.Size(800, 600);
            this.Controls.Add(this.comboBox1);
            this.Controls.Add(this.button1);
            this.Name = "Form1";
            this.Text = "Lab 5 – Ерміт і хмарне небо";
            this.Paint += new System.Windows.Forms.PaintEventHandler(this.Form1_Paint);
            this.ResumeLayout(false);
        }
    }
}
