//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Pipo_Pipon.Models
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    
    public partial class pipopiponEntities : DbContext
    {
        public pipopiponEntities()
            : base("name=pipopiponEntities")
        {
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public virtual DbSet<Bebida> Bebidas { get; set; }
        public virtual DbSet<Comida> Comidas { get; set; }
        public virtual DbSet<Empleado> Empleadoes { get; set; }
        public virtual DbSet<OrdenDetalle> OrdenDetalles { get; set; }
        public virtual DbSet<Usuario> Usuarios { get; set; }
    }
}
