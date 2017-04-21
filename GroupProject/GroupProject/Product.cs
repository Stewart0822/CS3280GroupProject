using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GroupProject
{
    public class Product:ICloneable
    {
        private string _product_code;
        private string _product_description;
        private double _product_cost;
        public bool inDB { get; internal set; } = false;
        public bool needDeleted { get; internal set; } = false;

        public string ProductCode
        {
            get { return _product_code; }
            set { _product_code = value; }
        }

        public string ProductDescription
        {
            get { return _product_description; }
            set { _product_description = value; }
        }

        public double ProductCost
        {
            get { return _product_cost; }
            set { _product_cost = value; }
        }

        public override string ToString()
        {
            return _product_description + "($" + _product_cost + ")" ;
        }

        public object Clone()
        {
            return new Product()
            {
                ProductCode = this.ProductCode,
                ProductDescription = this.ProductDescription
                ,
                ProductCost = this.ProductCost,
                inDB = this.inDB,
                needDeleted = this.needDeleted
            };
        }
    }
}
