using ApiGDS.Core.Dto;
using ApiGDS.Core.Entities;
using ApiGDS.Core.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ApiGDS.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BillsController : ControllerBase
    {
        private readonly IBillRepository _billRepository;
        public BillsController(IBillRepository billRepo)
        {
            _billRepository = billRepo ?? throw new ArgumentException(nameof(billRepo));
        }
        [HttpGet("/GetBills")]
        public async Task<ActionResult<IEnumerable<Bill>>> Get()
        {
            return await _billRepository.GetAllBills();
        }
        [HttpDelete("/DeleteBillById/{id:int}")]
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
                return NotFound();
            return Ok(await _billRepository.DeleteBillById(id));
        }
        [HttpPost("/CreateBill")]
        public async Task<ActionResult<Bill>> Postbill(BillDTO newBill)
        {
            Bill bill = await _billRepository.PostBill(newBill);
            return Ok(bill);
        }
    }
}
