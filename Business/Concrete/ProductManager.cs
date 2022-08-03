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
using Core.Ultities.Results;
using Business.Constants;
using FluentValidation;
using Business.ValidationRules.FluentValidation;
using Core.CrossCuttingConcerns.Validation;
using Core.Aspects.Autofac.Validation;

namespace Business.Concrete
{
    public class ProductManager : IProductService
    {
        IProductDal _productDal;
            

        public ProductManager(IProductDal productDal)
        {
            _productDal = productDal;
        }
        [ValidationAspect(typeof(ProductValidator))]
        public IResult Add(Product product)
        {

            _productDal.Add(product);
            return new SuccessResult(Messages.ProductAdded);
        }

        public IDataResult<List<Product>> GetAll()//İş kodları
        {
            if (DateTime.Now.Hour==23)
            {
                return new ErrorDataResult<List<Product>>(Messages.MaintenanceTime);
            }
            return new SuccessDataResult<List<Product>>(_productDal.Getall(),Messages.ProductsListed);
        }

        public IDataResult<List<Product>> GetAllByCategoryId(int id)
        {
            return new SuccessDataResult<List<Product>>( _productDal.Getall(p => p.CategoryId == id));
        }

        public IDataResult<List<Product>> GetByUnitPrice(decimal min, decimal max)
        {
            return new SuccessDataResult<List<Product>>( _productDal.Getall(p=>p.UnitPrice>=min &&p.UnitPrice<=max));

        }

        public IDataResult<List<ProductDetailDto>> GetProductDetails()
        {
           return new SuccessDataResult<List<ProductDetailDto>> (_productDal.GetProductDetails());
        }

        public IDataResult<Product> GeyById(int id)
        {
            return new SuccessDataResult<Product>( _productDal.Get(p=>p.ProductId==id));
        }

        
    }
}
