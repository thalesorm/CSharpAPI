using System;
using System.Collections.Generic;

namespace ApiGap.Models;

public partial class Collaboratortotechnology
{
    public string A { get; set; } = null!;

    public string B { get; set; } = null!;

    public virtual Collaborator ANavigation { get; set; } = null!;

    public virtual Technology BNavigation { get; set; } = null!;
}
