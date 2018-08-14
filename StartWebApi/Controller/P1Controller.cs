using StartWebApi.Models;
using System.Collections.Generic;
using System.Linq;
using System.Web.Http;

namespace StartWebApi.Controller
{
    public class P1Controller : ApiController
    {
        private List<Product> products = new List<Product>()
        {
            new Product{ Id =1, Name="T Shirt", Price = 26.5m, Quantity =5},
            new Product{ Id =2, Name="T Shirt 2", Price = 16.5m, Quantity =2 }
        };

        [HttpGet]
        [Route("p1/getproducts")]
        public IEnumerable<Product> Get()
        {
            return products.ToList();
        }

        [HttpGet]
        [Route("p1/{id}/getproduct")]
        public IHttpActionResult Get(int id)
        {
            var product = products.Where(x => x.Id == id);
            if (product == null)
                return NotFound();
            return Ok(product);
        }

        [HttpPost]
        public IHttpActionResult Create(Product product)
        {
            //save product to db
            if (product.Id != 0)
                return Ok();
            else
                return BadRequest();
        }

        [HttpPost]
        public void Create1(Product p)
        {
        }
        [HttpPut]
        public IHttpActionResult Put(Product product)
        {
            if (product.Id != 0)
                return Ok();
            else
                return BadRequest();
        }

        [HttpDelete]
        public IHttpActionResult Delete(int id)
        {
            var prod = products.Where(x => x.Id == id);
            if (prod != null)
                return Ok();
            else
                return
                    BadRequest();
        }
    }
}

