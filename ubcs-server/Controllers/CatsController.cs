using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using ubcs_server.Data;
using ubcs_server.Data.Models;
using ubcs_server.Infrastructure;
using ubcs_server.Models.Cats;

namespace ubcs_server.Controllers
{
    public class CatsController : ApiController
    {
        private readonly UbcsDbContext data;

        public CatsController(UbcsDbContext data)
        {
            this.data = data;
        }

        [Authorize]
        [HttpPost]
        public async Task<IActionResult> Create(CreateCatRequestModel model)
        {
            var userId = this.User.GetId();
            var cat = new Cat
            {
                Description = model.Description,
                ImageUrl = model.ImageUrl,
                UserId = userId
            };

            this.data.Add(cat);

            await this.data.SaveChangesAsync();

            return Created(nameof(this.Create), cat.Id);
        }
    }
}
