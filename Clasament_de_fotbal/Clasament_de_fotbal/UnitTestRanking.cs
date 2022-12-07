namespace Clasament_de_fotbal
{
    public class UnitTestRanking
    {
        [Fact]
        public void AddTeam_AddTeamToRanking_ShouldAddTeamToRankingInCorrectPosition()
        {
            Team team1 = new Team("team1", 3);
            Team team2 = new Team("team2", 1);
            Team team3 = new Team("team3", 2);
            List<Team> teams = new List<Team>();
            teams.Add(team1);
            teams.Add(team2);
            Ranking teamsList = new Ranking(teams);
            teamsList.AddTeam(team3);
            Assert.Equal(teamsList.ReportTeam(2), team3);
        }

        [Fact]
        public void ReportTeam_ReturnTeam_ShouldReturnTeamInGivenIndex()
        {
            Team team1 = new Team("team1", 3);
            Team team2 = new Team("team2", 1);
            List<Team> teams = new List<Team>();
            teams.Add(team1);
            teams.Add(team2);
            Ranking teamsList = new Ranking(teams);
            Assert.Equal(teamsList.ReportTeam(2), team2);
        }

        [Fact]
        public void ReportIndex_ReturnIndex_ShouldReturnIndexOfGivenTeam()
        {
            Team team1 = new Team("team1", 3);
            Team team2 = new Team("team2", 1);
            List<Team> teams = new List<Team>();
            teams.Add(team1);
            teams.Add(team2);
            Ranking teamsList = new Ranking(teams);
            Assert.Equal(teamsList.ReportIndex("team2"), 2);
        }

        [Fact]
        public void UpdateRanking_ChangeTeamScore_ShouldUpdateScoreAndReorderTeams()
        {
            Team team1 = new Team("team1", 3);
            Team team2 = new Team("team2", 1);
            List<Team> teams = new List<Team>();
            teams.Add(team1);
            teams.Add(team2);
            Ranking teamsList = new Ranking(teams);
            teamsList.UpdateRanking(team1, team2, 2);
            Assert.Equal(teamsList.ReportIndex("team2"), 1);
        }

        [Fact]
        public void SortTeams_ChangeTeamsPosition_ShouldReorderTeamsDependingOnScore()
        {
            Team team1 = new Team("team1", 1);
            Team team2 = new Team("team2", 3);
            List<Team> teams = new List<Team>();
            teams.Add(team1);
            teams.Add(team2);
            Ranking teamsList = new Ranking(teams);
            teamsList.SortTeams(ref teams);
            Assert.Equal(teamsList.ReportIndex("team2"), 1);
        }
    }
}