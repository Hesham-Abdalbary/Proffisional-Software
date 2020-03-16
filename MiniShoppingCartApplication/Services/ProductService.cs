using AutoMapper;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using MiniShoppingCartApplication.Models;
using MiniShoppingCartApplication.Repository;
using MiniShoppingCartApplication.ViewModels;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace MiniShoppingCartApplication.Services
{
    public class ProductService
    {
        private ProductRepository _repo;
        private readonly IHostingEnvironment _hostingEnvironment;
        public ProductService(IHostingEnvironment hostingEnvironment)
        {
            _repo = new ProductRepository();
            _hostingEnvironment = hostingEnvironment;
        }

        public List<ProductDto> GetAll(string rootPath)
        {
            var products = _repo.GetAll();
            var productsModels = Mapper.Map<List<Product>, List<ProductDto>>(products);
            productsModels = productsModels.Select( p => { p.ImagePath = rootPath + p.ImagePath; return p; }).ToList();
            return productsModels;
        }

        public ProductDto GetByID(int productID, string rootPath)
        {
            var productEntity = _repo.GetByID(productID);
            var productModel = Mapper.Map<Product, ProductDto>(productEntity);
            productModel.ImagePath = rootPath + productModel.ImagePath;
            return productModel;
        }

        public int Add(ProductDto productModel, List<IFormFile> files)
        {
            if (files != null)
            {
                var file = files.FirstOrDefault();
                var path = Path.Combine(_hostingEnvironment.ContentRootPath, "wwwroot\\" + file.FileName);
                using (FileStream filestream = File.Create(path))
                {
                    file.CopyTo(filestream);
                    filestream.Flush();
                    productModel.ImagePath = "//" + file.FileName;
                }
            }
            var productEntity = Mapper.Map<ProductDto, Product>(productModel);
            var addProductResult = _repo.Add(productEntity);
            return addProductResult;
        }

        public int Update(ProductDto productModel, List<IFormFile> files, string rootPath)
        {
            if(files != null)
            {
                var file = files.FirstOrDefault();
                var path = Path.Combine(_hostingEnvironment.ContentRootPath, "wwwroot\\" + file.FileName);
                using (FileStream filestream = File.Create(path))
                {
                    file.CopyToAsync(filestream);
                    filestream.FlushAsync();
                    productModel.ImagePath = "//" + file.FileName;
                }
            }
            else
            {
                var product = GetByID(productModel.ProductID, rootPath);
                productModel.ImagePath = product.ImagePath;
            }
            var productEntity = Mapper.Map<ProductDto, Product>(productModel);
            var updateProductResult = _repo.Update(productEntity);
            return updateProductResult;
        }

        public int Delete(int productID)
        {
            var deleteResult = _repo.Delete(productID);
            return deleteResult;
        }
    }
}
