﻿using AutoMapper;
using NLayer.Core.DTOs;
using NLayer.Core.Models;
using NLayer.Core.Repositories;
using NLayer.Core.Services;
using NLayer.Core.UnitOfWorks;
using NLayer.Repository.Repositoryies;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NLayer.Service.Services
{
    public class CategoryService : Service<Category>, ICategoryService
    {

        private readonly ICategoryRepository _categoryrepository;
        private readonly IMapper _mapper;


        public CategoryService(IUnitOfWork unitOfWork, IGenericRepository<Category> repository, ICategoryRepository categoryrepository, IMapper mapper) : base(unitOfWork, repository)
        {
            _categoryrepository = categoryrepository;
            _mapper = mapper;
        }

        public async Task<CustomResponseDto<CategoryWithProductsDto>> GetSingleCategoryByIdWithProductAsync(int categoryId)
        {
            var category = await _categoryrepository.GetSingleCategoryByIdWithProductAsync(categoryId);
            var categoryDto = _mapper.Map<CategoryWithProductsDto>(category);
            return CustomResponseDto<CategoryWithProductsDto>.Success(200, categoryDto);
            
        }
    }
}

