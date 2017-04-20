using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GroupProject
{
    public class Product
    {
        private string _product_code;
        private string _product_description;
        private double _product_cost;

        public void ProductCode()
        {
            //get { return _product_code; }
            //set { _product_code = value; }
        }

        public void ProductDescription()
        {
            //get { return _product_description; }
            //set { _product_description = value; }
        }

        public void ProductCost()
        {
            //get { return _product_cost; }
            //set { _product_cost = value; }
        }
        public override string ToString()
        {
            return _product_description + "($" + _product_cost + ")" ;
        }
    }
}
