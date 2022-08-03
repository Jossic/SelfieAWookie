using System.Collections;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using NuGet.Protocol;
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
     
        var model = _context.Selfies.Include(item => item.Wookie).Select(item =>
            new { Title = item.Title, WookieId = item.Wookie.Id, NbSelfie = item.Wookie.Selfies.Count }).ToList();
        return Ok(model);
    }
}