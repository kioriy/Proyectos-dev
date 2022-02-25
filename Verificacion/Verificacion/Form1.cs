using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Microsoft.TeamFoundation.WorkItemTracking.Client.Wiql;
using Newtonsoft.Json;
using System.Threading;

namespace Verificacion
{
    public partial class Form1 : Form
    {
        private string pathWindows = "C:/Users/alber/Documents/Proyectos/Dropbox-Uploader/";
        private string pathRasp = "/home/pi/Dropbox-Uploader/";
        public Form1()
        {
            InitializeComponent();
        }
        public void serial(Dictionary<string, string> dic)
        {
            int os = (int)Environment.OSVersion.Platform;
            string path = "";
            if ((os != 4) && (os != 128))
                path = pathWindows+"JSON/Log.json";
            else
                path = pathRasp+"JSON/Log.json";
            string document = "";
            List<Dictionary<string, string>> lal = new List<Dictionary<string, string>>();

            try
            {
                using (StreamReader jsonStream = File.OpenText(path))
                {
                    document = jsonStream.ReadToEnd();
                }
                lal = JsonConvert.DeserializeObject<List<Dictionary<string, string>>>(document);
            }
            catch (Exception ex) {
                int x = 0;
            }
            if(lal==null)
                lal = new List<Dictionary<string, string>>();
            lal.Add(dic);
            string json = JsonConvert.SerializeObject(lal, Formatting.Indented);//este se agrega
            System.IO.File.WriteAllText(path, json);

            ExecuteJson("uploadLog.sh");
        }
        public void serialAlumos()
        {
            Alumno al = new Alumno();
            bool res= al.select("select * from Alumno ","Alumno");
            List<Alumno> list = new List<Alumno>();
            if(res)
            list = al.list<Alumno>();
            int os = (int)Environment.OSVersion.Platform;
            string path = "";
            if ((os != 4) && (os != 128))
                path = pathWindows+"JSON/ALUMNO.json";
            else
                 path = pathRasp+"JSON/ALUMNO.json";
           
            string json = JsonConvert.SerializeObject(list, Formatting.Indented);//este se agrega
            System.IO.File.WriteAllText(path, json);

           
        }

        public  bool ExecuteJson(string nombreSH) 
            {
                try
                {
                    int os = (int)Environment.OSVersion.Platform;

                    if ((os != 4) && (os != 128))
                    {
                    string app = $"{pathWindows}{nombreSH}";
                    ProcessStartInfo info = new ProcessStartInfo(app);
                    Process.Start(info);
                }
                    else
                    {
                        string app = $"{pathRasp}{nombreSH}";
                        ProcessStartInfo info = new ProcessStartInfo(app);
                        Process.Start(info);
                    }
                }
                catch (Exception w)
                {
                    MessageBox.Show($"{w}");
                }
            return true;
        }
     

        private async void DeserealizarJsonAlumno() {
            string path;
            List<Alumno> list = new List<Alumno>();
           ExecuteJson("downloadAlumno.sh");
            int os = (int)Environment.OSVersion.Platform;
            if ((os != 4) && (os != 128))
                path = $"{pathWindows}JSON/ALUMNO.json";
            else
            {
                path = $"{pathRasp}JSON/ALUMNO.json";
            }
            bool sleep = false;

            Task.Run(async () =>
            {
                while (System.IO.File.Exists(path) == false)
                {
                    if (sleep == true)
                    {
                        break;
                    }
                }
            });
            await Task.Run(async () =>
            {
                System.Threading.Thread.Sleep(20000);
                if (System.IO.File.Exists(path) == false)
                { 
                    sleep = true;
                    MessageBox.Show("error al descargar el archivo"); 
                }
            });
            if(sleep)
                return;
            string document = "";
            
                string res="";
                foreach (string line in System.IO.File.ReadLines(path))
                {
                    res += line;
                }
            if (res == "SUCCES")
            {
                return;
            }

            try
            {
                using (StreamReader jsonStream = File.OpenText(path))
                {
                    document = jsonStream.ReadToEnd();
                }
                list = JsonConvert.DeserializeObject<List<Alumno>>(document);
            }
            catch (Exception ex) {
                MessageBox.Show($"{ex.ToString()}");
            }
            selectVerificacionAll(list);
        }

        private  void selectVerificacionAll(List<Alumno> list) {
            List<Alumno> list2 = new List<Alumno>();
            string query = "SELECT id_alumnos from Alumno as A where id_alumnos=";
            if (list == null)
                return;
            for (int x = 0; x < list.Count; x++) {
                if (x == 0)
                    query += list[x].id_alumnos.ToString();
                else
                    query += $" or id_alumnos={list[x].id_alumnos.ToString()}";
            }
            Alumno al = new Alumno();
            bool res=( al.select(query, "Alumno"));
            list2 = al.list<Alumno>();
           // MessageBox.Show(query);
            insertarALumnos(res, list,list2);
        }
        private void insertarALumnos(bool res,List<Alumno>list, List<Alumno> list2) {
           
            if (res == false) {
                string path = "";
                Alumno al = new Alumno();
                if (list.Count > 0)
                {
                    al.multiInsert(list);
                    ExecuteJson("rm_ALUMNO.sh");
                    int os = (int)Environment.OSVersion.Platform;
                    if ((os != 4) && (os != 128))
                        path = $"{pathWindows}JSON/ALUMNO.json";
                    else
                    {
                        path = $"{pathRasp}JSON/ALUMNO.json";
                    }
                    File.WriteAllText(path, "SUCCES");
                }
            }
            else {
                foreach (var alumno in list2)
                {
                    list.RemoveAll(x => x.id_alumnos== alumno.id_alumnos);
                }
                insertarALumnos(false,list,list2) ;
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
           /* Alumno al = new Alumno();
            al.select("SELECT * from ALUMNO", "ALUMNO");
            List<Alumno> list = new List<Alumno>();
            list = al.list<Alumno>();
            foreach (var item in list)
            {
                MessageBox.Show(item.nombre_alumno);
            }*/
            DeserealizarJsonAlumno();
        }
        

        private void button1_Click_1(object sender, EventArgs e)
        {
            Dictionary<string, string> dic = new Dictionary<string, string>();
            dic.Add(textBox1.Text, logStatus.RegistroNoEncontrado.ToString());
            serial(dic);
        }

        private void Form1_Load(object sender, EventArgs e)
        {
           
        }
    }
}