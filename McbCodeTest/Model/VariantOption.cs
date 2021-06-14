using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

#nullable disable

namespace McbCodeTest.Model
{
    [Table("VariantOption")]
    public partial class VariantOption
    {
        public VariantOption()
        {
            ItemVariantOptions = new HashSet<ItemVariantOption>();
            VariantOptionTexts = new HashSet<VariantOptionText>();
        }

        [Key]
        [Column("ID")]
        public int Id { get; set; }
        [Column("VariantID")]
        public int VariantId { get; set; }
        public int SortOrder { get; set; }
        [Required]
        [StringLength(200)]
        public string InternalName { get; set; }

        [ForeignKey(nameof(VariantId))]
        [InverseProperty("VariantOptions")]
        public virtual Variant Variant { get; set; }
        [InverseProperty(nameof(ItemVariantOption.VariantOption))]
        public virtual ICollection<ItemVariantOption> ItemVariantOptions { get; set; }
        [InverseProperty(nameof(VariantOptionText.VariantOption))]
        public virtual ICollection<VariantOptionText> VariantOptionTexts { get; set; }
    }
}
