using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ShopStrumentiMusicali.Models
{
    public class Category
    {
        public int Id { get; set; }

        [Column(TypeName = "varchar(100)")]
        public string CategoryName { get; set; }

        public List<Instrument> Instruments { get; set; }
    }
}
