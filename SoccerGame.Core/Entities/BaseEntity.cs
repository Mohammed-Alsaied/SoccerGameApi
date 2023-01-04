namespace Common
{
    public class BaseEntity
    {
        public Guid Id { get; set; }
        public DateTime CreationDate { get; set; }
        //public byte[] ConcurrencyStamp { get; set; }
    }
}