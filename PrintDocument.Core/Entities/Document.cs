using System.ComponentModel.DataAnnotations.Schema;

namespace PrintDocument.Core.Entities;

public class Document
{
    public int Id { get; set; }

    public string Title { get; set; } = string.Empty;

    [Column(TypeName = "ntext")]
    public required string PlainText { get; set; }

    public int CategoryId { get; set; }

    public Category? Category { get; set; }
}
