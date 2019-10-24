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

        [OperationContract]
        DataSet Select(string table, string where = "");
        [OperationContract]
        DataSet View(VIEWS v, string where = "");
        [OperationContract]
        void Update(LoginData login, string table, string set, string where = "");
        [OperationContract]
        void Delete(LoginData login, string table, string where = "");
        [OperationContract]
        bool existUserName(string user);
        [OperationContract]
        [WebGet(UriTemplate = "Restaurantes", ResponseFormat = WebMessageFormat.Json, RequestFormat = WebMessageFormat.Json)]
        List<Restaurantes> GetRestaurantes();
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
    public enum VIEWS
    {
        vComentario,
        vPlatillos,
        vRestaurantes,
        vUsuarios
    }
}
