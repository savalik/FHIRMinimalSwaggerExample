using Microsoft.AspNetCore.Mvc;

namespace FhirSwaggerExample.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class FhirSwaggerExample : ControllerBase
    {
        [HttpPost]
        public ActionResult Create(Hl7.Fhir.Model.Bundle bundle)
        {
            return Ok();
        }
    }
}