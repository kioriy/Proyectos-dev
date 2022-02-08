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
        private decimal numeroDeFechasTotales= 0.0M;
        public AsistenciasDelDiaForm()
        {
           
            InitializeComponent();
            regEntrada.select("SELECT count(DISTINCT Fecha) as allfechas from Entradas_salidas", "Entradas_salidas");
            numeroDeFechasTotales = int.Parse((regEntrada.dt = regEntrada.dataTable()).Rows[0][0].ToString());
            dataGridView1.BackgroundColor = Color.White;
            comboBoxGradoGrupo.SelectedIndexChanged -= comboBoxGradoGrupo_SelectedIndexChanged_1;
            comboBoxEstado.SelectedIndexChanged -= comboBoxEstado_SelectedIndexChanged;
            dataGridView1.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dataGridView1.AutoSizeColumnsMode = (DataGridViewAutoSizeColumnsMode)DataGridViewAutoSizeColumnMode.Fill;
            today = DateTime.Now.ToString("dd/MM/yyyy");
            today = "06/12/2021";
            regEntrada.select("SELECT " +
                "A.nombre_alumno AS Nombre," +
                 "ES.hora_entrada AS Entrada," +
                 "ES.hora_salida AS Salida," +
                 "ES.Fecha," +
                 "grado," +
                 "grupo," +
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
                "AS ES ON ES.fk_id_alumnos = A.id_alumnos "+
                "INNER JOIN AULAS on "+
                "id_aula = A.fk_id_aula "
                , "ALUMNO");
            regEntradaAll.select("SELECT " +
                "A.nombre_alumno AS Nombre," +
                 "ES.hora_entrada AS Entrada," +
                 "ES.hora_salida AS Salida," +
                 "ES.Fecha," +
                 "grado," +
                 "grupo," +
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
                "AS ES ON ES.fk_id_alumnos = A.id_alumnos "+
                 "INNER JOIN AULAS on " +
                "id_aula = A.fk_id_aula "
                , "ALUMNO");
        }
        private void Form1_Load(object sender, EventArgs e)
        {
            comboBox1.Visible = false;
            comboBox1.DropDownStyle = ComboBoxStyle.DropDownList;
            comboBoxEstado.DropDownStyle = ComboBoxStyle.DropDownList;
            comboBoxEstado.Items.Add("Asistentes");
            comboBoxEstado.Items.Add("Faltantes");
            comboBoxEstado.Items.Add("Todos");
            comboBoxEstado.SelectedIndex = 0;
            comboBoxGradoGrupo.DropDownStyle = ComboBoxStyle.DropDownList;
            Alumno alumno = new Alumno();
            alumno.select("select DISTINCT  grado || grupo as \"grado y grupo\" from AULAS","AULAS");
            alumno.dt = alumno.dataTable();
            comboBoxGradoGrupo.DataSource = alumno.dt;
            this.comboBoxGradoGrupo.DisplayMember = "grado y grupo";
            comboBoxGradoGrupo.SelectedIndexChanged += comboBoxGradoGrupo_SelectedIndexChanged_1;
            comboBoxEstado.SelectedIndexChanged += comboBoxEstado_SelectedIndexChanged;
            /*Estadisticas es = new Estadisticas(alumno.dt);
            es.Visible = true;
            this.WindowState = FormWindowState.Minimized;
           this.Enabled = false; */
            Grafica g = new Grafica(numeroDeFechasTotales);
            g.Visible = true; 
            this.WindowState = FormWindowState.Minimized;
            this.Enabled = false;
        }
        private void llenarDataGridView()
        {
            if (comboBoxEstado.SelectedIndex == 0 && !checkBoxTodosLosTiempos.Checked)
            {
             
                regEntrada.dt = regEntrada.dataTable();
                regEntrada.dt.DefaultView.RowFilter = $"fecha ='{today}' " +
                $"and grado='{comboBoxGradoGrupo.Text[0]}' " +
                $"and grupo='{comboBoxGradoGrupo.Text[1]}'";
                dataGridView1.DataSource = regEntrada.dt;
                comboBox1.SelectedIndexChanged -= comboBoxAlumnos_SelectedIndexChanged;
                comboBox1.DataSource = regEntrada.dt;
                this.comboBox1.DisplayMember = "Nombre";
                dataGridView1.Columns[0].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
                dataGridView1.Columns[1].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
                dataGridView1.Columns[2].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
                dataGridView1.Columns[4].Visible = false;
                dataGridView1.Columns[5].Visible = false;
                dataGridView1.Columns[6].Visible = false;
                Alumno al = new Alumno();
                al.select("select "+
                       "A.id_alumnos, " +
                       "A.nombre_alumno, " +
                       "ES.Fecha " +
                "from ALUMNO as A " +
                "inner join Entradas_salidas as ES " +
                "on A.id_alumnos = ES.fk_id_alumnos","ALUMNO");
                List<Alumno> listAl = new List<Alumno>();
                listAl = al.list<Alumno>();
                comboBox2.SelectedIndexChanged -= comboBoxAlumnos_SelectedIndexChanged;
                comboBox2.DataSource = regEntrada.dt;
                this.comboBox2.DisplayMember = "id_alumnos";
                List<decimal> porcentajes= new List<decimal>();
              
                for (int x = 0; x < comboBox2.Items.Count; x++) {
                    List<Alumno> listAl2 = new List<Alumno>();
                    comboBox2.SelectedIndex= x;
                    int RES=int.Parse(comboBox2.Text);
                    listAl2 = listAl.FindAll(y=>y.id_alumnos==RES);
                    decimal temp = (100/numeroDeFechasTotales);
                    temp = temp * listAl2.Count;
                    porcentajes.Add(temp);
                    MessageBox.Show(porcentajes[x].ToString());
                }
                comboBox2.SelectedIndex = 0;

            }   
            if (comboBoxEstado.SelectedIndex == 1 && !checkBoxTodosLosTiempos.Checked)
            {
                regEntrada.dt = regEntrada.dataTable();
                regEntrada.dt.DefaultView.RowFilter = $"fecha IS NULL " +
                $"and grado='{comboBoxGradoGrupo.Text[0]}' " +
                $"and grupo='{comboBoxGradoGrupo.Text[1]}'";
                dataGridView1.DataSource = regEntrada.dt;
                comboBox1.SelectedIndexChanged -= comboBoxAlumnos_SelectedIndexChanged;
                comboBox1.DataSource = regEntrada.dt;
                this.comboBox1.DisplayMember = "Nombre";
                dataGridView1.Columns[0].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
                dataGridView1.Columns[1].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
                dataGridView1.Columns[2].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
                dataGridView1.Columns[4].Visible = false;
                dataGridView1.Columns[5].Visible = false;
                dataGridView1.Columns[6].Visible = false;
            }
            if (comboBoxEstado.SelectedIndex == 2 && !checkBoxTodosLosTiempos.Checked)
            {
                regEntrada.dt = regEntrada.dataTable();
                regEntrada.dt.DefaultView.RowFilter =$"grado='{comboBoxGradoGrupo.Text[0]}' " +
                $"and grupo='{comboBoxGradoGrupo.Text[1]}'";
                dataGridView1.DataSource = regEntrada.dt;
                comboBox1.SelectedIndexChanged -= comboBoxAlumnos_SelectedIndexChanged;
                comboBox1.DataSource = regEntrada.dt;
                this.comboBox1.DisplayMember = "Nombre";
                dataGridView1.Columns[0].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
                dataGridView1.Columns[1].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
                dataGridView1.Columns[2].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
                dataGridView1.Columns[4].Visible = false;
                dataGridView1.Columns[5].Visible = false;
                dataGridView1.Columns[6].Visible = false;

            }
            if (checkBoxTodosLosTiempos.Checked) {
                    comboBoxEstado.SelectedIndex = 0;
                    regEntradaAll.dt = regEntradaAll.dataTable();
                    regEntradaAll.dt.DefaultView.RowFilter = $"grado='{comboBoxGradoGrupo.Text[0]}' " +
                    $"and grupo='{comboBoxGradoGrupo.Text[1]}' " +
                    "and fecha IS NOT NULL";
                    dataGridView1.DataSource = regEntradaAll.dt;
                comboBox1.SelectedIndexChanged -= comboBoxAlumnos_SelectedIndexChanged;
                comboBox1.DataSource = regEntrada.dt;
                this.comboBox1.DisplayMember = "Nombre";
                dataGridView1.Columns[0].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
                dataGridView1.Columns[1].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
                dataGridView1.Columns[2].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
                dataGridView1.Columns[4].Visible = false;
                dataGridView1.Columns[5].Visible = false;
                dataGridView1.Columns[6].Visible = false;
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
        }
        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            
            comboBox1.SelectedItem = dataGridView1.SelectedRows.ToString();          
            regEntradaAll.dt = regEntradaAll.dataTable();
            regEntradaAll.dt.DefaultView.RowFilter = $"Nombre='{comboBox1.Text}' "+
            "AND fecha IS NOT NULL";
            dataGridView1.DataSource = regEntradaAll.dt;
            
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
