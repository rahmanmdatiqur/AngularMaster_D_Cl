using System.ComponentModel.DataAnnotations;
using System.Xml.Linq;

namespace ng_MasterDetails.ViewModels
{
    public class CustomerViewModel
    {

        public int CustomerId { get; set; }
        [Required, StringLength(50), Display(Name = "Customer Name")]
        public string CustomerName { get; set; } = default!;
        [Required, StringLength(150)]
        public string Address { get; set; } = default!;
        [Required, StringLength(50)]
        public string Email { get; set; } = default!;
        public bool CanDelete { get; set; }
    }
}
