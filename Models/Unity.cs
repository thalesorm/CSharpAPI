using System;
using System.Collections.Generic;

namespace ApiGap.Models;

public partial class Unity
{
    public string Id { get; set; } = null!;

    public string Name { get; set; } = null!;

    public string Alias { get; set; } = null!;

    public DateTime CreatedAt { get; set; }

    public DateTime UpdatedAt { get; set; }

    public virtual ICollection<Action> Actions { get; set; } = new List<Action>();

    public virtual ICollection<User> Users { get; set; } = new List<User>();
}
