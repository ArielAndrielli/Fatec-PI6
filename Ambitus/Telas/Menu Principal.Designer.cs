namespace Ambitus.Telas
{
    partial class Recompensas
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Recompensas));
            label1 = new Label();
            pictureBox1 = new PictureBox();
            panel2 = new Panel();
            btnCriarEvento = new Button();
            panel1 = new Panel();
            lblCadastrar = new Label();
            button1 = new Button();
            label2 = new Label();
            dgvEventos = new DataGridView();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvEventos).BeginInit();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Arial Rounded MT Bold", 72F, FontStyle.Italic, GraphicsUnit.Point);
            label1.ForeColor = Color.FromArgb(111, 146, 0);
            label1.Location = new Point(761, 28);
            label1.Name = "label1";
            label1.Size = new Size(431, 111);
            label1.TabIndex = 11;
            label1.Text = "Ambitus";
            // 
            // pictureBox1
            // 
            pictureBox1.Image = (Image)resources.GetObject("pictureBox1.Image");
            pictureBox1.Location = new Point(619, 19);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new Size(136, 135);
            pictureBox1.SizeMode = PictureBoxSizeMode.StretchImage;
            pictureBox1.TabIndex = 10;
            pictureBox1.TabStop = false;
            // 
            // panel2
            // 
            panel2.Location = new Point(1060, 267);
            panel2.Name = "panel2";
            panel2.Size = new Size(832, 762);
            panel2.TabIndex = 26;
            // 
            // btnCriarEvento
            // 
            btnCriarEvento.BackColor = Color.FromArgb(66, 151, 17);
            btnCriarEvento.FlatStyle = FlatStyle.Flat;
            btnCriarEvento.Font = new Font("Arial Rounded MT Bold", 20.25F, FontStyle.Italic, GraphicsUnit.Point);
            btnCriarEvento.ForeColor = Color.FromArgb(144, 218, 101);
            btnCriarEvento.Location = new Point(39, 986);
            btnCriarEvento.Name = "btnCriarEvento";
            btnCriarEvento.Size = new Size(361, 43);
            btnCriarEvento.TabIndex = 29;
            btnCriarEvento.Text = "Cadastrar Eventos";
            btnCriarEvento.UseVisualStyleBackColor = false;
            // 
            // panel1
            // 
            panel1.Controls.Add(dgvEventos);
            panel1.Location = new Point(39, 267);
            panel1.Name = "panel1";
            panel1.Size = new Size(849, 691);
            panel1.TabIndex = 27;
            // 
            // lblCadastrar
            // 
            lblCadastrar.AutoSize = true;
            lblCadastrar.Font = new Font("Arial", 24F, FontStyle.Bold | FontStyle.Italic, GraphicsUnit.Point);
            lblCadastrar.ForeColor = Color.FromArgb(111, 146, 0);
            lblCadastrar.Location = new Point(1060, 218);
            lblCadastrar.Name = "lblCadastrar";
            lblCadastrar.Size = new Size(195, 36);
            lblCadastrar.TabIndex = 30;
            lblCadastrar.Text = "Premiações";
            // 
            // button1
            // 
            button1.BackColor = Color.FromArgb(66, 151, 17);
            button1.FlatStyle = FlatStyle.Flat;
            button1.Font = new Font("Arial Rounded MT Bold", 20.25F, FontStyle.Italic, GraphicsUnit.Point);
            button1.ForeColor = Color.FromArgb(144, 218, 101);
            button1.Location = new Point(527, 986);
            button1.Name = "button1";
            button1.Size = new Size(361, 43);
            button1.TabIndex = 31;
            button1.Text = "Gerenciar Eventos";
            button1.UseVisualStyleBackColor = false;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Arial", 24F, FontStyle.Bold | FontStyle.Italic, GraphicsUnit.Point);
            label2.ForeColor = Color.FromArgb(111, 146, 0);
            label2.Location = new Point(39, 218);
            label2.Name = "label2";
            label2.Size = new Size(140, 36);
            label2.TabIndex = 32;
            label2.Text = "Eventos";
            // 
            // dgvEventos
            // 
            dgvEventos.BackgroundColor = Color.White;
            dgvEventos.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvEventos.Location = new Point(3, 3);
            dgvEventos.Name = "dgvEventos";
            dgvEventos.RowTemplate.Height = 25;
            dgvEventos.Size = new Size(843, 685);
            dgvEventos.TabIndex = 0;
            // 
            // Recompensas
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(254, 250, 224);
            ClientSize = new Size(1904, 1041);
            Controls.Add(label2);
            Controls.Add(button1);
            Controls.Add(lblCadastrar);
            Controls.Add(panel1);
            Controls.Add(btnCriarEvento);
            Controls.Add(panel2);
            Controls.Add(label1);
            Controls.Add(pictureBox1);
            MinimizeBox = false;
            Name = "Recompensas";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Recompensas";
            WindowState = FormWindowState.Maximized;
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)dgvEventos).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion
        private Label label1;
        private PictureBox pictureBox1;
        private Panel panel2;
        private Button btnCriarEvento;
        private Panel panel1;
        private Label lblCadastrar;
        private Button button1;
        private Label label2;
        private DataGridView dgvEventos;
    }
}