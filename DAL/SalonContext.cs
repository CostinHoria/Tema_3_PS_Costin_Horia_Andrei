using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
//using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using Tema2_NoLogin.Models;
//using DbContext = Microsoft.EntityFrameworkCore.DbContext;


namespace Tema2_NoLogin.DAL
{
    public class SalonContext : DbContext
    {
        /*protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
            //modelBuilder.UseSqlServer(@"Server=.\SQLEXPRESS;Database=SchoolDB;Trusted_Connection=True;");
        }*/
        
        public SalonContext(DbContextOptions<SalonContext> options)
            : base(options){
        }
        public DbSet<User> Users { get; set; }
        public DbSet<Service> Services { get; set; }
        public DbSet<Appointment> Appointments { get; set; }

        /*protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(
                @"Server=(localdb)\mssqllocaldb;Database=Blogging;Integrated Security=True");
        }*/
        /*protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder
        }*/
    }
}
