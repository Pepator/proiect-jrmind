using Microsoft.VisualStudio.TestPlatform.ObjectModel;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Channels;
using System.Threading.Tasks;

namespace Clasament_de_fotbal
{
    internal class Ranking
    {
        const int FirstTeamWon = 1;
        const int SecondTeamWon = 2;
        const int PointsIfWin = 3;
        const int PointsIfDraw = 1;

        private List<Team> teams;

        public Ranking(List<Team> teams)
        {
            this.teams = teams;
        }

        public void AddTeam(Team team)
        {
            teams.Add(team);
            SortTeams(ref teams);
        }

        public Team ReportTeam(int index)
        {
            return teams[index - 1];
        }

        public int ReportIndex(string teamName)
        {
            for (int i = 0; i < teams.Count; i++)
            {
                if (teams[i].HasSameName(teamName))
                { 
                   return i + 1;
                } 
            }
            return -1;
        }

        public void UpdateRanking(Team team1, Team team2, int x)
        {
            if (x == FirstTeamWon) 
            {
                team1.AddToScore(PointsIfWin);
            }else if (x == SecondTeamWon)
            {
                team2.AddToScore(PointsIfWin);
            }
            else
            {
                team1.AddToScore(PointsIfDraw);
                team2.AddToScore(PointsIfDraw);
            }
            SortTeams(ref teams);
        }

        public void SortTeams(ref List<Team> teams)
        {
            Team free;
            for (int i = 0; i < teams.Count - 1; i++)
            {
                for (int j = i + 1; j < teams.Count; j++)
                {
                    if (!teams[i].HasBiggerScoreThan(teams[j]))
                    {
                        free = teams[j];
                        teams[j] = teams[i];
                        teams[i] = free;
                    }
                }
            }
        }
    }
}
