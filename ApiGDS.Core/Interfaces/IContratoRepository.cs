using ApiGDS.Core.Dto;
using ApiGDS.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApiGDS.Core.Interfaces
{
    public interface IContratoRepository
    {
        Task<List<Contrato>> GetAllContratos();
        Task<Contrato> GetContratoById(int id);
        Task<Contrato> GetContratoByName(string name);
        Task<Contrato> GetContratoByClase(string clase);
        Task<List<Contrato>> GetAllContratosByCliente(string clienteName);
        Task<Contrato> PostContrato(ContratoDTO newContratoDTO);
        Task<bool> UpdateContratoById(int contratoId, Contrato updatedContrato);
        Task<bool> DeleteContratoById(int? contratoId);
    }
}
