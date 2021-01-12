using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using ProgramareProiect.Models;

namespace ProgramareProiect.Data
{
    public class LibraryContext : DbContext
    {
        public LibraryContext(DbContextOptions<LibraryContext> options) :
       base(options)
        {
        }
        public DbSet<Client> Clienti { get; set; }
        public DbSet<Rezervare> Rezervari { get; set; }
        public DbSet<Camera> Camere { get; set; }
        public DbSet<Factura> Facturi { get; set; }
        public DbSet<Proprietar> Proprietari { get; set; }
        public DbSet<CameraInchiriata> CamereInchiriate { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Client>().ToTable("Client");
            modelBuilder.Entity<Rezervare>().ToTable("Rezervare");
            modelBuilder.Entity<Camera>().ToTable("Camera");
            modelBuilder.Entity<Factura>().ToTable("Factura");
            modelBuilder.Entity<Proprietar>().ToTable("Proprietar");
            modelBuilder.Entity<CameraInchiriata>().ToTable("CameraInchiriata");

            modelBuilder.Entity<CameraInchiriata>()
 .HasKey(c => new { c.CameraID, c.ProprietarID });//configureaza cheia primara compusa
        }
    }
}
