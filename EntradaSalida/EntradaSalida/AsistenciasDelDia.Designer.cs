
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
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.comboBoxEstado = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.checkBoxTodosLosTiempos = new System.Windows.Forms.CheckBox();
            this.comboBox1 = new System.Windows.Forms.ComboBox();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // comboBoxGradoGrupo
            // 
            this.comboBoxGradoGrupo.FormattingEnabled = true;
            this.comboBoxGradoGrupo.Location = new System.Drawing.Point(10, 27);
            this.comboBoxGradoGrupo.Name = "comboBoxGradoGrupo";
            this.comboBoxGradoGrupo.Size = new System.Drawing.Size(92, 21);
            this.comboBoxGradoGrupo.TabIndex = 2;
            this.comboBoxGradoGrupo.SelectedIndexChanged += new System.EventHandler(this.comboBoxGradoGrupo_SelectedIndexChanged_1);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 11);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(39, 13);
            this.label2.TabIndex = 4;
            this.label2.Text = "Grado.";
            // 
            // dataGridView1
            // 
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Location = new System.Drawing.Point(10, 54);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.Size = new System.Drawing.Size(435, 215);
            this.dataGridView1.TabIndex = 6;
            this.dataGridView1.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_CellClick);
            // 
            // comboBoxEstado
            // 
            this.comboBoxEstado.FormattingEnabled = true;
            this.comboBoxEstado.Location = new System.Drawing.Point(123, 27);
            this.comboBoxEstado.Name = "comboBoxEstado";
            this.comboBoxEstado.Size = new System.Drawing.Size(92, 21);
            this.comboBoxEstado.TabIndex = 7;
            this.comboBoxEstado.SelectedIndexChanged += new System.EventHandler(this.comboBoxEstado_SelectedIndexChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(120, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(40, 13);
            this.label1.TabIndex = 8;
            this.label1.Text = "Estado";
            // 
            // checkBoxTodosLosTiempos
            // 
            this.checkBoxTodosLosTiempos.AutoSize = true;
            this.checkBoxTodosLosTiempos.Location = new System.Drawing.Point(232, 29);
            this.checkBoxTodosLosTiempos.Name = "checkBoxTodosLosTiempos";
            this.checkBoxTodosLosTiempos.Size = new System.Drawing.Size(107, 17);
            this.checkBoxTodosLosTiempos.TabIndex = 9;
            this.checkBoxTodosLosTiempos.Text = "Todas las fechas";
            this.checkBoxTodosLosTiempos.UseVisualStyleBackColor = true;
            this.checkBoxTodosLosTiempos.CheckedChanged += new System.EventHandler(this.checkBoxTodosLosTiempos_CheckedChanged);
            // 
            // comboBox1
            // 
            this.comboBox1.FormattingEnabled = true;
            this.comboBox1.Location = new System.Drawing.Point(345, 25);
            this.comboBox1.Name = "comboBox1";
            this.comboBox1.Size = new System.Drawing.Size(92, 21);
            this.comboBox1.TabIndex = 10;
            // 
            // AsistenciasDelDiaForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(464, 281);
            this.Controls.Add(this.comboBox1);
            this.Controls.Add(this.checkBoxTodosLosTiempos);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.comboBoxEstado);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.comboBoxGradoGrupo);
            this.Name = "AsistenciasDelDiaForm";
            this.Text = "Asistencias del dia.";
            this.Load += new System.EventHandler(this.Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.ComboBox comboBoxGradoGrupo;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.ComboBox comboBoxEstado;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.CheckBox checkBoxTodosLosTiempos;
        private System.Windows.Forms.ComboBox comboBox1;
    }
}

