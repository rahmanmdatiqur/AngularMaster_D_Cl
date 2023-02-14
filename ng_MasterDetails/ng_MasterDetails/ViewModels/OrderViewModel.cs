using Microsoft.EntityFrameworkCore.Metadata.Internal;
using ng_MasterDetails.Models;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Xml.Linq;

namespace ng_MasterDetails.ViewModels
{
    public class OrderViewModel
    {
        public int OrderId { get; set; }
        
        public DateTime OrderDate { get; set; }
        
        public DateTime? DeliveryDate { get; set; }
        
        public Status Status { get; set; }
        
        public int CustomerId { get; set; }
        public string CustomerName { get; set; } = default!;
        public decimal OrderValue { get; set; }
    }
}
