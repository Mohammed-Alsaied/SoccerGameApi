namespace Common.Validation
{
    public interface IBaseValidation<TViewModel> where TViewModel : BaseViewModel
    {
        Task IsValid(TViewModel productViewModel);
    }
}
