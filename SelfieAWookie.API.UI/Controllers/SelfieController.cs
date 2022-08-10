 using System.Collections;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using NuGet.Protocol;
using SelfieAWookie.API.UI.Application.DTOs;
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
        var selfiesList = _repository.GetAll();
        var model = selfiesList.Select(item => new SelfieResumeDto() { Title = item.Title, WookieId = item.Wookie.Id, NbSelfiesFromWookie = (item.Wookie?.Selfies?.Count).GetValueOrDefault(0) }).ToList();
        return Ok(model);
    }
}