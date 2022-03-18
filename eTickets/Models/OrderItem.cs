using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace eTickets.Models
{
    public class OrderItem
    {
        [Key]
        public int Id { get; set; }
        public int Amount { get; set; }
        public double Price { get; set; }
        public int MovieId { get; set; }
        [ForeignKey("MovieId")]
        public virtual Movie Movie{ get; set; }


        //Relationship with order and item
        public int OrderId { get; set; }
        [ForeignKey("OrderId")]
        public virtual Order Order { get; set; }
    }
}
