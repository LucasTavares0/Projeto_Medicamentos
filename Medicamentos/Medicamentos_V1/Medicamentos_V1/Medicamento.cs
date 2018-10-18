using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Medicamentos_V1
{
    class Medicamento
    {
        //atributos
        private int id;
        private string nome;
        private string laboratorio;
        private Queue<Lote> lotes;

        //Propriedades getter e setter
        public void setId(int id)
        {
            this.id = id;
        }
        public void setNome(string nome)
        {
            this.nome = nome;
        }
        public void setLaboratorio(string laboratorio)
        {
            this.laboratorio = laboratorio;
        }
        public void setLotes(Lote lote)
        {
            lotes.Enqueue(lote);
            organizaLote();
        }
        //----------------
        public int getId()
        {
            return this.id;
        }
        public string getNome()
        {
            return this.nome;
        }
        public string getLaboratorio()
        {
            return this.laboratorio;
        }
        public Lote getLote()
        {
            return lotes.Dequeue();
        }

        // Contrutores
        public Medicamento()
        {
            setId(0);
            setNome("");
            setLaboratorio("");
            lotes = new Queue<Lote>();
            //setLotes(null);
        }
        public Medicamento(int id,string nome, string laboratrio)
        {
            setId(id);
            setNome(nome);
            setLaboratorio(laboratrio);
            lotes = new Queue<Lote>();
        }

        // Métodos Funcionais
        //
        //-- Verifica a quantidade disponível, somando a quantidade em todos os lotes
        public int quantDisponivel()
        {
            int quantDisponivel = 0;
            Lote[] lotesDisponiveis = new Lote[this.lotes.Count];
            lotes.CopyTo(lotesDisponiveis, 0);

            foreach(Lote l in lotesDisponiveis)
            {
                quantDisponivel += l.getQuant();
            }
            return quantDisponivel;
        }

        //-- Enfileira o lote recebido na fila de lotes(O mais novo sai por ultimo)
        public void comprarLote(Lote lote)
        {
            setLotes(lote);
        }

        // verifica se existe quant disponivel. Caso positivo, procede para a venda do lote mais antigo para o mais novo.
        public bool venderLote(int quant)
        {
            if(quant > quantDisponivel())
            {
                return false;
            }
            else
            {
                Lote l = lotes.Dequeue();

                if (quant < l.getQuant())
                {
                    l.setQuant(l.getQuant() - quant);
                    lotes.Enqueue(l);
                    organizaLote();
                }
                else
                {
                    if (quant == l.getQuant())
                    {
                        l = null;
                    }
                    else
                    {
                        if(quant > l.getQuant())
                        {
                            quant = quant - l.getQuant();
                            l = null;
                            venderLote(quant);
                        }
                    }
                }
                return true;
            }
        }

        //-- Retorna uma string de composição dos dados do medicamento
        public String dadosMedicamento()
        {
            StringBuilder dados = new StringBuilder();
            dados.Append("ID: " + getId()); dados.Append(" - ");
            dados.Append("NOME: " + getNome()); dados.Append(" - ");
            dados.Append("LABORATÓRIO: " + getLaboratorio()); dados.Append(" - ");
            dados.Append("QANT. DISPONÍVEL: " + quantDisponivel());
            return dados.ToString();
        }
        public String dadosMedicamentoLote()
        {
            StringBuilder dados = new StringBuilder();
            dados.Append(dadosMedicamento());
            dados.Append("\n\n");
            dados.Append("Dados de lote: \n");

            foreach(Lote l in lotes)
            {
                dados.Append(l.dadosLote());
                dados.Append("\n");
            }
            return dados.ToString();
        }

        // Verifica se existe algum Lote com o ID passado como parâmetro
        public Lote pesquisaLote(int id)
        {
            Lote lote = new Lote();
            bool existe = false;

            foreach(Lote l in lotes)
            {
                if (l.getId() == id)
                {
                    lote = l;
                    existe = true;
                    break;
                }
                else existe = false;
            }

            if (existe) return lote;
            else return null;
        }

        //Organiza lote de acordo com a data de vencimento (Da menor para a maior)
        public void organizaLote()
        {
            Queue<Lote> loteAux = new Queue<Lote>();
            IEnumerable<Lote> lotesOrganizados =
            from l in lotes
            orderby l.getVenc() 
            select l;

            foreach(Lote l in lotesOrganizados)
            {
                loteAux.Enqueue(l);
            }
            lotes = loteAux;
        }
    }
}
