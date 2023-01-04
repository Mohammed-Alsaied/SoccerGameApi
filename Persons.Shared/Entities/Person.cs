namespace Persons.Shared;
public class Person : BaseEntity
{
    public string Name { get; set; }
    public string NickName { get; set; }
    public int Age { get; set; }
    public string PlaceOfBirth { get; set; }
    public DateTime BirthDate { get; set; }
    public decimal Hight { get; set; }
    //public string Position { get; set; }
    public Guid NationalityId { get; set; }
    public Nationality Nationality { get; set; }
    public Guid LeagueTeamId { get; set; }
    public Guid NationalTeamId { get; set; }



}