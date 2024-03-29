﻿using Core.Ultities.Results;
using Entities.Concrete;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Abstract
{
     public interface IProductService
    {
        IDataResult<List<Product>> GetAll();
        IDataResult<List<Product>> GetAllByCategoryId(int id);

        IDataResult<List<Product>> GetByUnitPrice(decimal min,decimal max);
        IDataResult<List<ProductDetailDto>> GetProductDetails();

        IDataResult<Product>GeyById(int id);

        IResult  Add(Product product);//Bunda data yok

        IResult Update(Product product);

        IResult AddTransactionalTest(Product product);//uygulamlarda tutarlılığı yaptığımız yer
    }
}
