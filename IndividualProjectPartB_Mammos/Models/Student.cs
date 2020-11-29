using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IndividualProject.Models
{
    class Student
    {
        private string _firstName;
        private string _lastName;
        private DateTime _dateOfBirth;
        private decimal _tuitionFees;

        public string FirstName
        {
            get { return (this._firstName); }
            set { this._firstName = value.ToUpper(); }
        }
        public string LastName
        {
            get { return (this._lastName); }
            set { this._lastName = value.ToUpper(); }
        }
        public DateTime DateOfBirth
        {
            get { return (this._dateOfBirth); }
            set { this._dateOfBirth = value; }
        }
        public decimal TuitionFees
        {
            get { return (this._tuitionFees); }
            set { this._tuitionFees = value; }
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
            return ($"First Name: {_firstName}\tLast Name: {_lastName}\tDate of birth: {_dateOfBirth.ToShortDateString()}\t");
        }
    }
}
