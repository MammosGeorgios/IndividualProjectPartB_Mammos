using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IndividualProject.Models
{
    class Assignment
    {
        private string _title;
        private string _description;
        private DateTime _subDateTime;
        private int _oralMark;
        private int _totalMark; // Not actually total, more like written mark - but whatever!

        public string Title
        {
            get { return (this._title); }
            set { this._title = value.ToUpper(); }
        }
        public string Description
        {
            get { return (this._description); }
            set { this._description = value.ToUpper(); }
        }
        public DateTime SubDateTime
        {
            get { return (this._subDateTime); }
            set { this._subDateTime = value; }
        }
        public int OralMark
        {
            get { return (this._oralMark); }
            set { this._oralMark = value; }
        }
        public int TotalMark
        {
            get { return (this._totalMark); }
            set { this._totalMark = value; }
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
            return ($"Title: {_title}\tDescription: {_description}\tSub Date: {_subDateTime.ToShortDateString()}\tOral Mark: {_oralMark}\tTotal Mark: {_totalMark}");
        }
    }
}
