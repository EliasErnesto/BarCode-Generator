using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using BarcodeLib;
using System.Drawing.Imaging;

namespace BarCode
{
    public partial class Generador : Form
    {
        public Generador()
        {
            InitializeComponent();
        }

        private void btn_generar_Click(object sender, EventArgs e)
        {

            if (!String.IsNullOrEmpty(txt_code.Text))
            {
                Barcode codigo = new Barcode();
                codigo.IncludeLabel = true;       
                pantalla.BackgroundImage = codigo.Encode(BarcodeLib.TYPE.CODE128, txt_code.Text, Color.Black, Color.White, 400, 150);
                btn_guardar.Enabled = true;
            }
            else
            {
                MessageBox.Show("Debe ingresar un texto a codificar");
            }
            
        }

        private void btn_guardar_Click(object sender, EventArgs e)
        {
            Image img_guardada = (Image)pantalla.BackgroundImage.Clone();

            SaveFileDialog SaveDialogo = new SaveFileDialog();
            SaveDialogo.AddExtension = true;
            SaveDialogo.Filter = "Image PNG (*.png)|*.png";
            SaveDialogo.FileName = txt_code.Text;
            SaveDialogo.ShowDialog();

            if (!String.IsNullOrEmpty(SaveDialogo.FileName))
            {
                img_guardada.Save(SaveDialogo.FileName, ImageFormat.Png);
                txt_code.Text = "";
                img_guardada.Dispose();
            }
            else
            {
                MessageBox.Show("Debe ingresar un nombre para la imagen");

            }
            


        }
    }
}
