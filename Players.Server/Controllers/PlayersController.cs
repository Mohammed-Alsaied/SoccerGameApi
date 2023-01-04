namespace Players.Server;

using Common.Validation;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;

[Route("api/[controller]")]
[ApiController]
public class PlayersController : BaseController<Player, PlayerViewModel>
{
    //public PlayersController(IPlayerUnitOfWork unitOfWork, IMapper mapper, IValidator<PlayerViewModel> validator)
    //    : base(unitOfWork, mapper, validator)
    //{
    //}

    public PlayersController(IPlayerUnitOfWork unitOfWork, IMapper mapper, IBaseValidation<PlayerViewModel> validator)
        : base(unitOfWork, mapper, validator)
    {
    }

    [Authorize(Roles = "Admin")]
    public override Task<IActionResult> Post([FromBody] PlayerViewModel productViewModel)
    {
        return base.Post(productViewModel);
    }

    [Authorize(Roles = "Admin")]
    public override Task<IActionResult> Put(Guid id, [FromBody] PlayerViewModel productViewModel)
    {
        return base.Put(id, productViewModel);
    }

    [Authorize(Roles = "Admin")]
    public override Task Delete(Guid id)
    {
        return base.Delete(id);
    }
}