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
        public Form1()
        {
            InitializeComponent();
        }
        public static void serial(Dictionary<string, string> dic)
        {
            int os = (int)Environment.OSVersion.Platform;
            string path = "";
            if ((os != 4) && (os != 128))
                 path = "C://Users/alber/OneDrive/Escritorio/Log.json";
            else
                 path = "/home/pi/Desktop/Log.json";
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
            catch (Exception ex) { }


            lal.Add(dic);
            string json = JsonConvert.SerializeObject(lal, Formatting.Indented);//este se agrega
            System.IO.File.WriteAllText(path, json);

            SubirJson("uploadLog.sh");
        }
        public static void serialAlumos()
        {
            Alumno al = new Alumno();
            bool res= al.select("select * from Alumno ","Alumno");
            List<Alumno> list = new List<Alumno>();
            if(res)
            list = al.list<Alumno>();
            int os = (int)Environment.OSVersion.Platform;
            string path = "";
            if ((os != 4) && (os != 128))
                path = "C://Users/alber/OneDrive/Escritorio/ALUMNO.json";
            else
                 path = "home/pi/Desktop/ALUMNO.json";
           
            string json = JsonConvert.SerializeObject(list, Formatting.Indented);//este se agrega
            System.IO.File.WriteAllText(path, json);

           
        }

        public static bool SubirJson(string nombreSH) 
            {
                try
                {
                    int os = (int)Environment.OSVersion.Platform;

                    if ((os != 4) && (os != 128))
                    {
                    string app = $"C://Users/alber/OneDrive/Escritorio/{nombreSH}";
                    ProcessStartInfo info = new ProcessStartInfo(app);
                    Process.Start(info);
                }
                    else
                    {
                        string app = $"/home/pi/Desktop/{nombreSH}";
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
        private  void BajarJson(string nombreSh)
        {
            try
            {
                int os = (int)Environment.OSVersion.Platform;

                if ((os != 4) && (os != 128))
                {
                    string app = $"c://Users/alber/OneDrive/Escritorio/{nombreSh}";
                    ProcessStartInfo info = new ProcessStartInfo(app);
                    Process.Start(info);
                }
                else
                {
                    string app = $"/home/pi/Desktop/{nombreSh}";
                    ProcessStartInfo info = new ProcessStartInfo(app);
                    Process.Start(info);
                }
            }
            catch (Exception w)
            {
                MessageBox.Show($"{w}");
            }
        }

        private async void DeserealizarJsonAlumno() {
            string path;
            List<Alumno> list = new List<Alumno>();
            BajarJson("downloadAlumno.sh");
            int os = (int)Environment.OSVersion.Platform;
            if ((os != 4) && (os != 128))
                path = "c://Users/alber/OneDrive/Escritorio/ALUMNO.json";/////////////////////////////////////////////////////////borrar
            else
                path = "/home/pi/Desktop/ALUMNO.json";
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

        private static void selectVerificacionAll(List<Alumno> list) {
            List<Alumno> list2 = new List<Alumno>();
            string query = "SELECT id_alumnos from Alumno as A where id_alumnos=";
            for (int x = 0; x < list.Count; x++) {
                if (x == 0)
                    query += list[x].id_alumnos.ToString();
                else
                    query += $" or id_alumnos={list[x].id_alumnos.ToString()}";
            }
            Alumno al = new Alumno();
            bool res=( al.select(query, "Alumno"));
            list2 = al.list<Alumno>();
            insertarALumnos(res, list,list2);
        }
        private static void insertarALumnos(bool res,List<Alumno>list, List<Alumno> list2) {
           
            if (res == false) {
                Alumno al = new Alumno();
                if(list.Count>0)
                al.multiInsert(list);
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