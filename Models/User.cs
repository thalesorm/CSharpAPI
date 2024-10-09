using System;
using System.Collections.Generic;

namespace ApiGap.Models;

public partial class User
{
    public string Id { get; set; } = null!;

    public string Name { get; set; } = null!;

    public string Job { get; set; } = null!;

    public string Email { get; set; } = null!;

    public string Password { get; set; } = null!;

    public string? Avatar { get; set; }

    public string Status { get; set; } = null!;

    public string Role { get; set; } = null!;

    public string IdUnity { get; set; } = null!;

    public DateTime CreatedAt { get; set; }

    public DateTime UpdatedAt { get; set; }

    public virtual ICollection<Actioncollaborator> Actioncollaborators { get; set; } = new List<Actioncollaborator>();

    public virtual ICollection<Collaborator> Collaborators { get; set; } = new List<Collaborator>();

    public virtual Unity IdUnityNavigation { get; set; } = null!;

    public virtual ICollection<Login> Logins { get; set; } = new List<Login>();

    public virtual ICollection<Log> Logs { get; set; } = new List<Log>();
}
