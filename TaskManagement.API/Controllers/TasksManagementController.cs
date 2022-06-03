using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

using TaskManagement.Core.Domains;
using TaskManagement.Core.Infrastructure.Controllers;
using TaskManagement.Data;

using Throw;

namespace TaskManagement.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TasksManagementController : BaseApiController

    {
        private readonly TaskManagementDbContext _context;

        public TasksManagementController(TaskManagementDbContext context)
        {
            _context = context;
        }

        // GET: api/TasksManagement
        [HttpGet]
        public async Task<ActionResult<IEnumerable<TaskModel>>> GetTasks()
        {
            if (_context.Tasks == null)
            {
                return NotFound();
            }
            return await _context.Tasks.ToListAsync();
        }

        // GET: api/TasksManagement/5
        [HttpGet("{id}")]
        public async Task<ActionResult<TaskModel>> GetTask(int id)
        {
            if (_context.Tasks == null)
            {
                return NotFound();
            }
            var task = await _context.Tasks.FindAsync(id);

            if (task == null)
            {
                return NotFound();
            }

            return task;
        }

        // PUT: api/TasksManagement/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutTask(int id, TaskModel task)
        {
            if (id != task.Id)
            {
                return BadRequest();
            }
            update_audit(ref task);
            _context.Entry(task).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!TaskExists(id))
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

        // POST: api/TasksManagement
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<TaskModel>> PostTask(TaskModel task)
        {
            if (_context.Tasks == null)
            {
                return Problem("Entity set 'TaskManagementDbContext.Tasks'  is null.");
            }
            task.ThrowIfNull();
            create_audit(ref task);
            _context.Tasks.Add(task);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetTask", new { id = task.Id }, task);
        }

        // DELETE: api/TasksManagement/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteTask(int id)
        {
            if (_context.Tasks == null)
            {                
                return NotFound();
            }
            var task = await _context.Tasks.FindAsync(id);
            if (task == null)
            {
                return NotFound();
            }
            delete_audit(ref task);
            _context.Tasks.Remove(task);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool TaskExists(int id)
        {
            return (_context.Tasks?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
