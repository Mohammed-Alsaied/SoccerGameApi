namespace NationalTeams.Server;

using Common.Validation;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;

[Route("api/[controller]")]
[ApiController]
public class NationalTeamsController : BaseController<NationalTeam, NationalTeamViewModel>
{
    //public NationalTeamsController(INationalTeamUnitOfWork unitOfWork, IMapper mapper, IValidator<NationalTeamViewModel> validator)
    //    : base(unitOfWork, mapper, validator)
    //{
    //}

    public NationalTeamsController(INationalTeamUnitOfWork unitOfWork, IMapper mapper, IBaseValidation<NationalTeamViewModel> validator)
        : base(unitOfWork, mapper, validator)
    {
    }
    [Authorize(Roles = "Admin")]
    public override Task Delete(Guid id)
    {
        return base.Delete(id);
    }

    [Authorize(Roles = "Admin")]
    public override Task<IActionResult> Post([FromBody] NationalTeamViewModel productViewModel)
    {
        return base.Post(productViewModel);
    }

    [Authorize(Roles = "Admin")]
    public override Task<IActionResult> Put(Guid id, [FromBody] NationalTeamViewModel productViewModel)
    {
        return base.Put(id, productViewModel);
    }
}