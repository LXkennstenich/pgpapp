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
    /// Interaktionslogik für Encrypt.xaml
    /// </summary>
    public partial class Encrypt : Window
    {
        public Encrypt()
        {
            InitializeComponent();
        }

        private void EncryptMessageButton_Click(object sender, RoutedEventArgs e)
        {
            string publickey = new TextRange(PublicKeyBox.Document.ContentStart, PublicKeyBox.Document.ContentEnd).Text;
            string message = new TextRange(MessageToBeEncryptedBox.Document.ContentStart, MessageToBeEncryptedBox.Document.ContentEnd).Text;

            PGPLib pgp = new PGPLib();
            MemoryStream encryptedmessage = new MemoryStream();

            using(MemoryStream messagestream = new MemoryStream(Encoding.UTF8.GetBytes(message)))
            {
                using(MemoryStream publickeystream = new MemoryStream(Encoding.UTF8.GetBytes(publickey)))
                {
                    bool ascii = true;

                    pgp.EncryptStream(messagestream, publickeystream, encryptedmessage, ascii);

                    encryptedmessage = new MemoryStream(encryptedmessage.ToArray());

                    StreamReader streamReader = new StreamReader(encryptedmessage);
                    string encryptedtext = streamReader.ReadToEnd();

                    EncryptedMessageBox.Text = "";
                    EncryptedMessageBox.Text = encryptedtext;

                }
            }
        }
    }
}
