using Domain.Payment.DTO;
using Microsoft.AspNetCore.Mvc;
using System.Net;
using System.Threading.Tasks;

namespace TraveloAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class PaymentController : Controller
    {

        [Route("Initialize")]
        [HttpPost]
        public async Task<ActionResult> InitializePayment([FromBody] PaymentDTO request)
        {
            if (request.BlikCode == "" || request.TargetPhoneNumber == "") return BadRequest();

            if (request.CorrectionFlag)
                return Ok();
            else
                return StatusCode(500);
        }

    }
}
