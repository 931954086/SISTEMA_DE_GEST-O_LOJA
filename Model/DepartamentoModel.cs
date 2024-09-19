using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SISTEMA_DE_GESTÃO_LOJA.Model
{
    public class DepartamentoModel
    {
        private int idDepartamento;
        private string nomeDepartamento;
        private string descricao;
        private EmpresaModel empresaModel;



        public DepartamentoModel()
        {
            this.empresaModel = new EmpresaModel();
        }

        public int IdDepartamento { get => idDepartamento; set => idDepartamento = value; }
        public string NomeDepartamento { get => nomeDepartamento; set => nomeDepartamento = value; }
        public string Descricao { get => descricao; set => descricao = value; }
        public EmpresaModel EmpresaModel { get => this.empresaModel; set => this.empresaModel = value; }
    }
}
