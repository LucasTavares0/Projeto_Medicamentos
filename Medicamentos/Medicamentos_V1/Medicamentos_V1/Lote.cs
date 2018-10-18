using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Medicamentos_V1
{
    class Lote
    {
        //atributos
        private int id;
        private int quant;
        private DateTime venc;

        //Propriedades Getter e Setter
        public void setId(int id)
        {
            this.id = id;
        }
        public void setQuant(int quant)
        {
            this.quant = quant;
        }
        public void setVenc(DateTime data)
        {
            this.venc = data;
        }
        //-----------
        public int getId()
        {
            return this.id;
        }
        public int getQuant()
        {
            return this.quant;
        }
        public DateTime getVenc()
        {
            return this.venc;
        }

        //--Construtores
        public Lote()
        {
            DateTime data = new DateTime();
            setId(0);
            setQuant(0);
            setVenc(data);
        }
        public Lote(int id, int quant, DateTime venc)
        {
            setId(id);
            setQuant(quant);
            setVenc(venc);
        }

        //--métodos funcionais
        public String dadosLote()
        {
            StringBuilder dados = new StringBuilder();
            string venc = getVenc().ToString();
            venc = venc.Substring(0, 11);

            dados.Append("ID: " + getId()); dados.Append(" - ");
            dados.Append("Quantidade: " + getQuant()); dados.Append(" - ");
            dados.Append("Vencimento: " + venc);
            return dados.ToString();
        }
    }
}
