using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using BlazorWithIdentity.Server.Data;
using BlazorWithIdentity.Shared;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.JsonPatch.Operations;
using BlazorWithIdentity.Shared.Models;

namespace BlazorWithIdentity.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OpertationTypeController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public OpertationTypeController(ApplicationDbContext context)
        {
            _context = context;
        }
        public async Task<ActionResult<IEnumerable<OperationTypeRequest>>> GetOperation()
        {
            return await _context.OperationType.ToListAsync();
        }
    }
}
