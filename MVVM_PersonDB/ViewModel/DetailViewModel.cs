using System;
using System.Collections.Generic;
using System.Text;
using System.Windows;

namespace MVVM_PersonDB.ViewModel
{
    public class DetailViewModel
    {
        //Property, welche die neue oder zu bearbeitende Person beinhaltet
        public Model.Person AktuellePerson { get; set; }

        //Command-Properties
        public CustomCommand Ok_Cmd { get; set; }
        public CustomCommand Abbruch_Cmd { get; set; }

        public DetailViewModel()
        {
            //OK-Command (Bestätigung)
            this.Ok_Cmd = new CustomCommand
                (
                    //CanExe: Kann immer ausgeführt werden. Eine Prüfung auf die Validierung der einzelnen Eingabefelder findet schon in der GUI (vgl. DetailView) statt.
                    p => true,
                    //Exe:
                    p =>
                    {
                        string ausgabe = AktuellePerson.Vorname + " " + AktuellePerson.Nachname + " (" + AktuellePerson.Geschlecht + ")\n" + AktuellePerson.Geburtsdatum.ToShortDateString() + "\n" + AktuellePerson.Lieblingsfarbe.ToString();
                        ausgabe += AktuellePerson.Verheiratet ? "\nIst Verheiratet" : "";

                        //Nachfrage auf Korrektheit der Daten per MessageBox
                        if (MessageBox.Show(ausgabe + "\nSoll diese Person gespeichert werden?", $"{AktuellePerson.Vorname} {AktuellePerson.Nachname} abspeichern", MessageBoxButton.YesNo, MessageBoxImage.Question) == MessageBoxResult.Yes)
                        {
                            //Setzen des DialogResults des Views (welches per Parameter übergeben wurde) auf true, damit das LIstView weiß, dass es weiter
                            //machen kann (d.h. die neuen Person einfügen bzw. austauschen)
                            (p as View.DetailView).DialogResult = true;
                            //Schließen des Views
                            (p as View.DetailView).Close();
                        }
                    }
                );

            //Abbruch-Cmd
            this.Abbruch_Cmd = new CustomCommand
                (
                    //CanExe: Kann immer ausgeführt werden
                    p => true,
                    //Exe: Schließen des Fensters
                    p => (p as View.DetailView).Close()
                );
        }
    }
}
