using ApiGDS.Core.Dto;
using ApiGDS.Core.Entities;
using ApiGDS.Core.Exceptions;
using ApiGDS.Core.Interfaces;
using ApiGDS.Infraestructure.DbCtx;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApiGDS.Infraestructure.Services
{
    public class FolderService : IFolderRepository
    {
        public readonly AppDbContext _context;
        public FolderService(AppDbContext context)
        {
              _context= context;
        }
        public async Task<bool> DeleteFolderById(int? folderId)
        {
            var folder = await _context.Carpetas.FirstOrDefaultAsync(f=> f.Id == folderId);
            if (folder == null) 
            {
                return false;
            }
            _context.Carpetas.Remove(folder);
            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<List<Folder>> GetAllFolders()
        {
            return await _context.Carpetas
                .Include(c=>c.Client)
                .Include(c =>c.Contrato)
                .Include(a=>a.Appendix)
                .ToListAsync();
        }

        public Task<Folder> GetFolderByClient(string clientName)
        {
            var searchedFolder = _context.Carpetas.FirstOrDefault(f => f.ClientName == clientName);
            if (searchedFolder == null) 
            { 
                throw new NotFoundException($"Folder with Client Name {clientName} not found."); 
            }
            return Task.FromResult<Folder>(searchedFolder);
        }

        public Task<Folder> GetFolderById(int id)
        {
            var searchedFolder = _context.Carpetas.FirstOrDefault(f => f.Id == id);
            if(searchedFolder == null)
            {
                throw new NotFoundException($"Folder with id {id} not found.");
            }
            return Task.FromResult(searchedFolder);
        }

        public async Task<Folder> PostFolder(FolderDTO newFolderDTO)
        {
            Client? client = _context.Clientes.FirstOrDefault(cliente => cliente.Name == newFolderDTO.ClientName);
            if (client == null)
            {
                throw new NotFoundException($"Client with name {newFolderDTO.ClientName} not found.");
            };
            Contrato? contrato = _context.Contratos.FirstOrDefault(c => c.Name == newFolderDTO.ContratoName);
            if (contrato == null)
            {
                throw new NotFoundException($"Consultant with name {newFolderDTO.ContratoName} not found.");
            };
            Appendix? appendix = _context.Anexos.FirstOrDefault(appendix => appendix.Name == newFolderDTO.AppendixName);
            if (appendix == null)
            {
                throw new NotFoundException($"Consultant with name {newFolderDTO.AppendixName} not found.");
            };
            Folder folder = new()
            {
                
                ClientName = newFolderDTO.ClientName,
                Client = client,
                ContratoName = newFolderDTO.ContratoName,
                Contrato = contrato,
                AppendixName = newFolderDTO.AppendixName,
                Appendix = appendix
            };
            _context.Carpetas.Add(folder);
            await _context.SaveChangesAsync();
            return folder;
        }

        public Task<bool> UpdateFolderById(int folderId, Folder updatedFolder)
        {
            throw new NotImplementedException();
        }
    }
}
