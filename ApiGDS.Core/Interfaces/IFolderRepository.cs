using ApiGDS.Core.Dto;
using ApiGDS.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApiGDS.Core.Interfaces
{
    public interface IFolderRepository
    {
        Task<List<Folder>> GetAllFolders();
        Task<Folder> GetFolderById(int id);
        Task<Folder> GetFolderByClient(string clientName);
        Task<Folder> PostFolder(FolderDTO newFolderDTO);
        Task<bool> UpdateFolderById(int folderId, Folder updatedFolder);
        Task<bool> DeleteFolderById(int? folderId);
    }
}
