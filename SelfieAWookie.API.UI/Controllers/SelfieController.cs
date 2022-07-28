using System.Collections;
using Microsoft.AspNetCore.Mvc;

namespace SelfieAWookie.API.UI.Controllers;

    [Route("api/[controller]")]
    [ApiController]
    public class SelfieController : ControllerBase
    {
        [HttpGet]
        public IEnumerable<Selfie> Get() => Enumerable.Range(1, 10).Select(wookie => new Selfie(wookie));
    }