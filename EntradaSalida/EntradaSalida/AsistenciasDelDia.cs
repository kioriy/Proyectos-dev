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
        public AsistenciasDelDiaForm()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            comboBoxEstado.Items.Add("Asistentes");
            comboBoxEstado.Items.Add("Faltantes");
            comboBoxEstado.DropDownStyle = ComboBoxStyle.DropDownList;
            comboBoxGrado.DropDownStyle = ComboBoxStyle.DropDownList;
            comboBoxGrupo.DropDownStyle = ComboBoxStyle.DropDownList;
            Alumno alumno = new Alumno();
            alumno.select("select DISTINCT grado from ALUMNO", "ALUMNO");
            List<Alumno> listaAlumno = new List<Alumno>();
            listaAlumno = alumno.list<Alumno>();
            for (int x = 0; x < listaAlumno.Count; x++) 
            {
                comboBoxGrado.Items.Add(listaAlumno[x].grado + "º");
            }
            alumno = new Alumno();
            alumno.select("select DISTINCT grupo from ALUMNO", "ALUMNO");
            listaAlumno = new List<Alumno>();
            listaAlumno = alumno.list<Alumno>();
            for (int x = 0; x < listaAlumno.Count; x++)
            {
                comboBoxGrupo.Items.Add(listaAlumno[x].grupo);
            }
            comboBoxGrupo.SelectedIndex = 0;
            comboBoxEstado.SelectedIndex = 0;
            comboBoxGrado.SelectedIndex = 0;
            button1.Text = "consultar";
            dataGridView1.Visible = false;
        }



        private void button1_Click(object sender, EventArgs e)
        {
            string today = DateTime.Now.Date.ToShortDateString();
            //today = "06/12/2021";
            today += " ";
            string estado = comboBoxEstado.Text;
            string grado = comboBoxGrado.Text;
            string grupo = comboBoxGrupo.Text;
            dataGridView1.Visible = true;
            try
            {
                if (comboBoxEstado.Text == "Asistentes")
                {
                    Alumno alumno = new Alumno();
                    alumno.select("select * from ALUMNO where grado=\"" + grado + "\" and grupo=\"" + grupo + "\"", "ALUMNO");
                    List<Alumno> listaAlumno = new List<Alumno>();
                    listaAlumno = alumno.list<Alumno>();


                    RegEntradaSalida regentradasalida = new RegEntradaSalida();
                    regentradasalida.select("select * from Entradas_salidas where fecha =" + "\"" + today + "\"", "Entradas_salidas"); ;
                    List<RegEntradaSalida> listaEntradas = new List<RegEntradaSalida>();
                    listaEntradas = regentradasalida.list<RegEntradaSalida>();
                    List<Alumno> tempES = new List<Alumno>();
                   if(listaEntradas!=null)
                    for (int x = 0; x < listaAlumno.Count; x++)
                    {
                        for (int y = 0; y < listaEntradas.Count; y++)
                        {
                            if (listaEntradas[y].fk_id_alumnos == listaAlumno[x].id_alumnos)
                            {
                                tempES.Add(listaAlumno[x]);
                            }
                        }
                    }
                    dataGridView1.DataSource = tempES;
                 }
                else
                {
                    Alumno alumno = new Alumno();
                    alumno.select("select * from ALUMNO where grado=\"" + grado + "\" and grupo=\"" + grupo + "\"", "ALUMNO");
                    List<Alumno> listaAlumno = new List<Alumno>();
                    listaAlumno = alumno.list<Alumno>();

                    RegEntradaSalida regentradasalida = new RegEntradaSalida();
                    regentradasalida.select("select * from Entradas_salidas where fecha =" + "\"" + today + "\"", "Entradas_salidas"); ;
                    List<RegEntradaSalida> listaEntradas = new List<RegEntradaSalida>();
                    listaEntradas = regentradasalida.list<RegEntradaSalida>();
                    List<Alumno> tempES = new List<Alumno>();
                    if(listaEntradas!=null)
                    for (int x = 0; x < listaAlumno.Count; x++)
                    {
                        for (int y = 0; y < listaEntradas.Count; y++)
                        {
                            if (listaEntradas[y].fk_id_alumnos == listaAlumno[x].id_alumnos)
                            {
                                tempES.Add(listaAlumno[x]);
                            }
                        }
                    }
                    alumno = new Alumno();
                    alumno.select("select * from ALUMNO where grado=\"" + grado + "\" and grupo=\"" + grupo + "\"", "ALUMNO");
                    listaAlumno = new List<Alumno>();
                    listaAlumno = alumno.list<Alumno>();

                    for (int x = 0; x < listaAlumno.Count; x++)
                    {
                        int bandera = 0;
                        for (int y = 0; y < tempES.Count; y++)
                        {
                            if (listaAlumno[x].id_alumnos == tempES[y].id_alumnos)
                            {
                                bandera = 1;
                            }
                        }
                        if (bandera == 1)
                        {
                            listaAlumno.RemoveAt(x);
                            x--;
                        }
                    }
                    dataGridView1.DataSource = listaAlumno;
                }


            }
            catch (Exception ex ) { MessageBox.Show(ex.Message.ToString()); }
        }
    }
}
