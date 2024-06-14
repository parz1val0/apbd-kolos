using Kol2.Models;
using Microsoft.EntityFrameworkCore;

namespace Kol2.Data;

public class CharacterContext: DbContext
{
    protected CharacterContext()
    {
    }

    public CharacterContext(DbContextOptions options) : base(options)
    {
    }
    public DbSet<Items> Items { get; set; }
    public DbSet<Characters> Characters { get; set; }
    public DbSet<Backpacks> Backpacks { get; set; }
    public DbSet<Titles> Titles { get; set; }
    public DbSet<CharacterTitels> CharacterTitels { get; set; }
    
   protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Backpacks>().HasData(new List<Backpacks>
            {
                new Backpacks
                {
                    CharacterId = 1,
                    ItemId = 1,
                    Amount = 11
                },
                new Backpacks
                {
                    CharacterId = 2,
                    ItemId = 2,
                    Amount = 8
                }
            });

            modelBuilder.Entity<Items>().HasData(new List<Items>
            {
                new Items()
                {
                    id = 1,
                    Name = "Burger",
                    Weight = 2
                },
                new Items()
                {
                    id = 2,
                    Name = "Cola",
                    Weight = 1
                }
            });
            modelBuilder.Entity<Titles>().HasData(new List<Titles>
            {
                new Titles
                {
                    id = 1,
                    Name = "Title-1"
                },
                new Titles
                {
                    id= 2,
                    Name = "Title-2"
                }
            });
            modelBuilder.Entity<Characters>().HasData(new List<Characters>
            {
                new Characters()
                {
                    id = 1,
                    FirstName = "Piotr",
                    LastName = "Kowalski",
                    CurrentWeight = 12,
                    MaxWeight = 60
                },
                new Characters()
                {
                    id = 2,
                    FirstName = "Andrii",
                    LastName = "Demianchuk",
                    CurrentWeight = 11,
                    MaxWeight = 59
                }
            });
            modelBuilder.Entity<CharacterTitels>().HasData(new List<CharacterTitels>
            {
                new CharacterTitels
                {
                    CharacterId = 1,
                    TitelsId = 1,
                    AcquiredAt = DateTime.Parse("2022-10-17")
                },
                new CharacterTitels
                {
                    CharacterId = 2,
                    TitelsId = 2,
                    AcquiredAt = DateTime.Parse("2020-06-05")
                }
            });
        }
    }