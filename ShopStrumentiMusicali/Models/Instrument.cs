using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;


namespace ShopStrumentiMusicali.Models
{
    public class Instrument
    {
        public int Id { get; set; }

        [Column(TypeName = "varchar(100)")]
        [StringLength(100, ErrorMessage="Name cannot be longer than 100 characters.")]
        public string Name { get; set; }

        [Column(TypeName = "text")]
        public string Description { get; set; }

        [Column(TypeName = "varchar(300)")]
        [StringLength(300, ErrorMessage = "Image URL cannot be longer than 300 characters.")]
        public string ImageURL { get; set; }

        public int Price { get; set; }

        public int CategoryID { get; set; }
        public Category Category { get; set; }

        public List<UserTransaction>? UserTransactions { get; set; }

        public List<ShopTransaction>? ShopTransactions { get; set; }

        public Instrument() { }

        public Instrument(string name, string description, string imageURL)
        {
            Name = name;
            Description = description;
            ImageURL = imageURL;
        }
    }
}
