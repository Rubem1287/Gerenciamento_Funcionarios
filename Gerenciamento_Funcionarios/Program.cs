using System;
using System.Globalization;
using System.Collections.Generic;
using Gerenciamento_Funcionarios.Entitites;
using System.IO;
using System.Linq;

namespace Gerenciamento_Funcionarios
{
    class Program
    {
        static void Main(string[] args)
        {
            //C:\Users\rubem\Documents\Cadastro.txt


                    //      Dados do arquivo

                    //Maria, maria@gmail.com,3200.00
                    //Alex,alex @gmail.com,1900.00
                    //Marco,marco @gmail.com,1700.00
                    //Bob,bob @gmail.com,3500.00
                    //Anna,anna @gmail.com,2800.00


            List<Funcionarios> funcionarios = new List<Funcionarios>();


            Console.Write("Digite o caminho completo do arquivo : ");
            string caminho = Console.ReadLine();
            Console.WriteLine();

            using (StreamReader arquivo = File.OpenText(caminho))
            {
                while (!arquivo.EndOfStream)
                {
                    string[] campos = arquivo.ReadLine().Split(',');
                    string nome = campos[0];
                    string email = campos[1];
                    double salario = double.Parse(campos[2], CultureInfo.InvariantCulture);

                    funcionarios.Add(new Funcionarios(nome, email, salario));
                }
            }

            //var salarioMaior = funcionarios.Where(p => p.Salario >= 2000.00).Select(p => p.Email);
            //imprimir("Email das pessoas com o salário maior que 2000.00", salarioMaior);

            var salarioMaior = funcionarios.Where(p => p.Salario >= 2000.00).OrderBy(p => p.Nome);
            Console.WriteLine("Email das pessoas com o salário maior que 2000.00");
            foreach (Funcionarios dados in salarioMaior)
            {
                Console.WriteLine(dados.Email);
            }

            Console.WriteLine();

            var letraM = funcionarios.Where(p => p.Nome[0] == 'M');
            double soma = 0;
            foreach (Funcionarios r in letraM)
            {
                soma += r.Salario;
            }

            Console.WriteLine("Soma dos salários com os nomes que começa com a letra 'M' : " + soma);
            //foreach(Funcionarios dados in funcionarios)
            //{
            //    Console.WriteLine(dados.Nome+", "+dados.Email+", "+dados.Salario);
            //}

            //    Console.Write("Entre com o salário : ");
            //double valor = double.Parse(Console.ReadLine(), CultureInfo.InvariantCulture);





            //Console.WriteLine("Email das pessoas com o salário maior que 2000.00");
            //foreach(Funcionarios dados in salarioMaior)
            //{
            //    Console.WriteLine(dados.Email);
            //}
        }

        static void imprimir<T>(string mensagem, IEnumerable<T> colecao)
        {
            Console.WriteLine(mensagem);
            foreach (T dados in colecao)
            {
                Console.WriteLine(dados);
            }
            Console.WriteLine();
        }
    }
}
