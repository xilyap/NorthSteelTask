using System;
using System.Collections.Generic;

namespace WorkTask.Model;

public partial class Good
{
    public int Id { get; set; }

    public int? ProviderId { get; set; }

    public string Name { get; set; } = null!;

    public virtual Provider? Provider { get; set; }

    public virtual ICollection<SupplyGood> SupplyGoods { get; set; } = new List<SupplyGood>();
}
