using MVVM_PersonDB.View;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;

namespace MVVM_PersonDB.ViewModel
{
    public class StartViewModel : INotifyPropertyChanged
    {
        public int AnzahlPerson { get { return Model.Person.Personenliste.Count; } }

        public CustomCommand LadeDbCmd { get; set; }

        public CustomCommand OeffneDbCmd { get; set; }

        public StartViewModel()
        {
            LadeDbCmd = new CustomCommand
                (
                    p => this.AnzahlPerson == 0,
                    p =>
                    {
                        Model.Person.LadePersonenAusDb();
                        PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(AnzahlPerson)));
                    }
                );

            OeffneDbCmd = new CustomCommand
                (
                    p => this.AnzahlPerson > 0,
                    p =>
                    {
                        View.ListView db_Ansicht = new View.ListView();

                        db_Ansicht.Show();

                        (p as StartView).Close();
                    }
                );
        }

        public event PropertyChangedEventHandler PropertyChanged;
    }
}
