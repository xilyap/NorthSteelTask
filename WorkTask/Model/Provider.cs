using System;
using System.Collections.Generic;

namespace WorkTask.Model;

public partial class Provider
{
    public int Id { get; set; }

    public string? Name { get; set; }

    public virtual ICollection<Good> Goods { get; set; } = new List<Good>();

    public virtual ICollection<Supply> Supplies { get; set; } = new List<Supply>();
}
