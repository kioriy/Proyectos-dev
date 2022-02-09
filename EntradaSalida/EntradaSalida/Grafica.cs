﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;

namespace EntradaSalida
{
    public partial class Grafica : Form
    {
        private Alumno alumno = new Alumno();
        private RegEntradaSalida ES = new RegEntradaSalida();
        DataTable grados= new DataTable();
        private decimal fechasTotales;
        private List<decimal> allProcentajes = new List<decimal>();
        public Grafica(decimal fechasN)
        {
            InitializeComponent();
           /* dataGridView1.Visible = false;
            dataGridView1.Enabled = false;*/
            fechasTotales = fechasN;
            alumno.select("select DISTINCT  grado || grupo as \"grado y grupo\" from AULAS", "AULAS");
            grados = alumno.dataTable();
            alumno.select("select " +
               "nombre_alumno, " +
                "grado, " +
                "grupo, " +
                "Fecha " +
                "from ALUMNO AS A " +
                "INNER JOIN Entradas_salidas AS ES " +
                "ON A.id_alumnos = ES.fk_id_alumnos " +
                "INNER JOIN AULAS AS AU " +
                "ON " +
                "A.fk_id_aula = AU.id_aula ","ALUMNO");
        }
        private void Grafica_Load(object sender, EventArgs e)
        {
            PorcentajeAllAlumnos();
             CrearStatus();
            calcularNumeroDeFaltas();
        }
        private void PorcentajeAllAlumnos()
        {
            RegEntradaSalida reg = new RegEntradaSalida();
            Alumno alumno = new Alumno();
            alumno.select("Select * " +
                      "from ALUMNO AS A " +
                      "INNER JOIN AULAS AS AU " +
                      "on a.fk_id_aula = AU.id_aula", "ALUMNO");
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
            decimal res = 0;
            for (int x = 0; x < grados.Rows.Count; x++)
            {
                res = 0;
                string r=grados.Rows[x][0].ToString();
                reg.dt = reg.dataTable();
                reg.dt.DefaultView.RowFilter = $"grado= '{r[0]}' and grupo='{r[1]}'";
                dataGridView1.DataSource = reg.dt;
                NumFechas = dataGridView1.Rows.Count;
                alumno.dt = alumno.dataTable();
                alumno.dt.DefaultView.RowFilter = $"grado= '{r[0]}' and grupo='{r[1]}'";
                dataGridView1.DataSource = alumno.dt;
                NumAlumnos = dataGridView1.Rows.Count;
                res = fechasTotales * NumAlumnos;
                res = (100 / res);
                res = res * NumFechas;
                allProcentajes.Add( decimal.Round(res, 2));
            }
            chart1.Series.Clear();
            chart1.Palette = System.Windows.Forms.DataVisualization.Charting.ChartColorPalette.Excel;
            chart1.Titles.Add("Aulas");
            Series series;
            for (int x = 0; x < grados.Rows.Count; x++)
            {
                series = chart1.Series.Add(grados.Rows[x][0].ToString()+": "+allProcentajes[x].ToString());
                series.Points.AddXY("Aulas",double.Parse(allProcentajes[x].ToString()));
            }
        }

        private void CrearStatus()
        {
            List<string> listStatus = new List<string>();
            Dictionary<decimal, int> dic = new Dictionary<decimal, int>();
            dic.Add(100,0);
            dic.Add(90, 0);
            dic.Add(80, 1);
            dic.Add(70, 2);
            dic.Add(60, 3);
            for (int x = 0; x < grados.Rows.Count; x++) {
                decimal res;
                res = decimal.Round((allProcentajes[x] / 10), 0) * 10;
                res = allProcentajes[x] < 60 ? 60 : res;
                res = dic[res];
                switch (res) {
                    case 0:
                        listStatus.Add("excelente");
                        break;
                    case 1:
                        listStatus.Add("regular");
                        break;
                    case 2:
                        listStatus.Add("irregular");
                        break;
                    case 3:
                        listStatus.Add("pesimo");
                        break;
                }
            }
        }

        private void calcularNumeroDeFaltas() {
            Alumno al = new Alumno();
            al.select("SELECT "+
                      "(grado || ' ' || grupo) as \"grado y grupo\", count(\"grado y grupo\") as retardo " +
                      "FROM ALUMNO " +
                      "INNER JOIN " +
                      "Entradas_salidas ON " +
                      "id_alumnos = fk_id_alumnos " +
                      "INNER JOIN " +
                      "AULAS on " +
                      "id_aula = fk_id_aula " +
                      "WHERE hora_entrada > \"08:11\" and hora_entrada <= \"23:15\" " +
                      "GROUP BY \"grado y grupo\"","ALUMNO");
            al.dt = al.dataTable();
            dataGridView1.DataSource = alumno.dt;
            
        }

        
    }
}
