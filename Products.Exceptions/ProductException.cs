using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Products.Exceptions
{
    public class ProductException:ApplicationException
    {
        public ProductException():base()
        {

        }
        public ProductException(string errorMessage):base(errorMessage)
        {

        }
    }
}
