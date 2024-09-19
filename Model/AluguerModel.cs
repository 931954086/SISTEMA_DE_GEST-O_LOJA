using Microsoft.Reporting.Map.WebForms.BingMaps;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using SISTEMA_DE_GESTÃO_LOJA.Util;
using System.Windows.Forms;



namespace SISTEMA_DE_GESTÃO_LOJA.Model
{

  
    public class AluguerModel
    {
       #region variaveis
        private int    id;
        private string numerofatura;
        private FuncionarioModel  funcionarioModel;
        private ClienteModel  clienteModel;
        private SituacaoModel situacaomodel;
        private DateTime  dataInicio;
        private DateTime  dataFim;
        private DateTime  dataCadAluguer;
        private int       dias;
        private decimal   valorBrutoAluguer;
        private decimal   valorliqVenda;
        private decimal   imposto;
        private DateTime  dtpagamento;
        private string    clausula;
        private decimal   caucao;
        private string    frete;
        private decimal   fretePreco;
        private decimal   desconto;
        #endregion variaveis



        #region    constructor
            public AluguerModel()
            {
                this.FuncionarioModel = new FuncionarioModel();
                this.ClienteModel = new ClienteModel();
                this.SituacaoModel = new SituacaoModel();
                string descontoFormatado = CalcularDesconto().ToString("N");
            }
        #endregion constructor


        #region    metodos
        public int Id { get => id; set => id = value; }
        public ClienteModel ClienteModel { get => clienteModel; set => clienteModel = value; }
        public FuncionarioModel FuncionarioModel { get => funcionarioModel; set => funcionarioModel = value; }
        public SituacaoModel SituacaoModel { get => situacaomodel; set => situacaomodel = value; }
        public DateTime DataInicio { get => dataInicio; set => dataInicio = value; }
        public DateTime DataFim { get => dataFim; set => dataFim = value; }
        public decimal ValorBrutoAluguer { get => valorBrutoAluguer; set => valorBrutoAluguer = value; }
        public string Clausula { get => clausula; set => clausula = value; }
        public decimal Caucao { get => caucao; set => caucao = value; }
        public string Frete { get => frete; set => frete = value; }
        public decimal FretePreco { get => fretePreco; set => fretePreco = value; }
        public string NumeroFatura { get => numerofatura; set => numerofatura = value; }
        public DateTime DataCadAluguer { get => dataCadAluguer; set => dataCadAluguer = value; }
        public decimal ValorliqVenda { get => valorliqVenda; set => valorliqVenda = value; }
        public decimal Imposto { get => imposto; set => imposto = value; }
        public DateTime Dtpagamento { get => dtpagamento; set => dtpagamento = value; }
        public int Dias { get => dias; set => dias = value; }
        public decimal Desconto { get => desconto; set => desconto = value; }

        public decimal CalcularDesconto()
        {
            if (Desconto > 0)
            {
                return ValorliqVenda * (Desconto / 100);
            }
            return 0;
        }
        #endregion metodos

    }
}
