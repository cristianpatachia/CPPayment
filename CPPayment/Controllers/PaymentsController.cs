using CPPayment.Domain.Models.SqlViews;
using CPPayment.Domain.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace PaymentAPI.Controllers;

[Route("api/[controller]")]
[ApiController]
public class PaymentsController : ControllerBase
{
    private readonly IPaymentService _paymentService;

    public PaymentsController(IPaymentService paymentService)
    {
        _paymentService = paymentService;
    }

    // GET: api/Payments/GetPayments
    [HttpGet("GetPayments")]
    public async Task<ActionResult<IEnumerable<Payment>>> GetPayments()
    {
        var payments = await _paymentService.GetAllAsync();
        if (payments is null || payments.Count == 0)
        {
            return NotFound();
        }
        return payments;
    }

    // GET: api/Payments/GetPayment/5
    [HttpGet("GetPayment/{id}")]
    public async Task<ActionResult<Payment>> GetPayment(int id)
    {
        var payment = await _paymentService.GetByIdAsync(id);
        if (payment is null)
        {
            return NotFound();
        }

        return payment;
    }

    // PUT: api/Payments/UpdatePayment/5
    // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
    [HttpPut("UpdatePayment/{id}")]
    public async Task<IActionResult> UpdatePayment(int id, Payment payment)
    {
        if (id != payment.Id)
        {
            return BadRequest();
        }

        try
        {
            await _paymentService.UpdateAsync(payment);
        }
        catch (DbUpdateConcurrencyException)
        {
            if (_paymentService.GetByIdAsync(id) is null)
            {
                return NotFound();
            }
            else
            {
                throw;
            }
        }

        return Ok(await _paymentService.GetAllAsync());
    }

    // POST: api/Payments/CreatPayment
    // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
    [HttpPost("CreatePayment")]
    public async Task<ActionResult<Payment>> CreatePayment(Payment payment)
    {
        await _paymentService.AddAsync(payment);

        return Ok(await _paymentService.GetAllAsync());
    }

    // DELETE: api/Payments/DeletePayment/5
    [HttpDelete("DeletePayment/{id}")]
    public async Task<IActionResult> DeletePayment(int id)
    {
        var payment = await _paymentService.GetByIdAsync(id);
        if (payment is null)
        {
            return NotFound();
        }

        await _paymentService.DeleteAsync(payment);

        return Ok(await _paymentService.GetAllAsync());
    }
}