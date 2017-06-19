//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------
/// Author: Andr� Nannen
/// <summary>
/// Model that gets and sets the location. With validation attributes.
/// </summary>
namespace Delta_Impuls.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.ComponentModel.DataAnnotations;

    public partial class location
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public location()
        {
            this.member = new HashSet<member>();
        }
    
        public int ID { get; set; }

        [Required, DisplayName("Locatie")]
        [StringLength(35, ErrorMessage = "Locatie kan niet langer zijn dan 35 tekens.")]
        public string city { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<member> member { get; set; }
    }
}
