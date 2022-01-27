///*SELECT ES.id_entrada_salida, A.nombre_alumno, ES.Fecha FROM Entradas_salidas AS ES INNER JOIN ALUMNO AS A ON ES.fk_id_alumnos=A.id_alumnos WHERE Fecha ="06/12/2021 " */
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

        private void Estadisticas_Load(object sender, EventArgs e)
        {
          /* Alumno alumno = new Alumno();
            alumno.select("select * from ALUMNO", "ALUMNO");
            List<Alumno> listaAlumnos = new List<Alumno>();
            listaAlumnos = alumno.list<Alumno>();
            RegEntradaSalida entradasalida = new RegEntradaSalida();
            entradasalida.select("select * from Entradas_salidas", "Entradas_salidas");
            List<RegEntradaSalida> listaEntradasSalidas = new List<RegEntradaSalida>();
            listaEntradasSalidas = entradasalida.list<RegEntradaSalida>();
            List<RegEntradaSalida> busqueda = new List<RegEntradaSalida>();
            busqueda = listaEntradasSalidas.FindAll(item =>item.fk_id_alumnos == 1);*/

            
            ////calcular porcentaje de entradas del dia 
             string today = DateTime.Now.Date.ToShortDateString();
            today = "06/12/2021";//quitar
            double entradasDeHoy=0,totalDeAlumnos=0;
            Alumno alumno = new Alumno();
            alumno.select("select * from ALUMNO","ALUMNO");
            List<Alumno> listaAlumnos = new List<Alumno>();
            listaAlumnos = alumno.list<Alumno>();
            RegEntradaSalida entradasalida = new RegEntradaSalida();
            entradasalida.select("select * from Entradas_salidas where Fecha =\""+today+" \"","Entradas_salidas");
            List<RegEntradaSalida> listaEntradasSalidas = new List<RegEntradaSalida>();
            listaEntradasSalidas = entradasalida.list<RegEntradaSalida>();
            totalDeAlumnos = listaAlumnos.Count;
            if (listaEntradasSalidas != null)
                entradasDeHoy = listaEntradasSalidas.Count;
            else
                entradasDeHoy = 0;
            totalDeAlumnos = (100 / totalDeAlumnos);
            entradasDeHoy = entradasDeHoy * totalDeAlumnos;
            labelAsistenciaToday.Text = (Math.Round(entradasDeHoy,2)).ToString() + " %";
            ////end
            ///calcular el porcentaje de entradas del año
            int totalDeDias = 0,totalDeRegistros;
            double Multiporcentaje;
            entradasalida.select("select DISTINCT Fecha from Entradas_salidas", "Entradas_salidas"); ;
            listaEntradasSalidas = new List<RegEntradaSalida>();
            listaEntradasSalidas = entradasalida.list<RegEntradaSalida>();
            totalDeDias = listaEntradasSalidas.Count;
            totalDeAlumnos = listaAlumnos.Count;
            Multiporcentaje = 100 / (totalDeAlumnos * totalDeDias);
            entradasalida.select("select * from Entradas_salidas", "Entradas_salidas"); 
            listaEntradasSalidas = new List<RegEntradaSalida>();
            listaEntradasSalidas = entradasalida.list<RegEntradaSalida>();
            totalDeRegistros = listaEntradasSalidas.Count;
            Multiporcentaje = Multiporcentaje * totalDeRegistros;
            labelAsistenciaYear.Text = (Math.Round(Multiporcentaje, 2)).ToString() + " %";
            







        }

        private void labelAsistenciaToday_Click(object sender, EventArgs e)
        {

        }
    }
}
