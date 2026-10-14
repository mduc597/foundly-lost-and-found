using System.ComponentModel.DataAnnotations;
namespace Foundly.Sprint1.Domain;
public class Student
{
    public Guid Id { get; set; } = Guid.NewGuid();
    [MaxLength(180)] public string Email { get; set; } = "";
    [MaxLength(120)] public string FullName { get; set; } = "";
    public string PasswordHash { get; set; } = "";
}
public class Category
{
    public int Id { get; set; }
    [MaxLength(80)] public string Name { get; set; } = "";
}
public class CampusLocation
{
    public int Id { get; set; }
    [MaxLength(100)] public string Name { get; set; } = "";
}
public class ItemReport
{
    public Guid Id { get; set; } = Guid.NewGuid();
    public Guid UserId { get; set; }
    public Student? User { get; set; }
    [MaxLength(8)] public string Type { get; set; } = "LOST";
    [MaxLength(140)] public string ItemName { get; set; } = "";
    [MaxLength(1500)] public string Description { get; set; } = "";
    public int CategoryId { get; set; }
    public Category? Category { get; set; }
    public int LocationId { get; set; }
    public CampusLocation? Location { get; set; }
    public DateTime EventTime { get; set; }
    [MaxLength(16)] public string Status { get; set; } = "OPEN";
    public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
    public DateTime UpdatedAt { get; set; } = DateTime.UtcNow;
}
