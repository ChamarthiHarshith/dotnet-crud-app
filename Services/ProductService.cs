using Microsoft.EntityFrameworkCore;
using CrudApp.Data;
using CrudApp.Models;
using CrudApp.Models.DTOs;

namespace CrudApp.Services
{
    public class ProductService : IProductService
    {
        private readonly ApplicationDbContext _context;
        private readonly ILogger<ProductService> _logger;

        public ProductService(ApplicationDbContext context, ILogger<ProductService> logger)
        {
            _context = context;
            _logger = logger;
        }

        public async Task<IEnumerable<Product>> GetAllProductsAsync()
        {
            try
            {
                _logger.LogInformation("Fetching all products");
                return await _context.Products.ToListAsync();
            }
            catch (Exception ex)
            {
                _logger.LogError($"Error fetching products: {ex.Message}");
                throw;
            }
        }

        public async Task<Product?> GetProductByIdAsync(int id)
        {
            try
            {
                _logger.LogInformation($"Fetching product with ID: {id}");
                return await _context.Products.FindAsync(id);
            }
            catch (Exception ex)
            {
                _logger.LogError($"Error fetching product {id}: {ex.Message}");
                throw;
            }
        }

        public async Task<Product> CreateProductAsync(CreateProductDto createProductDto)
        {
            try
            {
                _logger.LogInformation($"Creating new product: {createProductDto.Name}");
                
                var product = new Product
                {
                    Name = createProductDto.Name,
                    Description = createProductDto.Description,
                    Price = createProductDto.Price,
                    Quantity = createProductDto.Quantity,
                    CreatedDate = DateTime.Now
                };

                _context.Products.Add(product);
                await _context.SaveChangesAsync();

                _logger.LogInformation($"Product created successfully with ID: {product.Id}");
                return product;
            }
            catch (Exception ex)
            {
                _logger.LogError($"Error creating product: {ex.Message}");
                throw;
            }
        }

        public async Task<Product?> UpdateProductAsync(int id, UpdateProductDto updateProductDto)
        {
            try
            {
                _logger.LogInformation($"Updating product with ID: {id}");
                
                var product = await _context.Products.FindAsync(id);
                if (product == null)
                {
                    _logger.LogWarning($"Product with ID {id} not found");
                    return null;
                }

                product.Name = updateProductDto.Name;
                product.Description = updateProductDto.Description;
                product.Price = updateProductDto.Price;
                product.Quantity = updateProductDto.Quantity;
                product.UpdatedDate = DateTime.Now;

                _context.Products.Update(product);
                await _context.SaveChangesAsync();

                _logger.LogInformation($"Product {id} updated successfully");
                return product;
            }
            catch (Exception ex)
            {
                _logger.LogError($"Error updating product {id}: {ex.Message}");
                throw;
            }
        }

        public async Task<bool> DeleteProductAsync(int id)
        {
            try
            {
                _logger.LogInformation($"Deleting product with ID: {id}");
                
                var product = await _context.Products.FindAsync(id);
                if (product == null)
                {
                    _logger.LogWarning($"Product with ID {id} not found");
                    return false;
                }

                _context.Products.Remove(product);
                await _context.SaveChangesAsync();

                _logger.LogInformation($"Product {id} deleted successfully");
                return true;
            }
            catch (Exception ex)
            {
                _logger.LogError($"Error deleting product {id}: {ex.Message}");
                throw;
            }
        }
    }
}
