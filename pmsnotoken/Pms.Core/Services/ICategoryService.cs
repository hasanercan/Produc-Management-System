using System;
using Pms.Core.Dtos;

namespace Pms.Core.Services
{
	public interface ICategoryService:IService<Category>
	{
        Task<CustomResponseDto<CategoryWithProductsDto>> GetSingleCategoryByIdWithProductsAsync(int categoryId);
    }
}

