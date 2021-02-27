using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using GendacHashProduct.Models;
using Microsoft.EntityFrameworkCore;

namespace GendacHashProduct.Data
{
    public class NBAPlayerContext : DbContext
    {
        public NBAPlayerContext(DbContextOptions<NBAPlayerContext> options) : base(options)
        {
        }
        public DbSet<NBAPlayer> NBAPlayers { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<NBAPlayer>().ToTable("NBAPlayer");
        }
    }

}
