﻿//------------------------------------------------------------------------------
// <auto-generated>
//     Este código fue generado por una herramienta.
//     Versión de runtime:4.0.30319.42000
//
//     Los cambios en este archivo podrían causar un comportamiento incorrecto y se perderán si
//     se vuelve a generar el código.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Prototipo.SQLTrans {
    using System.Runtime.Serialization;
    using System;
    
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Runtime.Serialization", "4.0.0.0")]
    [System.Runtime.Serialization.DataContractAttribute(Name="LoginData", Namespace="http://schemas.datacontract.org/2004/07/RESTService")]
    [System.SerializableAttribute()]
    public partial class LoginData : object, System.Runtime.Serialization.IExtensibleDataObject, System.ComponentModel.INotifyPropertyChanged {
        
        [System.NonSerializedAttribute()]
        private System.Runtime.Serialization.ExtensionDataObject extensionDataField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private string PASSField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private string USERField;
        
        [global::System.ComponentModel.BrowsableAttribute(false)]
        public System.Runtime.Serialization.ExtensionDataObject ExtensionData {
            get {
                return this.extensionDataField;
            }
            set {
                this.extensionDataField = value;
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public string PASS {
            get {
                return this.PASSField;
            }
            set {
                if ((object.ReferenceEquals(this.PASSField, value) != true)) {
                    this.PASSField = value;
                    this.RaisePropertyChanged("PASS");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public string USER {
            get {
                return this.USERField;
            }
            set {
                if ((object.ReferenceEquals(this.USERField, value) != true)) {
                    this.USERField = value;
                    this.RaisePropertyChanged("USER");
                }
            }
        }
        
        public event System.ComponentModel.PropertyChangedEventHandler PropertyChanged;
        
        protected void RaisePropertyChanged(string propertyName) {
            System.ComponentModel.PropertyChangedEventHandler propertyChanged = this.PropertyChanged;
            if ((propertyChanged != null)) {
                propertyChanged(this, new System.ComponentModel.PropertyChangedEventArgs(propertyName));
            }
        }
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Runtime.Serialization", "4.0.0.0")]
    [System.Runtime.Serialization.DataContractAttribute(Name="Restaurantes", Namespace="http://schemas.datacontract.org/2004/07/RESTService")]
    [System.SerializableAttribute()]
    public partial class Restaurantes : object, System.Runtime.Serialization.IExtensibleDataObject, System.ComponentModel.INotifyPropertyChanged {
        
        [System.NonSerializedAttribute()]
        private System.Runtime.Serialization.ExtensionDataObject extensionDataField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private string IDField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private string NOMBREField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private string RATEField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private string REFERENCIAField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private string URLField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private int XField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private int YField;
        
        [global::System.ComponentModel.BrowsableAttribute(false)]
        public System.Runtime.Serialization.ExtensionDataObject ExtensionData {
            get {
                return this.extensionDataField;
            }
            set {
                this.extensionDataField = value;
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public string ID {
            get {
                return this.IDField;
            }
            set {
                if ((object.ReferenceEquals(this.IDField, value) != true)) {
                    this.IDField = value;
                    this.RaisePropertyChanged("ID");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public string NOMBRE {
            get {
                return this.NOMBREField;
            }
            set {
                if ((object.ReferenceEquals(this.NOMBREField, value) != true)) {
                    this.NOMBREField = value;
                    this.RaisePropertyChanged("NOMBRE");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public string RATE {
            get {
                return this.RATEField;
            }
            set {
                if ((object.ReferenceEquals(this.RATEField, value) != true)) {
                    this.RATEField = value;
                    this.RaisePropertyChanged("RATE");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public string REFERENCIA {
            get {
                return this.REFERENCIAField;
            }
            set {
                if ((object.ReferenceEquals(this.REFERENCIAField, value) != true)) {
                    this.REFERENCIAField = value;
                    this.RaisePropertyChanged("REFERENCIA");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public string URL {
            get {
                return this.URLField;
            }
            set {
                if ((object.ReferenceEquals(this.URLField, value) != true)) {
                    this.URLField = value;
                    this.RaisePropertyChanged("URL");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public int X {
            get {
                return this.XField;
            }
            set {
                if ((this.XField.Equals(value) != true)) {
                    this.XField = value;
                    this.RaisePropertyChanged("X");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public int Y {
            get {
                return this.YField;
            }
            set {
                if ((this.YField.Equals(value) != true)) {
                    this.YField = value;
                    this.RaisePropertyChanged("Y");
                }
            }
        }
        
        public event System.ComponentModel.PropertyChangedEventHandler PropertyChanged;
        
        protected void RaisePropertyChanged(string propertyName) {
            System.ComponentModel.PropertyChangedEventHandler propertyChanged = this.PropertyChanged;
            if ((propertyChanged != null)) {
                propertyChanged(this, new System.ComponentModel.PropertyChangedEventArgs(propertyName));
            }
        }
    }
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    [System.ServiceModel.ServiceContractAttribute(ConfigurationName="SQLTrans.IService1")]
    public interface IService1 {
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IService1/Select", ReplyAction="http://tempuri.org/IService1/SelectResponse")]
        System.Data.DataSet Select(string table, string where);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IService1/Select", ReplyAction="http://tempuri.org/IService1/SelectResponse")]
        System.Threading.Tasks.Task<System.Data.DataSet> SelectAsync(string table, string where);
        
        // CODEGEN: Se está generando un contrato de mensaje, ya que el nombre de elemento v del espacio de nombres http://tempuri.org/ no está marcado para aceptar valores nil.
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IService1/View", ReplyAction="http://tempuri.org/IService1/ViewResponse")]
        Prototipo.SQLTrans.ViewResponse View(Prototipo.SQLTrans.ViewRequest request);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IService1/View", ReplyAction="http://tempuri.org/IService1/ViewResponse")]
        System.Threading.Tasks.Task<Prototipo.SQLTrans.ViewResponse> ViewAsync(Prototipo.SQLTrans.ViewRequest request);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IService1/Update", ReplyAction="http://tempuri.org/IService1/UpdateResponse")]
        void Update(Prototipo.SQLTrans.LoginData login, string table, string set, string where);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IService1/Update", ReplyAction="http://tempuri.org/IService1/UpdateResponse")]
        System.Threading.Tasks.Task UpdateAsync(Prototipo.SQLTrans.LoginData login, string table, string set, string where);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IService1/Delete", ReplyAction="http://tempuri.org/IService1/DeleteResponse")]
        void Delete(Prototipo.SQLTrans.LoginData login, string table, string where);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IService1/Delete", ReplyAction="http://tempuri.org/IService1/DeleteResponse")]
        System.Threading.Tasks.Task DeleteAsync(Prototipo.SQLTrans.LoginData login, string table, string where);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IService1/existUserName", ReplyAction="http://tempuri.org/IService1/existUserNameResponse")]
        bool existUserName(string user);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IService1/existUserName", ReplyAction="http://tempuri.org/IService1/existUserNameResponse")]
        System.Threading.Tasks.Task<bool> existUserNameAsync(string user);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IService1/GetRestaurantes", ReplyAction="http://tempuri.org/IService1/GetRestaurantesResponse")]
        Prototipo.SQLTrans.Restaurantes[] GetRestaurantes();
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IService1/GetRestaurantes", ReplyAction="http://tempuri.org/IService1/GetRestaurantesResponse")]
        System.Threading.Tasks.Task<Prototipo.SQLTrans.Restaurantes[]> GetRestaurantesAsync();
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IService1/sp_AgregarRestaurante", ReplyAction="http://tempuri.org/IService1/sp_AgregarRestauranteResponse")]
        void sp_AgregarRestaurante(Prototipo.SQLTrans.LoginData login, string name, string reference, string img);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IService1/sp_AgregarRestaurante", ReplyAction="http://tempuri.org/IService1/sp_AgregarRestauranteResponse")]
        System.Threading.Tasks.Task sp_AgregarRestauranteAsync(Prototipo.SQLTrans.LoginData login, string name, string reference, string img);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IService1/sp_AgregarUsuario", ReplyAction="http://tempuri.org/IService1/sp_AgregarUsuarioResponse")]
        void sp_AgregarUsuario(string id, string nombre, string apellido, string correo, string borndate, string pass, string img);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IService1/sp_AgregarUsuario", ReplyAction="http://tempuri.org/IService1/sp_AgregarUsuarioResponse")]
        System.Threading.Tasks.Task sp_AgregarUsuarioAsync(string id, string nombre, string apellido, string correo, string borndate, string pass, string img);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IService1/sp_ValidarUsuario", ReplyAction="http://tempuri.org/IService1/sp_ValidarUsuarioResponse")]
        System.Data.DataSet sp_ValidarUsuario(string iduser, string pass);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IService1/sp_ValidarUsuario", ReplyAction="http://tempuri.org/IService1/sp_ValidarUsuarioResponse")]
        System.Threading.Tasks.Task<System.Data.DataSet> sp_ValidarUsuarioAsync(string iduser, string pass);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IService1/sp_AgregarImagen", ReplyAction="http://tempuri.org/IService1/sp_AgregarImagenResponse")]
        int sp_AgregarImagen(Prototipo.SQLTrans.LoginData login, string url);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IService1/sp_AgregarImagen", ReplyAction="http://tempuri.org/IService1/sp_AgregarImagenResponse")]
        System.Threading.Tasks.Task<int> sp_AgregarImagenAsync(Prototipo.SQLTrans.LoginData login, string url);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IService1/sp_AgregarPlatillo", ReplyAction="http://tempuri.org/IService1/sp_AgregarPlatilloResponse")]
        void sp_AgregarPlatillo(Prototipo.SQLTrans.LoginData login, string nombre, float precio, string descripcion, int tipo, int restaurante, string img);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IService1/sp_AgregarPlatillo", ReplyAction="http://tempuri.org/IService1/sp_AgregarPlatilloResponse")]
        System.Threading.Tasks.Task sp_AgregarPlatilloAsync(Prototipo.SQLTrans.LoginData login, string nombre, float precio, string descripcion, int tipo, int restaurante, string img);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IService1/sp_AgregarPunto", ReplyAction="http://tempuri.org/IService1/sp_AgregarPuntoResponse")]
        void sp_AgregarPunto(Prototipo.SQLTrans.LoginData login, int x, int y, int restaurante);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IService1/sp_AgregarPunto", ReplyAction="http://tempuri.org/IService1/sp_AgregarPuntoResponse")]
        System.Threading.Tasks.Task sp_AgregarPuntoAsync(Prototipo.SQLTrans.LoginData login, int x, int y, int restaurante);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IService1/sp_AgregarEstadistica", ReplyAction="http://tempuri.org/IService1/sp_AgregarEstadisticaResponse")]
        void sp_AgregarEstadistica(Prototipo.SQLTrans.LoginData login);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IService1/sp_AgregarEstadistica", ReplyAction="http://tempuri.org/IService1/sp_AgregarEstadisticaResponse")]
        System.Threading.Tasks.Task sp_AgregarEstadisticaAsync(Prototipo.SQLTrans.LoginData login);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IService1/sp_AgregarComentario", ReplyAction="http://tempuri.org/IService1/sp_AgregarComentarioResponse")]
        void sp_AgregarComentario(Prototipo.SQLTrans.LoginData login, string idplatillo, string comentario);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IService1/sp_AgregarComentario", ReplyAction="http://tempuri.org/IService1/sp_AgregarComentarioResponse")]
        System.Threading.Tasks.Task sp_AgregarComentarioAsync(Prototipo.SQLTrans.LoginData login, string idplatillo, string comentario);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IService1/sp_AgregarValoracion", ReplyAction="http://tempuri.org/IService1/sp_AgregarValoracionResponse")]
        void sp_AgregarValoracion(Prototipo.SQLTrans.LoginData login, string idplatillo, float rate);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IService1/sp_AgregarValoracion", ReplyAction="http://tempuri.org/IService1/sp_AgregarValoracionResponse")]
        System.Threading.Tasks.Task sp_AgregarValoracionAsync(Prototipo.SQLTrans.LoginData login, string idplatillo, float rate);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IService1/sp_AgregarLog", ReplyAction="http://tempuri.org/IService1/sp_AgregarLogResponse")]
        void sp_AgregarLog(Prototipo.SQLTrans.LoginData login, string query);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IService1/sp_AgregarLog", ReplyAction="http://tempuri.org/IService1/sp_AgregarLogResponse")]
        System.Threading.Tasks.Task sp_AgregarLogAsync(Prototipo.SQLTrans.LoginData login, string query);
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
    [System.ServiceModel.MessageContractAttribute(IsWrapped=false)]
    public partial class ViewRequest {
        
        [System.ServiceModel.MessageBodyMemberAttribute(Name="View", Namespace="http://tempuri.org/", Order=0)]
        public Prototipo.SQLTrans.ViewRequestBody Body;
        
        public ViewRequest() {
        }
        
        public ViewRequest(Prototipo.SQLTrans.ViewRequestBody Body) {
            this.Body = Body;
        }
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
    [System.Runtime.Serialization.DataContractAttribute(Namespace="http://tempuri.org/")]
    public partial class ViewRequestBody {
        
        [System.Runtime.Serialization.DataMemberAttribute(EmitDefaultValue=false, Order=0)]
        public string v;
        
        [System.Runtime.Serialization.DataMemberAttribute(Order=1)]
        public string where;
        
        public ViewRequestBody() {
        }
        
        public ViewRequestBody(string v, string where) {
            this.v = v;
            this.where = where;
        }
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
    [System.ServiceModel.MessageContractAttribute(IsWrapped=false)]
    public partial class ViewResponse {
        
        [System.ServiceModel.MessageBodyMemberAttribute(Name="ViewResponse", Namespace="http://tempuri.org/", Order=0)]
        public Prototipo.SQLTrans.ViewResponseBody Body;
        
        public ViewResponse() {
        }
        
        public ViewResponse(Prototipo.SQLTrans.ViewResponseBody Body) {
            this.Body = Body;
        }
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
    [System.Runtime.Serialization.DataContractAttribute(Namespace="http://tempuri.org/")]
    public partial class ViewResponseBody {
        
        [System.Runtime.Serialization.DataMemberAttribute(Order=0)]
        public System.Data.DataSet ViewResult;
        
        public ViewResponseBody() {
        }
        
        public ViewResponseBody(System.Data.DataSet ViewResult) {
            this.ViewResult = ViewResult;
        }
    }
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public interface IService1Channel : Prototipo.SQLTrans.IService1, System.ServiceModel.IClientChannel {
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public partial class Service1Client : System.ServiceModel.ClientBase<Prototipo.SQLTrans.IService1>, Prototipo.SQLTrans.IService1 {
        
        public Service1Client() {
        }
        
        public Service1Client(string endpointConfigurationName) : 
                base(endpointConfigurationName) {
        }
        
        public Service1Client(string endpointConfigurationName, string remoteAddress) : 
                base(endpointConfigurationName, remoteAddress) {
        }
        
        public Service1Client(string endpointConfigurationName, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(endpointConfigurationName, remoteAddress) {
        }
        
        public Service1Client(System.ServiceModel.Channels.Binding binding, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(binding, remoteAddress) {
        }
        
        public System.Data.DataSet Select(string table, string where) {
            return base.Channel.Select(table, where);
        }
        
        public System.Threading.Tasks.Task<System.Data.DataSet> SelectAsync(string table, string where) {
            return base.Channel.SelectAsync(table, where);
        }
        
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
        Prototipo.SQLTrans.ViewResponse Prototipo.SQLTrans.IService1.View(Prototipo.SQLTrans.ViewRequest request) {
            return base.Channel.View(request);
        }
        
        public System.Data.DataSet View(string v, string where) {
            Prototipo.SQLTrans.ViewRequest inValue = new Prototipo.SQLTrans.ViewRequest();
            inValue.Body = new Prototipo.SQLTrans.ViewRequestBody();
            inValue.Body.v = v;
            inValue.Body.where = where;
            Prototipo.SQLTrans.ViewResponse retVal = ((Prototipo.SQLTrans.IService1)(this)).View(inValue);
            return retVal.Body.ViewResult;
        }
        
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
        System.Threading.Tasks.Task<Prototipo.SQLTrans.ViewResponse> Prototipo.SQLTrans.IService1.ViewAsync(Prototipo.SQLTrans.ViewRequest request) {
            return base.Channel.ViewAsync(request);
        }
        
        public System.Threading.Tasks.Task<Prototipo.SQLTrans.ViewResponse> ViewAsync(string v, string where) {
            Prototipo.SQLTrans.ViewRequest inValue = new Prototipo.SQLTrans.ViewRequest();
            inValue.Body = new Prototipo.SQLTrans.ViewRequestBody();
            inValue.Body.v = v;
            inValue.Body.where = where;
            return ((Prototipo.SQLTrans.IService1)(this)).ViewAsync(inValue);
        }
        
        public void Update(Prototipo.SQLTrans.LoginData login, string table, string set, string where) {
            base.Channel.Update(login, table, set, where);
        }
        
        public System.Threading.Tasks.Task UpdateAsync(Prototipo.SQLTrans.LoginData login, string table, string set, string where) {
            return base.Channel.UpdateAsync(login, table, set, where);
        }
        
        public void Delete(Prototipo.SQLTrans.LoginData login, string table, string where) {
            base.Channel.Delete(login, table, where);
        }
        
        public System.Threading.Tasks.Task DeleteAsync(Prototipo.SQLTrans.LoginData login, string table, string where) {
            return base.Channel.DeleteAsync(login, table, where);
        }
        
        public bool existUserName(string user) {
            return base.Channel.existUserName(user);
        }
        
        public System.Threading.Tasks.Task<bool> existUserNameAsync(string user) {
            return base.Channel.existUserNameAsync(user);
        }
        
        public Prototipo.SQLTrans.Restaurantes[] GetRestaurantes() {
            return base.Channel.GetRestaurantes();
        }
        
        public System.Threading.Tasks.Task<Prototipo.SQLTrans.Restaurantes[]> GetRestaurantesAsync() {
            return base.Channel.GetRestaurantesAsync();
        }
        
        public void sp_AgregarRestaurante(Prototipo.SQLTrans.LoginData login, string name, string reference, string img) {
            base.Channel.sp_AgregarRestaurante(login, name, reference, img);
        }
        
        public System.Threading.Tasks.Task sp_AgregarRestauranteAsync(Prototipo.SQLTrans.LoginData login, string name, string reference, string img) {
            return base.Channel.sp_AgregarRestauranteAsync(login, name, reference, img);
        }
        
        public void sp_AgregarUsuario(string id, string nombre, string apellido, string correo, string borndate, string pass, string img) {
            base.Channel.sp_AgregarUsuario(id, nombre, apellido, correo, borndate, pass, img);
        }
        
        public System.Threading.Tasks.Task sp_AgregarUsuarioAsync(string id, string nombre, string apellido, string correo, string borndate, string pass, string img) {
            return base.Channel.sp_AgregarUsuarioAsync(id, nombre, apellido, correo, borndate, pass, img);
        }
        
        public System.Data.DataSet sp_ValidarUsuario(string iduser, string pass) {
            return base.Channel.sp_ValidarUsuario(iduser, pass);
        }
        
        public System.Threading.Tasks.Task<System.Data.DataSet> sp_ValidarUsuarioAsync(string iduser, string pass) {
            return base.Channel.sp_ValidarUsuarioAsync(iduser, pass);
        }
        
        public int sp_AgregarImagen(Prototipo.SQLTrans.LoginData login, string url) {
            return base.Channel.sp_AgregarImagen(login, url);
        }
        
        public System.Threading.Tasks.Task<int> sp_AgregarImagenAsync(Prototipo.SQLTrans.LoginData login, string url) {
            return base.Channel.sp_AgregarImagenAsync(login, url);
        }
        
        public void sp_AgregarPlatillo(Prototipo.SQLTrans.LoginData login, string nombre, float precio, string descripcion, int tipo, int restaurante, string img) {
            base.Channel.sp_AgregarPlatillo(login, nombre, precio, descripcion, tipo, restaurante, img);
        }
        
        public System.Threading.Tasks.Task sp_AgregarPlatilloAsync(Prototipo.SQLTrans.LoginData login, string nombre, float precio, string descripcion, int tipo, int restaurante, string img) {
            return base.Channel.sp_AgregarPlatilloAsync(login, nombre, precio, descripcion, tipo, restaurante, img);
        }
        
        public void sp_AgregarPunto(Prototipo.SQLTrans.LoginData login, int x, int y, int restaurante) {
            base.Channel.sp_AgregarPunto(login, x, y, restaurante);
        }
        
        public System.Threading.Tasks.Task sp_AgregarPuntoAsync(Prototipo.SQLTrans.LoginData login, int x, int y, int restaurante) {
            return base.Channel.sp_AgregarPuntoAsync(login, x, y, restaurante);
        }
        
        public void sp_AgregarEstadistica(Prototipo.SQLTrans.LoginData login) {
            base.Channel.sp_AgregarEstadistica(login);
        }
        
        public System.Threading.Tasks.Task sp_AgregarEstadisticaAsync(Prototipo.SQLTrans.LoginData login) {
            return base.Channel.sp_AgregarEstadisticaAsync(login);
        }
        
        public void sp_AgregarComentario(Prototipo.SQLTrans.LoginData login, string idplatillo, string comentario) {
            base.Channel.sp_AgregarComentario(login, idplatillo, comentario);
        }
        
        public System.Threading.Tasks.Task sp_AgregarComentarioAsync(Prototipo.SQLTrans.LoginData login, string idplatillo, string comentario) {
            return base.Channel.sp_AgregarComentarioAsync(login, idplatillo, comentario);
        }
        
        public void sp_AgregarValoracion(Prototipo.SQLTrans.LoginData login, string idplatillo, float rate) {
            base.Channel.sp_AgregarValoracion(login, idplatillo, rate);
        }
        
        public System.Threading.Tasks.Task sp_AgregarValoracionAsync(Prototipo.SQLTrans.LoginData login, string idplatillo, float rate) {
            return base.Channel.sp_AgregarValoracionAsync(login, idplatillo, rate);
        }
        
        public void sp_AgregarLog(Prototipo.SQLTrans.LoginData login, string query) {
            base.Channel.sp_AgregarLog(login, query);
        }
        
        public System.Threading.Tasks.Task sp_AgregarLogAsync(Prototipo.SQLTrans.LoginData login, string query) {
            return base.Channel.sp_AgregarLogAsync(login, query);
        }
    }
}
