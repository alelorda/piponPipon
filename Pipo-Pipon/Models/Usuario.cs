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
    using System.Collections.Generic;
    using System.ComponentModel;

    public partial class Usuario
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Usuario()
        {
            this.Empleadoes = new HashSet<Empleado>();
        }
    
        public int id_usuario { get; set; }
        [DisplayName("Nombre de usuario")]
        public string username { get; set; }
        [DisplayName("Contraseņa")]
        public string password { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Empleado> Empleadoes { get; set; }
    }
}
