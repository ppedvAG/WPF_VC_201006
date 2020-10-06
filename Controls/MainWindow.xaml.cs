using System;
using System.Collections.Generic;
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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Controls
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();

            //Zuweisung eines weiteren EventHandlers zu dem CLick-Event des Buttons
            Btn_KlickMich.Click += Btn_KlickMich_Click_2;
        }

        //Event-Handler für das Click-Event des Buttons
        private void Btn_KlickMich_Click(object sender, RoutedEventArgs e)
        {
            //Änderung der Hintergrundfarbe des Fensters
            Wnd_Main.Background = new SolidColorBrush(Colors.DeepPink);

            //Prüfung, ob die Checkbox abgehakt ist
            if(Cbx_Haken.IsChecked == true)
                //Anzeige einer MessageBox mit Inhalt der TextBox und Auswahl der ComboBox
                MessageBox.Show(Tbx_Input.Text + "\n" + Cbb_Auswahl.Text);

            //Anzeige einer MessageBox mit Wert des Sliders
            MessageBox.Show(Sdr_Wert.Value.ToString());
        }

        //Zweiter Eventhandeler des Buttons (siehe Konsruktor)
        private void Btn_KlickMich_Click_2(object sender, RoutedEventArgs e)
        {

        }
        

        private void Neu_Click(object sender, RoutedEventArgs e)
        {
            //Öffen eines neuen Fensters als Dialogfenster
            MainWindow neuesFenster = new MainWindow();
            neuesFenster.ShowDialog();
        }
        
        private void Beenden_Click(object sender, RoutedEventArgs e)
        {
            //Schließen des aktuellen Fensters
            this.Close();
            //Schließen der kompletten Applikation
            Application.Current.Shutdown();
        }
    }
}
