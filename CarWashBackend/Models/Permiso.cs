﻿// <auto-generated> This file has been auto generated by EF Core Power Tools. </auto-generated>
#nullable disable
using System;
using System.Collections.Generic;

namespace CarWashBackend.Models;

public partial class Permiso
{
    public string id { get; set; }

    public string nombre { get; set; }

    public string descripcion { get; set; }

    public DateTime? created_at { get; set; }

    public DateTime? updated_at { get; set; }

    public bool? activo { get; set; }

    public virtual ICollection<Role> rols { get; set; } = new List<Role>();
}