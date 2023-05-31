using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Text;

using BE_CRUD.Models;
using Microsoft.EntityFrameworkCore;

namespace BE_CRUD.Services;

public class PetService : IPetsService
{
    protected readonly DatabaseQueryBuilder _context;

    public PetService(DatabaseQueryBuilder context)
    {
        _context = context;
    }

    public async Task<Pet> GetOne(int id)
    {
        var actualPet = await _context.Pets.FirstOrDefaultAsync(x => x.Id == id);

        return actualPet;
    }

    public IEnumerable<Pet> GetAll()
    {
        return _context.Pets;
    }

    public async Task Post(Pet pet)
    {
        pet.CreationDate = DateTime.Now;
        _context.Add(pet);
        await _context.SaveChangesAsync();
    }

    public async Task Update(int id, Pet pet)
    {
        var actualPet = await _context.Pets.FirstOrDefaultAsync(x => x.Id == id);

        if (actualPet != null)
        {
            actualPet.Name = pet.Name;
            actualPet.Age = pet.Age;
            actualPet.Race = pet.Race;
            actualPet.Weight = pet.Weight;
            actualPet.Color = pet.Color;
            await _context.SaveChangesAsync();
        }
    }

    public async Task<bool> Delete(int id)
    {
        var actualPet = await _context.Pets.FirstOrDefaultAsync(x => x.Id == id);

        if (actualPet != null)
        {
            _context.Remove(actualPet);
            await _context.SaveChangesAsync();
            return true;
        }
        return false;
    }
}

public interface IPetsService
{
    Task<Pet> GetOne(int id);
    IEnumerable<Pet> GetAll();
    Task Post(Pet pet);
    Task Update(int id, Pet pet);
    Task<bool> Delete(int id);
}
