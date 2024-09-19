namespace SISTEMA_DE_GESTÃO_LOJA.Model
{
    public class EnderecoCliModel
    {
       
        private int idEnderecoCli;
        private string complementoLogradouroCli;
        private string numLogradouroCli;
        private string logradouroCli;
        private string cepCli;
        private BairroModel bairro_Model;
        private ClienteModel cliente_Model;

        public EnderecoCliModel(ClienteModel clienteModel)
        {
             this.cliente_Model = clienteModel;
             this.bairro_Model = new BairroModel();
        }


        public int IdEnderecoCli { get => idEnderecoCli; set => idEnderecoCli = value; }
        public string ComplementoLogradouroCli { get => complementoLogradouroCli; set => complementoLogradouroCli = value; }
        public string NumLogradouroCli { get => numLogradouroCli; set => numLogradouroCli = value; }
        public string LogradouroCli { get => logradouroCli; set => logradouroCli = value; }
        public string CepCli { get => cepCli; set => cepCli = value; }
        public ClienteModel Cliente_Model { get => this.cliente_Model; set => this.cliente_Model = value; }
        public BairroModel Bairro_Model { get => this.bairro_Model; set => this.bairro_Model = value; }
    }
}
