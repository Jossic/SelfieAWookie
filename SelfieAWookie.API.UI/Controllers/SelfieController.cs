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
    private readonly ISelfieRepository _repository;
    public SelfieController(ISelfieRepository repository) => _repository = repository;


    [HttpGet]
    public IActionResult Get()
    {
        var selfieList = _repository.GetAll();
        var model = selfieList.Select(item =>
            new { Title = item.Title, WookieId = item.Wookie.Id, NbSelfie = item.Wookie.Selfies.Count });
        return Ok(model);
    }
}