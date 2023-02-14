using Microsoft.EntityFrameworkCore.Metadata.Internal;
using ng_MasterDetails.Models;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ng_MasterDetails.ViewModels.Input
{
    public class OrderInputModel
    {
        [Required]
        public int OrderId { get; set; }
        [Required, DataType(DataType.Date)]
        public DateTime OrderDate { get; set; }
        [DataType(DataType.Date)]
        public DateTime? DeliveryDate { get; set; }
        [Required, EnumDataType(typeof(Status))]
        public Status Status { get; set; }
        [Required]
        public int CustomerId { get; set; }
        public List<OrderItem> OrderItems { get; } = default!;
    }
}
