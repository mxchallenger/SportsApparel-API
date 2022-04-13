﻿using Catalyte.Apparel.Data.Model;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
//using Catalyte.Apparel.Providers.Providers;

namespace Catalyte.Apparel.Data.Interfaces
{
    /// <summary>
    /// This interface provides an abstraction layer for product repository methods.
    /// </summary>
    public interface IProductRepository
    {
        Task<Product> GetProductByIdAsync(int productId);

        Task<IEnumerable<Product>> GetProductsAsync();

        Task<IEnumerable<string>> GetAllUniqueCategoriesAsync();

       Task<IEnumerable<string>> GetAllUniqueTypesAsync();

        Task<IEnumerable<Product>> GetProductsByCategoryAsync(List<string> category);

        Task<IEnumerable<Product>> GetProductsByTypeAsync(List<string> type);

        Task<IEnumerable<Product>> GetProductsByDemographicAsync(List<string> demographic);

        Task<IEnumerable<Product>> GetProductsByPrimaryColorCodeAsync(List<string> primaryColorCode);

        Task<IEnumerable<Product>> GetProductsBySecondaryColorCodeAsync(List<string> secondaryColorCode);

        Task<IEnumerable<Product>> GetProductsByMaterialAsync(List<string> material);

        Task<IEnumerable<Product>> GetProductsByBrandAsync(List<string> brand);

        Task<IEnumerable<Product>> GetProductsByAllFiltersAsync(List<string> brand, List<string> category, List<string> type, List<string> demographic, List<string> primaryColorCode, List<string> secondaryColorCode, List<string> material, double min, double max);
    }
}
