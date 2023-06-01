using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Text;
using AutoMapper;

using BE_CRUD.Models;
using Microsoft.EntityFrameworkCore;
using BE_CRUD.Models.Profiles;

namespace BE_CRUD.Services;

public class PetService : IPetsService
{
    protected readonly DatabaseQueryBuilder _context;
    protected readonly IMapper _mapper;

    public PetService(DatabaseQueryBuilder context, IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }

    public async Task<PetDTO> GetOne(int id)
    {
        var actualPet = await _context.Pets.FirstOrDefaultAsync(x => x.Id == id);
        var petDto = _mapper.Map<PetDTO>(actualPet);
        return petDto;
    }

    public async Task<IEnumerable<PetDTO>> GetAll()
    {
        var pets = await _context.Pets.ToListAsync();
        var listPetsDto = _mapper.Map<IEnumerable<PetDTO>>(pets);
        return listPetsDto;
    }

    public async Task Post(PetDTO petDto)
    {
        var pet = _mapper.Map<Pet>(petDto);
        pet.CreationDate = DateTime.Now;
        _context.Add(pet);
        await _context.SaveChangesAsync();
        var petItemDto = _mapper.Map<PetDTO>(pet);
    }

    public async Task Update(int id, PetDTO petDto)
    {
        var pet = _mapper.Map<Pet>(petDto);

        var petItem = await _context.Pets.FindAsync(id);

        if (petItem != null)
        {
            petItem.Name = pet.Name;
            petItem.Age = pet.Age;
            petItem.Race = pet.Race;
            petItem.Weight = pet.Weight;
            petItem.Color = pet.Color;
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
    Task<PetDTO> GetOne(int id);
    Task<IEnumerable<PetDTO>> GetAll();
    Task Post(PetDTO petDto);
    Task Update(int id, PetDTO petDto);
    Task<bool> Delete(int id);
}
