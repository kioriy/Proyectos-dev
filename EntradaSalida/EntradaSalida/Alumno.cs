using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace EntradaSalida
{
    class Alumno : DB
    {
        #region atributos
        //public List<Producto> listaIdProducto;
        public int id_alumnos { get; set; }
        public string nombre_alumno { get; set; }
        public string direccion { get; set; }
        public string grado { get; set; }
        public string grupo { get; set; }
        public string CURP { get; set; }
        public string telefono { get; set; }
        public string apellido_alumno{ get; set; }
        public string tutor { get; set; }
        public string telefono_2 { get; set; }
        public string tipo_sangre { get; set; }
        public string fecha { get; set; }
        public string nivel_estudios { get; set; }
        public int numero_lista { get; set; }
        public string domicilio { get; set; }
        //private string respuesta = "";

        public string table { get; set; }

        public List<Alumno> list_alumno = new List<Alumno>();
        #endregion

        #region constructores
        public Alumno()
        {
            table = "ALUMNO";
        }
        #endregion

        #region metodos


        public void insert()
        {
            execute(table, values(), "insert", "");
        }

        public void update(string where)
        {
            execute(table, values(), "update", where);
        }

        public void query(string where)
        {
            execute(table, valuesString(), "query", where);
        }

        public void free(string query)
        {
            execute(table, "", "free", query);
        }

      /*/*  public int idCliente(string nombre)
        {
            if (nombre == "")
            {
                nombre = "PUBLICO EN GENERAL";
            }

            return list<Alumno>().Find(x => x.nombre_alumno == nombre).id_alumnos;//bd.llenarDgv(dgv, query.buscarProducto(rfc), tabla);
        }

        #endregion

        #region METODOS INTERFACE
        /*public void loadComboBox(ComboBox cb, ref bool entra)
        {
            execute(table, "", "query", "");

            cb.DataSource = null;

            list_alumno= list<Alumno>();

            entra = false;
            cb.DataSource = list_alumno;
            cb.DisplayMember = "nombre";//"descripcion_codigo";
            cb.ValueMember = "id_cliente";//"descripcion_codigo";

            cb.SelectedIndex = -1;
            //cb.Text = "";
            entra = true;
            /*cb.Items.Clear();

            query("1", $"{WHERE} ?");

            //deserializeJson();

            //cb.DataSource = user_list.Select(user => user.nombre).ToList();

            //cb.SelectedIndex = -1;
            try
            {
                foreach (var cliente in list<Cliente>())
                {
                    cb.Items.Add(cliente.nombre);
                }
            }
            catch (Exception)
            {
                
            }
        }*/

        //public void loadDgv(DataGridView dgv)
        //{
        //    dgv.Rows.Clear();

        //    query("1", $"{WHERE} ?");

        //    deserializeJson();

        //    /*cb.DataSource = user_list.Select(user => user.nombre).ToList();

        //    cb.SelectedIndex = -1;*/

        //    foreach (var cliente in list<Cliente>())
        //    {
        //        dgv.Rows.Add();
        //    }
        //}
        #endregion

        #region VALUES
        public string values()
        {
            return
            $"\"{id_alumnos}\"," +
            $"\"{nombre_alumno.ToUpper().Trim()}\"," +
            $"\"{apellido_alumno.ToUpper().Trim()}\"," +
            $"\"{grado.ToUpper().Trim()}\"," +
            $"\"{grupo.ToUpper().Trim()}\"," +
            $"\"{tutor.ToUpper().Trim()}\"," +
            $"\"{telefono.ToUpper().Trim()}\"," +
            $"\"{telefono_2.ToUpper().Trim()}\"," +
            $"\"{tipo_sangre.ToUpper().Trim()}\"," +
            $"\"{nivel_estudios.ToUpper().Trim()}\","+
            $"\"{fecha.ToUpper().Trim()}\"," +
            $"\"{numero_lista}\"," +
            $"\"{domicilio.ToUpper().Trim()}\"," +
            $"\"{CURP.ToUpper().Trim()}\"";
            
        }
        public string valuesString()
        {
            return
            "id_alumnos, " +
            "nombre_alumno, " +
            "apellido_alumno, " +
            "grado, " +
            "grupo, " +
            "tutor, " +
            "telefono, "+
            "telefono_2. " +
            "tipo_sangre, " +
            "nivel_estudios, " +
                "numero_lista, " +
            "domicilio, " +
            "CURP";
        }
        #endregion
    }
}