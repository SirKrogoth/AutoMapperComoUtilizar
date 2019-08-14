using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharpAutoMapper
{
    public class Aluno
    {
        public string Nome { get; set; }
        public string Email { get; set; }
        public Endereco Endereco { get; set; }
        public string Genero { get; set; }
        public int Idade { get; set; }
        public DateTime Nascimento { get; set; }

    }
}
