using System;
using System.Collections.Generic;

namespace ApiGap.Models;

public partial class Technology
{
    public string Id { get; set; } = null!;

    public string Name { get; set; } = null!;

    public DateTime CreatedAt { get; set; }

    public DateTime UpdatedAt { get; set; }
}
