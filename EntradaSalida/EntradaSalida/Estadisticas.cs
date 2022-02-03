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
        private DataTable dt= new DataTable();
        private List<Label> Ll = new List<Label>();
        private List<Alumno> listaAlumnos = new List<Alumno>();
        private int totalDeDias = 0;
        public Estadisticas(DataTable dat)
        {
            InitializeComponent();
            dataGridView1.Visible = false;
            dt = dat;
            // 5, 10
            Label l = new Label();
            int leftL = 5;
            int topL = 30;
           for (int x = 0; x < dt.Rows.Count; x++) {
                l = new Label();
                l.Text = dt.Rows[x]["grado y grupo"].ToString();
                if (x % 6==0 && x!=0 )
                {
                    leftL += 100;
                    topL = 30;
                }
                l.Left = leftL;
                l.Top = topL;
                Ll.Add(l);
                panel1.Controls.Add(Ll[x]);
                topL += 40;
            }
        }

        private void Estadisticas_Load(object sender, EventArgs e)
        {
            string today = DateTime.Now.Date.ToShortDateString();
            today = "06/12/2021";//quitar
            calcularEntradasDelDia(today);
            calcularEntradasDelAno();
            PorcentajeAllAlumnos();
        }
        private void  calcularEntradasDelDia(string today) {

            ////calcular porcentaje de entradas del dia 
          
            double entradasDeHoy = 0, totalDeAlumnos = 0;
            Alumno alumno = new Alumno();
            alumno.select("select id_alumnos from ALUMNO", "ALUMNO");
           
            listaAlumnos = alumno.list<Alumno>();
            RegEntradaSalida entradasalida = new RegEntradaSalida();
            entradasalida.select($"select * from Entradas_salidas where Fecha =\"{today}\"", "Entradas_salidas");
            List<RegEntradaSalida> listaEntradasSalidas = new List<RegEntradaSalida>();
            listaEntradasSalidas = entradasalida.list<RegEntradaSalida>();
            totalDeAlumnos = listaAlumnos.Count;
            if (listaEntradasSalidas != null)
                entradasDeHoy = listaEntradasSalidas.Count;
            else
                entradasDeHoy = 0;
            totalDeAlumnos = (100 / totalDeAlumnos);
            entradasDeHoy = entradasDeHoy * totalDeAlumnos;
            labelAsistenciaToday.Text = (Math.Round(entradasDeHoy, 2)).ToString() + " %";
            ////end
        }
        private void calcularEntradasDelAno() {
            ///calcular el porcentaje de entradas del año
            int totalDeRegistros;
            double Multiporcentaje=0,totalDeAlumnos=0;
            RegEntradaSalida entradasalida = new RegEntradaSalida();
            List<RegEntradaSalida> listaEntradasSalidas = new List<RegEntradaSalida>();
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
        private void PorcentajeAllAlumnos() {
            RegEntradaSalida reg = new RegEntradaSalida();
            Alumno alumno = new Alumno();

            alumno.select("Select * " +
                      "from ALUMNO AS A " +
                      "INNER JOIN AULAS AS AU " +
                      "on a.fk_id_aula = AU.id_aula","ALUMNO");
            reg.select("Select " +
                          "grado, " +
                          "grupo, " +
                          "fk_id_alumnos, " +
                          "id_alumnos, " +
                          "Fecha " +
                      "from ALUMNO AS A " +
                      "INNER JOIN Entradas_salidas AS ES " +
                      "ON ES.fk_id_alumnos = A.id_alumnos " +
                      "INNER JOIN AULAS AS AU " +
                      "on a.fk_id_aula = AU.id_aula ", "ALUMNO");
          
            int NumFechas = 0;
            int NumAlumnos;
            double res = 0;
            string mayor="", menor="";
            double mayorNum=0, menorNum=101;
            for (int x = 0; x < Ll.Count; x++) {
                res = 0;
                reg.dt = reg.dataTable();
                reg.dt.DefaultView.RowFilter = $"grado= '{Ll[x].Text[0]}' and grupo='{Ll[x].Text[1]}'";
                dataGridView1.DataSource = reg.dt;
                NumFechas = dataGridView1.Rows.Count;
                alumno.dt = alumno.dataTable();
                alumno.dt.DefaultView.RowFilter = $"grado= '{Ll[x].Text[0]}' and grupo='{Ll[x].Text[1]}'";
                dataGridView1.DataSource = alumno.dt;
                NumAlumnos = dataGridView1.Rows.Count;
                res = totalDeDias * NumAlumnos;
                res = (100 / res );
                res = res * NumFechas;
                string ress =  decimal.Round(((decimal)res),2).ToString();
                if (mayorNum <=res) {
                    mayor = Ll[x].Text;
                    mayorNum = res;
                }
                if (menorNum>= res)
                {
                    menor = Ll[x].Text;
                    menorNum = res;
                }
                Ll[x].Text +=": "+ress+" %.";
            }
            labelGoodAsistencia.Text = mayor;
            labelBadAsistencia.Text = menor;
        }

        private void labelAsistenciaToday_Click(object sender, EventArgs e)
        {

        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

      
    }
}
