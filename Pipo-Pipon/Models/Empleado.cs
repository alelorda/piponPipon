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

    public partial class Empleado
    {
        public string empleadoId { get; set; }
        [DisplayName("Nombre")]
        public string nombreEmpleado { get; set; }
        public int id_usuario { get; set; }
    
        public virtual Usuario Usuario { get; set; }
    }
}
