using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OOPShopApp.DAL.DAO;
using OOPShopApp.DAL.GateWay;

namespace OOPShopApp.BLL
{
    class ProductBll
    {
        private ProductGateWay aProductGateWay = new ProductGateWay();
        private Product anProduct = new Product();

        
        public string SaveProduct(Product aProduct)
        {
            if (aProduct.Code==string.Empty || aProduct.Name== string.Empty || aProduct.Quantity < 0)
            {
                return "Fill up fields before saving";
            }
            else
            {
                
               
                    if ((HasThisNameValid(aProduct.Name)) || (HasThisCodeValid(aProduct.Code)))
                    {
                        string msg = "";
                        if (HasThisNameValid(aProduct.Name))
                        {
                            msg += "Name already in database\n";
                        }
                        if (HasThisCodeValid(aProduct.Code))
                        {
                            msg += "Code already in database\n";
                        }
                        return msg;
                    }
                    else
                    {

                        aProductGateWay.SaveProduct(aProduct);
                        return "Product Save Successfull";
                    }
                
            }
            
        }

        private bool HasThisCodeValid(string code)
        {
            return aProductGateWay.HasThisCodeValid(code);
        }

        private bool HasThisNameValid(string name)
        {
            return aProductGateWay.HasThisNameValid(name);
        }

        public List<Product> GetAllProduct()
        {
            List<Product> allProductList = aProductGateWay.GetAllProduct();
            return allProductList;
        }
    }
}
