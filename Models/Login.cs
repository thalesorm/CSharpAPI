using System;
using System.Collections.Generic;

namespace ApiGap.Models;

public partial class Login
{
    public string Id { get; set; } = null!;

    public string IpUser { get; set; } = null!;

    public string IdUser { get; set; } = null!;

    public DateTime CreatedAt { get; set; }

    public virtual User IdUserNavigation { get; set; } = null!;
}
