namespace BE_CRUD.Models;

public class Pet
{
    public int Id { get; set; }
    public int Age { get; set; }
    public int Weight { get; set; }
    public string Name { get; set; }
    public string Race { get; set; }
    public string Color { get; set; }
    public DateTime CreationDate { get; set; }
}
