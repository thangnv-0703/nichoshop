using NichoShop.Domain.SeedWork;

public class Category(string name, string displayName, int? parentId) : AggregateRoot<int>
{
    public string Name { get; private set; } = name;

    public string DisplayName { get; private set; } = displayName;

    private readonly List<Category> _children = [];
    public IReadOnlyCollection<Category> Children => _children.AsReadOnly();

    public bool HasChildren => _children.Count > 0;

    public int? ParentId { get; private set; } = parentId;
    public Category? Parent { get; private set; }
}
