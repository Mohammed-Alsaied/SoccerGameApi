namespace LeagueTeams.Server;
public class LeagueTeam : BaseEntity
{
    public string Name { get; set; }
    public string NickName { get; set; }
    public string LeagueName { get; set; }
    public string President { get; set; }
    public string HomeStadium { get; set; }
    public int Capacity { get; set; }
    public DateTime Founded { get; set; }
    public List<Player> Players { get; set; }
    public Guid CoachId { get; set; }
    public Coach Coach { get; set; }
    public Guid CaptainId { get; set; }
}