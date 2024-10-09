using System;
using System.Collections.Generic;

namespace ApiGap.Models;

public partial class Action
{
    public string Id { get; set; } = null!;

    public string Name { get; set; } = null!;

    public string Description { get; set; } = null!;

    public DateTime StartDate { get; set; }

    public DateTime EndDate { get; set; }

    public string Status { get; set; } = null!;

    public string? Avatar { get; set; }

    public string Type { get; set; } = null!;

    public string IdUnity { get; set; } = null!;

    public DateTime CreatedAt { get; set; }

    public DateTime UpdatedAt { get; set; }

    public string? IdDocumentation { get; set; }

    public virtual ICollection<Actioncollaborator> Actioncollaborators { get; set; } = new List<Actioncollaborator>();

    public virtual ICollection<Documentation> Documentations { get; set; } = new List<Documentation>();

    public virtual Unity IdUnityNavigation { get; set; } = null!;

    public virtual ICollection<Meeting> Meetings { get; set; } = new List<Meeting>();

    public virtual ICollection<Step> Steps { get; set; } = new List<Step>();
}
