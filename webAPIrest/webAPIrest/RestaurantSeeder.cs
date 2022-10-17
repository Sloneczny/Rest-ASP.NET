using System.Reflection.Metadata.Ecma335;
using System.Xml.Serialization;
using webAPIrest.Entieties;

namespace webAPIrest
{
    public class RestaurantSeeder
    {
        private readonly RestaurantDbContext _dbContext;
        public RestaurantSeeder(RestaurantDbContext dbContext)
        {
            _dbContext = dbContext; 
        }  
        public void Seed()
        {
            if(_dbContext.Database.CanConnect())
            {
                if(!_dbContext.Restaurants.Any())
                {
                    var restauants = GetRestaurants();
                    _dbContext.Restaurants.AddRange(restauants);
                    _dbContext.SaveChanges();
                }
            }
        }
        public IEnumerable<Restaurant> GetRestaurants()
        {
            var restauants = new List<Restaurant>()
            {
                new Restaurant()
                {
                    Name ="MCDonald",
                    Category="Fast Food",
                    Description="Buergers and chips",
                    ContactNumber="798625654",
                    Email= "bartoszkwiatkowski1996@gmail.com",
                    Delivery=true,
                    Dishes = new List<Dish>()
                    {
                        new Dish()
                        {
                            Name="Mcroyal",
                            Price=10.20M,
                            Description=" kanapka premium"

                        },
                         new Dish()
                        {
                             Name="Chips Small",
                             Price=5M,
                             Description=" Frytki"



                        },
                          new Dish()
                        {
                              Name="MC Burger",
                              Price=10M,
                              Description=" mack burger"

                        }
                    },

                    Address = new Address()
                    {
                        City="Gdańsk",
                        Street="Wałowa",
                        PostalCode="80-858"


                    }




                }

            };
            return restauants;
        }
    }
}
