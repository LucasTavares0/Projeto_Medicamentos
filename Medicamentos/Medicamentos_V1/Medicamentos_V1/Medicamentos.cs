using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Medicamentos_V1
{
    class Medicamentos
    {
        //atributos
        private List<Medicamento> listaMedicamentos;

        //pripriedades Getter e Setter
        public void setMedicamento(Medicamento medicamento)
        {
            this.listaMedicamentos.Add(medicamento);
        }
        public Medicamento getMedicamento(int id)
        {
            bool existe = false;
            Medicamento med = new Medicamento();

            foreach(Medicamento m in listaMedicamentos)
            {
                if (m.getId() == id)
                {
                    med = m;
                    existe = true;
                    break;
                }
                else existe = false;
            }
            if (existe) return med;
            else return null;
        }

        //Contrutores
        public Medicamentos()
        {
            listaMedicamentos = new List<Medicamento>();
        }

        //Métodos Funcionais
        //
        //-- Adiciona um novo medicamento à lista
        public void adicionarMedicamento(Medicamento medicamento)
        {
            setMedicamento(medicamento);
        }

        // deleta um medicamento da lista, caso ele possu quantidade 0
        public bool deletarMedicamento(int id)
        {
            Medicamento medAux = pesquisarMedicamento(id);
            if (medAux == null)
            {
                return false;
            }
            else
            {
                if(medAux.quantDisponivel() != 0)
                {
                    return false;
                }
                else
                {
                    listaMedicamentos.Remove(medAux);
                    return true;
                }
            }
        }

        //Pesquisa um medicamento a partir do ID dele
        public Medicamento pesquisarMedicamento(int id)
        {
            return getMedicamento(id);
        }

        public int contarMedicamentos()
        {
            return listaMedicamentos.Count;
        }

        //Dados resumidos dos medicamentos cadastrados
        public String dadosResumidos()
        {
            StringBuilder dados = new StringBuilder();
            
            foreach(Medicamento m in listaMedicamentos)
            {
                dados.Append(m.dadosMedicamento());
                dados.Append("\n\n");
            }
            return dados.ToString();
        }
    }
}
