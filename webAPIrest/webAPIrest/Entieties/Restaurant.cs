using System.Net;

namespace webAPIrest.Entieties
{
    public class Restaurant
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; } 
        public string Category { get; set; }
        public  bool Delivery { get; set; }
        public string Email { get; set; }
        public string ContactNumber { get; set; }
        public int AddressId { get; set; }
        public virtual Address Address { get; set; }
        
        public virtual List<Dish> Dishes { get; set; }



        }
}
