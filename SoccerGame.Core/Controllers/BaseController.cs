// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860
namespace Common
{
    using AutoMapper;
    using Common.Validation;
    using Microsoft.AspNetCore.Mvc;

    public class BaseController<TEntity, TViewModel> : ControllerBase
        where TEntity : BaseEntity
        where TViewModel : BaseViewModel
    {
        protected readonly IBaseUnitOfWork<TEntity> _unitOfWork;
        protected readonly IMapper _mapper;
        //protected readonly IValidator<TViewModel> _validator;
        protected readonly IBaseValidation<TViewModel> _validator;

        //public BaseController(IBaseUnitOfWork<TEntity> unitOfWork, IMapper mapper, IValidator<TViewModel> validator)
        //{
        //    _unitOfWork = unitOfWork;
        //    _mapper = mapper;
        //    _validator = validator;
        //}

        public BaseController(IBaseUnitOfWork<TEntity> unitOfWork, IMapper mapper, IBaseValidation<TViewModel> validator)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
            _validator = validator;
        }

        [HttpGet]
        public virtual async Task<IEnumerable<TViewModel>> Get()
        {
            List<TEntity> entities = await _unitOfWork.ReadAsync();
            return entities.Select(product => _mapper.Map<TViewModel>(product));
        }

        [HttpGet("{id}")]
        public virtual async Task<IActionResult> Get(Guid id)
        {
            TEntity product = await _unitOfWork.ReadByIdAsync(id);
            TViewModel productViewModel = _mapper.Map<TViewModel>(product);
            return Ok(productViewModel);
        }

        [HttpPost]
        public virtual async Task<IActionResult> Post([FromBody] TViewModel productViewModel)
        {
            //ValidationResult validationResult = await _validator.ValidateAsync(productViewModel);
            //if (!validationResult.IsValid) return BadRequest(new { errors = validationResult.Errors });
            await _validator.IsValid(productViewModel);
            var product = _mapper.Map<TEntity>(productViewModel);
            product = await _unitOfWork.CreateAsync(product);
            return CreatedAtAction(nameof(Get), new { id = product.Id }, _mapper.Map<TViewModel>(product));
        }

        //[HttpPut]
        //public virtual async Task<IActionResult> Put([FromBody] TViewModel productViewModel)
        //{
        //    ValidationResult validationResult = await _validator.ValidateAsync(productViewModel);
        //    if (!validationResult.IsValid)
        //        return BadRequest(new { errors = validationResult.Errors });

        //    var product = _mapper.Map<TEntity>(productViewModel);
        //    product = await _unitOfWork.UpdateAsync(product);
        //    return Ok(_mapper.Map<TViewModel>(product));
        //}

        //[HttpPut("{id}")]
        //public virtual async Task<IActionResult> Put(Guid id, [FromBody] TViewModel productViewModel)
        //{
        //    ValidationResult validationResult = await _validator.ValidateAsync(productViewModel);
        //    if (!validationResult.IsValid) return BadRequest(new { errors = validationResult.Errors });
        //    var product = await _unitOfWork.ReadByIdAsync(id);
        //    if (product == null) return NotFound("Id Credential Invalid");
        //    product = _mapper.Map<TEntity>(productViewModel);
        //    product = await _unitOfWork.UpdateAsync(product);
        //    return Ok(_mapper.Map<TViewModel>(product));
        //}

        [HttpPut("{id}")]
        public virtual async Task<IActionResult> Put(Guid id, [FromBody] TViewModel productViewModel)
        {
            //ValidationResult validationResult = await _validator.ValidateAsync(productViewModel);
            //if (!validationResult.IsValid) return BadRequest(new { errors = validationResult.Errors });
            await _validator.IsValid(productViewModel);
            var product = await _unitOfWork.ReadByIdAsync(id);
            if (product == null) return NotFound("Id Credential Invalid");
            product = _mapper.Map<TEntity>(productViewModel);
            product = await _unitOfWork.UpdateAsync(id);
            return Ok(_mapper.Map<TViewModel>(product));
        }

        [HttpDelete("{id}")]
        public virtual async Task Delete(Guid id)
        {
            await _unitOfWork.DeleteAsync(id);

        }
    }
}