using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Application.DTOs.Payment;
using Microsoft.AspNetCore.Mvc;


namespace TraveloAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class PaymentController : Controller
    {
        [Route("Initialize")]
        [HttpPost]
        public async Task<ActionResult> AuthorisePayment([FromBody] PaymentDTO request) 
        {
            if (request.BlikCode == "" || request.TargetPhoneNumber == "") return BadRequest();

            if (request.CorrectionFlag)
                return Ok();
            else
                return StatusCode(500);
        }

    }
}

