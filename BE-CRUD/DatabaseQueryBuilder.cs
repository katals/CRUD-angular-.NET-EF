using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using BE_CRUD.Models;

namespace BE_CRUD;

public class DatabaseQueryBuilder : DbContext
{
    public DbSet<Pet> Pets { get; set; }

    public DatabaseQueryBuilder(DbContextOptions<DatabaseQueryBuilder> options)
        : base(options) { }

    protected override void OnModelCreating(ModelBuilder builder)
    {
        List<Pet> PetsInit = new List<Pet>();
        PetsInit.Add(
            new Pet()
            {
                Id = 1,
                Name = "Michaelo",
                Color = "gris",
                Race = "Pinscher",
                Weight = 10,
                Age = 2
            }
        );

        builder.Entity<Pet>(pet =>
        {
            pet.ToTable("Pet");
            pet.HasKey(p => p.Id);
            pet.Property(p => p.Age).IsRequired();
            pet.Property(p => p.Weight);
            pet.Property(p => p.Name).IsRequired();
            pet.Property(p => p.Color).IsRequired();
            pet.Property(p => p.Race).IsRequired();
            pet.Property(p => p.CreationDate).IsRequired();
            pet.HasData(PetsInit);
        });
    }
}
