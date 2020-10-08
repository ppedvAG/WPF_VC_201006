using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;

namespace Validation
{
    public class Person : IDataErrorInfo
    {
        private string name;

        public string Name
        {
            get { return name; }
            set
            {
                if (value.All(x => Char.IsLetter(x)))
                    name = value;

                else
                    throw new Exception("Bitte gib nur Buchstaben ein.");
            }
        }

        public int Alter { get; set; }

        public string Error
        {
            get { return ""; }
        }

        public string this[string columnName]
        {
            get
            {
                switch (columnName)
                {
                    case (nameof(Alter)):
                        if (Alter < 0 | Alter > 150) return "Bitte gib dein wahres Alter an.";

                        break;
                    default:
                        break;
                }
                return "";
            }
        }
    }
}
