namespace LeagueTeams.Shared;
public class LeagueTeamViewModel : BaseViewModel
{
    public string Name { get; set; }
    public string NickName { get; set; }
    public string LeagueName { get; set; }
    public string Location { get; set; }
    public string President { get; set; }
    public string HomeStadium { get; set; }
    public int Capacity { get; set; }
    public DateTime Founded { get; set; }
    //public List<PlayerViewModel> Players { get; set; }
    //public Guid CoachId { get; set; }
    //public CoachViewModel Coach { get; set; }
    public Guid CaptainId { get; set; }
}