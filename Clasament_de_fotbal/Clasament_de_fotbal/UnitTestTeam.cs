namespace Clasament_de_fotbal
{
    public class UnitTestTeam
    {
        [Fact]
        public void HasBiggerScoreThen_ComparesTwoTeams_ShouldReturnTrueIfFirstTeamHasMorePoints()
        {
            Team team1 = new Team("team1", 1);
            Team team2 = new Team("team2", 0);
            Assert.True(team1.HasBiggerScoreThan(team2));
        }

        [Fact]
        public void AddToScore_AddsPointsToTeamScore_ShouldAddGivenPointsToScore()
        {
            Team team1 = new Team("team1", 1);
            Team team2 = new Team("team2", 5);
            Team team3 = new Team("team3", 3);
            team1.AddToScore(3);
            Assert.True(team1.HasBiggerScoreThan(team3) && team2.HasBiggerScoreThan(team1));
        }
    }
}