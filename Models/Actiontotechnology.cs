using System;
using System.Collections.Generic;

namespace ApiGap.Models;

public partial class Actiontotechnology
{
    public string A { get; set; } = null!;

    public string B { get; set; } = null!;

    public virtual Action ANavigation { get; set; } = null!;

    public virtual Technology BNavigation { get; set; } = null!;
}
