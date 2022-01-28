using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace EntradaSalida
{
    public partial class AsistenciasDelDiaForm : Form
    {
        private RegEntradaSalida regEntrada= new RegEntradaSalida();
        public AsistenciasDelDiaForm()
        {
            InitializeComponent();
            comboBoxGradoGrupo.SelectedIndexChanged -= comboBoxGradoGrupo_SelectedIndexChanged_1;
            string today = DateTime.Now.ToString("dd/MM/yyyy");
            today = "06/12/2021";
            today += " ";
            regEntrada.select($"SELECT A.grupo, A.grado, ES.fk_id_alumnos, A.nombre_alumno, ES.Fecha, ES.hora_entrada, ES.hora_salida FROM Entradas_salidas AS ES INNER JOIN ALUMNO AS A ON ES.fk_id_alumnos = A.id_alumnos WHERE Fecha = \"{today}\""
           , "Entradas_salidas");
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            comboBoxEstado.Items.Add("Asistentes");
            comboBoxEstado.Items.Add("Faltantes");
            comboBoxEstado.SelectedIndex=0;
            comboBoxEstado.DropDownStyle = ComboBoxStyle.DropDownList;
            comboBoxGradoGrupo.DropDownStyle = ComboBoxStyle.DropDownList;
            Alumno alumno = new Alumno();
            alumno.select("select DISTINCT  grado || grupo as \"grado y grupo\" from ALUMNO","ALUMNO");
            alumno.dt = alumno.dataTable();
            comboBoxGradoGrupo.DataSource = alumno.dt;
            this.comboBoxGradoGrupo.DisplayMember = "grado y grupo";
            comboBoxGradoGrupo.SelectedIndexChanged += comboBoxGradoGrupo_SelectedIndexChanged_1;
        }



        private void button1_Click(object sender, EventArgs e)
        {
           
        }

        private void llenarDataGridViewAsistentes() 
        {
            regEntrada.dt = regEntrada.dataTable();
            DataTable dt = new DataTable();
            dt = regEntrada.dt;
            if (dt != null)
            {
                dt.DefaultView.RowFilter = $"grado={comboBoxGradoGrupo.Text[0]} AND grupo='{comboBoxGradoGrupo.Text[2]}'";
                dataGridView1.DataSource = dt;
                dataGridView1.Columns[0].Visible = false;
                dataGridView1.Columns[1].Visible = false;
                dataGridView1.Columns[2].Visible = false;
            }
            else
                MessageBox.Show("no se encuentran datos del dia de hoy");
              
        }
        private void llenarDataGridViewFaltantes()
        {
           
        }

        private void comboBoxGradoGrupo_SelectedIndexChanged_1(object sender, EventArgs e)
        {
            if (comboBoxGradoGrupo.Text != "")
            {
                if (comboBoxEstado.Text == "Asistentes")
                    llenarDataGridViewAsistentes();
                else
                    llenarDataGridViewFaltantes();
            }
        }
    }
}
