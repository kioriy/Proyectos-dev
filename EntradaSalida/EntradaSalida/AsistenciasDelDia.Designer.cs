
namespace EntradaSalida
{
    partial class AsistenciasDelDiaForm
    {
        /// <summary>
        /// Variable del diseñador necesaria.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Limpiar los recursos que se estén usando.
        /// </summary>
        /// <param name="disposing">true si los recursos administrados se deben desechar; false en caso contrario.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Código generado por el Diseñador de Windows Forms

        /// <summary>
        /// Método necesario para admitir el Diseñador. No se puede modificar
        /// el contenido de este método con el editor de código.
        /// </summary>
        private void InitializeComponent()
        {
            this.comboBoxGradoGrupo = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.comboBox1 = new System.Windows.Forms.ComboBox();
            this.comboBox2 = new System.Windows.Forms.ComboBox();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.panelControles = new System.Windows.Forms.Panel();
            this.panel2 = new System.Windows.Forms.Panel();
            this.buttonAllSalones = new System.Windows.Forms.Button();
            this.buttonAmbas = new System.Windows.Forms.Button();
            this.buttonSalidas = new System.Windows.Forms.Button();
            this.buttonEntradas = new System.Windows.Forms.Button();
            this.panel1 = new System.Windows.Forms.Panel();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.panelControles.SuspendLayout();
            this.panel2.SuspendLayout();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // comboBoxGradoGrupo
            // 
            this.comboBoxGradoGrupo.FormattingEnabled = true;
            this.comboBoxGradoGrupo.Location = new System.Drawing.Point(5, 22);
            this.comboBoxGradoGrupo.Name = "comboBoxGradoGrupo";
            this.comboBoxGradoGrupo.Size = new System.Drawing.Size(75, 21);
            this.comboBoxGradoGrupo.TabIndex = 2;
            this.comboBoxGradoGrupo.SelectedIndexChanged += new System.EventHandler(this.comboBoxGradoGrupo_SelectedIndexChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(2, 6);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(39, 13);
            this.label2.TabIndex = 4;
            this.label2.Text = "Grado.";
            // 
            // comboBox1
            // 
            this.comboBox1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.comboBox1.FormattingEnabled = true;
            this.comboBox1.Location = new System.Drawing.Point(19, 3);
            this.comboBox1.Name = "comboBox1";
            this.comboBox1.Size = new System.Drawing.Size(12, 21);
            this.comboBox1.TabIndex = 10;
            // 
            // comboBox2
            // 
            this.comboBox2.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.comboBox2.FormattingEnabled = true;
            this.comboBox2.Location = new System.Drawing.Point(3, 3);
            this.comboBox2.Name = "comboBox2";
            this.comboBox2.Size = new System.Drawing.Size(10, 21);
            this.comboBox2.TabIndex = 11;
            // 
            // dataGridView1
            // 
            this.dataGridView1.AllowUserToAddRows = false;
            this.dataGridView1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Location = new System.Drawing.Point(3, 3);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.Size = new System.Drawing.Size(358, 251);
            this.dataGridView1.TabIndex = 6;
            this.dataGridView1.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_CellClick);
            // 
            // panelControles
            // 
            this.panelControles.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.panelControles.Controls.Add(this.panel2);
            this.panelControles.Controls.Add(this.comboBox2);
            this.panelControles.Controls.Add(this.comboBox1);
            this.panelControles.Dock = System.Windows.Forms.DockStyle.Left;
            this.panelControles.Location = new System.Drawing.Point(0, 0);
            this.panelControles.Name = "panelControles";
            this.panelControles.Size = new System.Drawing.Size(94, 281);
            this.panelControles.TabIndex = 12;
            // 
            // panel2
            // 
            this.panel2.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.panel2.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.panel2.Controls.Add(this.buttonAllSalones);
            this.panel2.Controls.Add(this.buttonAmbas);
            this.panel2.Controls.Add(this.buttonSalidas);
            this.panel2.Controls.Add(this.buttonEntradas);
            this.panel2.Controls.Add(this.label2);
            this.panel2.Controls.Add(this.comboBoxGradoGrupo);
            this.panel2.Location = new System.Drawing.Point(3, 25);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(88, 232);
            this.panel2.TabIndex = 0;
            // 
            // buttonAllSalones
            // 
            this.buttonAllSalones.Location = new System.Drawing.Point(5, 138);
            this.buttonAllSalones.Name = "buttonAllSalones";
            this.buttonAllSalones.Size = new System.Drawing.Size(75, 39);
            this.buttonAllSalones.TabIndex = 14;
            this.buttonAllSalones.Text = "todos los salones";
            this.buttonAllSalones.UseVisualStyleBackColor = true;
            this.buttonAllSalones.Click += new System.EventHandler(this.buttonAllSalones_Click);
            // 
            // buttonAmbas
            // 
            this.buttonAmbas.Location = new System.Drawing.Point(5, 109);
            this.buttonAmbas.Name = "buttonAmbas";
            this.buttonAmbas.Size = new System.Drawing.Size(75, 23);
            this.buttonAmbas.TabIndex = 13;
            this.buttonAmbas.Text = "Ambas.";
            this.buttonAmbas.UseVisualStyleBackColor = true;
            this.buttonAmbas.Click += new System.EventHandler(this.buttonAmbas_Click);
            // 
            // buttonSalidas
            // 
            this.buttonSalidas.Location = new System.Drawing.Point(5, 80);
            this.buttonSalidas.Name = "buttonSalidas";
            this.buttonSalidas.Size = new System.Drawing.Size(75, 23);
            this.buttonSalidas.TabIndex = 12;
            this.buttonSalidas.Text = "Faltantes.";
            this.buttonSalidas.UseVisualStyleBackColor = true;
            this.buttonSalidas.Click += new System.EventHandler(this.buttonSalidas_Click);
            // 
            // buttonEntradas
            // 
            this.buttonEntradas.Location = new System.Drawing.Point(5, 50);
            this.buttonEntradas.Name = "buttonEntradas";
            this.buttonEntradas.Size = new System.Drawing.Size(75, 23);
            this.buttonEntradas.TabIndex = 11;
            this.buttonEntradas.Text = "Asistentes.";
            this.buttonEntradas.UseVisualStyleBackColor = true;
            this.buttonEntradas.Click += new System.EventHandler(this.buttonEntradas_Click);
            // 
            // panel1
            // 
            this.panel1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panel1.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.panel1.Controls.Add(this.dataGridView1);
            this.panel1.Location = new System.Drawing.Point(100, 12);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(364, 257);
            this.panel1.TabIndex = 13;
            // 
            // AsistenciasDelDiaForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(464, 281);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.panelControles);
            this.Name = "AsistenciasDelDiaForm";
            this.Text = "Asistencias del dia.";
            this.Load += new System.EventHandler(this.Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.panelControles.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.ComboBox comboBoxGradoGrupo;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox comboBox1;
        private System.Windows.Forms.ComboBox comboBox2;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.Panel panelControles;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Button buttonAllSalones;
        private System.Windows.Forms.Button buttonAmbas;
        private System.Windows.Forms.Button buttonSalidas;
        private System.Windows.Forms.Button buttonEntradas;
    }
}

