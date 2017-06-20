using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Andrey_8.Models
{
    public class Cliente
    {
        public long ClienteId { get; set; }
        public string Nome { get; set; }
        public long Cpf { get; set; }
        public string Email { get; set; }

        public virtual ICollection<Cadastro> Cadastros { get; set; }
    }
}