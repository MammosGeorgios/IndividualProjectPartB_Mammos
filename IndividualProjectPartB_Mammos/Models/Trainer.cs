using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IndividualProject.Models
{
    class Trainer
    {
        private string _firstName;
        private string _lastName;
        private int _subject;

        public string FirstName 
        { 
            get { return (this._firstName); } 
            set { this._firstName = value.ToUpper(); } 
        }

        public string LastName
        {
            get { return (this._lastName);  }
            set { this._lastName = value.ToUpper(); }
        }

        public int Subject
        {
            get { return (this._subject); }
            set { this._subject = value; }
        }

        public override bool Equals(object obj)
        {
            return base.Equals(obj);
        }

        public override int GetHashCode()
        {
            return base.GetHashCode();
        }

        public override string ToString()
        {
            return ($"First Name: {_firstName}\tLast Name: {_lastName}\tSubject: {_subject}");
        }

       
    }
}
