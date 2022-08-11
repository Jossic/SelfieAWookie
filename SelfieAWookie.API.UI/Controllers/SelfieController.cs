using Microsoft.AspNetCore.Mvc;
using SelfieAWookie.API.UI.Application.DTOs;
using SelfieAWookie.Core.Selfies.Domain;

namespace SelfieAWookie.API.UI.Controllers;

[Route("api/[controller]")]
[ApiController]
public class SelfieController : ControllerBase
{
    private readonly ISelfieRepository _repository;
    private readonly IWebHostEnvironment _webHostEnvironment;

    public SelfieController(ISelfieRepository repository, IWebHostEnvironment webHostEnvironment)
    {
        _repository = repository;
        _webHostEnvironment = webHostEnvironment;
    }


    [HttpGet]
    public IActionResult GetAll([FromQuery] int wookieId = 0)
    {
        var selfiesList = _repository.GetAll(wookieId);
        var model = selfiesList.Select(item => new SelfieResumeDto() { Title = item.Title, WookieId = item.Wookie.Id, NbSelfiesFromWookie = (item.Wookie?.Selfies?.Count).GetValueOrDefault(0) }).ToList();
        return Ok(model);
    }

    //[Route("photos")]
    //[HttpPost]
    //public async Task<IActionResult> AddPicture()
    //{
    //    using var stream = new StreamReader(Request.Body);

    //    var content = await stream.ReadToEndAsync();

    //    return Ok();
    //}

    [Route("photos")]
    [HttpPost]
    public async Task<IActionResult> AddPicture(IFormFile picture)
    {
        string filePath = Path.Combine(_webHostEnvironment.ContentRootPath, @"images\selfies");

        if (!Directory.Exists(filePath))
        {
            Directory.CreateDirectory(filePath);
        }
        filePath = Path.Combine(filePath, picture.FileName);


        using var stream = new FileStream(filePath, FileMode.OpenOrCreate);
        await picture.CopyToAsync(stream);

        return Ok();
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