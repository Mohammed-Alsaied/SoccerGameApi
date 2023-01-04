namespace Nationalities.Server;

using Common.Validation;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;

[Route("api/[controller]")]
[ApiController]
public class NationalitiesController : BaseController<Nationality, NationalityViewModel>
{
    //public NationalitiesController(INationalityUnitOfWork unitOfWork, IMapper mapper, IValidator<NationalityViewModel> validator)
    //    : base(unitOfWork, mapper, validator)
    //{
    //}

    public NationalitiesController(INationalityUnitOfWork unitOfWork, IMapper mapper, IBaseValidation<NationalityViewModel> validator)
       : base(unitOfWork, mapper, validator)
    {
    }

    [Authorize(Roles = "Admin")]
    public override Task Delete(Guid id)
    {
        return base.Delete(id);
    }

    [Authorize(Roles = "Admin")]
    public override Task<IActionResult> Post([FromBody] NationalityViewModel productViewModel)
    {
        return base.Post(productViewModel);
    }

    [Authorize(Roles = "Admin")]
    public override Task<IActionResult> Put(Guid id, [FromBody] NationalityViewModel productViewModel)
    {
        return base.Put(id, productViewModel);
    }
}