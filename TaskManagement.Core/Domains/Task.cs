using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TaskManagement.Core.Domains;

public class BaseEntity
{
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int Id { get; set; }

}
public class AuditableEntity : BaseEntity
{
    public Guid CreatedByUser { get; set; }
    public Guid UpdatedByUser { get; set; }
    public Guid DeletedtedByUser { get; set; }
    public DateTime CreateDate { get; set; }
    public DateTime UpdateDate { get; set; }
    public DateTime DeleteDate { get; set; }
    public bool IsDeleted { get; set; }
}


public class TaskModel : AuditableEntity
{
    [Display(Name = "Task Name")]
    public string TaskName { get; set; }
    [Display(Name ="Progress")]
    [DisplayFormat(DataFormatString="decimal(18,4)")]
    public decimal Progress { get; set; }
}
