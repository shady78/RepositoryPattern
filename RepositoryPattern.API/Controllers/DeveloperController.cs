using Domain.Entities;
using Domain.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace RepositoryPattern.API.Controllers;
[Route("api/[controller]")]
[ApiController]
public class DeveloperController : ControllerBase
{
    private readonly IUnitOfWork _unitOfWork;
    public DeveloperController(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    [HttpGet]
    public IActionResult GetPopularDevelopers([FromQuery] int count)
    {
        var popularDevelopers = _unitOfWork.Developers.GetDevelopersWithMoreFollowers(count);
        return Ok(popularDevelopers);
    }

    [HttpPost]
    public IActionResult AddDeveloper()
    {
        var developer = new Developer
        {
            Followers = 35,
            Name = "Shady Kh"
        };
        var project = new Project
        {
            Name = "codewithshady"
        };
        _unitOfWork.Developers.Add(developer);
        _unitOfWork.Projects.Add(project);
        _unitOfWork.Complete();
        return Ok();
    }
}
