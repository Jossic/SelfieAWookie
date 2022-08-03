using System.Collections;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SelfieAWookie.Core.Selfies.Domain;
using SelfieAWookie.Core.Selfies.Infrastructures.Data;

namespace SelfieAWookie.API.UI.Controllers;

    [Route("api/[controller]")]
    [ApiController]
    public class SelfieController : ControllerBase
    {

        private readonly SelfiesContext _context;
        public SelfieController(SelfiesContext context) => _context = context;

      
        [HttpGet]
        public IActionResult Get()
        {
            // var query = from wookie in _context.Selfies
            // select wookie;
            var model = _context.Selfies.Include(item => item.Wookie).Select().ToList();
            return Ok(model);
            // return Ok(query.ToList());
        } 
    }
