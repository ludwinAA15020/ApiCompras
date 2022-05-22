using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Compras.Migrations
{
    public partial class v1 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "CATEGORIA",
                columns: table => new
                {
                    IDCATEGORIA = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NOMBRECATEGORIA = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CATEGORIA", x => x.IDCATEGORIA)
                        .Annotation("SqlServer:Clustered", false);
                });

            migrationBuilder.CreateTable(
                name: "METODOPAGO",
                columns: table => new
                {
                    IDMETODOPAGO = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NOMBRETIPO = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_METODOPAGO", x => x.IDMETODOPAGO)
                        .Annotation("SqlServer:Clustered", false);
                });

            migrationBuilder.CreateTable(
                name: "REFERENCIA",
                columns: table => new
                {
                    IDREFERENCIA = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TIPOREFERENCIA = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: false),
                    NOMBRECOMPANIA = table.Column<string>(type: "varchar(100)", unicode: false, maxLength: 100, nullable: false),
                    NOMBRECONTACTO = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: false),
                    TELEFONOCONTACTO = table.Column<string>(type: "varchar(15)", unicode: false, maxLength: 15, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_REFERENCIA", x => x.IDREFERENCIA)
                        .Annotation("SqlServer:Clustered", false);
                });

            migrationBuilder.CreateTable(
                name: "ROLES",
                columns: table => new
                {
                    IDROL = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NOMBREROL = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: false),
                    DESCRIPCIONROL = table.Column<string>(type: "varchar(250)", unicode: false, maxLength: 250, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ROLES", x => x.IDROL)
                        .Annotation("SqlServer:Clustered", false);
                });

            migrationBuilder.CreateTable(
                name: "PRODUCTO",
                columns: table => new
                {
                    IDPRODUCTO = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    IDCATEGORIA = table.Column<int>(type: "int", nullable: false),
                    NOMBREPROD = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: false),
                    PRECIOPROD = table.Column<double>(type: "float", nullable: false),
                    MEDIDASPROD = table.Column<string>(type: "varchar(30)", unicode: false, maxLength: 30, nullable: true),
                    MARCAPROD = table.Column<string>(type: "varchar(20)", unicode: false, maxLength: 20, nullable: true),
                    UTILIDADPROD = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: true),
                    DESCRIPCIONPROD = table.Column<string>(type: "varchar(300)", unicode: false, maxLength: 300, nullable: false),
                    GARANTIAPROD = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: true),
                    IMAGENPROD = table.Column<string>(type: "varchar(200)", unicode: false, maxLength: 200, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PRODUCTO", x => x.IDPRODUCTO)
                        .Annotation("SqlServer:Clustered", false);
                    table.ForeignKey(
                        name: "FK_PRODUCTO_RELATIONS_CATEGORI",
                        column: x => x.IDCATEGORIA,
                        principalTable: "CATEGORIA",
                        principalColumn: "IDCATEGORIA",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "CATEGORIAPROVEEDOR",
                columns: table => new
                {
                    IDPROVEEDORES = table.Column<int>(type: "int", nullable: false),
                    IDCATEGORIA = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CATEGORIAPROVEEDOR", x => new { x.IDPROVEEDORES, x.IDCATEGORIA })
                        .Annotation("SqlServer:Clustered", false);
                    table.ForeignKey(
                        name: "FK_CATEGORI_CATEGORIA_CATEGORI",
                        column: x => x.IDCATEGORIA,
                        principalTable: "CATEGORIA",
                        principalColumn: "IDCATEGORIA",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "ORDENCOMPRA",
                columns: table => new
                {
                    IDORDENCOMPRA = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    IDCOTIZACION = table.Column<int>(type: "int", nullable: false),
                    FECHACOTIZACION = table.Column<DateTime>(type: "datetime", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ORDENCOMPRA", x => x.IDORDENCOMPRA)
                        .Annotation("SqlServer:Clustered", false);
                });

            migrationBuilder.CreateTable(
                name: "COTIZACION",
                columns: table => new
                {
                    IDCOTIZACION = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    IDREQUISICION = table.Column<int>(type: "int", nullable: false),
                    IDPROVEEDORES = table.Column<int>(type: "int", nullable: false),
                    IDORDENCOMPRA = table.Column<int>(type: "int", nullable: true),
                    IDMETODOPAGO = table.Column<int>(type: "int", nullable: false),
                    PRECIO = table.Column<double>(type: "float", nullable: false),
                    FECHACOTIZACION = table.Column<DateTime>(type: "datetime", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_COTIZACION", x => x.IDCOTIZACION)
                        .Annotation("SqlServer:Clustered", false);
                    table.ForeignKey(
                        name: "FK_COTIZACI_DAPASO2_ORDENCOM",
                        column: x => x.IDORDENCOMPRA,
                        principalTable: "ORDENCOMPRA",
                        principalColumn: "IDORDENCOMPRA",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_COTIZACI_SEPAGA_METODOPA",
                        column: x => x.IDMETODOPAGO,
                        principalTable: "METODOPAGO",
                        principalColumn: "IDMETODOPAGO",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "COMPANIA",
                columns: table => new
                {
                    IDCOMPANIA = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    IDPERFIL = table.Column<int>(type: "int", nullable: false),
                    NOMBRECOMPANIA = table.Column<string>(type: "varchar(100)", unicode: false, maxLength: 100, nullable: false),
                    VALORCOMPANIA = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: false),
                    CONTACTOCOMANIA = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: false),
                    TELEFONOCOMPANIA = table.Column<string>(type: "varchar(15)", unicode: false, maxLength: 15, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_COMPANIA", x => x.IDCOMPANIA)
                        .Annotation("SqlServer:Clustered", false);
                });

            migrationBuilder.CreateTable(
                name: "PERFILREFERENCIAS",
                columns: table => new
                {
                    IDPERFIL = table.Column<int>(type: "int", nullable: false),
                    IDREFERENCIA = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PERFILREFERENCIAS", x => new { x.IDPERFIL, x.IDREFERENCIA })
                        .Annotation("SqlServer:Clustered", false);
                    table.ForeignKey(
                        name: "FK_PERFILRE_PERFILREF_REFERENC",
                        column: x => x.IDREFERENCIA,
                        principalTable: "REFERENCIA",
                        principalColumn: "IDREFERENCIA",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "PERSONALCLAVE",
                columns: table => new
                {
                    IDPERSONALCLAVE = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    IDPERFIL = table.Column<int>(type: "int", nullable: false),
                    NOMBREPERSONAL = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: false),
                    CARGOPERSONAL = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: false),
                    FIRMAPERSONAL = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PERSONALCLAVE", x => x.IDPERSONALCLAVE)
                        .Annotation("SqlServer:Clustered", false);
                });

            migrationBuilder.CreateTable(
                name: "PROVEEDOR",
                columns: table => new
                {
                    IDPROVEEDORES = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    IDPERFIL = table.Column<int>(type: "int", nullable: true),
                    NOMBREPROVEEDOR = table.Column<string>(type: "varchar(100)", unicode: false, maxLength: 100, nullable: false),
                    REPRESENTANTE__ = table.Column<string>(type: "varchar(100)", unicode: false, maxLength: 100, nullable: false),
                    DIRECCIONCOMPANIA__ = table.Column<string>(type: "varchar(100)", unicode: false, maxLength: 100, nullable: true),
                    TELEFONOCOMPANIA__ = table.Column<string>(type: "varchar(15)", unicode: false, maxLength: 15, nullable: false),
                    FAXCOMPANIA__ = table.Column<string>(type: "varchar(15)", unicode: false, maxLength: 15, nullable: true),
                    MOVILCOMPANIA__ = table.Column<string>(type: "varchar(15)", unicode: false, maxLength: 15, nullable: true),
                    EMAIL__ = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: false),
                    CONTACTOS__LISTA___ = table.Column<int>(type: "int", nullable: true),
                    WEBSITE__ = table.Column<string>(type: "varchar(100)", unicode: false, maxLength: 100, nullable: true),
                    TIPOORGANIZACION = table.Column<int>(type: "int", nullable: false),
                    NIT = table.Column<string>(type: "varchar(20)", unicode: false, maxLength: 20, nullable: false),
                    NRC = table.Column<string>(type: "varchar(20)", unicode: false, maxLength: 20, nullable: false),
                    RUBRO = table.Column<int>(type: "int", nullable: false),
                    CALIFICACION = table.Column<string>(type: "varchar(20)", unicode: false, maxLength: 20, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PROVEEDOR", x => x.IDPROVEEDORES)
                        .Annotation("SqlServer:Clustered", false);
                });

            migrationBuilder.CreateTable(
                name: "PERFIL",
                columns: table => new
                {
                    IDPERFIL = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    IDPROVEEDORES = table.Column<int>(type: "int", nullable: false),
                    NOMBRECEO__ = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: false),
                    NOMBREGERENTE__ = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: false),
                    DIRECTORAREA_LISTA___ = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: false),
                    ESCRITURA = table.Column<string>(type: "varchar(100)", unicode: false, maxLength: 100, nullable: false),
                    RAZONSOCIAL = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PERFIL", x => x.IDPERFIL)
                        .Annotation("SqlServer:Clustered", false);
                    table.ForeignKey(
                        name: "FK_PERFIL_RELATIONS_PROVEEDO",
                        column: x => x.IDPROVEEDORES,
                        principalTable: "PROVEEDOR",
                        principalColumn: "IDPROVEEDORES",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "USUARIO",
                columns: table => new
                {
                    IDUSUARIO = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    IDROL = table.Column<int>(type: "int", nullable: false),
                    IDPROVEEDORES = table.Column<int>(type: "int", nullable: true),
                    NOMBREUSUARIO = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: false),
                    CORREO = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: false),
                    CONTRA = table.Column<string>(type: "char(10)", unicode: false, fixedLength: true, maxLength: 10, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_USUARIO", x => x.IDUSUARIO)
                        .Annotation("SqlServer:Clustered", false);
                    table.ForeignKey(
                        name: "FK_USUARIO_ESTABLECE_ROLES",
                        column: x => x.IDROL,
                        principalTable: "ROLES",
                        principalColumn: "IDROL",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_USUARIO_SELECREAN_PROVEEDO",
                        column: x => x.IDPROVEEDORES,
                        principalTable: "PROVEEDOR",
                        principalColumn: "IDPROVEEDORES",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "SUCURSAL",
                columns: table => new
                {
                    IDSUCURSAL = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    IDPERFIL = table.Column<int>(type: "int", nullable: false),
                    UBICACIONSUCURSAL = table.Column<string>(type: "varchar(100)", unicode: false, maxLength: 100, nullable: false),
                    IMAGENSUCURSAL = table.Column<string>(type: "varchar(100)", unicode: false, maxLength: 100, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SUCURSAL", x => x.IDSUCURSAL)
                        .Annotation("SqlServer:Clustered", false);
                    table.ForeignKey(
                        name: "FK_SUCURSAL_CUENTACON_PERFIL",
                        column: x => x.IDPERFIL,
                        principalTable: "PERFIL",
                        principalColumn: "IDPERFIL",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "REQUISICION",
                columns: table => new
                {
                    IDREQUISICION = table.Column<int>(type: "int", nullable: false),
                    IDUSUARIO = table.Column<int>(type: "int", nullable: false),
                    FECHACREADA = table.Column<DateTime>(type: "datetime", nullable: false),
                    NIVELIMPORTANCIA = table.Column<string>(type: "varchar(25)", unicode: false, maxLength: 25, nullable: false),
                    FECHAESTIMADA = table.Column<DateTime>(type: "datetime", nullable: false),
                    CANTIDADPRODUCTO = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_REQUISICION", x => x.IDREQUISICION)
                        .Annotation("SqlServer:Clustered", false);
                    table.ForeignKey(
                        name: "FK_REQUISIC_CREA_USUARIO",
                        column: x => x.IDUSUARIO,
                        principalTable: "USUARIO",
                        principalColumn: "IDUSUARIO",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "PRODUCTOREQUISICION",
                columns: table => new
                {
                    IDPRODUCTO = table.Column<int>(type: "int", nullable: false),
                    IDREQUISICION = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PRODUCTOREQUISICION", x => new { x.IDPRODUCTO, x.IDREQUISICION })
                        .Annotation("SqlServer:Clustered", false);
                    table.ForeignKey(
                        name: "FK_PRODUCTO_PRODUCTOR_PRODUCTO",
                        column: x => x.IDPRODUCTO,
                        principalTable: "PRODUCTO",
                        principalColumn: "IDPRODUCTO",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_PRODUCTO_PRODUCTOR_REQUISIC",
                        column: x => x.IDREQUISICION,
                        principalTable: "REQUISICION",
                        principalColumn: "IDREQUISICION",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "CATEGORIAPROVEEDOR_FK",
                table: "CATEGORIAPROVEEDOR",
                column: "IDPROVEEDORES");

            migrationBuilder.CreateIndex(
                name: "CATEGORIAPROVEEDOR2_FK",
                table: "CATEGORIAPROVEEDOR",
                column: "IDCATEGORIA");

            migrationBuilder.CreateIndex(
                name: "ATIENDE_FK",
                table: "COMPANIA",
                column: "IDPERFIL");

            migrationBuilder.CreateIndex(
                name: "DAPASO2_FK",
                table: "COTIZACION",
                column: "IDORDENCOMPRA");

            migrationBuilder.CreateIndex(
                name: "HACEN_FK",
                table: "COTIZACION",
                column: "IDPROVEEDORES");

            migrationBuilder.CreateIndex(
                name: "SEPAGA_FK",
                table: "COTIZACION",
                column: "IDMETODOPAGO");

            migrationBuilder.CreateIndex(
                name: "SURGE_FK",
                table: "COTIZACION",
                column: "IDREQUISICION");

            migrationBuilder.CreateIndex(
                name: "DAPASO_FK",
                table: "ORDENCOMPRA",
                column: "IDCOTIZACION");

            migrationBuilder.CreateIndex(
                name: "RELATIONSHIP_3_FK",
                table: "PERFIL",
                column: "IDPROVEEDORES");

            migrationBuilder.CreateIndex(
                name: "PERFILREFERENCIAS_FK",
                table: "PERFILREFERENCIAS",
                column: "IDPERFIL");

            migrationBuilder.CreateIndex(
                name: "PERFILREFERENCIAS2_FK",
                table: "PERFILREFERENCIAS",
                column: "IDREFERENCIA");

            migrationBuilder.CreateIndex(
                name: "PUEDETENER_FK",
                table: "PERSONALCLAVE",
                column: "IDPERFIL");

            migrationBuilder.CreateIndex(
                name: "RELATIONSHIP_1_FK",
                table: "PRODUCTO",
                column: "IDCATEGORIA");

            migrationBuilder.CreateIndex(
                name: "PRODUCTOREQUISICION_FK",
                table: "PRODUCTOREQUISICION",
                column: "IDPRODUCTO");

            migrationBuilder.CreateIndex(
                name: "PRODUCTOREQUISICION2_FK",
                table: "PRODUCTOREQUISICION",
                column: "IDREQUISICION");

            migrationBuilder.CreateIndex(
                name: "RELATIONSHIP_4_FK",
                table: "PROVEEDOR",
                column: "IDPERFIL");

            migrationBuilder.CreateIndex(
                name: "CREA_FK",
                table: "REQUISICION",
                column: "IDUSUARIO");

            migrationBuilder.CreateIndex(
                name: "CUENTACON_FK",
                table: "SUCURSAL",
                column: "IDPERFIL");

            migrationBuilder.CreateIndex(
                name: "ESTABLECEN_FK",
                table: "USUARIO",
                column: "IDROL");

            migrationBuilder.CreateIndex(
                name: "SELECREAN_FK",
                table: "USUARIO",
                column: "IDPROVEEDORES");

            migrationBuilder.AddForeignKey(
                name: "FK_CATEGORI_CATEGORIA_PROVEEDO",
                table: "CATEGORIAPROVEEDOR",
                column: "IDPROVEEDORES",
                principalTable: "PROVEEDOR",
                principalColumn: "IDPROVEEDORES",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_ORDENCOM_DAPASO_COTIZACI",
                table: "ORDENCOMPRA",
                column: "IDCOTIZACION",
                principalTable: "COTIZACION",
                principalColumn: "IDCOTIZACION",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_COTIZACI_HACEN_PROVEEDO",
                table: "COTIZACION",
                column: "IDPROVEEDORES",
                principalTable: "PROVEEDOR",
                principalColumn: "IDPROVEEDORES",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_COTIZACI_SURGE_REQUISIC",
                table: "COTIZACION",
                column: "IDREQUISICION",
                principalTable: "REQUISICION",
                principalColumn: "IDREQUISICION",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_COMPANIA_ATIENDE_PERFIL",
                table: "COMPANIA",
                column: "IDPERFIL",
                principalTable: "PERFIL",
                principalColumn: "IDPERFIL",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_PERFILRE_PERFILREF_PERFIL",
                table: "PERFILREFERENCIAS",
                column: "IDPERFIL",
                principalTable: "PERFIL",
                principalColumn: "IDPERFIL",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_PERSONAL_PUEDETENE_PERFIL",
                table: "PERSONALCLAVE",
                column: "IDPERFIL",
                principalTable: "PERFIL",
                principalColumn: "IDPERFIL",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_PROVEEDO_RELATIONS_PERFIL",
                table: "PROVEEDOR",
                column: "IDPERFIL",
                principalTable: "PERFIL",
                principalColumn: "IDPERFIL",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_COTIZACI_HACEN_PROVEEDO",
                table: "COTIZACION");

            migrationBuilder.DropForeignKey(
                name: "FK_PERFIL_RELATIONS_PROVEEDO",
                table: "PERFIL");

            migrationBuilder.DropForeignKey(
                name: "FK_USUARIO_SELECREAN_PROVEEDO",
                table: "USUARIO");

            migrationBuilder.DropForeignKey(
                name: "FK_COTIZACI_DAPASO2_ORDENCOM",
                table: "COTIZACION");

            migrationBuilder.DropTable(
                name: "CATEGORIAPROVEEDOR");

            migrationBuilder.DropTable(
                name: "COMPANIA");

            migrationBuilder.DropTable(
                name: "PERFILREFERENCIAS");

            migrationBuilder.DropTable(
                name: "PERSONALCLAVE");

            migrationBuilder.DropTable(
                name: "PRODUCTOREQUISICION");

            migrationBuilder.DropTable(
                name: "SUCURSAL");

            migrationBuilder.DropTable(
                name: "REFERENCIA");

            migrationBuilder.DropTable(
                name: "PRODUCTO");

            migrationBuilder.DropTable(
                name: "CATEGORIA");

            migrationBuilder.DropTable(
                name: "PROVEEDOR");

            migrationBuilder.DropTable(
                name: "PERFIL");

            migrationBuilder.DropTable(
                name: "ORDENCOMPRA");

            migrationBuilder.DropTable(
                name: "COTIZACION");

            migrationBuilder.DropTable(
                name: "METODOPAGO");

            migrationBuilder.DropTable(
                name: "REQUISICION");

            migrationBuilder.DropTable(
                name: "USUARIO");

            migrationBuilder.DropTable(
                name: "ROLES");
        }
    }
}
