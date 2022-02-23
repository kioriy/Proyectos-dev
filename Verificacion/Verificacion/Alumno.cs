using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Verificacion
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
        public string telefonos { get; set; }
        public string apellido_alumno { get; set; }
        public string tutor { get; set; }
        public string tipo_sangre { get; set; }
        public string fecha { get; set; }
        public string nivel_estudios { get; set; }
        public string numero_lista { get; set; }
        public string domicilio { get; set; }
        public string codigo { get; set; }
        public int fk_id_aula { get; set; }
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
        public string valuesMultiInsert(List<Alumno> alumnos) {
            string valuesInsert="";
            foreach (var alumno in alumnos)
            {
                valuesInsert += $"({alumno.values()}),";
            }
           // valuesInsert += "(\"37666\",\"\",\"\",\"\",\"3\",\"\",\"\",\"\",\"\",\"\",\"\",\"1\"),";
            return valuesInsert.Trim(',') ;
        }
        public void multiInsert(List<Alumno> alumnos)
        {
            execute(table, valuesMultiInsert(alumnos), dbAction.multiInsert.ToString(),"");
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
            if (codigo == null)
                codigo = "";
            if (nombre_alumno == null)
                nombre_alumno = "";
            if (apellido_alumno == null)
                apellido_alumno = "";
            if (numero_lista == null)
                numero_lista = "";
            if (nivel_estudios == null)
                nivel_estudios = "";
            if (CURP == null)
                CURP = "";
            if (tutor == null)
                tutor = "";
            if (telefonos == null)
                telefonos = "";
            if (domicilio == null)
                domicilio = "";
            if (tipo_sangre == null)
                tipo_sangre = "";
            return
            $"\"{id_alumnos}\"," +
            $"\"{codigo.ToUpper().Trim()}\"," +
            $"\"{nombre_alumno.ToUpper().Trim()}\"," +
            $"\"{apellido_alumno.ToUpper().Trim()}\"," +
            $"\"{numero_lista.ToUpper().Trim()}\"," +
            $"\"{nivel_estudios.ToUpper().Trim()}\"," +
            $"\"{CURP.ToUpper().Trim()}\","+
            $"\"{tutor.ToUpper().Trim()}\"," +
            $"\"{telefonos.ToUpper().Trim()}\"," +
            $"\"{domicilio.ToUpper().Trim()}\"," +
            $"\"{tipo_sangre.ToUpper().Trim()}\"," +
            $"\"{fk_id_aula}\"";

        }
        public string valuesString()
        {
            return
            "nombre_alumno, " +
            "apellido_alumno, " +
            "grado, " +
            "grupo, " +
            "tutor, " +
            "telefonos, " +
            "tipo_sangre, " +
            "nivel_estudios, " +
            "numero_lista, " +
            "domicilio, " + 
            "codigo, "+
            "fk_id_aula, "+
            "CURP";
        }
        #endregion
    }
}