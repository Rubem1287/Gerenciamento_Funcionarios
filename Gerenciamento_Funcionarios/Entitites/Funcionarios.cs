using System;
using System.Collections.Generic;
using System.Text;

namespace Gerenciamento_Funcionarios.Entitites
{
    class Funcionarios
    {
        public string Nome { get; set; }
        public string Email { get; set; }
        public double Salario { get; set; }


        public Funcionarios(string nome, string email, double salario)
        {
            Nome = nome;
            Email = email;
            Salario = salario;

        }

    }
}
