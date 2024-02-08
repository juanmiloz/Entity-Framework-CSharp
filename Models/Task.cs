using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Fundamentos_de_Entity_Framework.Models;

public class Task
{
    //[Key] <-- Fluent API remplaza estos data annotation
    public Guid TaskId { get; set; }
    
    [ForeignKey("CategoryId")]
    public Guid CategoryId { get; set; }
    
    //[Required]<-- Fluent API remplaza estos data annotation
    //[MaxLength(200)]<-- Fluent API remplaza estos data annotation
    public string Title { get; set; }
    public string  Description { get; set; }
    public Priority Priority { get; set; }
    public DateTime CreationDate { get; set; }
    public virtual Category Category { get; set; }
    
    //[NotMapped] //<- omite el campo en el momento que se genere la base de datos
    public string Resume { get; set; }
}