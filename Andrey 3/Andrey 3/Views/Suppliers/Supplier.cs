using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Andrey_3.Views.Categories
{
    public class Supplier
    {
        public long SupplierId { get; set; }
        public string Name { get; set; }

        public virtual ICollection<Product> Products { get; set; }
    }
}