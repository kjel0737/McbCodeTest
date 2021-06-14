using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

#nullable disable

namespace McbCodeTest.Model
{
    [Table("ItemText")]
    public partial class ItemText
    {
        [Key]
        [Column("ID")]
        public int Id { get; set; }
        [Column("ItemID")]
        public int ItemId { get; set; }
        [Column("LanguageID")]
        public int LanguageId { get; set; }
        [Required]
        [StringLength(200)]
        public string Name { get; set; }
        [StringLength(1000)]
        public string LogicalName { get; set; }

        [ForeignKey(nameof(ItemId))]
        [InverseProperty("ItemTexts")]
        public virtual Item Item { get; set; }
        [ForeignKey(nameof(LanguageId))]
        [InverseProperty("ItemTexts")]
        public virtual Language Language { get; set; }
    }
}
