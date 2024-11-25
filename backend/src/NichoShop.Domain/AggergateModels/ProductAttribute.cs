using NichoShop.Domain.SeedWork;

namespace NichoShop.Domain.AggergateModels;
public class ProductAttribute(string name, string displayName, int? parentId, bool mandatory, int valueId) : AggregateRoot<int>
{
    public string Name { get; private set; } = name;

    public int ValueId { get; private set; } = valueId;

    public string DisplayName { get; private set; } = displayName;

    public int? ParentId { get; private set; } = parentId;
    public ProductAttribute? Parent { get; private set; }
    
    private readonly List<ProductAttribute> _children = [];
    public IReadOnlyCollection<ProductAttribute> Children => _children.AsReadOnly();

    public bool Mandatory { get; private set; } = mandatory;
}
