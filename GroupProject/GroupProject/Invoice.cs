using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GroupProject
{
    public class Invoice
    {
        private int _id;
        private DateTime _date;
        private double _total_charge;

        public int ID
        {
            get { return _id; }
            set { _id = value; }
        }

        public DateTime Date
        {
            get { return _date; }
            set { _date = value; }
        }

        public double TotalCharge
        {
            get { return _total_charge; }
            set { _total_charge = value; }
        }
    }
}
