using FoodieCommunityCase.Domain.Entities.Food;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace FoodieCommunityCase.Domain.Repository
{
    public interface IFoodrepoRepository
    {
        Task<List<Recip>> GetAllAsyncRecip();
        Task<List<Image>> GetAllAsyncImage();
        Task<List<Nutrient>> GetAllAsyncNutrient();
        Task<List<NutrientInfo>> GetAllAsyncNutrientInfo();
        Task<List<Category>> GetAllAsyncCategory();

        Task<List<Recip>> GetAllAsyncRecipByCountry(string country);

        Task<Recip> GetAsyncRecipById(int Id);
        Task<Image> GetAsyncImageById(int Id);
        Task<Nutrient> GetAsyncNutrientById(int Id);
        Task<NutrientInfo> GetAsyncNutrientInfoById(int Id);
        Task<Category> GetAsyncCategoryById(int Id);

        void AddRecip(Recip entity);
        void AddImage(Image entity);
        void AddNutrient(Nutrient entity);
        void AddNutrientInfo(NutrientInfo entity);
        void AddCategory(Category entity);

        void AddRangeRecip(List<Recip> entities);
        void AddRangeImage(List<Image> entities);
        void AddRangeNutrient(List<Nutrient> entities);
        void AddRangeNutrientInfo(List<NutrientInfo> entities);
        void AddRangeCategory(List<Category> entities);

        void UpdateRecip(Recip entity);
        void UpdateImage(Image entity);
        void UpdateNutrient(Nutrient entity);
        void UpdateNutrientInfo(NutrientInfo entity);
        void UpdateCategory(Category entity);

        void UpdateRangeRecip(List<Recip> entities);
        void UpdateRangeImage(List<Image> entities);
        void UpdateRangeNutrient(List<Nutrient> entities);
        void UpdateRangeNutrientInfo(List<NutrientInfo> entities);
        void UpdateRangeCategory(List<Category> entities);

        void RemoveRecip(Recip entity);
        void RemoveImage(Image entity);
        void RemoveNutrient(Nutrient entity);
        void RemoveNutrientInfo(NutrientInfo entity);
        void RemoveCategory(Category entity);

        void RemoveRangeRecip(List<Recip> entities);
        void RemoveRangeImage(List<Image> entities);
        void RemoveRangeNutrient(List<Nutrient> entities);
        void RemoveRangeNutrientInfo(List<NutrientInfo> entities);
        void RemoveRangeCategory(List<Category> entities);
    }
}
