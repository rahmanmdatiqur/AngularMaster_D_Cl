using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ng_MasterDetails.Models
{
    public enum Status
    {
        Pending=1,
        Delivered,
        Cancelled
    }
    public class Customer
    {
        public int CustomerId { get; set; }
        [Required(ErrorMessage = "Customer name is required!!"),StringLength(50),Display(Name = "Customer Name")]
        public string CustomerName { get; set; } = default!;
        [Required,StringLength(150)]
        public string Address { get; set; } = default!;
        [Required,StringLength(50),EmailAddress]
        public string Email { get; set; } = default!;

        //nev
        public virtual ICollection<Order> Orders { get;set; } = new List<Order>();

    }
    public class Product
    {
        public int ProductId { get; set; }
        [Required(ErrorMessage = "Product name is required!!"), StringLength(50), Display(Name = "Product Name")]
        public string ProductName { get; set; }= default!;
        [Required(ErrorMessage = "Price is required!!"), Column(TypeName ="money"), DisplayFormat(DataFormatString ="{0:0.00}")]
        public decimal Price { get; set; }
        [Required,StringLength(150)]
        public string Picture { get; set; }=default!;
        public bool IsAvailable { get; set; }= default!;
        //nev
        public virtual ICollection<OrderItem> OrderItems { get; set; } = new List<OrderItem>();
    }
    public class Order
    {
        public int OrderId { get; set; }
        [Required,Column(TypeName ="date"),Display(Name = "Order Date"),DisplayFormat(DataFormatString ="{0:yyyy-MM-dd}",ApplyFormatInEditMode =true)]
        public DateTime OrderDate { get; set; }
        [Column(TypeName = "date"), Display(Name = "Delivery Date"), DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateTime? DeliveryDate { get; set; }
        [Required,EnumDataType(typeof(Status))]
        public Status Status { get; set; }
        //fk
        [ForeignKey("Customer")]
        public int CustomerId { get; set; }
        //nev
        public Customer Customer { get; set; } = default!;

        public virtual ICollection<OrderItem> OrderItems { get; set;}=new List<OrderItem>();

    }
    public class OrderItem
    {
        [ForeignKey("Order")]
        public int OrderId { get; set; }
        [ForeignKey("Product")]
        public int ProductId { get; set; }
        [Required]
        public int Quantity { get; set; }

        //nev
        public virtual Order Order { get; set; } = default!;
        public virtual Product Product { get; set; }=default!;

    }
    public class ProductDbContext : DbContext
    {
        public ProductDbContext(DbContextOptions<ProductDbContext> options):base(options) { }
        public DbSet<Customer> Customers { get; set; } = default!;
        public DbSet<Order> Orders { get; set; } = default!;
        public DbSet<OrderItem> OrderItems { get; set; } = default!;
        public DbSet<Product> Products { get; set; } = default!;
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<OrderItem>().HasKey(o => new { o.OrderId, o.ProductId });
        }
    }

}
