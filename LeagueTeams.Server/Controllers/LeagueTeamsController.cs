namespace LeagueTeams.Server;

using Common.Validation;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;

[Route("api/[controller]")]
[ApiController]
public class LeagueTeamsController : BaseController<LeagueTeam, LeagueTeamViewModel>
{
    //public LeagueTeamsController(ILeagueTeamUnitOfWork unitOfWork, IMapper mapper, IValidator<LeagueTeamViewModel> validator)
    //    : base(unitOfWork, mapper, validator)
    //{
    //}

    public LeagueTeamsController(ILeagueTeamUnitOfWork unitOfWork, IMapper mapper, IBaseValidation<LeagueTeamViewModel> validator)
        : base(unitOfWork, mapper, validator)
    {
    }
    [Authorize(Roles = "Admin")]
    public override Task Delete(Guid id)
    {
        return base.Delete(id);
    }

    [Authorize(Roles = "Admin")]
    public override Task<IActionResult> Post([FromBody] LeagueTeamViewModel productViewModel)
    {
        return base.Post(productViewModel);
    }

    [Authorize(Roles = "Admin")]
    public override Task<IActionResult> Put(Guid id, [FromBody] LeagueTeamViewModel productViewModel)
    {
        return base.Put(id, productViewModel);
    }

    //[Authorize(Roles = "Admin")]
    //public override Task<IActionResult> Put(Guid id, [FromBody] LeagueTeamViewModel productViewModel)
    //{
    //    var product = _unitOfWork.ReadByIdAsync(id);
    //    //if (product == null) Console.WriteLine($"No League Team was found With ID: {id}");

    //    return base.Put(id, productViewModel);
    //}
}