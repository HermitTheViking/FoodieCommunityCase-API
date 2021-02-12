using FoodieCommunityCase.Domain.Commands;
using FoodieCommunityCase.Domain.Entities.Food;
using FoodieCommunityCase.Domain.ErrorHandling;
using FoodieCommunityCase.Domain.Events;
using FoodieCommunityCase.Domain.Events.Foodrepo;
using FoodieCommunityCase.Domain.Mappers;
using FoodieCommunityCase.Domain.Messaging;
using FoodieCommunityCase.Domain.Models;
using FoodieCommunityCase.Domain.Repository;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;

namespace FoodieCommunityCase.Domain.CommandHandlers
{
    public class FoodrepoCommandHandler :
        ICommandHandler,
        IAsyncCommandHandler<UpdateCacheCommand>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IEventStore _eventStore;
        private readonly FoodrepoEventFactory _foodrepoEventFactory;
        private readonly IConfiguration _config;
        private readonly ILogger<FoodrepoCommandHandler> _logger;
        private readonly IMapper<RecipModel, Recip> _recipMapper;

        public FoodrepoCommandHandler(
            IUnitOfWork unitOfWork,
            IEventStore eventStore,
            IMapper<RecipModel, Recip> recipMapper,
            IConfiguration config,
            ILogger<FoodrepoCommandHandler> logger,
            FoodrepoEventFactory foodrepoEventFactory
            )
        {
            _unitOfWork = unitOfWork ?? throw new ArgumentNullException(nameof(unitOfWork));
            _eventStore = eventStore ?? throw new ArgumentNullException(nameof(eventStore));
            _recipMapper = recipMapper ?? throw new ArgumentNullException(nameof(recipMapper));
            _config = config ?? throw new ArgumentNullException(nameof(config));
            _logger = logger ?? throw new ArgumentNullException(nameof(logger));
            _foodrepoEventFactory = foodrepoEventFactory ?? throw new ArgumentNullException(nameof(foodrepoEventFactory));
        }

        public async Task HandleAsync(UpdateCacheCommand command)
        {
            if (command == null) { throw ExceptionFactory.CommandIsNull(); }

            List<RecipModel> listOfRecipModel = new List<RecipModel>();
            RootobjectModel rootobject = GetRootobject(GetFoodrepoProducts($"https://www.foodrepo.org/api/v3/products?page%5Bnumber%5D=1&page%5Bsize%5D={ command.PageSize }").Result, command.PageNumer);
            listOfRecipModel.AddRange(rootobject.Data);

            for (int i = 0; i < 3; i++)
            {
                rootobject = GetRootobject(GetFoodrepoProducts(rootobject.Links.Next).Result, command.PageNumer);
                listOfRecipModel.AddRange(rootobject.Data);
            }

            var tmpListOfRecips = (from RecipModel model in listOfRecipModel select _recipMapper.Map(model)).ToList();
            var listOfRecip = _unitOfWork.Foodrepos.GetAllAsyncRecip().Result;

            foreach (Recip recip in listOfRecip)
            {
                if (tmpListOfRecips.Select(x => x.RepoId).ToList().Contains(recip.RepoId))
                {
                    tmpListOfRecips.Remove(tmpListOfRecips.Where(x => x.RepoId == recip.RepoId).First());
                }
            }

            if (tmpListOfRecips.Count > 0 || listOfRecip.Count == 0)
            {
                try
                {
                    _unitOfWork.Foodrepos.AddRangeRecip(tmpListOfRecips);
                    _eventStore.AddEvents(_foodrepoEventFactory.GetFoodrepoUpdatedEvent(tmpListOfRecips));
                    await _unitOfWork.SaveAsync();
                }
                catch (Exception ex)
                {
                    _logger.LogError(ex.Message);
                }
            }
        }

        private RootobjectModel GetRootobject(string HttpResponseMessage, int pageNumer)
        {
            string responseBody = HttpResponseMessage;
            File.WriteAllText(@$"C:\temp\skole\foodrepo{ pageNumer }.json", responseBody);
            return JsonConvert.DeserializeObject<RootobjectModel>(responseBody);
        }

