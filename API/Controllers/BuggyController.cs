using Infrastructure.Data;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    public class BuggyController : BaseApiController
    {
        private readonly StoreContext context;
        public BuggyController(StoreContext context)
        {
            this.context = context;

        }

        [HttpGet("notfound")]
        public ActionResult GetNotFoundRequest()
        {
            var thing = this.context.Products.Find(44);

            if(thing == null)
            {
                return NotFound();
            }
            return Ok();
        }

        [HttpGet("servroerror")]
        public ActionResult GetServerError()
        {
            var thing = this.context.Products.Find(44);

            var thingToReturn = thing.ToString();

            return Ok();
        }

        [HttpGet("badrequest")]
        public ActionResult GetBadRequest()
        {

            return BadRequest();
        }

        [HttpGet("badrequest/{id}")]
        public ActionResult GetBadRequestWithId(int id)
        {
            
            return Ok();
        }
    }
}