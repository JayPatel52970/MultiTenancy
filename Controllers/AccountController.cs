using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MultiTenancyAngular;

namespace MultiTenancyAngular.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AccountController : ControllerBase
    {
        private readonly CatelogDbContext _context;

        public AccountController(CatelogDbContext context)
        {
            _context = context;
        }

        // GET: api/Account
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Tenant>>> Gettenants()
        {
            return await _context.tenants.ToListAsync();
        }

        // GET: api/Account/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Tenant>> GetTenant(string id)
        {
            var tenant = await _context.tenants.FindAsync(id);

            if (tenant == null)
            {
                return NotFound();
            }

            return tenant;
        }

        // PUT: api/Account/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutTenant(string id, Tenant tenant)
        {
            if (id != tenant.HostUrl)
            {
                return BadRequest();
            }

            _context.Entry(tenant).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!TenantExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // POST: api/Account
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<Tenant>> PostTenant(Tenant tenant)
        {
            _context.tenants.Add(tenant);
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (TenantExists(tenant.HostUrl))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtAction("GetTenant", new { id = tenant.HostUrl }, tenant);
        }

        // DELETE: api/Account/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<Tenant>> DeleteTenant(string id)
        {
            var tenant = await _context.tenants.FindAsync(id);
            if (tenant == null)
            {
                return NotFound();
            }

            _context.tenants.Remove(tenant);
            await _context.SaveChangesAsync();

            return tenant;
        }

        private bool TenantExists(string id)
        {
            return _context.tenants.Any(e => e.HostUrl == id);
        }
    }
}
