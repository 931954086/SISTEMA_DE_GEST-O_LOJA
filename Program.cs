  using SISTEMA_DE_GESTÃO_LOJA.Relatorios;
using SISTEMA_DE_GESTÃO_LOJA.Security;
using SISTEMA_DE_GESTÃO_LOJA.View;
using System;
using System.Windows.Forms;
using Microsoft.Win32;

namespace SISTEMA_DE_GESTÃO_LOJA
{
    public static class Program
    {
        /// <summary>
        /// Ponto de entrada principal para o aplicativo.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            //Application.Run(new WFLoginView());
            /*int diasRestantes = VerificarLicencaExistente();
             if (diasRestantes > 0)
             {
                Application.Run(new WFLoginView());
             }*/
            Application.Run(new WFLoginView());
            // Application.Run(new WFMateriaAluguerView());
            //Application.Run(new RegistarLicencas());
           // Application.Run(new View.WFPrincipalView(1, "", "Admin", "Dinho", 1));
            //Application.Run(new WFMaterialView());
            //Application.Run(new ProgessBarView());

        }



        static int VerificarLicencaExistente()
        {
            try
            {
                // Define a chave de registro onde a licença está armazenada
                string registryKeyPath = @"SOFTWARE\TechSolutions\GestorLicencas\default";
                string valueName = "true";

                // Abre a chave de registro para leitura
                using (RegistryKey key = Registry.LocalMachine.OpenSubKey(registryKeyPath))
                {
                    // Verifica se a chave de registro existe
                    if (key != null)
                    {
                        string licenseKey = key.GetValue(valueName) as string;

                        if (!string.IsNullOrEmpty(licenseKey))
                        {
                            SKGL.Validate validar = new SKGL.Validate();
                            validar.secretPhase = "2000!#";
                            validar.Key = licenseKey;

                            DateTime dataCriacao = validar.CreationDate;
                            DateTime dataExpiracao = dataCriacao.AddDays(validar.DaysLeft);

                            if (validar.IsValid && validar.DaysLeft > 0 && validar.CreationDate.Date >= DateTime.Today)
                            {
                                int diasRestantes = validar.DaysLeft;

                                if (diasRestantes <= 15 && diasRestantes > 0)
                                {
                                    MessageBox.Show($"Restam apenas {diasRestantes} dias para a licença expirar. Por favor, renove sua licença com  \n\nEmpresa: TechSolutions \nEmail: techconnetsolutions@gmail.com", "Renovar Licença", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                                }

                                if (diasRestantes == 10 || diasRestantes == 5)
                                {
                                    MessageBox.Show($"Restam apenas {diasRestantes} dias para a licença expirar. Por favor, renove sua licença com  \n\nEmpresa: TechSolutions \nEmail: techconnetsolutions@gmail.com", "Renovar Licença", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                                }
                                // Se a licença for válida e ainda estiver dentro do prazo, retorna o número de dias restantes
                                return diasRestantes;
                            }
                            else if (validar.IsValid)
                            {
                                 MessageBox.Show("A chave de licença é expirou em: " + dataExpiracao + "! por favor renova.", "Informação", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                // MessageBox.Show("A chave de licença é expirou em: " + dataExpiracao + "! por favor renova.", "Informação", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            }
                            else
                            {
                                MessageBox.Show("Aviso, chave de licença é inválida!", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            }
                        }
                    }
                    else
                    {
                        //MessageBox.Show("A chave de registro não foi encontrada.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        MessageBox.Show("A chave de licença não foi encontrada.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erro ao verificar a licença existente: " + ex.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }
            // Se não houver uma licença válida, expirada ou ocorrer um erro, abre o formulário para inserir uma nova licença 
         AbrirFormularioInserirLicenca();
            return 0;
        }



        static bool AbrirFormularioInserirLicenca()
        {
            WFAtualizarLicencas AtualizarLicencas = new WFAtualizarLicencas();
            return AtualizarLicencas.ShowDialog() == DialogResult.OK;

        }
    }
}
