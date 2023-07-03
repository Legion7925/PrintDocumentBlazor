namespace PrintDocument.Core.Entities;

public class Category
{
    public int Id { get; set; }

    public int? ParentId { get; set; }

    public string? Name { get; set; }

    public Category? Parent { get; set; }

    public ICollection<Category> ChildCategories { get; set; } = new HashSet<Category>();

    public ICollection<Document> Documents { get; set; } = new HashSet<Document>();
}

public class CategoryReport : Category
{
    public HashSet<CategoryReport> CategoryChildren = new HashSet<CategoryReport>();

    public HashSet<Document> DocumentChildren = new HashSet<Document>();

    public bool IsExpanded { get; set; } = false;

    public bool HasChild => CategoryChildren != null && CategoryChildren.Count > 0;

    public bool HasDocument => Documents != null && Documents.Count > 0;
}
