using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ThreeLayer.Data;
using ThreeLayer.Data.Models;
using ThreeLayer.Service.Dtos;
using ThreeLayer.Service.Models;

namespace ThreeLayer.Service
{
    public class ProductService
    {
        private readonly AppDbContext _context;

        private readonly IGenericRepository<Product> productRepository;
        private readonly IGenericRepository<Category> categoryRepository;
        private readonly IGenericRepository<ProductFeature> productFeatureRepository;

        private readonly UnitOfWork unitOfWork;

        public ProductService(AppDbContext context, IGenericRepository<Product> productRepository, IGenericRepository<Category> categoryRepository, IGenericRepository<ProductFeature> productFeatureRepository, UnitOfWork unitOfWork)
        {
            _context = context;
            this.productFeatureRepository = productFeatureRepository;
            this.productRepository = productRepository;
            this.categoryRepository = categoryRepository;
            this.productFeatureRepository = productFeatureRepository;
            this.unitOfWork = unitOfWork;
        }

        public async Task<Response<List<ProductDto>>> GetAll()
        {
            var products = await _context.Products.ToListAsync();

            var productDtos = products.Select(p => new ProductDto()
            {
                Id = p.Id,
                Name = p.Name,
                Price = p.Price,
                Stock = p.Stock,
                CategoryId = p.CategoryId,
            }).ToList();

            if (!productDtos.Any())
            {
                return new Response<List<ProductDto>>()
                {
                    Data = null,
                    Errors = new List<string>() { "Ürün mevcut değildir." },
                    Status = 404
                };
            }

            return new Response<List<ProductDto>>()
            {
                Data = productDtos,
                Errors = null,
                Status = 200
            };
        }

        public async Task<Response<string>> CreateAll(Category category, Product product, ProductFeature productFeature)
        {
            await categoryRepository.Add(category);
            await productRepository.Add(product);
            await productFeatureRepository.Add(productFeature);

            await unitOfWork.Commit();
            using (var transaction = unitOfWork.BeginTransaction())
            {
                transaction.Commit();
            }
            return new Response<string>();
        }
    }
}