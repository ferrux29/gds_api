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
            _billRepository = billRepo ?? throw new ArgumentNullException(nameof(billRepo));
        }
        [HttpGet("/GetBills")]
        public async Task<ActionResult<IEnumerable<Bill>>> GetBills()
        {
            return await _billRepository.GetAllBills();
        }
        [HttpGet("/GetBillsById/{id:int}")]
        public async Task<ActionResult<Bill>> GetBill(int id)
        {
            return await _billRepository.GetBillById(id);
        }
        [HttpPost("/CreateBill")]
        public async Task<ActionResult<Bill>> PostBill(BillDTO billDTO)
        {
            Bill bill = await _billRepository.PostBill(billDTO);
            return CreatedAtAction("GetBill", new { id = bill.Id }, bill);
        }
        [HttpDelete("/DeleteBillById/{id:int}")]
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            return Ok(await _billRepository.DeleteBillById(id));
        }
    }
}
