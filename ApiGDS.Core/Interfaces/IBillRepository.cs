using ApiGDS.Core.Dto;
using ApiGDS.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApiGDS.Core.Interfaces
{
    public interface IBillRepository
    {
        Task<List<Bill>> GetAllBills();
        Task<Bill> GetBillById(int id);
        Task<Bill> PostBill(BillDTO newBillDTO);
        Task<bool> UpdateBillById(int id, Bill updatedBill);
        Task<bool> DeleteBillById(int? id);
    }
}
