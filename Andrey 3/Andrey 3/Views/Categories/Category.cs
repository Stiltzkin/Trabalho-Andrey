﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Andrey_3.Views.Categories
{
    public class Category
    {
        public long CategoryId { get; set; }
        public string Name { get; set; }
        public long CategoriaId { get; internal set; }

        public virtual ICollection<Product> Products { get; set; }
    }
}