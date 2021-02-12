using FoodieCommunityCase.Domain.Entities;
using FoodieCommunityCase.Domain.Entities.Food;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FoodieCommunityCase.Domain.Repository.Implementations
{
    public class FoodrepoRepository : IFoodrepoRepository
    {
        private readonly FoodEntities _entities;

        public FoodrepoRepository(FoodEntities entities)
        {
            _entities = entities ?? throw new ArgumentNullException(nameof(entities));
        }

        #region Get
        public async Task<List<Recip>> GetAllAsyncRecip()
        {
            return await _entities.Recipes.Include(x => x.Nutrient).ThenInclude(x => x.CarbohydratesInfo)
.Include(x => x.Nutrient).ThenInclude(x => x.ProteinInfo)
.Include(x => x.Nutrient).ThenInclude(x => x.EnergyInfo)
.Include(x => x.Nutrient).ThenInclude(x => x.EnergyKcalInfo)
.Include(x => x.Nutrient).ThenInclude(x => x.FatInfo)
.Include(x => x.Nutrient).ThenInclude(x => x.FiberInfo)
.Include(x => x.Nutrient).ThenInclude(x => x.SaltInfo)
.Include(x => x.Nutrient).ThenInclude(x => x.SaturatedFatInfo)
.Include(x => x.Nutrient).ThenInclude(x => x.SodiumInfo)
.Include(x => x.Nutrient).ThenInclude(x => x.SugarsInfo)
.Include(x => x.Images)
.AsNoTracking().ToListAsync();
        }

        public async Task<List<Image>> GetAllAsyncImage()
        {
            return await _entities.Images.AsNoTracking().ToListAsync();
        }

        public async Task<List<Nutrient>> GetAllAsyncNutrient()
        {
            return await _entities.Nutrients.Include(x => x.CarbohydratesInfo).Include(x => x.ProteinInfo)
.Include(x => x.EnergyInfo).Include(x => x.EnergyKcalInfo).Include(x => x.FatInfo).Include(x => x.FiberInfo)
.Include(x => x.SaltInfo).Include(x => x.SaturatedFatInfo).Include(x => x.SodiumInfo).Include(x => x.SugarsInfo)
.AsNoTracking().ToListAsync();
        }

        public async Task<List<NutrientInfo>> GetAllAsyncNutrientInfo()
        {
            return await _entities.NutrientInfos.AsNoTracking().ToListAsync();
        }

        public async Task<List<Category>> GetAllAsyncCategory()
        {
            return await _entities.Categories.ToListAsync();
        }

        public async Task<List<Recip>> GetAllAsyncRecipByCountry(string country)
        {
            return await _entities.Recipes.Include(x => x.Nutrient).ThenInclude(x => x.CarbohydratesInfo)
.Include(x => x.Nutrient).ThenInclude(x => x.ProteinInfo)
.Include(x => x.Nutrient).ThenInclude(x => x.EnergyInfo)
.Include(x => x.Nutrient).ThenInclude(x => x.EnergyKcalInfo)
.Include(x => x.Nutrient).ThenInclude(x => x.FatInfo)
.Include(x => x.Nutrient).ThenInclude(x => x.FiberInfo)
.Include(x => x.Nutrient).ThenInclude(x => x.SaltInfo)
.Include(x => x.Nutrient).ThenInclude(x => x.SaturatedFatInfo)
.Include(x => x.Nutrient).ThenInclude(x => x.SodiumInfo)
.Include(x => x.Nutrient).ThenInclude(x => x.SugarsInfo)
.Include(x => x.Images)
.AsNoTracking().Where(x => x.Country == country).ToListAsync();
        }

        public async Task<Recip> GetAsyncRecipById(int Id)
        {
            return await _entities.Recipes.Include(x => x.Nutrient).ThenInclude(x => x.CarbohydratesInfo)
.Include(x => x.Nutrient).ThenInclude(x => x.ProteinInfo)
.Include(x => x.Nutrient).ThenInclude(x => x.EnergyInfo)
.Include(x => x.Nutrient).ThenInclude(x => x.EnergyKcalInfo)
.Include(x => x.Nutrient).ThenInclude(x => x.FatInfo)
.Include(x => x.Nutrient).ThenInclude(x => x.FiberInfo)
.Include(x => x.Nutrient).ThenInclude(x => x.SaltInfo)
.Include(x => x.Nutrient).ThenInclude(x => x.SaturatedFatInfo)
.Include(x => x.Nutrient).ThenInclude(x => x.SodiumInfo)
.Include(x => x.Nutrient).ThenInclude(x => x.SugarsInfo)
.Include(x => x.Images)
.AsNoTracking().FirstOrDefaultAsync(x => x.Id == Id);
        }

        public async Task<Image> GetAsyncImageById(int Id)
        {
            return await _entities.Images.AsNoTracking().FirstOrDefaultAsync(x => x.Id == Id);
        }

        public async Task<Nutrient> GetAsyncNutrientById(int Id)
        {
            return await _entities.Nutrients.Include(x => x.CarbohydratesInfo).Include(x => x.ProteinInfo)
.Include(x => x.EnergyInfo).Include(x => x.EnergyKcalInfo).Include(x => x.FatInfo).Include(x => x.FiberInfo)
.Include(x => x.SaltInfo).Include(x => x.SaturatedFatInfo).Include(x => x.SodiumInfo).Include(x => x.SugarsInfo)
.AsNoTracking().FirstOrDefaultAsync(x => x.Id == Id);
        }

        public async Task<NutrientInfo> GetAsyncNutrientInfoById(int Id)
        {
            return await _entities.NutrientInfos.AsNoTracking().FirstOrDefaultAsync(x => x.Id == Id);
        }

        public async Task<Category> GetAsyncCategoryById(int Id)
        {
            return await _entities.Categories.AsNoTracking().FirstOrDefaultAsync(x => x.Id == Id);
        }
        #endregion

        #region Add
        public void AddRecip(Recip entity)
        {
            _entities.Recipes.Add(entity);
        }

        public void AddImage(Image entity)
        {
            _entities.Images.Add(entity);
        }

        public void AddNutrient(Nutrient entity)
        {
            _entities.Nutrients.Add(entity);
        }

        public void AddNutrientInfo(NutrientInfo entity)
        {
            _entities.NutrientInfos.Add(entity);
        }

        public void AddCategory(Category entity)
        {
            _entities.Categories.Add(entity);
        }

        public void AddRangeRecip(List<Recip> entities)
        {
            _entities.Recipes.AddRange(entities);
        }

        public void AddRangeImage(List<Image> entities)
        {
            _entities.Images.AddRange(entities);
        }

        public void AddRangeNutrient(List<Nutrient> entities)
        {
            _entities.Nutrients.AddRange(entities);
        }

        public void AddRangeNutrientInfo(List<NutrientInfo> entities)
        {
            _entities.NutrientInfos.AddRange(entities);
        }

        public void AddRangeCategory(List<Category> entities)
        {
            _entities.Categories.AddRange(entities);
        }
        #endregion

        #region Update
        public void UpdateRecip(Recip entity)
        {
            _entities.Recipes.Update(entity);
        }

        public void UpdateImage(Image entity)
        {
            _entities.Images.Update(entity);
        }

        public void UpdateNutrient(Nutrient entity)
        {
            _entities.Nutrients.Update(entity);
        }

        public void UpdateNutrientInfo(NutrientInfo entity)
        {
            _entities.NutrientInfos.Update(entity);
        }

        public void UpdateCategory(Category entity)
        {
            _entities.Categories.Update(entity);
        }

        public void UpdateRangeRecip(List<Recip> entity)
        {
            _entities.Recipes.UpdateRange(entity);
        }

        public void UpdateRangeImage(List<Image> entity)
        {
            _entities.Images.UpdateRange(entity);
        }

        public void UpdateRangeNutrient(List<Nutrient> entity)
        {
            _entities.Nutrients.UpdateRange(entity);
        }

        public void UpdateRangeNutrientInfo(List<NutrientInfo> entity)
        {
            _entities.NutrientInfos.UpdateRange(entity);
        }

        public void UpdateRangeCategory(List<Category> entity)
        {
            _entities.Categories.UpdateRange(entity);
        }
        #endregion

        #region Remove
        public void RemoveRecip(Recip entity)
        {
            _entities.Recipes.Remove(entity);
        }

        public void RemoveImage(Image entity)
        {
            _entities.Images.Remove(entity);
        }

        public void RemoveNutrient(Nutrient entity)
        {
            _entities.Nutrients.Remove(entity);
        }

        public void RemoveNutrientInfo(NutrientInfo entity)
        {
            _entities.NutrientInfos.Remove(entity);
        }

        public void RemoveCategory(Category entity)
        {
            _entities.Categories.Remove(entity);
        }

        public void RemoveRangeRecip(List<Recip> entity)
        {
            _entities.Recipes.RemoveRange(entity);
        }

        public void RemoveRangeImage(List<Image> entity)
        {
            _entities.Images.RemoveRange(entity);
        }

        public void RemoveRangeNutrient(List<Nutrient> entity)
        {
            _entities.Nutrients.RemoveRange(entity);
        }

        public void RemoveRangeNutrientInfo(List<NutrientInfo> entity)
        {
            _entities.NutrientInfos.RemoveRange(entity);
        }

        public void RemoveRangeCategory(List<Category> entity)
        {
            _entities.Categories.RemoveRange(entity);
        }
        #endregion
    }
}
