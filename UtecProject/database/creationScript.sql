/*==============================================================*/
/* Table: IMAGENES                                              */
/*==============================================================*/
create table IMAGENES (
   ID_IMAGEN            int                  identity,
   URL                  varchar(200)         not null,
   constraint PK_IMAGENES primary key (ID_IMAGEN)
)
go

/*==============================================================*/
/* Table: POINT                                                 */
/*==============================================================*/
create table POINT (
   ID_POINT             int                  identity,
   X                    int                  not null,
   Y                    int                  not null,
   constraint PK_POINT primary key (ID_POINT)
)
go

/*==============================================================*/
/* Table: RESTAURANTES                                          */
/*==============================================================*/
create table RESTAURANTES (
   ID_RESTAURANTES      int                  identity,
   ID_IMAGEN            int                  null,
   ID_POINT             int                  null,
   NOMBRE               nvarchar(200)        not null,
   REFERENCIA           nvarchar(200)        null,
   RATE                 float                null,
   constraint PK_RESTAURANTES primary key (ID_RESTAURANTES),
   constraint FK_RESTAURA_REFERENCE_IMAGENES foreign key (ID_IMAGEN)
      references IMAGENES (ID_IMAGEN),
   constraint FK_RESTAURA_REFERENCE_POINT foreign key (ID_POINT)
      references POINT (ID_POINT)
)
go

/*==============================================================*/
/* Table: TIPOPLATILLO                                          */
/*==============================================================*/
create table TIPOPLATILLO (
   ID_TIPO              int                  identity,
   TIPO                 varchar(100)         null,
   constraint PK_TIPOPLATILLO primary key (ID_TIPO)
)
go

/*==============================================================*/
/* Table: PLATILLOS                                             */
/*==============================================================*/
create table PLATILLOS (
   ID_PLATILLOS         int                  identity,
   ID_RESTAURANTES      int                  null,
   ID_IMAGEN            int                  null,
   ID_TIPO              int                  null,
   NOMBRE               nvarchar(200)        not null,
   RATE                 float                null,
   PRECIO               float                not null,
   DESCRIPCION          nvarchar(200)        not null,
   constraint PK_PLATILLOS primary key (ID_PLATILLOS),
   constraint FK_PLATILLO_REFERENCE_RESTAURA foreign key (ID_RESTAURANTES)
      references RESTAURANTES (ID_RESTAURANTES),
   constraint FK_PLATILLO_REFERENCE_IMAGENES foreign key (ID_IMAGEN)
      references IMAGENES (ID_IMAGEN),
   constraint FK_PLATILLO_REFERENCE_TIPOPLAT foreign key (ID_TIPO)
      references TIPOPLATILLO (ID_TIPO)
)
go

/*==============================================================*/
/* Table: USUARIOS                                              */
/*==============================================================*/
create table USUARIOS (
   ID_USUARIO           varchar(50)          not null,
   ID_IMAGEN            int                  null,
   NOMBRE               nvarchar(200)        not null,
   APELLIDO             nvarchar(200)        not null,
   CORREO_ELECTRONICO   nvarchar(200)        not null,
   FECHA_CUMPLE         datetime             not null,
   CONTRASENA           varbinary(500)       not null,
   ADMIN                bit                  not null,
   constraint PK_USUARIOS primary key (ID_USUARIO),
   constraint FK_USUARIOS_REFERENCE_IMAGENES foreign key (ID_IMAGEN)
      references IMAGENES (ID_IMAGEN)
)
go

/*==============================================================*/
/* Table: ACCIONCLICK                                           */
/*==============================================================*/
create table ACCIONCLICK (
   ID_ACCION            int                  identity,
   ID_PLATILLOS         int                  null,
   ID_USUARIO           varchar(50)          null,
   CANTIDAD             int                  not null,
   constraint PK_ACCIONCLICK primary key (ID_ACCION),
   constraint FK_ACCIONCL_REFERENCE_PLATILLO foreign key (ID_PLATILLOS)
      references PLATILLOS (ID_PLATILLOS),
   constraint FK_ACCIONCL_REFERENCE_USUARIOS foreign key (ID_USUARIO)
      references USUARIOS (ID_USUARIO)
)
go

