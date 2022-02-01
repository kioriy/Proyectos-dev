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
        private RegEntradaSalida regEntradaAll = new RegEntradaSalida();
        private Alumno alumno = new Alumno();
        private string today;
        public AsistenciasDelDiaForm()
        {
            InitializeComponent();
            comboBoxGradoGrupo.SelectedIndexChanged -= comboBoxGradoGrupo_SelectedIndexChanged_1;
            comboBoxEstado.SelectedIndexChanged -= comboBoxEstado_SelectedIndexChanged;
            today = DateTime.Now.ToString("dd/MM/yyyy");
            today = "06/12/2021";
            today += " ";
            regEntrada.select("SELECT " +
                "A.nombre_alumno AS Nombre," +
                 "ES.hora_entrada AS Entrada," +
                 "ES.hora_salida AS Salida," +
                 "ES.Fecha," +
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
            regEntradaAll.select("SELECT " +
                "A.nombre_alumno AS Nombre," +
                 "ES.hora_entrada AS Entrada," +
                 "ES.hora_salida AS Salida," +
                 "ES.Fecha," +
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
                 ") " +
                "AS ES ON ES.fk_id_alumnos = A.id_alumnos ", "ALUMNO");
        }
        private void Form1_Load(object sender, EventArgs e)
        {
           // comboBoxAlumnos.DropDownStyle = ComboBoxStyle.DropDownList;
            comboBoxEstado.DropDownStyle = ComboBoxStyle.DropDownList;
            comboBoxEstado.Items.Add("Asistentes");
            comboBoxEstado.Items.Add("Faltantes");
            comboBoxEstado.Items.Add("Todos");
            comboBoxEstado.SelectedIndex=(0);
            comboBoxGradoGrupo.DropDownStyle = ComboBoxStyle.DropDownList;
            Alumno alumno = new Alumno();
            alumno.select("select DISTINCT  grado || grupo as \"grado y grupo\" from ALUMNO","ALUMNO");
            alumno.dt = alumno.dataTable();
            comboBoxGradoGrupo.DataSource = alumno.dt;
            this.comboBoxGradoGrupo.DisplayMember = "grado y grupo";
            comboBoxGradoGrupo.SelectedIndexChanged += comboBoxGradoGrupo_SelectedIndexChanged_1;
            comboBoxEstado.SelectedIndexChanged += comboBoxEstado_SelectedIndexChanged;
        }
        private void llenarDataGridView()
        {

            if (comboBoxEstado.SelectedIndex == 0 && !checkBoxTodosLosTiempos.Checked)
            {
                regEntrada.dt = regEntrada.dataTable();
                regEntrada.dt.DefaultView.RowFilter = $"fecha ='{today}' " +
                $"and grado='{comboBoxGradoGrupo.Text[0]}' " +
                $"and grupo='{comboBoxGradoGrupo.Text[2]}'";
                dataGridView1.DataSource = regEntrada.dt;
              //  comboBoxAlumnos.SelectedIndexChanged -= comboBoxAlumnos_SelectedIndexChanged;
               // comboBoxAlumnos.SelectedIndexChanged -= comboBoxAlumnos_SelectedIndexChanged;
               // comboBoxAlumnos.DataSource = regEntrada.dt;
                //this.comboBoxAlumnos.DisplayMember = "Nombre";
               // comboBoxAlumnos.SelectedItem = null;
               // dataGridView1.Rows[1].Selected = true;
               // comboBoxAlumnos.SelectedIndexChanged += comboBoxAlumnos_SelectedIndexChanged;
            }
            if (comboBoxEstado.SelectedIndex == 1 && !checkBoxTodosLosTiempos.Checked)
            {
                regEntrada.dt = regEntrada.dataTable();
                regEntrada.dt.DefaultView.RowFilter = $"fecha IS NULL " +
                $"and grado='{comboBoxGradoGrupo.Text[0]}' " +
                $"and grupo='{comboBoxGradoGrupo.Text[2]}'";
                dataGridView1.DataSource = regEntrada.dt;            }
            if (comboBoxEstado.SelectedIndex == 2 && !checkBoxTodosLosTiempos.Checked)
            {
                regEntrada.dt = regEntrada.dataTable();
                regEntrada.dt.DefaultView.RowFilter =$"grado='{comboBoxGradoGrupo.Text[0]}' " +
                $"and grupo='{comboBoxGradoGrupo.Text[2]}'";
                dataGridView1.DataSource = regEntrada.dt;
            }
            if (checkBoxTodosLosTiempos.Checked) {
                // if (comboBoxEstado.SelectedIndex==0)
                //{
                    comboBoxEstado.SelectedIndex = 0;
                    regEntradaAll.dt = regEntradaAll.dataTable();
                    regEntradaAll.dt.DefaultView.RowFilter = $"grado='{comboBoxGradoGrupo.Text[0]}' " +
                    $"and grupo='{comboBoxGradoGrupo.Text[2]}' " +
                    "and fecha IS NOT NULL";
                    dataGridView1.DataSource = regEntradaAll.dt;
                // }
                /*if (comboBoxEstado.SelectedIndex == 1)
                {
                    regEntradaAll.dt = regEntradaAll.dataTable();
                    regEntradaAll.dt.DefaultView.RowFilter = $"grado='{comboBoxGradoGrupo.Text[0]}' " +
                    $"and grupo='{comboBoxGradoGrupo.Text[2]}' "+
                    "and fecha IS NULL";
                    dataGridView1.DataSource = regEntradaAll.dt;
                }
                if (comboBoxEstado.SelectedIndex == 2)
                {
                    regEntradaAll.dt = regEntradaAll.dataTable();
                    regEntradaAll.dt.DefaultView.RowFilter = $"grado='{comboBoxGradoGrupo.Text[0]}' " +
                    $"and grupo='{comboBoxGradoGrupo.Text[2]}' ";
                    dataGridView1.DataSource = regEntradaAll.dt;
                }*/
            }
        }
        private void comboBoxGradoGrupo_SelectedIndexChanged_1(object sender, EventArgs e)
        {
            llenarDataGridView();
        }

        private void comboBoxEstado_SelectedIndexChanged(object sender, EventArgs e)
        {
            llenarDataGridView();
        }

        private void checkBoxTodosLosTiempos_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBoxTodosLosTiempos.Checked) {
                llenarDataGridView();
            }
        }

        private void comboBoxAlumnos_SelectedIndexChanged(object sender, EventArgs e)
        {
            MessageBox.Show("");
        }
    }
}