        private async Task<string> GetFoodrepoProducts(string url)
        {
            try
            {
                HttpClient client = new HttpClient();
                client.DefaultRequestHeaders.Add("Authorization", JObject.Parse(File.ReadAllText(_config.GetSection("FoodrepoApi").GetSection("ApiKey").Value)).GetValueOrThrowException("key").ToString());

                var request = new HttpRequestMessage()
                {
                    RequestUri = new Uri(url),
                    Method = HttpMethod.Get
                };

                HttpResponseMessage response = client.SendAsync(request).Result;
                response.EnsureSuccessStatusCode();
                return await response.Content.ReadAsStringAsync();
            }
            catch (HttpRequestException hrex)
            {
                throw ExceptionFactory.ErrorAtFoodrepo(hrex.Message);
            }
        }

        //private void RemoveDuplicates()
        //{
        //    var listOfNutrients = _unitOfWork.Foodrepos.GetAllAsyncNutrient().Result;

        //    if (listOfNutrients.Select(x => x.CarbohydratesInfoId).Count() > 1)
        //    {
        //        var keepId = listOfNutrients.Select(x => x.CarbohydratesInfoId).First();
        //        foreach (var nutrient in listOfNutrients.Where(x => x.CarbohydratesInfoId != null))
        //        {
        //            nutrient.CarbohydratesInfoId = keepId;
        //        }

        //        foreach (var item in listOfNutrients.Select(x => x.CarbohydratesInfoId).Skip(1).ToList())
        //        {
        //            _unitOfWork.Foodrepos.RemoveNutrientInfo(_unitOfWork.Foodrepos. GetAsyncNutrientInfoById((int)item));
        //        }
        //    }

        //    if (listOfNutrients.Select(x => x.ProteinInfoId).Count() > 1)
        //    {
        //        var keepId = listOfNutrients.Select(x => x.ProteinInfoId).First();
        //        foreach (var nutrient in listOfNutrients.Where(x => x.ProteinInfoId != null))
        //        {
        //            nutrient.ProteinInfoId = keepId;
        //        }

        //        foreach (var item in listOfNutrients.Select(x => x.ProteinInfoId).Skip(1).ToList())
        //        {
        //            _unitOfWork.Foodrepos.RemoveNutrientInfo(_unitOfWork.Foodrepos. GetAsyncNutrientInfoById((int)item));
        //        }
        //    }

        //    if (listOfNutrients.Select(x => x.EnergyInfoId).Count() > 1)
        //    {
        //        var keepId = listOfNutrients.Select(x => x.EnergyInfoId).First();
        //        foreach (var nutrient in listOfNutrients.Where(x => x.EnergyInfoId != null))
        //        {
        //            nutrient.EnergyInfoId = keepId;
        //        }

        //        foreach (var item in listOfNutrients.Select(x => x.EnergyInfoId).Skip(1).ToList())
        //        {
        //            _unitOfWork.Foodrepos.RemoveNutrientInfo(_unitOfWork.Foodrepos. GetAsyncNutrientInfoById((int)item));
        //        }
        //    }

        //    if (listOfNutrients.Select(x => x.EnergyKcalInfoId).Count() > 1)
        //    {
        //        var keepId = listOfNutrients.Select(x => x.EnergyKcalInfoId).First();
        //        foreach (var nutrient in listOfNutrients.Where(x => x.EnergyKcalInfoId != null))
        //        {
        //            nutrient.EnergyKcalInfoId = keepId;
        //        }

        //        foreach (var item in listOfNutrients.Select(x => x.EnergyKcalInfoId).Skip(1).ToList())
        //        {
        //            _unitOfWork.Foodrepos.RemoveNutrientInfo(_unitOfWork.Foodrepos. GetAsyncNutrientInfoById((int)item));
        //        }
        //    }

