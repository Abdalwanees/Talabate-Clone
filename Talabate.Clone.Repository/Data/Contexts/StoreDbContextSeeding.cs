using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using Talabate.Clone.Core.Entites;

namespace Talabate.Clone.Repository.Data.Contexts
{
    public static class StoreDbContextSeeding
    {
        public async static Task SeedAsync(StoreDbContext context)
        {
            if (!(context.ProductBrands.Count() > 0))
            {
                // Read the JSON file asynchronously and wait for the result
                var brandSeedData = await File.ReadAllTextAsync("../Talabate.Clone.Repository/Data/DataSeeding/brands.json");

                // Deserialize the JSON data into a list of ProductBrand objects
                var brandData = JsonSerializer.Deserialize<List<ProductBrand>>(brandSeedData);

                // Optionally check if data is not null before proceeding
                if (brandData != null && brandData.Any())
                {
                    brandData = brandData.Select(b => new ProductBrand()
                    {
                        Name = b.Name
                    }).ToList();
                    // Add the deserialized data to the context and save changes
                    context.ProductBrands.AddRange(brandData);
                    await context.SaveChangesAsync();
                }

            }
            if (!(context.ProductCategories.Count() > 0))
            {
                var categoriySeedData = await File.ReadAllTextAsync("../Talabate.Clone.Repository/Data/DataSeeding/categories.json");
                var categoriyData = JsonSerializer.Deserialize<List<ProductCategories>>(categoriySeedData);
                if (categoriyData != null && categoriyData.Any())
                {
                    categoriyData = categoriyData.Select(b => new ProductCategories()
                    {
                        Name = b.Name
                    }).ToList();
                    context.ProductCategories.AddRange(categoriyData);
                    await context.SaveChangesAsync();
                }

            }
            if (!(context.Products.Count() > 0))
            {
                var productSeedData = await File.ReadAllTextAsync("../Talabate.Clone.Repository/Data/DataSeeding/products.json");
                var productData = JsonSerializer.Deserialize<List<Product>>(productSeedData);

                if (productData != null && productData.Any())
                {
                    productData = productData.Select(b => new Product()
                    {
                        Name = b.Name,
                        Description= b.Description,
                        PictureUrl= b.PictureUrl,
                        Price= b.Price,
                        BrandId= b.BrandId,
                        Brand= b.Brand,
                        Category= b.Category,
                        CategoryId= b.CategoryId,
                        
                    }).ToList();
                    context.Products.AddRange(productData);
                    await context.SaveChangesAsync();
                }

            }
        }

    }
}
