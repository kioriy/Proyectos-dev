
namespace EntradaSalida
{
    partial class Estadisticas
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
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.labelAsistenciaToday = new System.Windows.Forms.Label();
            this.labelAsistenciaYear = new System.Windows.Forms.Label();
            this.labelGoodAsistencia = new System.Windows.Forms.Label();
            this.labelBadAsistencia = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(10, 10);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(98, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Asistencias de hoy:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(10, 70);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(101, 13);
            this.label2.TabIndex = 1;
            this.label2.Text = "Asistencias del año:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(10, 130);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(139, 13);
            this.label3.TabIndex = 2;
            this.label3.Text = "Salon con mayor asistencia:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(10, 190);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(132, 13);
            this.label4.TabIndex = 3;
            this.label4.Text = "Salon con peor asistencia:";
            // 
            // labelAsistenciaToday
            // 
            this.labelAsistenciaToday.AutoSize = true;
            this.labelAsistenciaToday.Font = new System.Drawing.Font("Microsoft Sans Serif", 20F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelAsistenciaToday.Location = new System.Drawing.Point(10, 30);
            this.labelAsistenciaToday.Name = "labelAsistenciaToday";
            this.labelAsistenciaToday.Size = new System.Drawing.Size(68, 31);
            this.labelAsistenciaToday.TabIndex = 4;
            this.labelAsistenciaToday.Text = "30%";
            // 
            // labelAsistenciaYear
            // 
            this.labelAsistenciaYear.AutoSize = true;
            this.labelAsistenciaYear.Font = new System.Drawing.Font("Microsoft Sans Serif", 20F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelAsistenciaYear.Location = new System.Drawing.Point(10, 90);
            this.labelAsistenciaYear.Name = "labelAsistenciaYear";
            this.labelAsistenciaYear.Size = new System.Drawing.Size(68, 31);
            this.labelAsistenciaYear.TabIndex = 5;
            this.labelAsistenciaYear.Text = "30%";
            // 
            // labelGoodAsistencia
            // 
            this.labelGoodAsistencia.AutoSize = true;
            this.labelGoodAsistencia.Font = new System.Drawing.Font("Microsoft Sans Serif", 20F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelGoodAsistencia.Location = new System.Drawing.Point(10, 150);
            this.labelGoodAsistencia.Name = "labelGoodAsistencia";
            this.labelGoodAsistencia.Size = new System.Drawing.Size(68, 31);
            this.labelGoodAsistencia.TabIndex = 6;
            this.labelGoodAsistencia.Text = "30%";
            // 
            // labelBadAsistencia
            // 
            this.labelBadAsistencia.AutoSize = true;
            this.labelBadAsistencia.Font = new System.Drawing.Font("Microsoft Sans Serif", 20F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelBadAsistencia.Location = new System.Drawing.Point(10, 210);
            this.labelBadAsistencia.Name = "labelBadAsistencia";
            this.labelBadAsistencia.Size = new System.Drawing.Size(68, 31);
            this.labelBadAsistencia.TabIndex = 7;
            this.labelBadAsistencia.Text = "30%";
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.panel1.Location = new System.Drawing.Point(370, -3);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(95, 289);
            this.panel1.TabIndex = 8;
            // 
            // Estadisticas
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(464, 281);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.labelBadAsistencia);
            this.Controls.Add(this.labelGoodAsistencia);
            this.Controls.Add(this.labelAsistenciaYear);
            this.Controls.Add(this.labelAsistenciaToday);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Name = "Estadisticas";
            this.Text = "Estadisticas";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label labelAsistenciaToday;
        private System.Windows.Forms.Label labelAsistenciaYear;
        private System.Windows.Forms.Label labelGoodAsistencia;
        private System.Windows.Forms.Label labelBadAsistencia;
        private System.Windows.Forms.Panel panel1;
    }
}