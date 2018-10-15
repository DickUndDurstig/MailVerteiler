using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MailVerteiler
{
    class User
    {
        private string _salutation;
        public string Andrede
        {
            get
            {
                return _salutation;
            }
            set
            {
                _salutation = value;
            }
        }

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

        private string _street;
        public string Straße
        {
            get
            {
                return _street;
            }
            set
            {
                _street = value;
            }
        }

        private string _place;
        public string Ort
        {
            get
            {
                return _place;
            }
            set
            {
                _place = value;
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

        private string _state;
        public string Bundesland
        {
            get
            {
                return _state;
            }
            set
            {
                _state = value;
            }
        }

        private string _office;
        public string Amt
        {
            get
            {
                return _office;
            }
            set
            {
                _office = value;
            }
        }

        private string _email;
        public string Email
        {
            get
            {
                return _email;
            }
            set
            {
                _email = value;
            }
        }

        public User(string salutation, string lastName, string firstName, string street, string place, string state,
            string office, string email, string plz)
        {
            _salutation = salutation;
            _lastName = lastName;
            _firstName = firstName;
            _street = street;
            _place = place;
            _plz = plz;
            _state = state;
            _office = office;
            _email = email;            
        }

        public User(string[] values)
        {
            _salutation = values[0];
            _lastName = values[1];
            _firstName = values[2];
            _street = values[3];
            _place = values[4];
            _plz = values[5];
            _state = values[6];
            _office = values[7];
            _email = values[8];
        }
    }
}
