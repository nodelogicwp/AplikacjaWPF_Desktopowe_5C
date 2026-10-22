using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Menadrzerzadan
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }


        private void WyslijButton_Click(object sender, RoutedEventArgs e)
        {
            // Wyświetlenie komunikatu
            MessageBox.Show(
                "Wysłano pomyślnie!",
                "Sukces",
                MessageBoxButton.OK,
                MessageBoxImage.Information
            );

            // Wyczyszczenie pól formularza
            ImieTextBox.Clear();
            NazwiskoTextBox.Clear();
            WiekTextBox.Clear();
        }
    }
}