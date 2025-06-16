using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

public class TaskLog
{
    [Key]
    public int Id { get; set; }

    [Required]
    public int TaskItemId { get; set; }

    [ForeignKey("TaskItemId")]
    public virtual TaskItem Task { get; set; }

    public DateTime Timestamp { get; set; } = DateTime.Now;

    [StringLength(1000)]
    public string Message { get; set; }

    public string StatusSnapshot { get; set; }
}
