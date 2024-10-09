using System;
using System.Collections.Generic;

namespace ApiGap.Models;

public partial class Meeting
{
    public string Id { get; set; } = null!;

    public string Topic { get; set; } = null!;

    public string? Description { get; set; }

    public DateTime Date { get; set; }

    public string IdAction { get; set; } = null!;

    public DateTime CreatedAt { get; set; }

    public DateTime UpdatedAt { get; set; }

    public virtual Action IdActionNavigation { get; set; } = null!;

    public virtual ICollection<Pending> Pendings { get; set; } = new List<Pending>();
}
