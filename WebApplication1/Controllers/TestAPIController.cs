using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using TestAPI.IServices;
using TestAPI.Services;
using TestModel.Models;
// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace WebApplication1.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TestAPIController : ControllerBase
    {
        // GET: api/<TestAPIController>
        /// <summary>
        /// Sum接口
        /// </summary>
        /// <param name="i">参数i</param>
        /// <param name="j">参数j</param>
        /// <returns></returns>
        [HttpGet]
        public string[] Get(int i, int j)
        {
            return new string[] { "value1", "value2" };
            //IAdvertisementServices adServices = new AdvertisementServices();
            //return adServices.Sum(i, j);
        }
        
        // GET api/<TestAPIController>/5
        /// <summary>
        /// sqlsugar测试
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet("{id}")]
        public async  Task<List<Advertisement>> Get(int id)
        {
            //return "value";
            IAdvertisementServices adServices = new AdvertisementServices();
            return await adServices.Query(d=>d.Id==id);
        }

        // POST api/<TestAPIController>
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT api/<TestAPIController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<TestAPIController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
