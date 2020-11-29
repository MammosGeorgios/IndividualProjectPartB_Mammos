using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IndividualProject.Models
{
    class Course
    {
        private string _title;
        private int _stream;
        private int _type;
        private DateTime _startDate;
        private DateTime _endDate;

        public string Title
        {
            get { return (this._title); }
            set { this._title = value.ToUpper(); }
        }
        public int Stream
        {
            get { return (this._stream); }
            set { this._stream = value; }
        }
        public int Type
        {
            get { return (this._type); }
            set { this._type = value; }
        }
        public DateTime StartDate
        {
            get { return (this._startDate); }
            set { this._startDate = value; }
        }
        public DateTime EndDate
        {
            get { return (this._endDate); }
            set { this._endDate = value; }
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
            return ($"Title: {_title}\tStream: {_stream}\tType: {_type}\tStart Date: {_startDate.ToShortDateString()}\tEnd Date: {_endDate.ToShortDateString()}");
        }
    }
}
