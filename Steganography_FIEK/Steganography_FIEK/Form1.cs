using System;
using System.Drawing;
using System.IO;
using System.Text;
using System.Windows.Forms;
using WaveStegano;

namespace Steganography_FIEK
{
    public partial class Form1 : Form
    {
        Bitmap carrierImage;        // variabla per ruajtjen e imazhit pa mezazhin e fshehur
        Bitmap steganoImage;        // variabla per ruajtjen e imazhit me mesazhin e fshehur

        WaveAudio carrierAudio;     // variabla per ruajtjen e audios pa mezazhin e fshehur
        WaveAudio steganoAudio;     // variabla per ruajtjen e audios me mezazhin e fshehur

        string secretFile;          // variabla per ruajtjen e mesazhit te fshehur
        bool imageFlag;

        public Form1()
        {
            InitializeComponent();
        }


        private void Form1_Load(object sender, EventArgs e)
        {
            lblCarrierProp1.Text = "Type of file:\nSize of file:";
            lblSecretProp1.Text = "Size of file:";

            cbSteganography.Enabled = false;
            cbSteganoanalysis.Enabled = false;
        }


        //////////  butoni per zgjedhjen e imazhit per fshehjen e mesazhit
        private void btnCarrier_Click(object sender, EventArgs e)
        {
            OpenFileDialog dialog = new OpenFileDialog();
            dialog.Filter = "Bitmap Image (.bmp)|*.bmp|WAVE Audio (.wav)|*.wav";
            
            if (dialog.ShowDialog() == DialogResult.OK)
            {
                txtCarrier.Text = dialog.FileName;

                if (Path.GetExtension(dialog.FileName) == ".bmp")
                {
                    imageFlag = true;
                    carrierImage = new Bitmap(dialog.FileName, false);
                    int size = carrierImage.Width * carrierImage.Height * 3 + 54;
                    lblCarrierProp2.Text = "Bitmap Image, " + carrierImage.Width + " X " + carrierImage.Height + ", " + carrierImage.PixelFormat + "\n" + size.ToString("N0") + " bytes";
                    cbSteganography.Enabled = true;
                }
                else if(Path.GetExtension(dialog.FileName) == ".wav")
                {
                    imageFlag = false;
                    cbSteganography.Enabled = false;
                    carrierAudio = new WaveAudio(new FileStream(txtCarrier.Text, FileMode.Open, FileAccess.Read));
                    lblCarrierProp2.Text = "WAVE Audio \n" + carrierAudio.getSize() + " kByte";
                }
            }
        }


        //////////  butoni per zgjedhjen tekstit sekret
        private void btnSecret_Click(object sender, EventArgs e)
        {
            OpenFileDialog dialog = new OpenFileDialog();
            dialog.Filter = "Text File (.txt)|*.txt";

            if (dialog.ShowDialog() == DialogResult.OK)
            {
                txtSecret.Text = dialog.FileName;
                secretFile = dialog.FileName;

                string secretText = File.ReadAllText(secretFile);
                lblSecretProp2.Text = secretText.Length + " bytes";
            }
        }


        //////////  butoni per mbylljen e aplikacionit
        private void btnExit_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }


        //////////  butoni per mbylljen e aplikacionit
        private void btnExit2_Click(object sender, EventArgs e) 
        {
            Application.Exit();
        }


