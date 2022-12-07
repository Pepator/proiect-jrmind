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
            SortTeams();
        }

        public Team ReportTeam(int index)
        {
            return teams[index - 1];
        }

        public int ReportIndex(Team teamName)
        {
            for (int i = 0; i < teams.Count; i++)
            {
                if (teams[i].Equals(teamName))
                { 
                   return i + 1;
                } 
            }
            return -1;
        }

        public void UpdateRanking(int teamOneScore, int teamTwoScore)
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
            SortTeams();
        }

        public void SortTeams()
        {
            Team free;
            bool swapped;
            for (int i = 0; i < teams.Count - 1; i++)
            {
                swapped = false;
                for (int j = 0; j < teams.Count - 1 - i; j++)
                {
                    if (!teams[j].HasBiggerScoreThan(teams[j + 1]))
                    {
                        free = teams[j];
                        teams[j] = teams[j + 1];
                        teams[j + 1] = free;
                        swapped = true;
                    }
                }
                if (swapped == false)
                {
                    break;
                }
            }
        }
    }
}
