﻿using System;
using System.Collections.Generic;

namespace WorkTask.Model;

public partial class SupplyGood
{
    public int Id { get; set; }

    public int? SupplyId { get; set; }

    public int? GoodId { get; set; }

    public int Weight { get; set; }

    public int Price { get; set; }

    public virtual Good? Good { get; set; }

    public virtual Supply? Supply { get; set; }
}