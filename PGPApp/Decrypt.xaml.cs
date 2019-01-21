using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using DidiSoft.Pgp;

namespace PGPApp
{
    /// <summary>
    /// Interaktionslogik für Decrypt.xaml
    /// </summary>
    public partial class Decrypt : Window
    {
        public Decrypt()
        {
            InitializeComponent();
        }

        private void DecryptButton_Click(object sender, RoutedEventArgs e)
        {
            string encryptedmessage = new TextRange(EncryptedMessageTextbox.Document.ContentStart, EncryptedMessageTextbox.Document.ContentEnd).Text;
            string password = PasswordBox.Text;
            string privatekey = new TextRange(PrivateKeyTextbox.Document.ContentStart, PrivateKeyTextbox.Document.ContentEnd).Text;

            if(encryptedmessage == String.Empty)
            {
                MessageBox.Show("Keine Nachricht eingegeben");
            }

            if(privatekey == String.Empty)
            {
                MessageBox.Show("Keinen Private Key eingegeben");
            }

            PGPLib pGPLib = new PGPLib();
            MemoryStream decrypted = new MemoryStream();

            using(MemoryStream encryptedmessagestream = new MemoryStream(Encoding.UTF8.GetBytes(encryptedmessage)))
            {
                using(MemoryStream privatekeystream = new MemoryStream(Encoding.UTF8.GetBytes(privatekey)))
                {
                    string test = pGPLib.DecryptStream(encryptedmessagestream, privatekeystream, password, decrypted);

                    decrypted = new MemoryStream(decrypted.ToArray());

                    StreamReader streamReader = new StreamReader(decrypted);
                    string decryptedtext = streamReader.ReadToEnd();

                    DecryptedMessageBox.Text = "";
                    DecryptedMessageBox.Text = decryptedtext;
                }
            }

        }
    }
}
