using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

#nullable disable

namespace McbCodeTest.Model
{
    [Table("Item")]
    public partial class Item
    {
        public Item()
        {
            InverseParent = new HashSet<Item>();
            ItemTexts = new HashSet<ItemText>();
            ItemVariantOptions = new HashSet<ItemVariantOption>();
        }

        [Key]
        [Column("ID")]
        public int Id { get; set; }
        [Required]
        [Column("SKU")]
        [StringLength(200)]
        public string Sku { get; set; }
        public double Inventory { get; set; }
        [Column("ParentID")]
        public int? ParentId { get; set; }

        [ForeignKey(nameof(ParentId))]
        [InverseProperty(nameof(Item.InverseParent))]
        public virtual Item Parent { get; set; }
        [InverseProperty(nameof(Item.Parent))]
        public virtual ICollection<Item> InverseParent { get; set; }
        [InverseProperty(nameof(ItemText.Item))]
        public virtual ICollection<ItemText> ItemTexts { get; set; }
        [InverseProperty(nameof(ItemVariantOption.Item))]
        public virtual ICollection<ItemVariantOption> ItemVariantOptions { get; set; }
    }
}
