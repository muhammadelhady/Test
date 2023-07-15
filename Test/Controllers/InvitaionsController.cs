using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Test.Helpers;
using Test.Services.Invetation;
using Test.ViewModels.Invitaion;

namespace Test.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class InvitaionsController : ControllerBase
    {
        private readonly IInvitaionService _invitaionService;

        public InvitaionsController(IInvitaionService invitaionService)
        {
            _invitaionService = invitaionService;
        }
        [HttpGet("{userid:int}/invitaions")]
        public async Task<IActionResult> GetUserInvitaions(int userid,[FromQuery]BaseQueryParameters baseQueryParameters)
        {
            var invitaions = await _invitaionService.GetUserInvitaions(baseQueryParameters, userid);
            if(invitaions != null)
            {
                return Ok(invitaions);
            }
            return BadRequest("Failed To Get User Invitaions");
        }

        [HttpPut("{invitaionId:int}/respond")]
        public async Task<IActionResult> Respond(int invitaionId,[FromBody]InvitaionResponseInputModel invitaionResponseInputModel)
        {
            var invitaions = await _invitaionService.Respond(invitaionResponseInputModel, invitaionId);
            if (invitaions)
            {
                return Ok("Done");
            }
            return BadRequest("Failed To save invitaion response");
        }
        [HttpPost("{eventid:int}/send")]
        public async Task<IActionResult> Send(int eventid,[FromBody]SendInvitationInputModel sendInvitationInputModel)
        {
            var invitaions = await _invitaionService.Send(eventid, sendInvitationInputModel);
            if (invitaions)
            {
                return Ok("Invitaions Sent");
            }
            return BadRequest("Failed To send invitaions");
        }
    }
}
