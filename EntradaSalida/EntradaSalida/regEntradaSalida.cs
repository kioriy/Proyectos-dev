using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace EntradaSalida
{
    class RegEntradaSalida : DB
    {
        #region atributos
        //public List<Producto> listaIdProducto;
        public int id_entrada_salida { get; set; }
        public string fecha { get; set; }
        public string hora_entrada { get; set; }
        public string esta_dentro { get; set; }
        public string hora_salida { get; set; }
        public int fk_id_alumnos { get; set; }
        public string table { get; set; }

        public List<Alumno> list_alumno = new List<Alumno>();
        #endregion

        #region constructores
        public RegEntradaSalida()
        {
            table = "Entradas_salidas";
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

        public void query(string valuesString, string where)
        {
            execute(table, $"{valuesString}", "query", where);
        }

        public void free(string query)
        {
            execute(table, "", "free", query);
        }

        public int idCliente(string nombre)
        {
            if (nombre == "")
            {
                nombre = "PUBLICO EN GENERAL";
            }

            return list<Alumno>().Find(x => x.nombre_alumno == nombre).id_alumnos;//bd.llenarDgv(dgv, query.buscarProducto(rfc), tabla);
        }

        #endregion

        #region METODOS INTERFACE
        public void loadComboBox(ComboBox cb, ref bool entra)
        {
            execute(table, "", "query", "");

            cb.DataSource = null;

            list_alumno = list<Alumno>();

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
                
            }*/
        }

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
            $"\"{id_entrada_salida}\"," +
            $"\"{fecha.ToUpper().Trim()}\"," +
            $"\"{hora_entrada.ToUpper().Trim()}\"," +
            $"\"{esta_dentro.ToUpper().Trim()}\"," +
            $"\"{hora_salida.ToUpper().Trim()}\"," +
            $"\"{fk_id_alumnos}\"";


        }
        #endregion
    }
}