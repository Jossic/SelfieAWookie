using Microsoft.AspNetCore.Mvc;
using SelfieAWookie.API.UI.Application.DTOs;
using SelfieAWookie.Core.Selfies.Domain;

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

    [HttpPost]
    public IActionResult AddOne(SelfieDto selfie)
    {
        IActionResult result = BadRequest();

        Selfie addSelfie = _repository.AddOne(new Selfie()
        {
            ImagePath = selfie.ImagePath,
            Title = selfie.Title,

        });

        _repository.UnitOfWork.SaveChanges();

        if (addSelfie != null)
        {
            selfie.Id = addSelfie.Id;
            result = Ok(selfie);
        }

        return result;
    }
}