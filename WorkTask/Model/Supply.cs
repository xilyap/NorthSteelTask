﻿using System;
using System.Collections.Generic;

namespace WorkTask.Model;

public partial class Supply
{
    public int Id { get; set; }

    public DateTime Date { get; set; }

    public int? ProviderId { get; set; }

    public virtual Provider? Provider { get; set; }

    public virtual ICollection<SupplyGood> SupplyGoods { get; set; } = new List<SupplyGood>();
}
