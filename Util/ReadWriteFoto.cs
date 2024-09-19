using System;
using System.Collections.Generic;
using System.Drawing.Imaging;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SISTEMA_DE_GESTÃO_LOJA.Util
{
    public class ReadWriteFoto
    {
        #region Variáveis

        private MemoryStream ms = null;
        private PictureBox picbox = null;
        private Bitmap bmp = null;

        #endregion Variáveis

        /// <summary>
        /// Instanciar quando for selecionar uma imagem
        /// </summary>
        /// <param name="pic"></param>
        public ReadWriteFoto(PictureBox pic)
        {
            picbox = pic;
        }

        /// <summary>
        /// Instanciar quando for Incluir/Alterar a imagem
        /// </summary>
        public ReadWriteFoto()
        {
        }

        #region Propriedades

        //public string PathImagem { get; set; }

        #endregion Propriedades

        #region Métodos

        /// <summary>
        /// Seleciona a foto e carrega na picturebox
        /// </summary>
        public Bitmap EscolherFoto()
        {
            using (var dialog = new OpenFileDialog())
            {
                dialog.RestoreDirectory = true;
                dialog.FilterIndex = 1;
                dialog.Filter = "jpg files(*.jpg)|*.jpg|gif files(*.gif)|*.gif|png files(*.png)|*.png|bmp files(*.bmp)|*.bmp";
                if (dialog.ShowDialog() == DialogResult.OK)
                {
                    bmp = CarregarFoto(dialog.FileName);
                    //PathImagem = dialog.FileName;
                }
            }
            return bmp;
        }

        public Bitmap ConverterParaBitmap(string caminho)
        {
            if (!string.IsNullOrWhiteSpace(caminho))
            {
                bmp = new Bitmap(caminho);
                return bmp;
            }
            return null;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="arquivo">Caminho com o arquivo da foto.</param>
        public Bitmap CarregarFoto(string arquivo)
        {
            if (!string.IsNullOrWhiteSpace(arquivo))
            {
                //Exibe a imagem na PictureBox
                bmp = new Bitmap(arquivo);
                picbox.Image = bmp;
                return bmp;
            }
            return null;
        }

        private byte[] ConverterImagemToArray(Bitmap bmp, MemoryStream ms)
        {
            bmp.Save(ms, ImageFormat.Bmp);
            return ms.ToArray();
        }

        // public Bitmap Imagem { get; set; }

        public byte[] ConverterImagemToArray(Bitmap bmp)
        {
            try
            {
                ms = new MemoryStream();
                bmp.Save(ms, ImageFormat.Bmp);
                return ms.ToArray();
            }
            catch (Exception)
            {
                throw;
            }
        }

        /// <summary>
        /// Converte a imagem do PictureBox para um array de bytes.
        /// </summary>
        /// <param name="img">PictureBox.Image</param>
        /// <returns>byte[]  Array de bytes.</returns>
        public byte[] ConverteImagemParaByteArray(Image img)
        {
            try
            {
                using (MemoryStream mStream = new MemoryStream())
                {
                    img.Save(mStream, img.RawFormat);
                    return mStream.ToArray();
                }
            }
            catch (Exception)
            {
                throw;
            }
        }

        /// <summary>
        /// Converte um array de bytes (byte[]) para Image.
        /// </summary>
        /// <param name="byteArrayIn">Array de bytes da imagem.</param>
        /// <returns>Image</returns>
        public Image ConverteByteArrayToImage(byte[] byteArrayIn)
        {
            MemoryStream ms = new MemoryStream(byteArrayIn);
            Image returnImage = Image.FromStream(ms);
            return returnImage;
        }

        /// <summary>
        /// Atribui o array de byte para a propriedade Image da PictureBox.
        /// </summary>
        /// <param name="fotobinary">Array de byte que representa a imagem recuperada do Banco de Dados.
        /// Exemplo:  (byte[])dr["Foto"] </param>
        public void LendoVarbinary(byte[] fotobinary)
        {
            if (fotobinary == null)
            {
                return;
            }
            byte[] foto = fotobinary;// (byte[])dr["Foto"];

            ms = new MemoryStream(foto);
            picbox.Image = Image.FromStream(ms);
        }

        #endregion Métodos
    }
}
