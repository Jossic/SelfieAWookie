using System.Collections;
using Microsoft.AspNetCore.Mvc;
using SelfieAWookie.Core.Selfies.Domain;
using SelfieAWookie.Core.Selfies.Infrastructures.Data;

namespace SelfieAWookie.API.UI.Controllers;

    [Route("api/[controller]")]
    [ApiController]
    public class SelfieController : ControllerBase
    {

        private readonly SelfiesContext _context = null;
        public SelfieController(SelfiesContext context) => _context = context;

        [HttpGet]
        // public IEnumerable<Selfie> Get() => Enumerable.Range(1, 10).Select(wookie => new Selfie(wookie));


        [HttpGet]
        public IActionResult Get()
        {
            var model = _context.Selfies.ToList();
            // ===
            var query = from wookie in _context.Selfies
                select wookie;
            // var model =Enumerable.Range(1, 10).Select(wookie => new Selfie(wookie));
            return Ok(query.ToList());
        } 
    }
