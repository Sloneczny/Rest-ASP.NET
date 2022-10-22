using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using webAPIrest.Entieties;
using webAPIrest.MApperData;

namespace webAPIrest.Controllers
{
    [Route("api/restaurant")]
    public class RestaurantController : ControllerBase
    {
        private readonly RestaurantDbContext _dbContext;
        private readonly IMapper _mapper;

        public RestaurantController(RestaurantDbContext dbContext , IMapper mapper)
        {
            _dbContext = dbContext;
            _mapper = mapper;
        }

        /// <summary>
        /// cala lista rstauracji z bazy danych
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public ActionResult<IEnumerable<RestaurantMapp>> GetAll()
        {
            var restaurants = _dbContext
                .Restaurants
                .Include(r=>r.Address)
                .Include(r=>r.Dishes)
                .ToList();

            var restaurantM = _mapper.Map<List<RestaurantMapp>>(restaurants);

           // var restaurantDto = restaurant.Select(r => new RestaurantMapp()
           // {
           //     Name = r.Name,
           //     Category = r.Category,
           //     City = r.Address.City
           // });
            return Ok(restaurantM);
        }
        /// <summary>
        /// szukanie po ID restauracji
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet("{id}")]
        public ActionResult<RestaurantMapp> Get([FromRoute] int id)
        {
            var restaurants = _dbContext
                .Restaurants
                .Include(r => r.Address)
                .Include(r => r.Dishes)
                .FirstOrDefault(x => x.Id == id);
                

            if (restaurants is null)
            {
                return NotFound();
            }
            var restaurantMs = _mapper.Map<RestaurantMapp>(restaurants);
            return Ok(restaurantMs);
        }
    }
}
