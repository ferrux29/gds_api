using ApiGDS.Core.Entities;
using ApiGDS.Core.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ApiGDS.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FoldersController : ControllerBase
    {
        private readonly IFolderRepository _folderRepository;
        public FoldersController(IFolderRepository folderRepository)
        {
            _folderRepository = folderRepository;
        }
        [HttpGet("/GetFolders")]
        public async Task<ActionResult<IEnumerable<Folder>>> GetFolders()
        {
            return await _folderRepository.GetAllFolders();
        }
        [HttpGet("/GetFolderById")]
        public async Task<ActionResult<Folder>> GetFolderById(int id)
        {
            return await _folderRepository.GetFolderById(id);
        }
        /*[HttpGet("/GetFolderByCliente")]
        public async Task<ActionResult>*/
    }
}
