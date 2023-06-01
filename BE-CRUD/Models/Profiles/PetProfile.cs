using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;

namespace BE_CRUD.Models.Profiles;

public class PetProfile : Profile
{
    public PetProfile()
    {
        CreateMap<Pet, PetDTO>();
        CreateMap<PetDTO, Pet>();
    }
}
