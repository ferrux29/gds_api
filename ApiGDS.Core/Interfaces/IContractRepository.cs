using ApiGDS.Core.Dto;
using ApiGDS.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApiGDS.Core.Interfaces
{
    public interface IContractRepository
    {
        Task<List<Contract>> GetAllContratos();
        Task<Contract> GetContratoById(int id);
        Task<List<Contract>> GetAllContratosByCliente(string clienteName);
        Task<Contract> PostContrato(ContractDTo newContratoDTO);
        Task<bool> UpdateContratoById(int contratoId, ContractEditDto updatedContrato);
        Task<bool> DeleteContratoById(int? contratoId);
    }
}
