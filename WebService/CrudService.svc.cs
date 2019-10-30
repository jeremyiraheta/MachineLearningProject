using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;
using System.Data.SqlClient;
using System.Data;
namespace WebService
{
    // NOTA: puede usar el comando "Rename" del menú "Refactorizar" para cambiar el nombre de clase "Service1" en el código, en svc y en el archivo de configuración.
    // NOTE: para iniciar el Cliente de prueba WCF para probar este servicio, seleccione Service1.svc o Service1.svc.cs en el Explorador de soluciones e inicie la depuración.
    public class CrudService : ICrudService
    {
        const string NOLOGIN = "Transaccion no valida no es usuario valido!";
        const string NOGRANT = "Transaccion no valida no tiene los privilegios correctos!";
        string conexion = "Data Source=localhost; Initial Catalog=UTEC;Integrated Security=true;";
        SqlDataAdapter adapter;
        public DataSet Select(string table, string where = "")
        {
            DataSet ds = new DataSet();
            adapter = new SqlDataAdapter(string.Concat("select * from ", table,(where != "") ? " where " + where : ""), conexion);            
            adapter.Fill(ds,table);
            return ds;
        }
        public DataSet View(VIEWS v, string where = "")
        {
            return Select(v.ToString(), where);
        }
        public void Update(LoginData login, string table, string set,string where = "")
        {
            if (!isValidUser(login.USER, login.PASS))
                throw new Exception(NOLOGIN);
            adapter = new SqlDataAdapter(string.Concat("update ", table, " ", set, (where != "") ? " where " + where : ""), conexion);            
            adapter.Fill(new DataSet());            
            adapter.Dispose();           
        }
        public void Delete(LoginData login, string table, string where = "")
        {
            if (!isValidUser(login.USER, login.PASS))
                throw new Exception(NOLOGIN);
            adapter = new SqlDataAdapter(string.Concat("delete from ", table, (where != "") ? " where " + where : ""), conexion);            
            adapter.Fill(new DataSet());            
            adapter.Dispose();
        }
        public void sp_AgregarRestaurante(LoginData login, string name, string reference, string img)
        {
            if (!isValidUser(login.USER, login.PASS))
                throw new Exception(NOLOGIN);
            adapter = new SqlDataAdapter("sp_AgregarRestaurante", conexion);
            adapter.SelectCommand.CommandType = System.Data.CommandType.StoredProcedure;
            adapter.SelectCommand.Parameters.Add(new SqlParameter("@user", login.USER));
            adapter.SelectCommand.Parameters.Add(new SqlParameter("@nombre", name));
            adapter.SelectCommand.Parameters.Add(new SqlParameter("@referencia", reference));
            if(img != "")
                adapter.SelectCommand.Parameters.Add(new SqlParameter("@image", img));
            adapter.Fill(new DataSet());            
            adapter.Dispose();
        }
        public void sp_AgregarUsuario(string id, string nombre, string apellido, string correo, string borndate, string pass, string img)
        {            
            adapter = new SqlDataAdapter("sp_AgregarUsuario", conexion);
            adapter.SelectCommand.CommandType = CommandType.StoredProcedure;
            adapter.SelectCommand.Parameters.Add(new SqlParameter("@id", id));
            adapter.SelectCommand.Parameters.Add(new SqlParameter("@nombre", nombre));
            adapter.SelectCommand.Parameters.Add(new SqlParameter("@apellido", apellido));
            adapter.SelectCommand.Parameters.Add(new SqlParameter("@correo", correo));
            adapter.SelectCommand.Parameters.Add(new SqlParameter("@borndate", borndate));
            adapter.SelectCommand.Parameters.Add(new SqlParameter("@pass", pass));
            if(img != "")
                adapter.SelectCommand.Parameters.Add(new SqlParameter("@image", img));
            adapter.Fill(new DataSet());
            adapter.Dispose();
            

        }
        public DataSet sp_ValidarUsuario(string iduser, string pass)
        {
            DataSet ds = new DataSet();
            adapter = new SqlDataAdapter("sp_ValidarUsuario", conexion);
            adapter.SelectCommand.CommandType = CommandType.StoredProcedure;
            adapter.SelectCommand.Parameters.Add(new SqlParameter("@iduser",iduser));
            adapter.SelectCommand.Parameters.Add(new SqlParameter("@pass", pass));
            adapter.Fill(ds);
            adapter.Dispose();
            return ds;
        }
        public bool isValidUser(string iduser, string pass)
        {
            DataSet ds = sp_ValidarUsuario(iduser, pass);
            if (ds.Tables[0].Rows[0].ItemArray.Length == 1)
                return false;
            else
                return true;
        }
        public bool existUserName(string user)
        {
            DataSet ds = Select("USUARIOS", "id_usuario='" + user + "'");
            if (ds.Tables[0].Rows.Count == 0)
                return false;
            else
                return true;
        }
        public bool isAdmin(string user)
        {
            DataSet ds = View(VIEWS.vUsuarios, "id_usuario='" + user + "' and admin=1");
            if (ds.Tables[0].Rows.Count == 0)
                return false;
            else
                return true;
        }
        public int sp_AgregarImagen(LoginData login, string url)
        {
            if (!isValidUser(login.USER, login.PASS))
                throw new Exception(NOLOGIN);
            int r = 0;
            SqlConnection c = new SqlConnection(conexion);
            SqlCommand cmd = new SqlCommand("sp_AgregarImagen", c);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add(new SqlParameter("@url", url));
            c.Open();
            r = Convert.ToInt32(cmd.ExecuteScalar());
            c.Close();            
            return r;            
        }
        public void sp_AgregarPlatillo(LoginData login, string nombre, float precio, string descripcion, int tipo, int restaurante, string img)
        {
            if (!isValidUser(login.USER, login.PASS))
                throw new Exception(NOLOGIN);
            adapter = new SqlDataAdapter("sp_AgregarPlatillo", conexion);
            adapter.SelectCommand.CommandType = CommandType.StoredProcedure;
            adapter.SelectCommand.Parameters.Add(new SqlParameter("@user", login.USER));
            adapter.SelectCommand.Parameters.Add(new SqlParameter("@nombre", nombre));
            adapter.SelectCommand.Parameters.Add(new SqlParameter("@precio", precio));
            adapter.SelectCommand.Parameters.Add(new SqlParameter("@descripcion", descripcion));
            adapter.SelectCommand.Parameters.Add(new SqlParameter("@tipo", tipo));
            adapter.SelectCommand.Parameters.Add(new SqlParameter("@restaurante", restaurante));
            if(img != "")
                adapter.SelectCommand.Parameters.Add(new SqlParameter("@image", img));
            adapter.Fill(new DataSet());            
            adapter.Dispose();
        }

