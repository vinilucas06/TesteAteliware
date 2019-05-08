using Microsoft.EntityFrameworkCore;
using PortalTest.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PortalTest.Data
{
    public class TesteContext : DbContext
    {
        public TesteContext(DbContextOptions<TesteContext> options) : base(options)
        {
        }

        /*
         create table Teste(Id bigint,
	Name varchar(100),
	Description varchar(500),
	LastUpdated DateTimeOffset,
	Url varchar(100),
	WatchCount int,
	Language varchar(100)) 
             */
        public DbSet<GitRepositorie> GitRepositorie { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<GitRepositorie>().ToTable("Teste");
        }


    }
}