/*==============================================================*/
/* Table: ACCIONTIEMPO                                          */
/*==============================================================*/
create table ACCIONTIEMPO (
   ID_ACCION            int                  identity,
   ID_PLATILLOS         int                  null,
   ID_USUARIO           varchar(50)          null,
   TIEMPO               int                  not null,
   constraint PK_ACCIONTIEMPO primary key (ID_ACCION),
   constraint FK_ACCIONTI_REFERENCE_PLATILLO foreign key (ID_PLATILLOS)
      references PLATILLOS (ID_PLATILLOS),
   constraint FK_ACCIONTI_REFERENCE_USUARIOS foreign key (ID_USUARIO)
      references USUARIOS (ID_USUARIO)
)
go

/*==============================================================*/
/* Table: COMENTARIOS                                           */
/*==============================================================*/
create table COMENTARIOS (
   ID_COMENTARIOS       int                  identity,
   ID_USUARIO           varchar(50)          null,
   ID_PLATILLOS         int                  null,
   COMENTARIOS          nvarchar(200)        not null,
   constraint PK_COMENTARIOS primary key (ID_COMENTARIOS),
   constraint FK_COMENTAR_REFERENCE_USUARIOS foreign key (ID_USUARIO)
      references USUARIOS (ID_USUARIO),
   constraint FK_COMENTAR_REFERENCE_PLATILLO foreign key (ID_PLATILLOS)
      references PLATILLOS (ID_PLATILLOS)
)
go

/*==============================================================*/
/* Table: ESTADISTICA                                           */
/*==============================================================*/
create table ESTADISTICA (
   ID_ESTADISTICA       int                  identity,
   ID_USUARIO           varchar(50)          null,
   CANTIDAD             int                  not null,
   constraint PK_ESTADISTICA primary key (ID_ESTADISTICA),
   constraint FK_ESTADIST_REFERENCE_USUARIOS foreign key (ID_USUARIO)
      references USUARIOS (ID_USUARIO)
)
go

/*==============================================================*/
/* Table: RECOMENDACIONES                                       */
/*==============================================================*/
create table RECOMENDACIONES (
   ID_USUARIOA          varchar(50)          null,
   ID_USUARIOB          varchar(50)          null,
   COINCIDENCIAS        int                  not null,
   constraint FK_RECOMEND_REFERENCE_USUARIOS1 foreign key (ID_USUARIOA)
      references USUARIOS (ID_USUARIO),
   constraint FK_RECOMEND_REFERENCE_USUARIOS2 foreign key (ID_USUARIOB)
      references USUARIOS (ID_USUARIO)
)
go

/*==============================================================*/
/* Table: VALORACIONES                                          */
/*==============================================================*/
create table VALORACIONES (
   ID_PLATILLOS         int                  null,
   ID_USUARIO           varchar(50)          null,
   RATE                 float                not null,
   constraint FK_VALORACI_REFERENCE_PLATILLO foreign key (ID_PLATILLOS)
      references PLATILLOS (ID_PLATILLOS),
   constraint FK_VALORACI_REFERENCE_USUARIOS foreign key (ID_USUARIO)
      references USUARIOS (ID_USUARIO)
)
go

/*==============================================================*/
/* Table: LOGS                                                  */
/*==============================================================*/
create table LOGS(
	ID_ACTION int identity,
	ID_USUARIO varchar(50) foreign key references Usuarios(ID_USUARIO),
	ID_OBJECT int,
	CREACION date,
  TABLA varchar(10),
	TIPO varchar(3),
	check(TIPO = 'C' OR TIPO = 'U' OR TIPO = 'D')	
)
go
