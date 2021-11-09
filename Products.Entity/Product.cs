using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Products.Exceptions;

namespace Products.Entity
{
    public class Product
    {
        #region Attributes
        int productID;
        string prodName;
        string prodCategory;
        float price;
        int qty;
        #endregion

        #region Properties
        public int ProductID { get { return productID; } set { productID = value; } }
        public string ProdName { get { return prodName; } set { prodName = value; } }
        public string ProdCategory { get { return prodCategory; } set { prodCategory = value; } }
        public float Price
        {
            get
            {
                return price;
            }
            set
            {
                if (value > 0)
                {
                    price = value;
                }
                else
                {
                    throw new ProductException("Price cannot be less than or equal to Zero.");
                }
            }
        }
        public int Qty
        {
            get
            {
                return qty;
            }
            set
            {
                if (value > 0)
                {
                    qty = value;
                }
                else
                {
                    throw new ProductException("Quantity cannot be less than or equal to Zero.");
                }
            }
        }
        #endregion
    }
}
