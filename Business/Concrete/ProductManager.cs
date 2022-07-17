using Business.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataAccess.Concrete.InMemory;
using DataAccess.Abstract;
using Entities.DTOs;

namespace Business.Concrete
{
    public class ProductManager : IProductService
    {
        IProductDal _productDal;
       

        public ProductManager(IProductDal productDal)
        {
            _productDal = productDal;
        }

    

        public List<Product> GetAll()//İş kodları
        {
            return _productDal.Getall();
        }

        public List<Product> GetAllByCategoryId(int id)
        {
            return _productDal.Getall(p => p.CategoryId == id);
        }

        public List<Product> GetByUnitPrice(decimal min, decimal max)
        {
            return _productDal.Getall(p=>p.UnitPrice>=min &&p.UnitPrice<=max);

        }

        public List<ProductDetailDto> GetProductDetails()
        {
           return _productDal.GetProductDetails();
        }
    }
}
