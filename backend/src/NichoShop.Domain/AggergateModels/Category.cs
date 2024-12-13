using NichoShop.Domain.SeedWork;

public class Category : AggregateRoot<int>
{
    public string Name { get; private set; }

    public string DisplayName { get; private set; }

    private readonly List<Category> _children = [];

    public Category(int id, string name, string displayName, int? parentId)
    {
        Id = id;
        Name = name;
        DisplayName = displayName;
        ParentId = parentId;
    }

    public IReadOnlyCollection<Category> Children => _children.AsReadOnly();

    public bool HasChildren => _children.Count > 0;

    public int? ParentId { get; private set; }
    public Category? Parent { get; private set; }

    private void SetParent(Category parent)
    {
        Parent = parent;
    }

    public void AddChild(Category category)
    {
        category.SetParent(this);
        _children.Add(category);
    }
}
