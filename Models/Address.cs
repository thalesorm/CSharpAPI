using System;
using System.Collections.Generic;

namespace ApiGap.Models;

public partial class Address
{
    public string Id { get; set; } = null!;

    public string Street { get; set; } = null!;

    public string Number { get; set; } = null!;

    public string? Complement { get; set; }

    public string District { get; set; } = null!;

    public string City { get; set; } = null!;

    public string State { get; set; } = null!;

    public string ZipCode { get; set; } = null!;

    public DateTime CreatedAt { get; set; }

    public DateTime UpdatedAt { get; set; }

    public virtual ICollection<Collaborator> Collaborators { get; set; } = new List<Collaborator>();
}
