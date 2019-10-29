using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;
using System.Data;
namespace RESTService
{
    // NOTA: puede usar el comando "Rename" del menú "Refactorizar" para cambiar el nombre de interfaz "IService1" en el código y en el archivo de configuración a la vez.
    [ServiceContract]
    public interface IService1
    {                
        bool existUserName(string user);
        [OperationContract]
        bool isAdmin(string user);
        [OperationContract]
        List<Restaurantes> GetRestaurantes(int id = -1);
        [OperationContract]
        List<Usuarios> GetUsuarios(string id = null);
        [OperationContract]
        List<Platillos> GetPlatillos(int id = -1);
        [OperationContract]
        List<Comentarios> GetComentarios(int id_platillo);
        [OperationContract]
        void sp_AgregarRestaurante(LoginData login, string name, string reference, string img);
        [OperationContract]
        void sp_AgregarUsuario(string id, string nombre, string apellido, string correo, string borndate, string pass, string img);
        [OperationContract]
        DataSet sp_ValidarUsuario(string iduser, string pass);
        [OperationContract]
        int sp_AgregarImagen(LoginData login, string url);
        [OperationContract]
        void sp_AgregarPlatillo(LoginData login, string nombre, float precio, string descripcion, int tipo, int restaurante, string img);
        [OperationContract]
        void sp_AgregarPunto(LoginData login, int x, int y, int restaurante);
        [OperationContract]
        void sp_AgregarEstadistica(LoginData login);
        [OperationContract]
        void sp_AgregarComentario(LoginData login, string idplatillo, string comentario);
        [OperationContract]
        void sp_AgregarValoracion(LoginData login, string idplatillo, float rate);
        [OperationContract]
        void sp_AgregarLog(LoginData login, string query);
    }
    [DataContract]
    public class LoginData
    {
        [DataMember]
        public string USER { get; set;}
        [DataMember]
        public string PASS { get; set; }
        [DataMember]
        public bool isAdmin { get; set; }       
    }
    [DataContract]
    public class Restaurantes
    {
        [DataMember]
        public string ID { get; set; }
        [DataMember]
        public string URL { get; set; }
        [DataMember]
        public string NOMBRE { get; set; }
        [DataMember]
        public string REFERENCIA { get; set; }
        [DataMember]
        public string RATE { get; set; }
        [DataMember]
        public int X { get; set; }
        [DataMember]
        public int Y { get; set; }
    }
    [DataContract]
    public class Usuarios
    {
        [DataMember]
        public string ID_USUARIO;
        [DataMember]
        public string NOMBRE;
        [DataMember]
        public string APELLIDO;
        [DataMember]
        public string CORREO_ELECTRONICO;
        [DataMember]
        public string FECHA_CUMPLE;
        [DataMember]
        public bool ADMIN;
        [DataMember]
        public string URL;
        [DataMember]
        public int VISITAS;
    }
    [DataContract]
    public class Platillos
    {
        [DataMember]
        public int ID_PLATILLOS;
        [DataMember]
        public int ID_RESTAURANTES;
        [DataMember]
        public int ID_TIPO;
        [DataMember]
        public string NOMBRE;
        [DataMember]
        public decimal RATE;
        [DataMember]
        public decimal PRECIO;
        [DataMember]
        public string DESCRIPCION;
        [DataMember]
        public string URL;
    }
    [DataContract]
    public class Comentarios
    {
        [DataMember]
        public int ID_COMENTARIOS;
        [DataMember]
        public int ID_USUARIO;
        [DataMember]
        public int ID_PLATILLOS;
        [DataMember]
        public string COMENTARIOS;
        [DataMember]
        public string URL;        
    }
    [DataContract]
    public enum VIEWS
    {
        vComentario,
        vPlatillos,
        vRestaurantes,
        vUsuarios
    }
}
