using Microsoft.AspNetCore.Mvc;

using System;
using System.Threading.Tasks;

using TreeApp.ApplicationServices.Services;

namespace TreeApp.Web.Controllers
{
    [Route("/api/[controller]")]
    public class TreeController : Controller
    {
        private readonly ITreeService _treeService;

        public TreeController(ITreeService treeService)
        {
            _treeService = treeService;
        }

        [HttpGet("get/{id}")]
        public async Task GetAsync(Guid id)
        {
            HttpContext.Response.ContentType = "image/png";
            var content = await _treeService.GetTreeImageContent(id);
            await HttpContext.Response.BodyWriter.WriteAsync(content);
        }
    }
}
