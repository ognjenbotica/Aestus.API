﻿// <auto-generated> This file has been auto generated by EF Core Power Tools. </auto-generated>
#nullable disable
using System;
using System.Collections.Generic;

namespace Aestus.API.Data;

public partial class SettingVersion
{
    public int VersionId { get; set; }

    public int? SettingId { get; set; }

    public decimal Value { get; set; }

    public DateTime StartDate { get; set; }

    public DateTime? EndDate { get; set; }

    public virtual Setting Setting { get; set; }
}