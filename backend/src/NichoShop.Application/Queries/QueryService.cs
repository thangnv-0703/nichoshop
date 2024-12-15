using Microsoft.EntityFrameworkCore;
using NichoShop.Application.Enums;
using NichoShop.Application.Models.ViewModels;
using NichoShop.Infrastructure;

namespace NichoShop.Application.Queries;
public class QueryService(NichoShopDbContext dbContext) : IQueryService
{
    private readonly NichoShopDbContext _dbContext = dbContext;

    public async Task<List<CategoryViewModel>> GetCategoryViewModelsAsync()
    {
        return await _dbContext.Category
            .Select(c => new CategoryViewModel
            {
                Id = c.Id,
                Name = c.Name,
                DisplayName = c.DisplayName
            })
            .ToListAsync();
    }

    public async Task<List<LocationViewModel>> GetLocationViewModelsAsync(int type, string parentCode)
    {
        // Get provinces
        if (type == (int)LocationEnum.Province)
        {
            return await _dbContext.Province
                .Select(c => new LocationViewModel
                {
                    Code = c.Code,
                    Name = c.Name,
                    FullName = c.FullName,
                    NameEn = c.NameEn,
                    FullNameEn = c.FullNameEn,
                    CodeName = c.CodeName,
                })
                .ToListAsync();
        }
        // Get districts
        else if (type == (int)LocationEnum.District)
        {
            return await _dbContext.District
                .Where(x => x.ProvinceCode == parentCode)
                .Select(c => new LocationViewModel
                {
                    Code = c.Code,
                    Name = c.Name,
                    FullName = c.FullName,
                    NameEn = c.NameEn,
                    FullNameEn = c.FullNameEn,
                    CodeName = c.CodeName,
                })
                .ToListAsync();
        }
        // Get wards
        else if (type == (int)LocationEnum.Ward)
        {
            return await _dbContext.Ward
                .Where(x => x.DistrictCode == parentCode)
                .Select(c => new LocationViewModel
                {
                    Code = c.Code,
                    Name = c.Name,
                    FullName = c.FullName,
                    NameEn = c.NameEn,
                    FullNameEn = c.FullNameEn,
                    CodeName = c.CodeName,
                })
                .ToListAsync();
        }
        return new List<LocationViewModel>();
    }
}
