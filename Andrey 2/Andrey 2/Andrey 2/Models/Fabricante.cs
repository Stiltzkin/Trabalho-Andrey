﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Andrey_2.Models
{
    public class Fabricante
    {
        public long FabricanteId { get; set; }
        public string Nome { get; set; }

        public virtual ICollection<Produto> Produtos { get; set; }
    }
}