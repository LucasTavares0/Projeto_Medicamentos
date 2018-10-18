using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Medicamentos_V1
{
    class Program
    {
        static void Main(string[] args)
        {
            //O metodo main sera utilizado para chamar itens da classe view
            //aqui será criado somente o menu interativo
            //as demais mensagem serão tratadas na classe View
            int escolha = -1;
            View v = new View();

            do
            {
                escolha = Program.menu();

                //tratamento da escolha realizada
                switch (escolha)
                {
                    case 0: System.Environment.Exit(0); break;
                    case 1: v.cadastrarMedicamento(); break;
                    case 2: v.consultarMedicamentoS(); break;
                    case 3: v.consultarMedicamentoA(); break;
                    case 4: v.comprarMedicamento(); break;
                    case 5: v.venderMedicamento(); break;
                    case 6: v.listarMedicamentos(); break;
                    default: Console.Clear(); Console.WriteLine("\nEscolha Inválida!!"); Console.ReadKey(); break;
                }
            }
            while (escolha != 0);
        }

        //Menu interativo
        public static int menu()
        {
            int escolha = 0;

            try
            {
                Console.Clear();
                Console.WriteLine("========== CONTROLE DE MEDICAMENTOS ==========");
                Console.WriteLine("\n");
                Console.WriteLine("0 - Finalizar Processo");
                Console.WriteLine("1 - Cadastrar Medicamento");
                Console.WriteLine("2 - Consultar Medicamento (Sintético)");
                Console.WriteLine("3 - Pesquisar Medicamento (Analítico)");
                Console.WriteLine("4 - Comprar Medicamento (Cadastrar lote)");
                Console.WriteLine("5 - Vender Medicamento (Abater lote mais antigo)");
                Console.WriteLine("6 - Listar Medicamentos (Dados Sintéticos)");
                escolha = int.Parse(Console.ReadLine());
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }

            return escolha;
        }
    }
}
