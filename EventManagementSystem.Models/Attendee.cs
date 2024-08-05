﻿using System;
using System.Collections.Generic;

namespace EventManagementSystem.Models;

public partial class Attendee
{
    public int Id { get; set; }
    public string Name { get; set; } = null!;
    public string Email { get; set; } = null!;
    public virtual ICollection<Registration> Registrations { get; set; } = new List<Registration>();
}
