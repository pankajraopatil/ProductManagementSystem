using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Products.Entity;
using Products.Exceptions;
using Products.DAL;

namespace Products.BL
{
    public class ProductBL
    {
        Product pObj = null;
        ProductDAL pDAL = null;

        public ProductBL()
        {
            pObj = new Product();
            pDAL = new ProductDAL();
        }
        public ProductBL(Product prodObj)
        {
            pObj = prodObj;
            pDAL = new ProductDAL(pObj);
        }

        public bool AddProduct()
        {
            return pDAL.AddProduct();
        }

        public bool UpdateRecord(int prodId)
        {
            return pDAL.UpdateRecord(prodId);
        }

        public bool DeleteRecord(int Id)
        {
            return pDAL.DeleteRecord(Id);
        }

        public Product SearchProductByID(int Id)
        {
            return pDAL.SearchProductByID(Id);
        }

        public List<Product> SearchProductByName(string prodName)
        {
            return pDAL.SearchProductByName(prodName);
        }

        public List<Product> ShowAllProducts()
        {
            List<Product> prodList = null;
            try
            {
                prodList = pDAL.ShowAllProducts();
            }
            catch(Exception)
            {
                throw new ProductException();
            }
            return prodList;
        }
    }
}
