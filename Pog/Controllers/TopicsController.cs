#nullable disable
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Pog.Models.ViewModel;

namespace Pog.Controllers
{
    [Authorize]
    public class TopicsController : Controller
    {
        private readonly ApplicationDbContext _context;

        public TopicsController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Topics
        public async Task<IActionResult> Index(int? page)
        {

            var applicationDbContext = await _context.Topics.Include(t => t.TopicDueDate).Include(t => t.Category).Include(t => t.User).Include(t => t.Comments).ToListAsync();
            if (page == null) page = 1;

            var links = (from l in _context.Topics
                         select l).OrderBy(x => x.Id);

            int pageSize = 5;
            int pageNumber = (page ?? 1);

            return View(links.ToPagedList(pageNumber, pageSize));
        }

        // GET: Topics/Details/5
        [HttpGet]
        public async Task<IActionResult> Details(int? id)
        {
           
        
            if (id == null)
            {
                return NotFound();
            }
            var topic =await _context.Topics
                .Include(c=>c.Comments)
                    .ThenInclude(c=>c.User)
                .Include(c=>c.User)
                .Include(c => c.TopicDueDate)
                .Include(c=>c.Category)
                .FirstOrDefaultAsync(c=>c.Id == id);

            if(topic == null)
            {
                return NotFound(); 
            }


            return View(topic);
        }

        // GET: Topics/Create
        public IActionResult Create()
        {
            ViewData["TopicDueDateId"] = new SelectList(_context.TopicDueDates, "Id", "Id");
            ViewData["CategoryId"] = new SelectList(_context.Categories, "Id", "Name");
            //ViewData["StaffId"] = new SelectList(_context.Users, "Id", "Email");
            return View();
        }

        // POST: Topics/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Name,Description,IsAnonymous,DateCreate,StaffId,CategoryId,TermAndCondition,TopicAttachments,TopicAttachmentName,TopicDueDateId")] Topic topic, List<IFormFile> files)
        { 
            if (ModelState.IsValid)
            {
                //Attachment  
                foreach (var file in files)
                {
                    var basePath = Path.Combine(Directory.GetCurrentDirectory() + "\\Files\\");
                    bool basePathExists = System.IO.Directory.Exists(basePath);
                    if (!basePathExists) Directory.CreateDirectory(basePath);
                    var fileName = Path.GetFileNameWithoutExtension(file.FileName);
                    var filePath = Path.Combine(basePath, file.FileName);
                    var extension = Path.GetExtension(file.FileName);

                    using (var stream = new FileStream(filePath, FileMode.Create))
                    {
                        await file.CopyToAsync(stream);
                    }
                    topic.TopicAttachmentName = fileName;
                    topic.TopicAttachments = filePath;

                  

                }

                topic.DateCreate = DateTime.Now;
                topic.User = _context.Users.Where(u => u.UserName == User.Identity.Name).FirstOrDefault();;
                      _context.Add(topic);
                await _context.SaveChangesAsync();
                return RedirectToAction("Details", "TopicDueDates", new { id = topic.TopicDueDateId });
            }
            ViewData["CategoryId"] = new SelectList(_context.Categories, "Id", "Name", topic.CategoryId);
            ViewData["TopicDueDateId"] = new SelectList(_context.TopicDueDates, "Id", "Id", topic.TopicDueDate);
            return View(topic);

        }

        //Download Attachment
        public async Task<IActionResult> DownloadFileFromFileSystem(int? id, List<IFormFile> files)
        {

            if (id == null)
            {
                return NotFound();
            }

            var topic = await _context.Topics
                .FirstOrDefaultAsync(m => m.Id == id);
            if (topic == null)
            {
                return NotFound();
            }
            var basePath = Path.Combine(Directory.GetCurrentDirectory() + "\\Files\\" + Path.GetFileName(topic.TopicAttachments));
            var memory = new MemoryStream();
            using (var stream = new FileStream(basePath, FileMode.Open))
            {
                await stream.CopyToAsync(memory);
            }
            memory.Position = 0;
            return File(memory, GetContentType(basePath), Path.GetFileName(basePath));
        }

