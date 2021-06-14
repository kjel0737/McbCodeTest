using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

#nullable disable

namespace McbCodeTest.Model
{
    [Table("Language")]
    public partial class Language
    {
        public Language()
        {
            ItemTexts = new HashSet<ItemText>();
            VariantOptionTexts = new HashSet<VariantOptionText>();
        }

        [Key]
        [Column("ID")]
        public int Id { get; set; }
        [Required]
        [StringLength(200)]
        public string InternalName { get; set; }

        [InverseProperty(nameof(ItemText.Language))]
        public virtual ICollection<ItemText> ItemTexts { get; set; }
        [InverseProperty(nameof(VariantOptionText.Language))]
        public virtual ICollection<VariantOptionText> VariantOptionTexts { get; set; }
    }
}
