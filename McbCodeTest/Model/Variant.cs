using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

#nullable disable

namespace McbCodeTest.Model
{
    [Table("Variant")]
    public partial class Variant
    {
        public Variant()
        {
            VariantOptions = new HashSet<VariantOption>();
        }

        [Key]
        [Column("ID")]
        public int Id { get; set; }
        [Required]
        [StringLength(200)]
        public string InternalName { get; set; }
        public int SortOrder { get; set; }

        [InverseProperty(nameof(VariantOption.Variant))]
        public virtual ICollection<VariantOption> VariantOptions { get; set; }
    }
}
