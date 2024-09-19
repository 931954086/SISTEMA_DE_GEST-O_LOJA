namespace SISTEMA_DE_GESTÃO_LOJA.Model
{
    public class MaterialModel
    {
        private int idMaterial;
        private string nomeMaterial;
        private string corMaterial;
        private string descricaoMaterial;
        private string modeloMaterial;
        private decimal qtdDisponivelMaterial;
        private decimal qtdTotal;
       private decimal preco;
        private string codigoBarra;
        private decimal qtdmin;


        public MaterialModel() { }

        public int IdMaterial { get => idMaterial; set => idMaterial = value; }
        public string NomeMaterial { get => nomeMaterial; set => nomeMaterial = value; }
        public string CorMaterial { get => corMaterial; set => corMaterial = value; }
        public string DescricaoMaterial { get => descricaoMaterial; set => descricaoMaterial = value; }
        public string ModeloMaterial { get => modeloMaterial; set => modeloMaterial = value; }
        public decimal QtdDisponivelMaterial { get => qtdDisponivelMaterial; set => qtdDisponivelMaterial = value; }
        public decimal QtdTotal { get => qtdTotal; set => qtdTotal = value; }
       public decimal Preco { get => preco; set => preco = value; }
        public string CodigoBarra { get => codigoBarra;  set => codigoBarra = value; }
        public decimal Qtdmin { get => qtdmin; set => qtdmin = value; }
    }
}
