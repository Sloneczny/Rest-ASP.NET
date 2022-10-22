namespace webAPIrest.MApperData
{
    public class RestaurantMapp
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string Category { get; set; }
        public bool Delivery { get; set; }
        public string City { get; set; }
        public string Street { get; set; }
        public string PostalCode { get; set; }
        public  List<DishMapp> Dishes { get; set; }
    }
}