        //Get content type
        private string GetContentType(string path)
        {
            var types = GetMimeTypes();
            var ext = Path.GetExtension(path).ToLowerInvariant();
            return types[ext];
        }

        //Get mime types
        private static Dictionary<string, string> GetMimeTypes()
        {
            return new Dictionary<string, string>
            {
                {".txt", "text/plain"},
                {".pdf", "application/pdf"},
                {".doc", "application/vnd.ms-word"},
                {".docx", "application/vnd.ms-word"},
                {".xls", "application/vnd.ms-excel"},
                {".xlsx", "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet"},
                {".png", "image/png"},
                {".jpg", "image/jpeg"},
                {".jpeg", "image/jpeg"},
                {".gif", "image/gif"},
                {".csv", "text/csv"}
            };
         }

        //Comment
        //


        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Comment(int topicid, CommentViewModel vm)
        {
            var topic = _context.Topics
                .Include(c => c.Comments)
                .Include(c => c.TopicDueDate)
                .Include(c => c.User)
                .FirstOrDefault(m => m.Id == topicid);
            if (topic.TopicDueDate.FinalDate < DateTime.Now)
            {
               
               return Content("You can't post comment");

            }
            else { 
            if (!ModelState.IsValid)
            {
                return RedirectToAction("Details", new { id = vm.TopicId});
            }
            
           var CommentDue = _context.TopicDueDates.FirstOrDefault(m => m.Id == topicid);

            var user = _context.Users.Where(u=>u.UserName == User.Identity.Name).FirstOrDefault();
          
            if (vm.CommentId == 0)
            {
                topic.Comments = topic.Comments ?? new List<Comment>();
                
                topic.Comments.Add(new Comment 
                {   
                    
                    TopicDueDateId= topic.TopicDueDateId,                    
                    CommentText = vm.CommentText,
                    DateCreate = DateTime.Now,
                    User = user,
                    IsAnonymous = vm.IsAnonymous,
                });
                _context.Update(topic);
            }
            }
            await _context.SaveChangesAsync();
            return RedirectToAction("Details", new {id = vm.TopicId});
        }

        // GET: Topics/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            var user = _context.Users.Where(u => u.UserName == User.Identity.Name).FirstOrDefault();
            var topic = await _context.Topics.FindAsync(id);
            if (topic == null)
            {
                return NotFound();
            }
            ViewData["CategoryId"] = new SelectList(_context.Categories, "Id", "Name", topic.CategoryId);
            ViewData["TopicDueDateId"] = new SelectList(_context.TopicDueDates, "Id", "Id", topic.TopicDueDate);
            return View(topic);
        }

        // POST: Topics/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Name,Description,IsAnonymous,DateCreate,StaffId,CategoryId,TermAndCondition,TopicAttachments,TopicAttachmentName,TopicDueDateId")] Topic topic, List<IFormFile> files)
        {
            if (id != topic.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    
                    topic.DateCreate=DateTime.Now;
                    _context.Update(topic);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!TopicExists(topic.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction("Details", "TopicDueDates", new { id = topic.TopicDueDateId });
            }
            ViewData["CategoryId"] = new SelectList(_context.Categories, "Id", "Name", topic.CategoryId);
            ViewData["TopicDueDateId"] = new SelectList(_context.TopicDueDates, "Id", "Id", topic.TopicDueDate);
            return View(topic);
        }

        // GET: Topics/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var topic = await _context.Topics
                .Include(t => t.Category)
                .Include(t => t.User)
                .Include(t=>t.Comments)
                .Include(t=>t.TopicDueDate)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (topic == null)
            {
                return NotFound();
            }
            
            return View(topic);
        }

        // POST: Topics/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            foreach(var comment in _context.Comments)
            {
                if(comment.Id == id)
                {
                    _context.Comments.Remove(comment);
                }
            }
            var topic = await _context.Topics.FindAsync(id);
            _context.Topics.Remove(topic);
            await _context.SaveChangesAsync();
            return RedirectToAction("Details", "TopicDueDates", new { id = topic.TopicDueDateId });
        }

        private bool TopicExists(int id)
        {
            return _context.Topics.Any(e => e.Id == id);
        }


    }
}
