﻿// <auto-generated> This file has been auto generated by EF Core Power Tools. </auto-generated>
#nullable disable
using System;
using System.Collections.Generic;

namespace CarWashBackend.Models;

public partial class Vehiculo
{
    public string id { get; set; }

    public string cliente_id { get; set; }

    public string placa { get; set; }

    public string modelo { get; set; }

    public string marca { get; set; }

    public string color { get; set; }

    public bool? activo { get; set; }

    public DateTime? created_at { get; set; }

    public DateTime? updated_at { get; set; }

    public virtual ICollection<RegistroServicio> RegistroServicios { get; set; } = new List<RegistroServicio>();

    public virtual Cliente cliente { get; set; }
}