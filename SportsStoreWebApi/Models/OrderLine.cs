using System.ComponentModel.DataAnnotations;
using System.Web.Http;
using System.Web.ModelBinding;

namespace SportsStoreWebApi.Models
{
    public class OrderLine
    {
        [HttpBindNever]
        public int Id { get; set; }

        [Required]
        [Range(1,100)]
        public int Count { get; set; }

        [Required]
        public int ProductId { get; set; }

        [HttpBindNever]
        public int OrderId { get; set; }

        [HttpBindNever]
        public Product Product { get; set; }
        [HttpBindNever]
        public Order Order { get; set; }
    }
}