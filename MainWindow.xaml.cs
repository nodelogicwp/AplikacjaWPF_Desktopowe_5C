
using System;
using System.Windows;
using System.Windows.Controls;

namespace Menadrzerzadan
{
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();

            // Nie pozwalaj wybierać przyszłej daty urodzenia.
            DataUrodzeniaPicker.DisplayDateEnd = DateTime.Today;
        }

        private void WyslijButton_Click(object sender, RoutedEventArgs e)
        {
            // Walidacja imienia
            if (string.IsNullOrWhiteSpace(ImieTextBox.Text))
            {
                PokazBlad("Wpisz imię.");
                ImieTextBox.Focus();
                return;
            }

            // Walidacja nazwiska
            if (string.IsNullOrWhiteSpace(NazwiskoTextBox.Text))
            {
                PokazBlad("Wpisz nazwisko.");
                NazwiskoTextBox.Focus();
                return;
            }

            // Walidacja wieku
            if (string.IsNullOrWhiteSpace(WiekTextBox.Text))
            {
                PokazBlad("Wpisz wiek.");
                WiekTextBox.Focus();
                return;
            }

            if (!int.TryParse(WiekTextBox.Text, out int wiek)
                || wiek < 1 || wiek > 130)
            {
                PokazBlad("Wiek musi być liczbą całkowitą od 1 do 130.");
                WiekTextBox.Focus();
                return;
            }

            // Walidacja płci
            if (MezczyznaRadioButton.IsChecked != true &&
                KobietaRadioButton.IsChecked != true)
            {
                PokazBlad("Wybierz płeć.");
                return;
            }

            // Walidacja daty urodzenia
            if (DataUrodzeniaPicker.SelectedDate == null)
            {
                PokazBlad("Wybierz datę urodzenia.");
                DataUrodzeniaPicker.Focus();
                return;
            }

            if (DataUrodzeniaPicker.SelectedDate.Value > DateTime.Today)
            {
                PokazBlad("Data urodzenia nie może być datą przyszłą.");
                DataUrodzeniaPicker.Focus();
                return;
            }

            // Walidacja dodatkowych informacji
            if (string.IsNullOrWhiteSpace(InformacjeTextBox.Text))
            {
                PokazBlad("Wpisz dodatkowe informacje o użytkowniku.");
                InformacjeTextBox.Focus();
                return;
            }

            // Odczyt danych
            string imie = ImieTextBox.Text.Trim();
            string nazwisko = NazwiskoTextBox.Text.Trim();

            string plec = MezczyznaRadioButton.IsChecked == true
                ? "Mężczyzna"
                : "Kobieta";

            DateTime dataUrodzenia =
                DataUrodzeniaPicker.SelectedDate.Value;

            string informacje = InformacjeTextBox.Text.Trim();

            // Wyświetlenie podsumowania
            MessageBox.Show(
                $"Wysłano pomyślnie!\n\n" +
                $"Imię: {imie}\n" +
                $"Nazwisko: {nazwisko}\n" +
                $"Wiek: {wiek}\n" +
                $"Płeć: {plec}\n" +
                $"Data urodzenia: {dataUrodzenia:dd.MM.yyyy}\n" +
                $"Dodatkowe informacje: {informacje}",
                "Podsumowanie formularza",
                MessageBoxButton.OK,
                MessageBoxImage.Information
            );

            // Wyczyszczenie pól formularza
            ImieTextBox.Clear();
            NazwiskoTextBox.Clear();
            WiekTextBox.Clear();
            InformacjeTextBox.Clear();

            MezczyznaRadioButton.IsChecked = false;
            KobietaRadioButton.IsChecked = false;
            DataUrodzeniaPicker.SelectedDate = null;
        }

        private void PokazBlad(string komunikat)
        {
            MessageBox.Show(
                komunikat,
                "Błąd walidacji",
                MessageBoxButton.OK,
                MessageBoxImage.Warning
            );
        }
    }
}
