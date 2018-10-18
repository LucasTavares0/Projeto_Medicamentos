using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Medicamentos_V1
{
    class View
    {
        //atributos
        Medicamentos listaMedicamentos;

        //Contrutores
        public View()
        {
            this.listaMedicamentos = new Medicamentos();
        }

        //Métodos funcionais
        public void cadastrarMedicamento()
        {
            int id = 0;
            string nome, laboratorio;

            try
            {
                Console.Clear();
                Console.WriteLine("======== CADASTRO MEDICAMENTO =========");
                Console.WriteLine("\nID do Medicamento: ");
                id = int.Parse(Console.ReadLine());
            }
            catch (Exception e)
            {
                Console.Clear();
                Console.WriteLine(e.Message);
                Console.ReadKey();
                cadastrarMedicamento();
            }

            Medicamento aux = listaMedicamentos.pesquisarMedicamento(id);

            if (aux == null)
            {
                Console.WriteLine("\nNome do Medicamento: ");
                nome = Console.ReadLine();
                Console.WriteLine("\nLaboratório do Medicamento: ");
                laboratorio = Console.ReadLine();

                aux = new Medicamento(id, nome, laboratorio);
                listaMedicamentos.adicionarMedicamento(aux);
                Console.Clear(); Console.WriteLine("Medicamento cadastrado com sucesso! ");
                Console.ReadKey();
            }  
            else
            {
                Console.Clear();
                Console.WriteLine("Já exite um medicamento cadastrado com esse ID!");
                Console.ReadKey();
            }
        }
        public void consultarMedicamentoS()
        {
            int id = -1;

            try
            {
                Console.Clear();
                Console.WriteLine("======== PESQUISA MEDICAMENTO (Sintético)=========");
                Console.WriteLine("\nID do Medicamento: ");
                id = int.Parse(Console.ReadLine());
            }
            catch (Exception e)
            {
                Console.Clear();
                Console.WriteLine(e.Message);
                Console.ReadKey();
                consultarMedicamentoS();
            }

            Medicamento aux = listaMedicamentos.pesquisarMedicamento(id);

            if(aux == null)
            {
                Console.Clear();
                Console.WriteLine("Não existe nenhum medicamento com esse ID cadastrado!");
                Console.ReadKey();
            }
            else
            {
                Console.Clear();
                Console.WriteLine("\n" + aux.dadosMedicamento());
                Console.ReadKey();
            }
        }
        public void consultarMedicamentoA()
        {
            int id = -1;

            try
            {
                Console.Clear();
                Console.WriteLine("======== PESQUISA MEDICAMENTO (Analítico)=========");
                Console.WriteLine("\nID do Medicamento: ");
                id = int.Parse(Console.ReadLine());
            }
            catch (Exception e)
            {
                Console.Clear();
                Console.WriteLine(e.Message);
                Console.ReadKey();
                consultarMedicamentoA();
            }

            Medicamento aux = listaMedicamentos.pesquisarMedicamento(id);

            if (aux == null)
            {
                Console.Clear();
                Console.WriteLine("Não existe nenhum medicamento com esse ID cadastrado!");
                Console.ReadKey();
            }
            else
            {
                Console.Clear();
                Console.WriteLine("\n" + aux.dadosMedicamentoLote());
                Console.ReadKey();
            }
        }
        public void comprarMedicamento()
        {
            int id = -1;
            int id2 = -1, quant = 0, dia = 0, mes = 0, ano = 0;
            DateTime venc;

            try
            {
                Console.Clear();
                Console.WriteLine("======== EXECUTANDO COMPRA DE LOTE =========");
                Console.WriteLine("\nID do Medicamento: ");
                id = int.Parse(Console.ReadLine());
            }
            catch (Exception e)
            {
                Console.Clear();
                Console.WriteLine(e.Message);
                Console.ReadKey();
                cadastrarMedicamento();
            }

            Medicamento aux = listaMedicamentos.pesquisarMedicamento(id);

            if (aux == null)
            {
                Console.Clear();
                Console.WriteLine("Não existe nenhum medicamento com esse ID cadastrado!");
                Console.ReadKey();
            }
            else
            {
                try
                {
                    Console.Clear();
                    Console.WriteLine(aux.dadosMedicamento());
                    Console.WriteLine("\n\nID do Lote: ");
                    id2 = int.Parse(Console.ReadLine());
                }
                catch(Exception e)
                {
                    Console.Clear();
                    Console.WriteLine(e.Message);
                    Console.ReadKey();
                    comprarMedicamento();
                }

                Lote aux2 = aux.pesquisaLote(id2);

                if (aux2 == null)
                {
                    try
                    {
                        Console.WriteLine("\nQuantidade: ");
                        quant = int.Parse(Console.ReadLine());
                        Console.WriteLine("\nData de vencimento: ");
                        Console.WriteLine("\nDia: ");
                        dia = int.Parse(Console.ReadLine());
                        Console.WriteLine("\nMês: ");
                        mes = int.Parse(Console.ReadLine());
                        Console.WriteLine("\nAno: ");
                        ano = int.Parse(Console.ReadLine());
                    }
                    catch(Exception e)
                    {
                        Console.Clear();
                        Console.WriteLine(e.Message);
                        Console.ReadKey();
                        comprarMedicamento();
                    }

                    try
                    {
                        venc = new DateTime(ano, mes, dia);
                        aux2 = new Lote(id2, quant, venc);

                        listaMedicamentos.pesquisarMedicamento(id).comprarLote(aux2);
                        Console.Clear();
                        Console.WriteLine("Lote comprado com sucesso! ");
                        Console.ReadKey();
                    }
                    catch(Exception e)
                    {
                        Console.Clear();
                        Console.WriteLine(e.Message);
                        Console.ReadKey();
                        comprarMedicamento();
                    }
                }
                else
                {
                    Console.Clear();
                    Console.WriteLine("Já existe um lote cadastrado com esse ID! ");
                    Console.ReadKey();
                }
            }
        }
        public void venderMedicamento()
        {
            int id = -1;
            int quant = 0;

            try
            {
                Console.Clear();
                Console.WriteLine("======== EXECUTANDO VENDA DE MEDICAMENTO =========");
                Console.WriteLine("\nID do Medicamento: ");
                id = int.Parse(Console.ReadLine());
            }
            catch (Exception e)
            {
                Console.Clear();
                Console.WriteLine(e.Message);
                Console.ReadKey();
                cadastrarMedicamento();
            }

            Medicamento aux = listaMedicamentos.pesquisarMedicamento(id);

            if (aux == null)
            {
                Console.Clear();
                Console.WriteLine("Não existe nenhum medicamento com esse ID cadastrado!");
                Console.ReadKey();
            }
            else
            {
                try
                {
                    Console.WriteLine("\n");
                    Console.WriteLine(aux.dadosMedicamento());
                    Console.WriteLine("\nInforme a quantidade a ser vendida: ");
                    quant = int.Parse(Console.ReadLine());
                }
                catch (Exception e)
                {
                    Console.Clear();
                    Console.WriteLine(e.Message);
                    Console.ReadKey();
                    cadastrarMedicamento();
                }

                if(listaMedicamentos.pesquisarMedicamento(id).venderLote(quant))
                {
                    Console.Clear();
                    Console.WriteLine("Venda executada com sucesso! ");
                    Console.ReadKey();
                }
                else
                {
                    Console.Clear();
                    Console.WriteLine("Impossível vender. Quantidade não disponível!! ");
                    Console.ReadKey();
                }
            }
        }
        public void listarMedicamentos()
        {
            if(listaMedicamentos.contarMedicamentos() == 0)
            {
                Console.Clear();
                Console.WriteLine("Não existe nenhum medicamento cadastrado! ");
                Console.ReadKey();
            }
            else
            {
                Console.Clear();
                Console.WriteLine("========== LISTAGEM DOS MEDICAMENTOS CADASTRADOS ========\n"); 
                Console.WriteLine(listaMedicamentos.dadosResumidos());
                Console.ReadKey();
            }
        }
    }
}
