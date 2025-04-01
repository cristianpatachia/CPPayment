using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CPPayment.Domain.Models.SqlViews;

[Table("Payments")]
public class Payment : SqlView
{
    [Key]
    public int Id { get; set; }

    [Column(TypeName = "nvarchar(100)")]
    public string CardOwnerName { get; set; } = string.Empty;

    [Column(TypeName = "nvarchar(16)")]
    public string CardNumber { get; set; } = string.Empty;

    [Column(TypeName = "datetime2")]
    public DateTime ExpirationDate { get; set; } = DateTime.MinValue;

    [Column(TypeName = "nvarchar(3)")]
    public string SecurityCode { get; set; } = string.Empty;

    [Column(TypeName = "decimal(18, 2)")]
    public decimal Amount { get; set; } = decimal.Zero;
}
