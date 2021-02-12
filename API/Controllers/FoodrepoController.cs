using FoodieCommunityCase.Domain.Commands;
using FoodieCommunityCase.Domain.Messaging;
using FoodieCommunityCase.Domain.Repository;
using FoodieCommunityCase.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Threading.Tasks;

namespace FoodieCommunityCase.Controllers
{
    [ApiController]
    public class FoodrepoController : ControllerBase
    {
        private readonly IMessageBus _messageBus;
        private readonly IUnitOfWork _unitOfWork;
        private readonly ILogger<FoodrepoController> _logger;

        public FoodrepoController(
            IMessageBus messageBus,
            IUnitOfWork unitOfWork,
            ILogger<FoodrepoController> logger
            )
        {
            _messageBus = messageBus ?? throw new ArgumentNullException(nameof(messageBus));
            _unitOfWork = unitOfWork ?? throw new ArgumentNullException(nameof(unitOfWork));
            _logger = logger ?? throw new ArgumentNullException(nameof(logger));
        }

        [HttpPut]
        [Route("api/foodrepo/updatecache")]
        [Authorize]
        public async Task<IActionResult> PutUpdateCacheAsync(UpdateCacheDto updateCache)
        {
            if (updateCache == null) { return BadRequest("Body was is empty"); }

            await _messageBus.SendAsync(new UpdateCacheCommand
            {
                PageNumer = updateCache.PageNumer > 0 ? updateCache.PageNumer : 1,
                PageSize = updateCache.PageSize > 0 ? updateCache.PageSize : 200
            });

            return Ok("Cache updated");
        }
    }
}
