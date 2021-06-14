using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

#nullable disable

namespace McbCodeTest.Model
{
    [Table("VariantOptionText")]
    public partial class VariantOptionText
    {
        [Key]
        [Column("VariantOptionID")]
        public int VariantOptionId { get; set; }
        [Key]
        [Column("LanguageID")]
        public int LanguageId { get; set; }
        [Required]
        [StringLength(200)]
        public string Name { get; set; }

        [ForeignKey(nameof(LanguageId))]
        [InverseProperty("VariantOptionTexts")]
        public virtual Language Language { get; set; }
        [ForeignKey(nameof(VariantOptionId))]
        [InverseProperty("VariantOptionTexts")]
        public virtual VariantOption VariantOption { get; set; }
    }
}