        //    if (listOfNutrients.Select(x => x.FatInfoId).Count() > 1)
        //    {
        //        var keepId = listOfNutrients.Select(x => x.FatInfoId).First();
        //        foreach (var nutrient in listOfNutrients.Where(x => x.FatInfoId != null))
        //        {
        //            nutrient.FatInfoId = keepId;
        //        }

        //        foreach (var item in listOfNutrients.Select(x => x.FatInfoId).Skip(1).ToList())
        //        {
        //            _unitOfWork.Foodrepos.RemoveNutrientInfo(_unitOfWork.Foodrepos. GetAsyncNutrientInfoById((int)item));
        //        }
        //    }

        //    if (listOfNutrients.Select(x => x.FiberInfoId).Count() > 1)
        //    {
        //        var keepId = listOfNutrients.Select(x => x.FiberInfoId).First();
        //        foreach (var nutrient in listOfNutrients.Where(x => x.FiberInfoId != null))
        //        {
        //            nutrient.FiberInfoId = keepId;
        //        }

        //        foreach (var item in listOfNutrients.Select(x => x.FiberInfoId).Skip(1).ToList())
        //        {
        //            _unitOfWork.Foodrepos.RemoveNutrientInfo(_unitOfWork.Foodrepos. GetAsyncNutrientInfoById((int)item));
        //        }
        //    }

        //    if (listOfNutrients.Select(x => x.SaltInfoId).Count() > 1)
        //    {
        //        var keepId = listOfNutrients.Select(x => x.SaltInfoId).First();
        //        foreach (var nutrient in listOfNutrients.Where(x => x.SaltInfoId != null))
        //        {
        //            nutrient.SaltInfoId = keepId;
        //        }

        //        foreach (var item in listOfNutrients.Select(x => x.SaltInfoId).Skip(1).ToList())
        //        {
        //            _unitOfWork.Foodrepos.RemoveNutrientInfo(_unitOfWork.Foodrepos. GetAsyncNutrientInfoById((int)item));
        //        }
        //    }

        //    if (listOfNutrients.Select(x => x.SaturatedFatInfoId).Count() > 1)
        //    {
        //        var keepId = listOfNutrients.Select(x => x.SaturatedFatInfoId).First();
        //        foreach (var nutrient in listOfNutrients.Where(x => x.SaturatedFatInfoId != null))
        //        {
        //            nutrient.SaturatedFatInfoId = keepId;
        //        }

        //        foreach (var item in listOfNutrients.Select(x => x.SaturatedFatInfoId).Skip(1).ToList())
        //        {
        //            _unitOfWork.Foodrepos.RemoveNutrientInfo(_unitOfWork.Foodrepos. GetAsyncNutrientInfoById((int)item));
        //        }
        //    }

        //    if (listOfNutrients.Select(x => x.SodiumInfoId).Count() > 1)
        //    {
        //        var keepId = listOfNutrients.Select(x => x.SodiumInfoId).First();
        //        foreach (var nutrient in listOfNutrients.Where(x => x.SodiumInfoId != null))
        //        {
        //            nutrient.SodiumInfoId = keepId;
        //        }

        //        foreach (var item in listOfNutrients.Select(x => x.SodiumInfoId).Skip(1).ToList())
        //        {
        //            _unitOfWork.Foodrepos.RemoveNutrientInfo(_unitOfWork.Foodrepos. GetAsyncNutrientInfoById((int)item));
        //        }
        //    }

        //    if (listOfNutrients.Select(x => x.SugarsInfoId).Count() > 1)
        //    {
        //        var keepId = listOfNutrients.Select(x => x.SugarsInfoId).First();
        //        foreach (var nutrient in listOfNutrients.Where(x => x.SugarsInfoId != null))
        //        {
        //            nutrient.SugarsInfoId = keepId;
        //        }

        //        foreach (var item in listOfNutrients.Select(x => x.SugarsInfoId).Skip(1).ToList())
        //        {
        //            _unitOfWork.Foodrepos.RemoveNutrientInfo(_unitOfWork.Foodrepos. GetAsyncNutrientInfoById((int)item));
        //        }
        //    }

        //    _unitOfWork.Save();
        //}
    }
}
