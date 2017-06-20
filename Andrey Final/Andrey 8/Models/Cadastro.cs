using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Andrey_8.Models
{
    public class Cadastro
    {
        public long? CadastroId { get; set; }
        public long NumeroCadastro { get; set; }
        public long? CoberturaId { get; set; }
        public long? ClienteId { get; set; }
        public Cobertura Cobertura { get; set; }
        public Cliente Cliente { get; set; }
    }
}