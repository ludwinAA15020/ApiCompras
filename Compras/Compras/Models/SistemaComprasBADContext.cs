using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

#nullable disable

namespace Compras.Models
{
    public partial class SistemaComprasBADContext : DbContext
    {
        public SistemaComprasBADContext()
        {
        }

        public SistemaComprasBADContext(DbContextOptions<SistemaComprasBADContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Categoriaproveedor> Categoriaproveedors { get; set; }
        public virtual DbSet<Categorium> Categoria { get; set; }
        public virtual DbSet<Companium> Compania { get; set; }
        public virtual DbSet<Cotizacion> Cotizacions { get; set; }
        public virtual DbSet<Metodopago> Metodopagos { get; set; }
        public virtual DbSet<Ordencompra> Ordencompras { get; set; }
        public virtual DbSet<Perfil> Perfils { get; set; }
        public virtual DbSet<Perfilreferencia> Perfilreferencias { get; set; }
        public virtual DbSet<Personalclave> Personalclaves { get; set; }
        public virtual DbSet<Producto> Productos { get; set; }
        public virtual DbSet<Productorequisicion> Productorequisicions { get; set; }
        public virtual DbSet<Proveedor> Proveedors { get; set; }
        public virtual DbSet<Referencium> Referencia { get; set; }
        public virtual DbSet<Requisicion> Requisicions { get; set; }
        public virtual DbSet<Role> Roles { get; set; }
        public virtual DbSet<Sucursal> Sucursals { get; set; }
        public virtual DbSet<Usuario> Usuarios { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseSqlServer("Data source=LAPTOP-RM2GTL61\\SQLEXPRESS; Initial Catalog=SistemaComprasBAD; user id=sa; password=0000;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("Relational:Collation", "Modern_Spanish_CI_AS");

            modelBuilder.Entity<Categoriaproveedor>(entity =>
            {
                entity.HasKey(e => new { e.Idproveedores, e.Idcategoria })
                    .IsClustered(false);

                entity.ToTable("CATEGORIAPROVEEDOR");

                entity.HasIndex(e => e.Idcategoria, "CATEGORIAPROVEEDOR2_FK");

                entity.HasIndex(e => e.Idproveedores, "CATEGORIAPROVEEDOR_FK");

                entity.Property(e => e.Idproveedores).HasColumnName("IDPROVEEDORES");

                entity.Property(e => e.Idcategoria).HasColumnName("IDCATEGORIA");

                entity.HasOne(d => d.IdcategoriaNavigation)
                    .WithMany(p => p.Categoriaproveedors)
                    .HasForeignKey(d => d.Idcategoria)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_CATEGORI_CATEGORIA_CATEGORI");

                entity.HasOne(d => d.IdproveedoresNavigation)
                    .WithMany(p => p.Categoriaproveedors)
                    .HasForeignKey(d => d.Idproveedores)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_CATEGORI_CATEGORIA_PROVEEDO");
            });

            modelBuilder.Entity<Categorium>(entity =>
            {
                entity.HasKey(e => e.Idcategoria)
                    .IsClustered(false);

                entity.ToTable("CATEGORIA");

                entity.Property(e => e.Idcategoria).HasColumnName("IDCATEGORIA");

                entity.Property(e => e.Nombrecategoria)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("NOMBRECATEGORIA");
            });

            modelBuilder.Entity<Companium>(entity =>
            {
                entity.HasKey(e => e.Idcompania)
                    .IsClustered(false);

                entity.ToTable("COMPANIA");

                entity.HasIndex(e => e.Idperfil, "ATIENDE_FK");

                entity.Property(e => e.Idcompania).HasColumnName("IDCOMPANIA");

                entity.Property(e => e.Contactocomania)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("CONTACTOCOMANIA");

                entity.Property(e => e.Idperfil).HasColumnName("IDPERFIL");

                entity.Property(e => e.Nombrecompania)
                    .IsRequired()
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("NOMBRECOMPANIA");

                entity.Property(e => e.Telefonocompania)
                    .IsRequired()
                    .HasMaxLength(15)
                    .IsUnicode(false)
                    .HasColumnName("TELEFONOCOMPANIA");

                entity.Property(e => e.Valorcompania)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("VALORCOMPANIA");

                entity.HasOne(d => d.IdperfilNavigation)
                    .WithMany(p => p.Compania)
                    .HasForeignKey(d => d.Idperfil)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_COMPANIA_ATIENDE_PERFIL");
            });

            modelBuilder.Entity<Cotizacion>(entity =>
            {
                entity.HasKey(e => e.Idcotizacion)
                    .IsClustered(false);

                entity.ToTable("COTIZACION");

                entity.HasIndex(e => e.Idordencompra, "DAPASO2_FK");

                entity.HasIndex(e => e.Idproveedores, "HACEN_FK");

                entity.HasIndex(e => e.Idmetodopago, "SEPAGA_FK");

                entity.HasIndex(e => e.Idrequisicion, "SURGE_FK");

                entity.Property(e => e.Idcotizacion).HasColumnName("IDCOTIZACION");

                entity.Property(e => e.Fechacotizacion)
                    .HasColumnType("datetime")
                    .HasColumnName("FECHACOTIZACION");

                entity.Property(e => e.Idmetodopago).HasColumnName("IDMETODOPAGO");

                entity.Property(e => e.Idordencompra).HasColumnName("IDORDENCOMPRA");

                entity.Property(e => e.Idproveedores).HasColumnName("IDPROVEEDORES");

                entity.Property(e => e.Idrequisicion).HasColumnName("IDREQUISICION");

                entity.Property(e => e.Precio).HasColumnName("PRECIO");

                entity.HasOne(d => d.IdmetodopagoNavigation)
                    .WithMany(p => p.Cotizacions)
                    .HasForeignKey(d => d.Idmetodopago)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_COTIZACI_SEPAGA_METODOPA");

                entity.HasOne(d => d.IdordencompraNavigation)
                    .WithMany(p => p.Cotizacions)
                    .HasForeignKey(d => d.Idordencompra)
                    .HasConstraintName("FK_COTIZACI_DAPASO2_ORDENCOM");

                entity.HasOne(d => d.IdproveedoresNavigation)
                    .WithMany(p => p.Cotizacions)
                    .HasForeignKey(d => d.Idproveedores)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_COTIZACI_HACEN_PROVEEDO");

                entity.HasOne(d => d.IdrequisicionNavigation)
                    .WithMany(p => p.Cotizacions)
                    .HasForeignKey(d => d.Idrequisicion)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_COTIZACI_SURGE_REQUISIC");
            });

            modelBuilder.Entity<Metodopago>(entity =>
            {
                entity.HasKey(e => e.Idmetodopago)
                    .IsClustered(false);

                entity.ToTable("METODOPAGO");

                entity.Property(e => e.Idmetodopago).HasColumnName("IDMETODOPAGO");

                entity.Property(e => e.Nombretipo)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("NOMBRETIPO");
            });

            modelBuilder.Entity<Ordencompra>(entity =>
            {
                entity.HasKey(e => e.Idordencompra)
                    .IsClustered(false);

                entity.ToTable("ORDENCOMPRA");

                entity.HasIndex(e => e.Idcotizacion, "DAPASO_FK");

                entity.Property(e => e.Idordencompra).HasColumnName("IDORDENCOMPRA");

                entity.Property(e => e.Fechacotizacion)
                    .HasColumnType("datetime")
                    .HasColumnName("FECHACOTIZACION");

                entity.Property(e => e.Idcotizacion).HasColumnName("IDCOTIZACION");

                entity.HasOne(d => d.IdcotizacionNavigation)
                    .WithMany(p => p.Ordencompras)
                    .HasForeignKey(d => d.Idcotizacion)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_ORDENCOM_DAPASO_COTIZACI");
            });

            modelBuilder.Entity<Perfil>(entity =>
            {
                entity.HasKey(e => e.Idperfil)
                    .IsClustered(false);

                entity.ToTable("PERFIL");

                entity.HasIndex(e => e.Idproveedores, "RELATIONSHIP_3_FK");

                entity.Property(e => e.Idperfil).HasColumnName("IDPERFIL");

                entity.Property(e => e.DirectorareaLista)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("DIRECTORAREA_LISTA___");

                entity.Property(e => e.Escritura)
                    .IsRequired()
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("ESCRITURA");

                entity.Property(e => e.Idproveedores).HasColumnName("IDPROVEEDORES");

                entity.Property(e => e.Nombreceo)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("NOMBRECEO__");

                entity.Property(e => e.Nombregerente)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("NOMBREGERENTE__");

                entity.Property(e => e.Razonsocial)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("RAZONSOCIAL");

                entity.HasOne(d => d.IdproveedoresNavigation)
                    .WithMany(p => p.Perfils)
                    .HasForeignKey(d => d.Idproveedores)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_PERFIL_RELATIONS_PROVEEDO");
            });

            modelBuilder.Entity<Perfilreferencia>(entity =>
            {
                entity.HasKey(e => new { e.Idperfil, e.Idreferencia })
                    .IsClustered(false);

                entity.ToTable("PERFILREFERENCIAS");

                entity.HasIndex(e => e.Idreferencia, "PERFILREFERENCIAS2_FK");

                entity.HasIndex(e => e.Idperfil, "PERFILREFERENCIAS_FK");

                entity.Property(e => e.Idperfil).HasColumnName("IDPERFIL");

                entity.Property(e => e.Idreferencia).HasColumnName("IDREFERENCIA");

                entity.HasOne(d => d.IdperfilNavigation)
                    .WithMany(p => p.Perfilreferencia)
                    .HasForeignKey(d => d.Idperfil)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_PERFILRE_PERFILREF_PERFIL");

                entity.HasOne(d => d.IdreferenciaNavigation)
                    .WithMany(p => p.Perfilreferencia)
                    .HasForeignKey(d => d.Idreferencia)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_PERFILRE_PERFILREF_REFERENC");
            });

            modelBuilder.Entity<Personalclave>(entity =>
            {
                entity.HasKey(e => e.Idpersonalclave)
                    .IsClustered(false);

                entity.ToTable("PERSONALCLAVE");

                entity.HasIndex(e => e.Idperfil, "PUEDETENER_FK");

                entity.Property(e => e.Idpersonalclave).HasColumnName("IDPERSONALCLAVE");

                entity.Property(e => e.Cargopersonal)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("CARGOPERSONAL");

                entity.Property(e => e.Firmapersonal)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("FIRMAPERSONAL");

                entity.Property(e => e.Idperfil).HasColumnName("IDPERFIL");

                entity.Property(e => e.Nombrepersonal)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("NOMBREPERSONAL");

                entity.HasOne(d => d.IdperfilNavigation)
                    .WithMany(p => p.Personalclaves)
                    .HasForeignKey(d => d.Idperfil)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_PERSONAL_PUEDETENE_PERFIL");
            });

            modelBuilder.Entity<Producto>(entity =>
            {
                entity.HasKey(e => e.Idproducto)
                    .IsClustered(false);

                entity.ToTable("PRODUCTO");

                entity.HasIndex(e => e.Idcategoria, "RELATIONSHIP_1_FK");

                entity.Property(e => e.Idproducto).HasColumnName("IDPRODUCTO");

                entity.Property(e => e.Descripcionprod)
                    .IsRequired()
                    .HasMaxLength(300)
                    .IsUnicode(false)
                    .HasColumnName("DESCRIPCIONPROD");

                entity.Property(e => e.Garantiaprod)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("GARANTIAPROD");

                entity.Property(e => e.Idcategoria).HasColumnName("IDCATEGORIA");

                entity.Property(e => e.Imagenprod)
                    .HasMaxLength(200)
                    .IsUnicode(false)
                    .HasColumnName("IMAGENPROD");

                entity.Property(e => e.Marcaprod)
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasColumnName("MARCAPROD");

                entity.Property(e => e.Medidasprod)
                    .HasMaxLength(30)
                    .IsUnicode(false)
                    .HasColumnName("MEDIDASPROD");

                entity.Property(e => e.Nombreprod)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("NOMBREPROD");

                entity.Property(e => e.Precioprod).HasColumnName("PRECIOPROD");

                entity.Property(e => e.Utilidadprod)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("UTILIDADPROD");

                entity.HasOne(d => d.IdcategoriaNavigation)
                    .WithMany(p => p.Productos)
                    .HasForeignKey(d => d.Idcategoria)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_PRODUCTO_RELATIONS_CATEGORI");
            });

            modelBuilder.Entity<Productorequisicion>(entity =>
            {
                entity.HasKey(e => new { e.Idproducto, e.Idrequisicion })
                    .IsClustered(false);

                entity.ToTable("PRODUCTOREQUISICION");

                entity.HasIndex(e => e.Idrequisicion, "PRODUCTOREQUISICION2_FK");

                entity.HasIndex(e => e.Idproducto, "PRODUCTOREQUISICION_FK");

                entity.Property(e => e.Idproducto).HasColumnName("IDPRODUCTO");

                entity.Property(e => e.Idrequisicion).HasColumnName("IDREQUISICION");

                entity.HasOne(d => d.IdproductoNavigation)
                    .WithMany(p => p.Productorequisicions)
                    .HasForeignKey(d => d.Idproducto)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_PRODUCTO_PRODUCTOR_PRODUCTO");

                entity.HasOne(d => d.IdrequisicionNavigation)
                    .WithMany(p => p.Productorequisicions)
                    .HasForeignKey(d => d.Idrequisicion)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_PRODUCTO_PRODUCTOR_REQUISIC");
            });

            modelBuilder.Entity<Proveedor>(entity =>
            {
                entity.HasKey(e => e.Idproveedores)
                    .IsClustered(false);

                entity.ToTable("PROVEEDOR");

                entity.HasIndex(e => e.Idperfil, "RELATIONSHIP_4_FK");

                entity.Property(e => e.Idproveedores).HasColumnName("IDPROVEEDORES");

                entity.Property(e => e.Calificacion)
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasColumnName("CALIFICACION");

                entity.Property(e => e.ContactosLista).HasColumnName("CONTACTOS__LISTA___");

                entity.Property(e => e.Direccioncompania)
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("DIRECCIONCOMPANIA__");

                entity.Property(e => e.Email)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("EMAIL__");

                entity.Property(e => e.Faxcompania)
                    .HasMaxLength(15)
                    .IsUnicode(false)
                    .HasColumnName("FAXCOMPANIA__");

                entity.Property(e => e.Idperfil).HasColumnName("IDPERFIL");

                entity.Property(e => e.Movilcompania)
                    .HasMaxLength(15)
                    .IsUnicode(false)
                    .HasColumnName("MOVILCOMPANIA__");

                entity.Property(e => e.Nit)
                    .IsRequired()
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasColumnName("NIT");

                entity.Property(e => e.Nombreproveedor)
                    .IsRequired()
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("NOMBREPROVEEDOR");

                entity.Property(e => e.Nrc)
                    .IsRequired()
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasColumnName("NRC");

                entity.Property(e => e.Representante)
                    .IsRequired()
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("REPRESENTANTE__");

                entity.Property(e => e.Rubro).HasColumnName("RUBRO");

                entity.Property(e => e.Telefonocompania)
                    .IsRequired()
                    .HasMaxLength(15)
                    .IsUnicode(false)
                    .HasColumnName("TELEFONOCOMPANIA__");

                entity.Property(e => e.Tipoorganizacion).HasColumnName("TIPOORGANIZACION");

                entity.Property(e => e.Website)
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("WEBSITE__");

                entity.HasOne(d => d.IdperfilNavigation)
                    .WithMany(p => p.Proveedors)
                    .HasForeignKey(d => d.Idperfil)
                    .HasConstraintName("FK_PROVEEDO_RELATIONS_PERFIL");
            });

            modelBuilder.Entity<Referencium>(entity =>
            {
                entity.HasKey(e => e.Idreferencia)
                    .IsClustered(false);

                entity.ToTable("REFERENCIA");

                entity.Property(e => e.Idreferencia).HasColumnName("IDREFERENCIA");

                entity.Property(e => e.Nombrecompania)
                    .IsRequired()
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("NOMBRECOMPANIA");

                entity.Property(e => e.Nombrecontacto)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("NOMBRECONTACTO");

                entity.Property(e => e.Telefonocontacto)
                    .IsRequired()
                    .HasMaxLength(15)
                    .IsUnicode(false)
                    .HasColumnName("TELEFONOCONTACTO");

                entity.Property(e => e.Tiporeferencia)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("TIPOREFERENCIA");
            });

            modelBuilder.Entity<Requisicion>(entity =>
            {
                entity.HasKey(e => e.Idrequisicion)
                    .IsClustered(false);

                entity.ToTable("REQUISICION");

                entity.HasIndex(e => e.Idusuario, "CREA_FK");

                entity.Property(e => e.Idrequisicion)
                    .ValueGeneratedNever()
                    .HasColumnName("IDREQUISICION");

                entity.Property(e => e.Cantidadproducto).HasColumnName("CANTIDADPRODUCTO");

                entity.Property(e => e.Fechacreada)
                    .HasColumnType("datetime")
                    .HasColumnName("FECHACREADA");

                entity.Property(e => e.Fechaestimada)
                    .HasColumnType("datetime")
                    .HasColumnName("FECHAESTIMADA");

                entity.Property(e => e.Idusuario).HasColumnName("IDUSUARIO");

                entity.Property(e => e.Nivelimportancia)
                    .IsRequired()
                    .HasMaxLength(25)
                    .IsUnicode(false)
                    .HasColumnName("NIVELIMPORTANCIA");

                entity.HasOne(d => d.IdusuarioNavigation)
                    .WithMany(p => p.Requisicions)
                    .HasForeignKey(d => d.Idusuario)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_REQUISIC_CREA_USUARIO");
            });

            modelBuilder.Entity<Role>(entity =>
            {
                entity.HasKey(e => e.Idrol)
                    .IsClustered(false);

                entity.ToTable("ROLES");

                entity.Property(e => e.Idrol).HasColumnName("IDROL");

                entity.Property(e => e.Descripcionrol)
                    .IsRequired()
                    .HasMaxLength(250)
                    .IsUnicode(false)
                    .HasColumnName("DESCRIPCIONROL");

                entity.Property(e => e.Nombrerol)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("NOMBREROL");
            });

            modelBuilder.Entity<Sucursal>(entity =>
            {
                entity.HasKey(e => e.Idsucursal)
                    .IsClustered(false);

                entity.ToTable("SUCURSAL");

                entity.HasIndex(e => e.Idperfil, "CUENTACON_FK");

                entity.Property(e => e.Idsucursal).HasColumnName("IDSUCURSAL");

                entity.Property(e => e.Idperfil).HasColumnName("IDPERFIL");

                entity.Property(e => e.Imagensucursal)
                    .IsRequired()
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("IMAGENSUCURSAL");

                entity.Property(e => e.Ubicacionsucursal)
                    .IsRequired()
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("UBICACIONSUCURSAL");

                entity.HasOne(d => d.IdperfilNavigation)
                    .WithMany(p => p.Sucursals)
                    .HasForeignKey(d => d.Idperfil)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_SUCURSAL_CUENTACON_PERFIL");
            });

            modelBuilder.Entity<Usuario>(entity =>
            {
                entity.HasKey(e => e.Idusuario)
                    .IsClustered(false);

                entity.ToTable("USUARIO");

                entity.HasIndex(e => e.Idrol, "ESTABLECEN_FK");

                entity.HasIndex(e => e.Idproveedores, "SELECREAN_FK");

                entity.Property(e => e.Idusuario).HasColumnName("IDUSUARIO");

                entity.Property(e => e.Contra)
                    .IsRequired()
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasColumnName("CONTRA")
                    .IsFixedLength(true);

                entity.Property(e => e.Correo)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("CORREO");

                entity.Property(e => e.Idproveedores).HasColumnName("IDPROVEEDORES");

                entity.Property(e => e.Idrol).HasColumnName("IDROL");

                entity.Property(e => e.Nombreusuario)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("NOMBREUSUARIO");

                entity.HasOne(d => d.IdproveedoresNavigation)
                    .WithMany(p => p.Usuarios)
                    .HasForeignKey(d => d.Idproveedores)
                    .HasConstraintName("FK_USUARIO_SELECREAN_PROVEEDO");

                entity.HasOne(d => d.IdrolNavigation)
                    .WithMany(p => p.Usuarios)
                    .HasForeignKey(d => d.Idrol)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_USUARIO_ESTABLECE_ROLES");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
