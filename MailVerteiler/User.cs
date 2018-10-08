using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MailVerteiler
{
    class User
    {
        private string _lastName;
        public string Nachname {
            get
            {
                return _lastName;
            }
            set
            {
                _lastName = value;
            }
        }

        private string _firstName;
        public string Vorname
        {
            get
            {
                return _firstName;
            }
            set
            {
                _firstName = value;
            }
        }

        private string _plz;
        public string PLZ
        {
            get
            {
                return _plz;
            }
            set
            {
                _plz = value;
            }
        }

        public User(string lastName, string firstName, string plz)
        {
            _lastName = lastName;
            _firstName = firstName;
            _plz = plz;
        }

        public User(string[] values)
        {
            _lastName = values[0];
            _firstName = values[1];
            _plz = values[2];
        }
    }
}
