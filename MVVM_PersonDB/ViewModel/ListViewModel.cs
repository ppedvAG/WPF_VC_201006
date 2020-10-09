using MVVM_PersonDB.Model;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using System.Windows;

namespace MVVM_PersonDB.ViewModel
{
    public class ListViewModel
    {
        //Listen-Property, welche auf die Liste des Models verlinkt
        public ObservableCollection<Person> Personenliste { get { return Model.Person.Personenliste; } }

        //Command-Properties
        public CustomCommand NeuCmd { get; set; }
        public CustomCommand AendernCmd { get; set; }
        public CustomCommand LoeschenCmd { get; set; }
        public CustomCommand SchliessenCmd { get; set; }

        public ListViewModel()
        {
            //Command-Definitionen
            //Hinzufügen einer neuen Person
            NeuCmd = new CustomCommand
                (
                    //CanExe: kann immer ausgeführt werden
                    p => true,
                    //Exe:
                    p =>
                    {
                        //Instanzieren eines neuen DetailViews
                        View.DetailView NeuePerson_Dialog = new View.DetailView();

                        //(NeuePerson_Dialog.DataContext as DetailViewModel).AktuellePerson = new Person();

                        //Erstellung eines neuen DetailViewModels als dessen DataContext
                        DetailViewModel detailViewModel = new DetailViewModel();
                        //Zuweisung einer neuen Person in die 'AktuellePerson'-Property des neuen DetailViewModels
                        detailViewModel.AktuellePerson = new Person();
                        //Zuweisung des ViewModels als DataContext für das View
                        NeuePerson_Dialog.DataContext = detailViewModel;

                        //Aufruf des DetailViews mit Überprüfung auf dessen DialogResult(wird true, wenn der Benutzer OK klickt)
                        if (NeuePerson_Dialog.ShowDialog() == true)
                            //Hinzufügen der neuen Person zu Liste
                            Model.Person.Personenliste.Add((NeuePerson_Dialog.DataContext as DetailViewModel).AktuellePerson);
                    }
                );

            //Ändern einer bestehenden Person
            AendernCmd = new CustomCommand
                (
                     //CanExe: Kann ausgeführt werden, wenn der Parameter (der im DataGrid ausgewählte Eintrag) eine Person ist.
                     //Fungiert als Null-Prüfung
                     p => p is Model.Person,
                    p =>
                    {
                        //Vgl. NeuCmd (s.o.)
                        View.DetailView AenderePerson_Dialog = new View.DetailView();
                        //Ändern des Titels des neuen DetailViews
                        (AenderePerson_Dialog as View.DetailView).Title = "Ändere " + (p as Model.Person).Vorname + " " + (p as Model.Person).Nachname;

                        DetailViewModel detailViewModel = new DetailViewModel();
                        //Zuweisung einer Kopie der ausgewählten Person in die 'AktuellePerson'-Property des neuen DetailViewModels
                        detailViewModel.AktuellePerson = new Person(p as Person);

                        AenderePerson_Dialog.DataContext = detailViewModel;

                        if (AenderePerson_Dialog.ShowDialog() == true)
                            //Austausch der (veränderten) Person-Kopie mit dem Original in der Liste
                            Model.Person.Personenliste[Model.Person.Personenliste.IndexOf(p as Person)] = (AenderePerson_Dialog.DataContext as DetailViewModel).AktuellePerson;
                    }
                );

            //Löschen einer Person
            LoeschenCmd = new CustomCommand
                (
                    //CanExe: s.o.
                    p => p is Model.Person,
                    //Exe: Löschen der ausgewählten Person (nach Rückfrage per MessageBox)
                    p =>
                    {
                        if (MessageBox.Show($"Soll {(p as Person).Vorname} {(p as Person).Nachname} wirklich gelöscht werden?", "Person löschen", MessageBoxButton.YesNo, MessageBoxImage.Question) == MessageBoxResult.Yes)
                            Model.Person.Personenliste.Remove(p as Person);
                    }
                );

            //Schließen des Programms
            SchliessenCmd = new CustomCommand
                (
                    //CanExe: kann immer ausgeführt werden
                    p => true,
                    //Exe: Schließen der Applikation
                    p => (p as Window).Close()
                );
        }
    }
}
