namespace MyShop.Domain.AggregateModels.RoleAggregate.Models;

public class Role : AggregateRoot<long>
{
    public string Name { get; private set; }
    
    public string Description { get; private set; }

    public Role(string name, string description)
    {
        Name = name;
        Description = description;
    }
}   