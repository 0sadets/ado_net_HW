using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WH2_EntityFramework
{
    public class MusicDbContext :DbContext
    {
        public MusicDbContext()
        {
            this.Database.EnsureDeleted();
            this.Database.EnsureCreated();
        }
        public DbSet<Artist> Artists { get; set; }
        public DbSet<Trek> Treks { get; set; }
        public DbSet<Album> Albums { get; set; }
        public DbSet<Playlist> Playlists { get; set; }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);


            optionsBuilder.UseSqlServer(@"Data Source = localhost\SQLEXPRESS;
                                 Initial Catalog= MusicDb;
                                 Integrated Security=true;
                                 Connect Timeout = 2;Encrypt=False;
                                 Trust Server Certificate=False;
                                 Application Intent=ReadWrite;
                                 Multi Subnet Failover=False");
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<Artist>().HasData(
                new Artist[]
                {
                    new Artist()
                    {
                        Id = 1,
                        Name = "Conan",
                        Lastname = "Gray",
                        Country = "USA"

                    },
                    new Artist()
                    {
                        Id = 2,
                        Name = "Henry",
                        Lastname = "Morris",
                        Country = "USA"
                    },
                    new Artist()
                    {
                        Id = 3,
                        Name = "Dutch",
                        Lastname = "Melrose",
                        Country = "USA"
                    }
                }
             );
            modelBuilder.Entity<Album>().HasData(
                new Album[]
                {
                    new Album()
                    {
                        Id = 1,
                        Name = "Superache",
                        ArtistId = 1,
                        Year = 2022,
                        Genre ="Pop"
                    },
                    new Album()
                    {
                        Id = 2,
                        Name = "Jawbreaker",
                        ArtistId = 2,
                        Year = 2024,
                        Genre ="punk rock"
                    },
                    new Album()
                    {
                        Id = 3,
                        Name = "RUSH",
                        ArtistId = 3,
                        Year = 2023,
                        Genre ="Indie"
                    },
                }   
                
             );
            modelBuilder.Entity<Trek>().HasData(
                new Trek[]
                {
                    new Trek()
                    {
                        Id = 1,
                        Name = "People Watching",
                        Duration = "2:39",
                        AlbumId = 1 
                    },
                    new Trek()
                    {
                        Id = 2,
                        Name = "Family Line",
                        Duration = "3:36",
                        AlbumId = 1
                    },
                    new Trek()
                    {
                        Id = 3,
                        Name = "Jigsaw",
                        Duration = "3:29",
                        AlbumId = 1
                    },
                    new Trek()
                    {
                        Id = 4,
                        Name = "Dirty Magazine",
                        Duration = "3:28",
                        AlbumId = 2
                    },
                    new Trek()
                    {
                        Id = 5,
                        Name = "Sween N Low",
                        Duration = "3:00",
                        AlbumId = 2
                    },
                    new Trek()
                    {
                        Id = 6,
                        Name = "King of Saying Sorry",
                        Duration = "4:03",
                        AlbumId = 2
                    },
                    new Trek()
                    {
                        Id = 7,
                        Name = "Rush",
                        Duration = "2:52",
                        AlbumId = 3
                    },
                });
            modelBuilder.Entity<Playlist>().HasData(
                new Playlist[]
                {
                    new Playlist()
                    {
                        Id = 1,
                        Category = "Music",
                        Title = "Sleep",
                    },
                    new Playlist()
                    {
                        Id = 2,
                        Category = "Music",
                        Title = "Work",
                    },
                });
        }

    }
    [Table("Artists")]
    public class Artist
    {
        public int Id { get; set; }
        [Required, MaxLength(100)]
        public string Name { get; set; }
        [Required, MaxLength(100)]
        public string Lastname { get; set; }
        [Required, MaxLength(100)]
        public string Country {  get; set; }
        public ICollection<Album> Albums { get; set; }
    }
    [Table("Albums")]
    public class Album
    {
        public int Id { get; set; }
        [Required, MaxLength(100)]
        public string Name { get; set; }
        public Artist Artist {  get; set; }
        public int ArtistId { get; set; }
        public int Year { get; set; }
        [Required, MaxLength(100)]
        public string Genre { get; set; }
        public ICollection<Trek> Treks { get; set; }
    }
    public class Trek
    {
        public int Id { get; set; }
        [Required, MaxLength(100)]
        public string Name { get; set; }
        public string Duration { get ; set; }
        
        public Album Album { get; set; }
        public int AlbumId { get; set; }
        public ICollection<Playlist> Playlists { get; set; }
    }
   [Table("Playlists")]
    public class Playlist
    {
        public int Id { get; set; }
        [Required, MaxLength(100)]
        public string Title { get; set; }
        [Required, MaxLength(100)]
        public string Category { get; set; }
        public ICollection<Trek> treks { get; set; }
    }

}
