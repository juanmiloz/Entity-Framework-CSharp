using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace Fundamentos_de_Entity_Framework.Models;

public class Category
{
    //[Key] <-- Fluent API remplaza estos data annotation 
    public Guid CategoryId { get; set; }
    
    //[Required] <-- Fluent API remplaza estos data annotation
    //[MaxLength(150)] <-- Fluent API remplaza estos data annotation
    public string Name { get; set; }
    public string Description { get; set; }
    public int Weight { get; set; }
    [JsonIgnore]
    public virtual ICollection<Task> Tasks { get; set; }
}