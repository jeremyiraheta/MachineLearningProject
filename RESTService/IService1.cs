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
        [WebGet(UriTemplate = "Restaurantes", ResponseFormat = WebMessageFormat.Json, RequestFormat = WebMessageFormat.Json)]
        List<Restaurantes> GetRestaurantes();
        [OperationContract]
        void sp_AgregarRestaurante(string name, string reference, string img);
        [OperationContract]
        void sp_AgregarUsuario(string id, string nombre, string apellido, string correo, string borndate, string pass, string img);
        [OperationContract]
        DataSet sp_ValidarUsuario(string iduser, string pass);
        [OperationContract]
        int sp_AgregarImagen(string url);
        [OperationContract]
        void sp_AgregarPlatillo(string nombre, float precio, string descripcion, int tipo, int restaurante, string img);
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
}
