using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

#nullable disable

namespace McbCodeTest.Model
{
    [Table("ItemVariantOption")]
    public partial class ItemVariantOption
    {
        [Key]
        [Column("ItemID")]
        public int ItemId { get; set; }
        [Key]
        [Column("VariantOptionID")]
        public int VariantOptionId { get; set; }

        [ForeignKey(nameof(ItemId))]
        [InverseProperty("ItemVariantOptions")]
        public virtual Item Item { get; set; }
        [ForeignKey(nameof(VariantOptionId))]
        [InverseProperty("ItemVariantOptions")]
        public virtual VariantOption VariantOption { get; set; }
    }
}
