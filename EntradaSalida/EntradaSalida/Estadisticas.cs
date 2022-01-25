using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace EntradaSalida
{
    public partial class Estadisticas : Form
    {
        public Estadisticas()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            comboBox1.Items.Add("Asistentes");
            comboBox1.Items.Add("Faltantes");
            comboBox1.DropDownStyle = ComboBoxStyle.DropDownList;
            comboBox2.Items.Add("llenar con consulta");
            comboBox2.DropDownStyle = ComboBoxStyle.DropDownList;
            comboBox1.SelectedIndex = 0;
            comboBox2.SelectedIndex = 0;
            button1.Text = "consultar";
            dataGridView1.Visible = false;
        }



        private void button1_Click(object sender, EventArgs e)
        {
            dataGridView1.Visible = true;
            
            Alumno alumno = new Alumno();
            alumno.select("select * from ALUMNO","ALUMNO");
            List<Alumno> lista = new List<Alumno>();
            lista = alumno.list<Alumno>();
            alumno.llenarDgv(dataGridView1,"select * from ALUMNO ","ALUMNO");
            alumno.attributes("ALUMNO");
           
            



            // db.llenarDgv(dataGridView1, "SELECT ", "ALUMNO");
        }

      
    }
}
