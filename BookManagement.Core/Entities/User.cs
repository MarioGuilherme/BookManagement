namespace BookManagement.Core.Entities;

public class User(string name, string email) : IEntityBase {
    public int Id { get; private set; }
    public string Name { get; private set; } = name;
    public string Email { get; private set; } = email;
}