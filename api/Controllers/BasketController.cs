using System.Threading.Tasks;
using Core.Entities;
using Core.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace api.Controllers
{
    public class BasketController : BaseApiController
    {
        private readonly IBasketRepository _basketRepository;

        public BasketController(IBasketRepository basketRepository)
        {
            this._basketRepository = basketRepository;
        }

        [HttpGet]
        public async Task<ActionResult<CustomerBasket>> GetBasketById(string Id)
        {
            var backet = await _basketRepository.GetBasketAsync(Id);

            return Ok(backet ?? new CustomerBasket(Id));
        }

        [HttpPost]
        public async Task<ActionResult<CustomerBasket>> UpdateBasket(CustomerBasket basket)
        {
            var result = await _basketRepository.UpdateBasketAsync(basket);
            return Ok(result);
        }

        [HttpDelete]
        public async Task DeleteBasket(string Id)
        {
            await _basketRepository.DeleteBasketAsync(Id);
        }

    }
}