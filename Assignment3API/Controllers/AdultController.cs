using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Assignment3API.Model;
using Assignment3API.Service;
using Microsoft.AspNetCore.Mvc;

namespace Assignment3API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class AdultController : ControllerBase
    {
        private IAdultService adultService;
        public AdultController(IAdultService adultService)
        {
            this.adultService = adultService;
        }
        
        [HttpGet]
        public async Task<ActionResult<IList<Adult>>> GetAdults()
        {
            try
            {
                IList<Adult> adults = await adultService.getAdultsAsync();
                return Ok(adults);
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                return StatusCode(500, e.Message);
            }
        }
        
        [HttpPost]
        public async Task<ActionResult<Adult>> AddAdult([FromBody] Adult adult) {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            try
            {
                Adult added = await adultService.AddAdultAsync(adult);
                return Created($"/{added.Id}",added); 
            } catch (Exception e) {
                Console.WriteLine(e);
                return StatusCode(500, e.Message);
            }
        }
        [HttpDelete]
        [Route("{id:int}")]
        public async Task<ActionResult> DeleteAdult([FromRoute] int id) {
            try
            {
                await adultService.RemoveAdultAsync(id);
                return Ok();
            } catch (Exception e) {
                Console.WriteLine(e);
                return StatusCode(500, e.Message);
            }
        }
    }
}