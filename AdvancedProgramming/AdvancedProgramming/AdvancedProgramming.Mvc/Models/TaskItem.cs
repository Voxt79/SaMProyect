using AdvancedProgramming.Mvc.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

public class TaskItem
{
    [Key]
    public int Id { get; set; }

    [Required]
    [StringLength(200)]
    public string Name { get; set; }

    [StringLength(1000)]
    public string Description { get; set; }

    [Required]
    public TaskPriority Priority { get; set; }

    [Required]
    public TaskStatus Status { get; set; } = TaskStatus.Pending;

    [Required]
    public DateTime ScheduledDate { get; set; }

    public DateTime? StartTime { get; set; }

    public DateTime? EndTime { get; set; }

    public string FailureReason { get; set; }

    // Navigation Property
    public virtual ICollection<TaskLog> Logs { get; set; }
}
