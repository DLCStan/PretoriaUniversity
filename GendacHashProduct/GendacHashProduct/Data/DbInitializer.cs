using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using GendacHashProduct.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;


namespace GendacHashProduct.Data
{
    public class DbInitializer
    {
        public static void Initialize(NBAPlayerContext context)
        {

            context.Database.EnsureCreated();

            if (context.NBAPlayers.Any())
            {
                return; //Database has already been seeded
            }

            context.NBAPlayers.AddRange(
                new NBAPlayer
                {
                    Id = 1,
                    PlayerName = "Lebron James",
                    TeamName = "Lakers",
                    PointsPerGame = 27.7M
                },
                new NBAPlayer
                {
                    Id = 2,
                    PlayerName = "Kevin Durant",
                    TeamName = "Nets",
                    PointsPerGame = 30.7M
                },
                new NBAPlayer
                {
                    Id = 3,
                    PlayerName = "Luka Doncic",
                    TeamName = "Mavericks",
                    PointsPerGame = 27.9M
                },
                new NBAPlayer
                {
                    Id = 5,
                    PlayerName = "Steph Curry",
                    TeamName = "Warriors",
                    PointsPerGame = 31.2M
                },
                new NBAPlayer
                {
                    Id = 6,
                    PlayerName = "Trae Young",
                    TeamName = "Hawks",
                    PointsPerGame = 27.7M
                }
            );
            context.SaveChanges();
        }
    }
}
