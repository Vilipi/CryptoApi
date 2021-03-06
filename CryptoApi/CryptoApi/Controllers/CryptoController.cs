using System;
using CryptoApi.Domain;
using Microsoft.AspNetCore.Mvc;

namespace CryptoApi.Controllers
{
    [ApiController]
    [Route("[controller]")]

    public class CryptoController : ControllerBase
    {
        private static List<Crypto> cryptos = new List<Crypto>
        {
        new Crypto { Id = 1, Name = "Bitcoin", CurrentValue = 10, LastValue = 9, Favourite = false, Image = "https://w7.pngwing.com/pngs/766/282/png-transparent-bitcoin-btc-crypto-cryptocurrency-digital-currency-gold-money-fintech-coin-technology.png", LastModified = new DateTime(2022, 6, 20)},
        new Crypto { Id = 2, Name = "Etehreum", CurrentValue = 5, LastValue = 4, Favourite = false, Image = "https://w7.pngwing.com/pngs/766/282/png-transparent-bitcoin-btc-crypto-cryptocurrency-digital-currency-gold-money-fintech-coin-technology.png", LastModified = new DateTime(2022, 6, 20)},
        };


        // Se me muestran todas las cryptos 
        [HttpGet]
        public ActionResult<List<Crypto>> Get() {
            return Ok(cryptos); //200
        }

        [HttpPut] // Update to fav, not fav
        public ActionResult Put(int id) {
            var existingCrypto = cryptos.Find(x => x.Id == id);
            if (existingCrypto == null) {
                return Conflict("There is not any crypto with this Id"); // Status 409
            } else {
                existingCrypto.Favourite = !existingCrypto.Favourite;
                return Ok();
            }
        }

    }
}

