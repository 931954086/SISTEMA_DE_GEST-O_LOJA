namespace SISTEMA_DE_GESTÃO_LOJA.Model
{
    public class EnderecoForModel
    {
        private int idEnderecoFor;
        private string complementoLogradouroFor;
        private string numLogradouroFor;
        private string logradouroFor;
        private string cepFor;
        private BairroModel bairro_Model;
        private FornecedorModel fornecedor_Model;


        public EnderecoForModel(FornecedorModel funcionarioModel)
        {
            this.fornecedor_Model = funcionarioModel;
            this.bairro_Model = new BairroModel();
        }

        public int IdEnderecoFor { get => idEnderecoFor; set => idEnderecoFor = value; }
        public string ComplementoLogradouroFor { get => complementoLogradouroFor; set => complementoLogradouroFor = value; }
        public string NumLogradouroFor { get => numLogradouroFor; set => numLogradouroFor = value; }
        public string LogradouroFor { get => logradouroFor; set => logradouroFor = value; }
        public string CepFor { get => cepFor; set => cepFor = value; }
        public BairroModel Bairro_Model { get => this.bairro_Model; set => this.bairro_Model = value; }
        public FornecedorModel Fornecedor_Model { get => this.fornecedor_Model; set => this.fornecedor_Model = value; }
       
    }
}
