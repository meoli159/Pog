using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace Pog.Controllers
{
    //[Authorize(Roles = "Admin,QA")]
    [AllowAnonymous]
    public class UsersController : Controller
    {
        private readonly ApplicationDbContext _context;
        public UsersController(ApplicationDbContext context)
        {
            _context = context;
        }
        // GET: UserController
        public async Task<IActionResult> Index()
        {
            return View(await _context.Users.ToListAsync());
        }

        // GET: UserController/Details/5
        public async Task<IActionResult> Details(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var user = await _context.Users.Include(u => u.Department).FirstOrDefaultAsync(m => m.Id == id);
            if (user == null)
            {
                return NotFound();
            }

            return View(user);
        }

        public async Task<IActionResult> Edit(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var user = await _context.Users.FindAsync(id);
            if (user == null) {
                return NotFound();
            }
            ViewData["DepartmentIds"] = new SelectList(_context.Departments, "Id", "DepartmentName", user.DepartmentId);
            return View(user);
        }

        // POST: UserController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(string id, CUser user)
        {
            if (id != user.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(user);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!UserExists(user.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            ViewData["DepartmentIds"] = new SelectList(_context.Departments, "Id", "DepartmentName", user.DepartmentId);
            return View(user);

        }

        // GET: UserController/Delete/5
        public async Task<IActionResult> Delete(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var user = await _context.Users.FirstOrDefaultAsync(m => m.Id == id);
            if (user == null)
            {
                return NotFound();
            }

            return View(user);
        }

        // POST: UserController/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(string id)
        {

            var user = await _context.Users.FindAsync(id);
            if (user == null)
            {
                return NotFound();
            }
            _context.Users.Remove(user);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool UserExists(string id)
        {
            return _context.Users.Any(e => e.Id == id);
        }

        public async Task<IActionResult> AssignRole(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var user = await _context.Users.Include(u => u.Department).FirstOrDefaultAsync(m => m.Id == id);
            if (user == null)
            {
                return NotFound();
            }

            var currentRoleIds = await _context.UserRoles.Where(u => u.UserId == user.Id).Select(u => u.RoleId).ToListAsync();
            //Change Name to Id if you want to show RoleID
            var remainingRolesIds = await _context.Roles.Where(u => !currentRoleIds.Contains(u.Name)).Select(u => u.Name).ToListAsync();

            ViewData["RemainingRoleIds"] = remainingRolesIds;
            ViewData["CurrentRoleIds"] = currentRoleIds;

            return View(user);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> AddRole(string roleId, string userId)
        {
            if (roleId != null && userId != null)
            {
                var userrole = new IdentityUserRole<string>() 
                {
                    UserId = userId,
                    RoleId = roleId
                };

                _context.Add(userrole);
                await _context.SaveChangesAsync();
            }
            return RedirectToAction(nameof(AssignRole), new { id = userId });
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> RemoveRole(string roleId, string userId)
        {
            var userrole = await _context.UserRoles.FirstOrDefaultAsync(u => u.UserId == userId && u.RoleId == roleId);

            if (userrole != null)
            {
                _context.Remove(userrole);
                await _context.SaveChangesAsync();
            }
            return RedirectToAction(nameof(AssignRole), new { id = userId });
        }
    }
}
