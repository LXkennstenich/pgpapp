using System;
using System.Windows;


namespace PGPApp
{
    /// <summary>
    /// Interaktionslogik für MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void EncryptButton_Click(object sender, RoutedEventArgs e)
        {
            Hide();
            Encrypt encrypt = new Encrypt();
            encrypt.Closed += Encrypt_Closed;
            encrypt.Show();
        }

        private void Encrypt_Closed(object sender, EventArgs e)
        {
            Show();
        }

        private void DecryptButton_Click(object sender, RoutedEventArgs e)
        {
            Hide();
            Decrypt decrypt = new Decrypt();
            decrypt.Closed += Decrypt_Closed;
            decrypt.Show();
        }

        private void Decrypt_Closed(object sender, EventArgs e)
        {
            Show();
        }
    }
}
