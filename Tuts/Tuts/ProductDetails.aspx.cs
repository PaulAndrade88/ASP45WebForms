using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Tuts.Models;
using System.Web.ModelBinding;

namespace Tuts
{
    public partial class ProductDetails : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        //Method when using (string)url  + id (older non-friendly, non-routed URL).
        //public IQueryable<Product> GetProduct([QueryString("productID")] int? productId)
        //{
        //    var _db = new Tuts.Models.ProductContext();
        //    IQueryable<Product> query = _db.Products;
        //    if (productId.HasValue && productId > 0)
        //    {
        //        query = query.Where(p => p.ProductID == productId);
        //    }
        //    else
        //    {
        //        query = null;
        //    }
        //    return query;
        //}

        public IQueryable<Product> GetProduct([QueryString("ProductID")] int? productId,
        [RouteData] string productName)
        {
            var _db = new Tuts.Models.ProductContext();
            IQueryable<Product> query = _db.Products;
            if (productId.HasValue && productId > 0)
            {
                query = query.Where(p => p.ProductID == productId);
            }
            else if (!String.IsNullOrEmpty(productName))
            {
                query = query.Where(p =>
                      String.Compare(p.ProductName, productName) == 0);
            }
            else
            {
                query = null;
            }
            return query;
        }
    }
}