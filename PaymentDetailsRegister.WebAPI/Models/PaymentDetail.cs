using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CardsWebAPI.Models
{
    public class PaymentDetail
    {
        [Key]
        public int PaymentId { get; set; }
        [Required]
        [Column(TypeName = "nvarchar(100)")]
        public string CardOwnerName { get; set; }
        [Required]
        [Column(TypeName = "nvarchar(16)")]
        public string CardNumber { get; set; }
        [Required]
        [Column(TypeName = "nvarchar(5)")]
        public string ExpirationDate { get; set; }
        [Required]
        [Column(TypeName = "nvarchar(3)")]
        public string CVV { get; set; }
    }
}
