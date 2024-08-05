using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace EventManagementSystem.Models;

public partial class Event
{
    public int Id { get; set; }
    public string Name { get; set; } = null!;
    public string? Description { get; set; }
    public DateTime StartDate { get; set; }
    public DateTime EndDate { get; set; }
    public string? Location { get; set; }
    public string? Organizer { get; set; }
    public virtual ICollection<Registration> Registrations { get; set; } = new List<Registration>();
}
