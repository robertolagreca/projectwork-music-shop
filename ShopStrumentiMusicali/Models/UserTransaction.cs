using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ShopStrumentiMusicali.Models
{
    //La classe che si occupa di gestire gli acquisti e ordini fatti dai clienti.

    public class UserTransaction
    {
        public string Id { get; set; }

        [Column(TypeName="date")]
        public DateOnly? TransactionDate { get; set; }

        [Column(TypeName="smallint")]
        [Range(0,32000, ErrorMessage = "Invalid input for quantity")]
        public int TransactionQuantity { get; set; }

        //FKs

        public UserTransaction() { }

        public UserTransaction(DateOnly? transactionDate, int transactionQuantity)
        {
            TransactionDate = transactionDate;
            TransactionQuantity = transactionQuantity;
        }
    }
}
