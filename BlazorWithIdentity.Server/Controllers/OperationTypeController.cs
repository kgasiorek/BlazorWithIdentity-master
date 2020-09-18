using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BlazorWithIdentity.Server.Data;
using BlazorWithIdentity.Shared.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace BlazorWithIdentity.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OperationTypeController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public OperationTypeController(ApplicationDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<OperationTypeRequest>>> GetOperation()
        {
            return await _context.OperationType.ToListAsync();
        }
    }
}
