using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace Personendatenbank
{
    /// <summary>
    /// Interaction logic for Db_Ansicht.xaml
    /// </summary>
    public partial class Db_Ansicht : Window
    {
        public ObservableCollection<Person> Personenliste { get; set; }

        public Db_Ansicht()
        {
            InitializeComponent();

            Personenliste = new ObservableCollection<Person>()
            {
                new Person(){Vorname="Rainer", Nachname="Zufall", Geburtsdatum=new DateTime(2002, 4, 26), Geschlecht=Gender.Männlich, Lieblingsfarbe=Colors.Blue, Verheiratet=true}
            };
            Personenliste.Add(new Person() { Vorname = "Anna", Nachname = "Nass", Geburtsdatum = new DateTime(1989, 5, 12), Geschlecht = Gender.Weiblich, Lieblingsfarbe = Colors.Green, Verheiratet = false });

            this.DataContext = this;
        }

        private void Btn_Loeschen_Click(object sender, RoutedEventArgs e)
        {
            if(MessageBox.Show("Soll die Person wirklich gelöscht werden?", "Person löschen", MessageBoxButton.YesNo, MessageBoxImage.Question) == MessageBoxResult.Yes)
                Personenliste.Remove(Dgd_Personen.SelectedItem as Person);
        }

        private void Btn_Neu_Click(object sender, RoutedEventArgs e)
        {
            Personendialog dialog = new Personendialog();

            if (dialog.ShowDialog() == true)
                Personenliste.Add(dialog.NeuePerson);
        }

        private void Btn_Aendern_Click(object sender, RoutedEventArgs e)
        {
            Personendialog dialog = new Personendialog();
            dialog.NeuePerson = new Person(Dgd_Personen.SelectedItem as Person);
            dialog.DataContext = dialog.NeuePerson;

            if (dialog.ShowDialog() == true)
                Personenliste[Dgd_Personen.SelectedIndex] = dialog.NeuePerson;
        }

        private void MeI_Beenden_Click(object sender, RoutedEventArgs e)
        {
            Application.Current.Shutdown();
        }
    }
}