        public List<Restaurantes> GetRestaurantes(int id=-1)
        {
            DataSet dsALL = (id == -1) ? View(VIEWS.vRestaurantes) : View(VIEWS.vRestaurantes, "ID_RESTAURANTES=" + id);
            List<Restaurantes> r = new List<Restaurantes>();
            foreach (DataRow row in dsALL.Tables[0].Rows)
            {
                Restaurantes nr = new Restaurantes();
                nr.ID = Convert.ToString(row[0]);
                nr.NOMBRE = Convert.ToString(row[3]);
                nr.REFERENCIA = Convert.ToString(row[4]);
                nr.RATE = Convert.ToString(row[5]);
                nr.URL = Convert.ToString(row[6]);
                nr.X = Convert.ToInt32(row[7]);
                nr.Y = Convert.ToInt32(row[8]);
                r.Add(nr);
            }
            return r;
        }
        public List<Usuarios> GetUsuarios(string id=null)
        {
            DataSet dsAll = (id == null) ? View(VIEWS.vUsuarios,id) : View(VIEWS.vUsuarios, "ID_USUARIO='" + id + "'");
            List<Usuarios> r = new List<Usuarios>();
            foreach(DataRow row in dsAll.Tables[0].Rows)
            {
                Usuarios nu = new Usuarios();
                nu.ID_USUARIO = Convert.ToString(row["ID_USUARIO"]);
                nu.ADMIN = Convert.ToBoolean(row["ADMIN"]);
                nu.APELLIDO = Convert.ToString(row["APELLIDO"]);
                nu.URL = Convert.ToString(row["URL"]);
                nu.CORREO_ELECTRONICO = Convert.ToString(row["CORREO_ELECTRONICO"]);
                nu.VISITAS = Convert.ToInt32(row["VISITAS"]);
                nu.NOMBRE = Convert.ToString(row["NOMBRE"]);
                nu.FECHA_CUMPLE = Convert.ToString(row["FECHA_CUMPLE"]);
                r.Add(nu);
            }
            return r;
        }        
        public List<Platillos> GetPlatillos(int id=-1)
        {
            DataSet dsAll = (id == -1) ? View(VIEWS.vPlatillos) : View(VIEWS.vPlatillos, "ID_PLATILLOS" + id);
            List<Platillos> r = new List<Platillos>();
            foreach(DataRow row in dsAll.Tables[0].Rows)
            {
                Platillos np = new Platillos();
                np.DESCRIPCION = Convert.ToString(row["DESCRIPCION"]);
                np.ID_PLATILLOS = Convert.ToInt32(row["ID_PLATILLOS"]);
                np.ID_RESTAURANTES = Convert.ToInt32(row["ID_RESTAURANTES"]);
                np.ID_TIPO = Convert.ToInt32(row["ID_TIPO"]);
                np.NOMBRE = Convert.ToString(row["NOMBRE"]);
                np.PRECIO = Convert.ToDecimal(row["PRECIO"]);
                np.RATE = Convert.ToDecimal(row["RATE"]);
                np.URL = Convert.ToString(row["URL"]);
                r.Add(np);
            }
            return r;
        }
        public List<Comentarios> GetComentarios(int id_platillo)
        {
            DataSet dsAll = View(VIEWS.vComentario, "ID_PLATILLOS=" + id_platillo);
            List<Comentarios> r = new List<Comentarios>();
            foreach(DataRow row in dsAll.Tables[0].Rows)
            {
                Comentarios nc = new Comentarios();
                nc.COMENTARIOS = Convert.ToString(row["COMENTARIOS"]);
                nc.ID_COMENTARIOS = Convert.ToInt32(row["ID_COMENTARIOS"]);
                nc.ID_PLATILLOS = Convert.ToInt32(row["ID_PLATILLOS"]);
                nc.ID_USUARIO = Convert.ToInt32(row["ID_USUARIO"]);
                nc.URL = Convert.ToString(row["URL"]);
                r.Add(nc);
            }
            return r;
        }
        public List<string> GetTiposPlatillo()
        {
            DataSet dsAll = Select("TIPOPLATILLO");
            List<string> r = new List<string>();
            foreach(DataRow row in dsAll.Tables[0].Rows)
            {
                r.Add(Convert.ToString(row[1]));
            }
            return r;
        }
        public void sp_AgregarPunto(LoginData login, int x, int y, int restaurante)
        {
            if (!isValidUser(login.USER, login.PASS))
                throw new Exception(NOLOGIN);
            adapter = new SqlDataAdapter("sp_AgregarPunto", conexion);
            adapter.SelectCommand.CommandType = CommandType.StoredProcedure;
            adapter.SelectCommand.Parameters.Add(new SqlParameter("@x", x));
            adapter.SelectCommand.Parameters.Add(new SqlParameter("@y", y));
            adapter.SelectCommand.Parameters.Add(new SqlParameter("@restaurante", restaurante));
            adapter.Fill(new DataSet());
            adapter.Dispose();
            
        }
        public void sp_AgregarEstadistica(LoginData login)
        {
            if (!isValidUser(login.USER, login.PASS))
                throw new Exception(NOLOGIN);
            adapter = new SqlDataAdapter("sp_AgregarEstadistica", conexion);
            adapter.SelectCommand.CommandType = CommandType.StoredProcedure;
            adapter.SelectCommand.Parameters.Add(new SqlParameter("@iduser", login.USER));
            adapter.Fill(new DataSet());
            adapter.Dispose();
        }
        public void sp_AgregarComentario(LoginData login, string idplatillo, string comentario)
        {
            if (!isValidUser(login.USER, login.PASS))
                throw new Exception(NOLOGIN);
            adapter = new SqlDataAdapter("sp_AgregarComentario", conexion);
            adapter.SelectCommand.CommandType = CommandType.StoredProcedure;
            adapter.SelectCommand.Parameters.Add(new SqlParameter("@iduser", login.USER));
            adapter.SelectCommand.Parameters.Add(new SqlParameter("@idplatillo", idplatillo));
            adapter.SelectCommand.Parameters.Add(new SqlParameter("@comentario", comentario));
            adapter.Fill(new DataSet());
            adapter.Dispose();
        }
        public void sp_AgregarValoracion(LoginData login, string idplatillo, float rate)
        {
            if (!isValidUser(login.USER, login.PASS))
                throw new Exception(NOLOGIN);
            adapter = new SqlDataAdapter("sp_AgregarValoracion", conexion);
            adapter.SelectCommand.CommandType = CommandType.StoredProcedure;
            adapter.SelectCommand.Parameters.Add(new SqlParameter("@iduser", login.USER));
            adapter.SelectCommand.Parameters.Add(new SqlParameter("@idplatillo", idplatillo));
            adapter.SelectCommand.Parameters.Add(new SqlParameter("@rate", rate));
            adapter.Fill(new DataSet());
            adapter.Dispose();
        }
        public void sp_AgregarLog(LoginData login, string obj, string table, string cls)
        {
            if (!isValidUser(login.USER, login.PASS))
                throw new Exception(NOLOGIN);
            adapter = new SqlDataAdapter("sp_AgregarLog", conexion);
            adapter.SelectCommand.CommandType = CommandType.StoredProcedure;
            adapter.SelectCommand.Parameters.Add(new SqlParameter("@iduser", login.USER));
            adapter.SelectCommand.Parameters.Add(new SqlParameter("@object", obj));
            adapter.SelectCommand.Parameters.Add(new SqlParameter("@table", table));
            adapter.SelectCommand.Parameters.Add(new SqlParameter("@class", cls));
            adapter.Fill(new DataSet());
            adapter.Dispose();
        }
        public void sp_Delete(LoginData login, DeleteType Tipo, int id)
        {
            if (!isValidUser(login.USER, login.PASS))
                throw new Exception(NOLOGIN);
            char t;
            switch(Tipo)
            {
                case DeleteType.Comentario:
                    t = 'C';
                    break;
                case DeleteType.Platillo:
                    t = 'P';
                    break;
                case DeleteType.Restaurante:
                    t = 'R';
                    break;
                default:
                    throw new Exception("Tipo no valido");                    
            }

            adapter = new SqlDataAdapter("sp_Delete", conexion);
            adapter.SelectCommand.CommandType = CommandType.StoredProcedure;
            adapter.SelectCommand.Parameters.Add(new SqlParameter("@tipo", t));
            adapter.SelectCommand.Parameters.Add(new SqlParameter("@id", id));
            adapter.SelectCommand.Parameters.Add(new SqlParameter("@user", login.USER));
            adapter.Fill(new DataSet());
            adapter.Dispose();
        }
        public void sp_AlterRestaurant(LoginData login, int id, int img, int point, string nombre, string referencia)
        {
            if (!isValidUser(login.USER, login.PASS))
                throw new Exception(NOLOGIN);
            adapter = new SqlDataAdapter("sp_AlterRestaurant", conexion);
            adapter.SelectCommand.CommandType = CommandType.StoredProcedure;
            adapter.SelectCommand.Parameters.Add(new SqlParameter("@id", id));
            adapter.SelectCommand.Parameters.Add(new SqlParameter("@user", login.USER));
            adapter.SelectCommand.Parameters.Add(new SqlParameter("@image", img));
            adapter.SelectCommand.Parameters.Add(new SqlParameter("@point", point));
            adapter.SelectCommand.Parameters.Add(new SqlParameter("@nombre", nombre));
            adapter.SelectCommand.Parameters.Add(new SqlParameter("@referencia", referencia));
            adapter.Fill(new DataSet());
            adapter.Dispose();
        }
        public void sp_AlterPlatillo(LoginData login, int id, int restaurant, int img, int tipo, string nombre, float precio, string descripcion)
        {
            if (!isValidUser(login.USER, login.PASS))
                throw new Exception(NOLOGIN);
            adapter = new SqlDataAdapter("sp_AlterPlatillo", conexion);
            adapter.SelectCommand.CommandType = CommandType.StoredProcedure;
            adapter.SelectCommand.Parameters.Add(new SqlParameter("@id", id));
            adapter.SelectCommand.Parameters.Add(new SqlParameter("@user", login.USER));
            adapter.SelectCommand.Parameters.Add(new SqlParameter("@tipo", tipo));
            adapter.SelectCommand.Parameters.Add(new SqlParameter("@precio", precio));
            adapter.SelectCommand.Parameters.Add(new SqlParameter("@nombre", nombre));
            adapter.SelectCommand.Parameters.Add(new SqlParameter("@descripcion", descripcion));
            adapter.Fill(new DataSet());
            adapter.Dispose();
        }
        public void sp_AlterComentario(LoginData login, int id, string comentario)
        {
            if (!isValidUser(login.USER, login.PASS))
                throw new Exception(NOLOGIN);
            adapter = new SqlDataAdapter("sp_AlterComentario", conexion);
            adapter.SelectCommand.CommandType = CommandType.StoredProcedure;
            adapter.SelectCommand.Parameters.Add(new SqlParameter("@id", id));
            adapter.SelectCommand.Parameters.Add(new SqlParameter("@user", login.USER));
            adapter.SelectCommand.Parameters.Add(new SqlParameter("@comentario", comentario));
            adapter.Fill(new DataSet());
            adapter.Dispose();
        }
        public void sp_AlterUsuario(LoginData login,string image, string nombre, string apellido, string correo, string birth, bool admin, string password=null)
        {
            if (!isValidUser(login.USER, login.PASS))
                throw new Exception(NOLOGIN);
            adapter = new SqlDataAdapter("sp_AlterUsuario", conexion);
            adapter.SelectCommand.CommandType = CommandType.StoredProcedure;
            adapter.SelectCommand.Parameters.Add(new SqlParameter("@iduser", login.USER));
            if(password != null)
                adapter.SelectCommand.Parameters.Add(new SqlParameter("@password", password));
            else
                adapter.SelectCommand.Parameters.Add(new SqlParameter("@password", login.PASS));
            adapter.SelectCommand.Parameters.Add(new SqlParameter("@image", image));
            adapter.SelectCommand.Parameters.Add(new SqlParameter("@nombre", nombre));
            adapter.SelectCommand.Parameters.Add(new SqlParameter("@apellido", apellido));
            adapter.SelectCommand.Parameters.Add(new SqlParameter("@correo", correo));
            adapter.SelectCommand.Parameters.Add(new SqlParameter("@birth", birth));
            adapter.SelectCommand.Parameters.Add(new SqlParameter("@admin", admin));
            adapter.Fill(new DataSet());
            adapter.Dispose();
        }
    }
}
