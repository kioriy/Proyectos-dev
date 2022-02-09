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
        private int estado = 0; 
        public AsistenciasDelDiaForm()
        {
            InitializeComponent();
            comboBox2.Visible = false;
            regEntrada.select("SELECT count(DISTINCT Fecha) as allfechas from Entradas_salidas", "Entradas_salidas");
            numeroDeFechasTotales = int.Parse((regEntrada.dt = regEntrada.dataTable()).Rows[0][0].ToString());
            dataGridView1.BackgroundColor = Color.White;
            dataGridView1.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
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
            comboBoxGradoGrupo.DropDownStyle = ComboBoxStyle.DropDownList;
            Alumno alumno = new Alumno();
            alumno.select("select DISTINCT  grado || grupo as \"grado y grupo\" from AULAS","AULAS");
            alumno.dt = alumno.dataTable();
            comboBoxGradoGrupo.DataSource = alumno.dt;
            this.comboBoxGradoGrupo.DisplayMember = "grado y grupo";
            /*Estadisticas es = new Estadisticas(alumno.dt);
            es.Visible = true;
            this.WindowState = FormWindowState.Minimized;
           this.Enabled = false; */
            Grafica g = new Grafica(numeroDeFechasTotales);
            g.Visible = true; 
            this.WindowState = FormWindowState.Minimized;
            this.Enabled = false;
        }
      
        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            comboBox1.SelectedItem = dataGridView1.SelectedRows.ToString();          
            regEntradaAll.dt = regEntradaAll.dataTable();
            regEntradaAll.dt.DefaultView.RowFilter = $"Nombre='{comboBox1.Text}' "+
            "AND fecha IS NOT NULL";
            dataGridView1.DataSource = regEntradaAll.dt;
        }
        private void buttonEntradas_Click(object sender, EventArgs e)
        {
            mostrarAsistentes();
            estado = 1;
        }
        private void buttonSalidas_Click(object sender, EventArgs e)
        {
            mostrarFaltantes();
            estado = 2;
        }
        private void buttonAmbas_Click(object sender, EventArgs e)
        {
            mostrarAmbas();
            estado = 3;
        }
        private void buttonAllSalones_Click(object sender, EventArgs e)
        {
            estado = 0;
            mostrarAllFechas();
        }
        private void mostrarAsistentes() 
        {
            regEntrada.dt = regEntrada.dataTable();
            regEntrada.dt.DefaultView.RowFilter = $"fecha ='{today}' " +
            $"and grado='{comboBoxGradoGrupo.Text[0]}' " +
            $"and grupo='{comboBoxGradoGrupo.Text[1]}'";
            dataGridView1.DataSource = regEntrada.dt;
            comboBox1.DataSource = regEntrada.dt;
            this.comboBox1.DisplayMember = "Nombre";
            dataGridView1.Columns[0].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            dataGridView1.Columns[1].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            dataGridView1.Columns[2].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            dataGridView1.Columns[4].Visible = false;
            dataGridView1.Columns[5].Visible = false;
            dataGridView1.Columns[6].Visible = false;
        }
        private void mostrarFaltantes() 
        {
            regEntrada.dt = regEntrada.dataTable();
            regEntrada.dt.DefaultView.RowFilter = $"fecha IS NULL " +
            $"and grado='{comboBoxGradoGrupo.Text[0]}' " +
            $"and grupo='{comboBoxGradoGrupo.Text[1]}'";
            dataGridView1.DataSource = regEntrada.dt;
            comboBox1.DataSource = regEntrada.dt;
            this.comboBox1.DisplayMember = "Nombre";
            dataGridView1.Columns[0].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            dataGridView1.Columns[1].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            dataGridView1.Columns[2].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            dataGridView1.Columns[4].Visible = false;
            dataGridView1.Columns[5].Visible = false;
            dataGridView1.Columns[6].Visible = false;
        }
        private void mostrarAmbas() 
        {
            regEntrada.dt = regEntrada.dataTable();
            regEntrada.dt.DefaultView.RowFilter = $"grado='{comboBoxGradoGrupo.Text[0]}' " +
            $"and grupo='{comboBoxGradoGrupo.Text[1]}'";
            dataGridView1.DataSource = regEntrada.dt;
            comboBox1.DataSource = regEntrada.dt;
            this.comboBox1.DisplayMember = "Nombre";
            dataGridView1.Columns[0].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            dataGridView1.Columns[1].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            dataGridView1.Columns[2].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            dataGridView1.Columns[4].Visible = false;
            dataGridView1.Columns[5].Visible = false;
            dataGridView1.Columns[6].Visible = false;
        }
        private void mostrarAllFechas() 
        {
            regEntradaAll.dt = regEntradaAll.dataTable();
            regEntradaAll.dt.DefaultView.RowFilter = $"grado='{comboBoxGradoGrupo.Text[0]}' " +
            $"and grupo='{comboBoxGradoGrupo.Text[1]}' " +
            "and fecha IS NOT NULL";
            dataGridView1.DataSource = regEntradaAll.dt;
            comboBox1.DataSource = regEntrada.dt;
            this.comboBox1.DisplayMember = "Nombre";
            dataGridView1.Columns[0].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            dataGridView1.Columns[1].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            dataGridView1.Columns[2].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            dataGridView1.Columns[4].Visible = false;
            dataGridView1.Columns[5].Visible = false;
            dataGridView1.Columns[6].Visible = false;
        }
        private void comboBoxGradoGrupo_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (estado == 1)
                mostrarAsistentes();
            if (estado == 2)
                mostrarFaltantes();
            if (estado == 3)
                mostrarAllFechas();
        }
    }
}
