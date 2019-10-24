﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;
using System.Data.SqlClient;
using System.Data;
namespace RESTService
{
    // NOTA: puede usar el comando "Rename" del menú "Refactorizar" para cambiar el nombre de clase "Service1" en el código, en svc y en el archivo de configuración.
    // NOTE: para iniciar el Cliente de prueba WCF para probar este servicio, seleccione Service1.svc o Service1.svc.cs en el Explorador de soluciones e inicie la depuración.
    public class Service1 : IService1
    {
        const string NOLOGIN = "Transaccion no valida no es usuario valido!";
        const string NOGRANT = "Transaccion no valida no tiene los privilegios correctos!";
        string conexion = "Data Source=localhost; Initial Catalog=UTEC;Integrated Security=true;";
        SqlDataAdapter adapter;
        public DataSet Select(string table, string where = "")
        {
            DataSet ds = new DataSet();
            adapter = new SqlDataAdapter(string.Concat("select * from ", table,(where != "") ? " where " + where : ""), conexion);
            adapter.SelectCommand.CommandType = CommandType.TableDirect;
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
            adapter.SelectCommand.CommandType = CommandType.TableDirect;
            adapter.Fill(new DataSet());
            sp_AgregarLog(login, adapter.SelectCommand.CommandText);
            adapter.Dispose();           
        }
        public void Delete(LoginData login, string table, string where = "")
        {
            if (!isValidUser(login.USER, login.PASS))
                throw new Exception(NOLOGIN);
            adapter = new SqlDataAdapter(string.Concat("delete from ", table, (where != "") ? " where " + where : ""), conexion);
            adapter.SelectCommand.CommandType = CommandType.TableDirect;
            adapter.Fill(new DataSet());
            sp_AgregarLog(login, adapter.SelectCommand.CommandText);
            adapter.Dispose();
        }
        public void sp_AgregarRestaurante(LoginData login, string name, string reference, string img)
        {
            if (!isValidUser(login.USER, login.PASS))
                throw new Exception(NOLOGIN);
            adapter = new SqlDataAdapter("sp_AgregarRestaurante", conexion);
            adapter.SelectCommand.CommandType = System.Data.CommandType.StoredProcedure;
            adapter.SelectCommand.Parameters.Add(new SqlParameter("@nombre", name));
            adapter.SelectCommand.Parameters.Add(new SqlParameter("@referencia", reference));
            if(img != "")
                adapter.SelectCommand.Parameters.Add(new SqlParameter("@image", img));
            adapter.Fill(new DataSet());
            sp_AgregarLog(login, adapter.SelectCommand.CommandText);
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
            DataSet ds = Select("USUARIOS", "id_usuario");
            if (ds.Tables.Count == 0)
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
            sp_AgregarLog(login, adapter.SelectCommand.CommandText);
            return r;            
        }
        public void sp_AgregarPlatillo(LoginData login, string nombre, float precio, string descripcion, int tipo, int restaurante, string img)
        {
            if (!isValidUser(login.USER, login.PASS))
                throw new Exception(NOLOGIN);
            adapter = new SqlDataAdapter("sp_AgregarPlatillo", conexion);
            adapter.SelectCommand.CommandType = CommandType.StoredProcedure;
            adapter.SelectCommand.Parameters.Add(new SqlParameter("@nombre", nombre));
            adapter.SelectCommand.Parameters.Add(new SqlParameter("@precio", precio));
            adapter.SelectCommand.Parameters.Add(new SqlParameter("@descripcion", descripcion));
            adapter.SelectCommand.Parameters.Add(new SqlParameter("@tipo", tipo));
            adapter.SelectCommand.Parameters.Add(new SqlParameter("@restaurante", restaurante));
            if(img != "")
                adapter.SelectCommand.Parameters.Add(new SqlParameter("@image", img));
            adapter.Fill(new DataSet());
            sp_AgregarLog(login, adapter.SelectCommand.CommandText);
            adapter.Dispose();
        }

        public List<Restaurantes> GetRestaurantes()
        {
            DataSet dsALL = View(VIEWS.vRestaurantes);
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
        public void sp_AgregarLog(LoginData login, string query)
        {
            if (!isValidUser(login.USER, login.PASS))
                throw new Exception(NOLOGIN);
            adapter = new SqlDataAdapter("sp_AgregarLog", conexion);
            adapter.SelectCommand.CommandType = CommandType.StoredProcedure;
            adapter.SelectCommand.Parameters.Add(new SqlParameter("@iduser", login.USER));
            adapter.SelectCommand.Parameters.Add(new SqlParameter("@query", query));
            adapter.Fill(new DataSet());
            adapter.Dispose();
        }
    }
}
