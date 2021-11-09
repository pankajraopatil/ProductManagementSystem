using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Products.Entity;
using Products.Exceptions;
using System.Data;
using System.Data.SqlClient;

namespace Products.DAL
{
    public class ProductDAL
    {
        SqlConnection con = null;
        SqlCommand cmd = null;
        SqlDataReader sdr = null;

        Product prodObj = null;

        public ProductDAL()
        {
            prodObj = new Product();
            con = new SqlConnection();
            con.ConnectionString = @"Server=.\SqlExpress;Integrated Security = true;Database=CGCMR";
        }
        public ProductDAL(Product pObj)
        {
            con = new SqlConnection();
            con.ConnectionString = @"Server=.\SqlExpress;Integrated Security = true;Database=CGCMR";
            prodObj = pObj;
        }

        public bool AddProduct()
        {
            con.Open();

            SqlParameter p1, p2, p3, p4, p5;

            p1 = new SqlParameter("@prodID",prodObj.ProductID);
            p2 = new SqlParameter("@prodName",prodObj.ProdName);
            p3 = new SqlParameter("@category", prodObj.ProdCategory);
            p4 = new SqlParameter("@price", prodObj.Price);
            p5 = new SqlParameter("@qty", prodObj.Qty);

            cmd = new SqlCommand();
            cmd.CommandText = "Insert Into Products(ProdID,ProdName,ProdCategory,Price,Qty) values(@prodID,@prodName,@category,@price,@qty)";
            cmd.CommandType = CommandType.Text;
            cmd.Connection = con;

            cmd.Parameters.Add(p1);
            cmd.Parameters.Add(p2);
            cmd.Parameters.Add(p3);
            cmd.Parameters.Add(p4);
            cmd.Parameters.Add(p5);

            cmd.ExecuteNonQuery();
            con.Close();
            return true;
        }

        public bool UpdateRecord(int prodId)
        {
            con.Open();

            SqlParameter p1, p2, p3, p4, p5;

            p1 = new SqlParameter("@prodID", prodId);
            p2 = new SqlParameter("@prodName", prodObj.ProdName);
            p3 = new SqlParameter("@prodCategory", prodObj.ProdCategory);
            p4 = new SqlParameter("@price", prodObj.Price);
            p5 = new SqlParameter("@qty", prodObj.Qty);

            cmd = new SqlCommand();
            cmd.CommandText = "Update Products set ProdName=@prodName,ProdCategory=@prodCategory,Price=@price,Qty=@qty Where ProdID=@prodID";
            cmd.CommandType = CommandType.Text;
            cmd.Connection = con;

            cmd.Parameters.Add(p1);
            cmd.Parameters.Add(p2);
            cmd.Parameters.Add(p3);
            cmd.Parameters.Add(p4);
            cmd.Parameters.Add(p5);

            cmd.ExecuteNonQuery();

            return true;
        }

        public bool DeleteRecord(int Id)
        {
            con.Open();

            SqlParameter p;
            p = new SqlParameter("@prodID",Id);

            cmd = new SqlCommand();
            cmd.CommandText = "Delete From Products Where ProdID = @prodID";
            cmd.CommandType = CommandType.Text;
            cmd.Connection = con;

            cmd.Parameters.Add(p);
            cmd.ExecuteNonQuery();
            con.Close();
            return true;
        }

        public Product SearchProductByID(int Id)
        {
            Product p1 = new Product();
            con.Open();
            SqlParameter p;
            p = new SqlParameter("@prodID", Id);

            cmd = new SqlCommand();
            cmd.CommandText = "Select * From Products Where ProdID = @prodID";
            cmd.CommandType = CommandType.Text;
            cmd.Connection = con;

            cmd.Parameters.Add(p);
            sdr = cmd.ExecuteReader();
            sdr.Read();
            if(sdr!=null)
            {
                p1.ProductID = Int32.Parse(sdr[0].ToString());
                p1.ProdName = sdr[1].ToString();
                p1.ProdCategory = sdr[2].ToString();
                p1.Price = Int32.Parse(sdr[3].ToString());
                p1.Qty = Int32.Parse(sdr[4].ToString());
            }
            con.Close();

            return p1;
        }

        public List<Product> SearchProductByName(string prodName)
        {
            List<Product> prodList = new List<Product>();
            con.Open();
            SqlParameter p;
            p = new SqlParameter("@prodName",prodName);
            
            cmd = new SqlCommand();
            cmd.CommandText = "Select * From Products Where ProdName = @prodName";
            cmd.CommandType = CommandType.Text;
            cmd.Connection = con;

            cmd.Parameters.Add(p);
            sdr = cmd.ExecuteReader();

            DataTable dt = new DataTable();
            dt.Load(sdr);
            con.Close();

            if(dt.Rows.Count > 0)
            {
                Product p1 = new Product();
                foreach (DataRow drow in dt.Rows)
                {
                    p1.ProductID = Int32.Parse(drow[0].ToString());
                    p1.ProdName = drow[1].ToString();
                    p1.ProdCategory = drow[2].ToString();
                    p1.Price = Int32.Parse(drow[3].ToString());
                    p1.Qty = Int32.Parse(drow[4].ToString());

                    prodList.Add(p1);
                }
            }
            return prodList;
        }

        public List<Product> ShowAllProducts()
        {
            List<Product> prodList = new List<Product>();

            con.Open();
            cmd = new SqlCommand();
            cmd.CommandText = "Select * From Products";
            cmd.CommandType = CommandType.Text;
            cmd.Connection = con;

            sdr = cmd.ExecuteReader();

            DataTable dt = new DataTable();
            dt.Load(sdr);
            con.Close();

            //Converting DataTable Into List

            if(dt.Rows.Count > 0)
            {
                Product p1 = null;

                foreach (DataRow dRow in dt.Rows)
                {
                    p1 = new Product();
                    p1.ProductID = Int32.Parse(dRow[0].ToString());
                    p1.ProdName = dRow[1].ToString();
                    p1.ProdCategory = dRow[2].ToString();
                    p1.Price = Int32.Parse(dRow[3].ToString());
                    p1.Qty = Int32.Parse(dRow[4].ToString());

                    prodList.Add(p1);
                }
            }
            return prodList;
        }
    }
}
