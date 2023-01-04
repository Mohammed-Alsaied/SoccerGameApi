namespace Nationalities.Server
{
    using Common;

    public class NationalityUnitOfWork : BaseUnitOfWork<Nationality>, INationalityUnitOfWork
    {
        public NationalityUnitOfWork(INationalityRepository repsitory) : base(repsitory)
        {
        }
    }
}