        //////////  metoda kryesore per fshehjen e mesazhit sekret ne imazh
        private void btnHide_Click(object sender, EventArgs e)
        {
            string secretText = "";
            SaveFileDialog dialog;

            try
            {
                secretText = File.ReadAllText(secretFile);
                dialog = new SaveFileDialog();

                if(imageFlag)
                {
                    if (cbSteganography.SelectedIndex == 1)
                        steganoImage = stegano_classes.stegano_LSB.hideText_imageLSB(secretText, carrierImage);
                    else if(cbSteganography.SelectedIndex == 2)
                    {
                        stegano_classes.stegano_PVD PVDobj = new stegano_classes.stegano_PVD();
                        Object obj = PVDobj.stego(carrierImage, secretText, true);
                        steganoImage = (Bitmap)obj;
                    }
                    
                    dialog.Filter = "Bitmap Image (.bmp)|*.bmp";
                    if (dialog.ShowDialog() == DialogResult.OK)
                    {
                        steganoImage.Save(dialog.FileName);
                    }
                }
                else
                {
                    steganoAudio = stegano_classes.stegano_audio.hideText_audio(secretText, carrierAudio);
                    dialog.Filter = "WAVE Audio (.wav)|*.wav";
                    if (dialog.ShowDialog() == DialogResult.OK)
                    {
                        steganoAudio.WriteFile(dialog.FileName);
                    }
                }

                MessageBox.Show("The secret text was hidden successfully!");
            }
            catch(Exception m)
            {
                MessageBox.Show(m.Message);
            }
        }


        private void btnStegano_Click(object sender, EventArgs e)
        {
            OpenFileDialog dialog = new OpenFileDialog();
            dialog.Filter = "Bitmap Image (.bmp)|*.bmp|WAVE Audio (.wav)|*.wav";
            
            if (dialog.ShowDialog() == DialogResult.OK)
            {
                txtStegano.Text = dialog.FileName;
                if (Path.GetExtension(dialog.FileName) == ".bmp")
                {
                    imageFlag = true;
                    cbSteganoanalysis.Enabled = true;
                    steganoImage = new Bitmap(dialog.FileName);
                }
                else
                {
                    imageFlag = false;
                    cbSteganoanalysis.Enabled = false;
                    steganoAudio = new WaveAudio(new FileStream(txtStegano.Text, FileMode.Open, FileAccess.Read));
                }
            }
        }


        private void btnAnalyze_Click(object sender, EventArgs e)
        {
            try
            {
                SaveFileDialog dialog = new SaveFileDialog();
                dialog.Filter = "Text File (.txt)|*.txt";

                if (dialog.ShowDialog() == DialogResult.OK)
                {
                    string secretFilePath = dialog.FileName;

                    if (imageFlag)
                    {
                        if (cbSteganoanalysis.SelectedIndex == 1)
                            File.WriteAllText(secretFilePath, stegano_classes.stegano_LSB.extractText_imageLSB(new Bitmap(steganoImage)));
                        else if (cbSteganoanalysis.SelectedIndex == 2)
                        {
                            stegano_classes.stegano_PVD PVDobj = new stegano_classes.stegano_PVD();
                            Object obj = PVDobj.stego(steganoImage, "", false);
                            if (obj != null)
                            {
                                String secretTextPVD = (String)obj;
                                File.WriteAllText(secretFilePath, decodeSecretPVD(secretTextPVD));
                            }
                            else
                            {
                                MessageBox.Show("No hidden message was found in this picture.");
                            }
                        }
                    }
                    else
                    {
                        File.WriteAllText(secretFilePath, stegano_classes.stegano_audio.extractText_audio(steganoAudio));
                    }

                    MessageBox.Show("The secret text was extracted successfully!");
                }
            }
            catch (Exception ee)
            {
                MessageBox.Show(ee.Message);
            }
        }

        private string decodeSecretPVD(String txtSecret)
        {
            StringBuilder thelast = new StringBuilder();
            StringBuilder strChar = new StringBuilder();
            for (int i = 0; i < txtSecret.Length;)
            {
                strChar.Clear();
                for (int j = 0; j < 8; j++)
                {
                    if (i < txtSecret.Length)
                        strChar.Append(txtSecret[i++]);
                }
                int b = Convert.ToInt32(strChar.ToString(), 2);

                thelast.Append(((char)b).ToString());
            }
            return thelast.ToString();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            MessageBox.Show("a");
        }
        
        private void pictureBox1_Click_1(object sender, EventArgs e)
        {
            MessageBox.Show("SteganoFIEK  v1.0 \nCopyright © 2017  Petrit Rama - FIEK", "Information - SteganoFIEK", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
    }
}