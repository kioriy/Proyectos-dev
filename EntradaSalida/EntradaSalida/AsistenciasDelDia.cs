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
        private Alumno alumno = new Alumno();
        public AsistenciasDelDiaForm()
        {
            InitializeComponent();
            comboBoxGradoGrupo.SelectedIndexChanged -= comboBoxGradoGrupo_SelectedIndexChanged_1;
            string today = DateTime.Now.ToString("dd/MM/yyyy");
            today = "06/12/2021";
            today += " ";
            regEntrada.select("SELECT "+
                 "ES.Fecha,"+
                 "ES.hora_entrada AS Entrada," +
                 "ES.hora_salida AS Salida," +
                 "A.nombre_alumno AS Nombre," +
                 "A.grado," +
                 "A.grupo," +
                 "A.id_alumnos " +
                 "FROM ALUMNO AS A " +
                 "LEFT JOIN" +
                 "(" +
                   " SELECT" +
                      "  ES.fk_id_alumnos, " +
                        "ES.Fecha," +
                        "ES.hora_entrada, " +
                        "ES.hora_salida " +
                        "FROM Entradas_salidas AS ES " +
                        "INNER JOIN ALUMNO AS A " +
                       " ON ES.fk_id_alumnos = A.id_alumnos " +
                       $" WHERE Fecha = \"{today}\" " +
                 ") " +
                "AS ES ON ES.fk_id_alumnos = A.id_alumnos ", "ALUMNO");
           
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
        private void llenarDataGridViewAsistentes() 
        {
            regEntrada.dt = regEntrada.dataTable();
            dataGridView1.DataSource = regEntrada.dt;
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
