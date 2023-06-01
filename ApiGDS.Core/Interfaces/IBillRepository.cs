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
        Task<Bill> PostBill(BillDTO newBilldto);
        Task<bool> DeleteBillById(int? billId);
    }
}
