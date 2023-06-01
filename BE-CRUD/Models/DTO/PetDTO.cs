using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BE_CRUD.Models.Profiles;

public class PetDTO
{
    public int Id { get; set; }
    public int Age { get; set; }
    public int Weight { get; set; }
    public string Name { get; set; }
    public string Race { get; set; }
    public string Color { get; set; }
}
