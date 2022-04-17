using Microsoft.AspNetCore.Mvc;

namespace Pog.Controllers
{
    public class DashBoardsController : Controller
    {
        private readonly ApplicationDbContext _context;

        public DashBoardsController(ApplicationDbContext context)
        {
            _context = context;
        }


        // GET: Dashboards
        [HttpGet]
        public ActionResult Index()
        {
            //Get all idea
            var listTopic = _context.Topics.ToList();


            //Create new list
            List<int> dataTopicInFac = new List<int>();



            //data
            var getTopic = _context.Topics.ToList();
            var getCategory = _context.Categories.ToList();
            var categorytype = listTopic.Select(p => p.Category.Name).Distinct();


            //count Idea of each department
            foreach (var item in categorytype)
            {
                dataTopicInFac.Add(listTopic.Count(x => x.Category.Name == item));

            }

            var analysisData = dataTopicInFac;

            //X
            ViewBag.CATEGORYTYPE = categorytype;
            //Y
            ViewBag.ANALYSISDATA = analysisData.ToList();
            //Y1


            return View();
        }


        public ActionResult PieChart()
        {
            //Get all idea
            var listTopic = _context.Topics.ToList();


            //Create new list
            List<int> dataTopicInFac = new List<int>();



            //data
            var getTopic = _context.Topics.ToList();
            var getCategory = _context.Categories.ToList();
            var categorytype = listTopic.Select(p => p.Category.Name).Distinct();


            //count Idea of each department
            foreach (var item in categorytype)
            {
                dataTopicInFac.Add(listTopic.Count(x => x.Category.Name == item));

            }

            var analysisData = dataTopicInFac;

            //X
            ViewBag.CATEGORYTYPE = categorytype;
            //Y
            ViewBag.ANALYSISDATA = analysisData.ToList();
            //Y1


            return View();
        }

        [HttpGet]
        public ActionResult CommentIndex()
        {
            //Get all idea
            var listComment = _context.Comments.ToList();


            //Create new list
            List<int> dataCommentInFac = new List<int>();



            //data
            var getComment = _context.Comments.ToList();
            var getCategory = _context.Categories.ToList();
            var commenttype = listComment.Select(p => p.CommentText).Distinct();


            //count Idea of each department
            foreach (var item in commenttype)
            {
                dataCommentInFac.Add(listComment.Count(x => x.CommentText == item));

            }

            var analysisData = dataCommentInFac;

            //X
            ViewBag.COMMENTTYPE = commenttype;
            //Y
            ViewBag.ANALYSISDATA = analysisData.ToList();
            //Y1


            return View();
        }

        public ActionResult CommentPieChart()
        {
            //Get all idea
            var listComment = _context.Comments.ToList();


            //Create new list
            List<int> dataCommentInFac = new List<int>();



            //data
            var getComment = _context.Comments.ToList();
            var getCategory = _context.Categories.ToList();
            var commenttype = listComment.Select(p => p.CommentText).Distinct();


            //count Idea of each department
            foreach (var item in commenttype)
            {
                dataCommentInFac.Add(listComment.Count(x => x.CommentText == item));

            }

            var analysisData = dataCommentInFac;

            //X
            ViewBag.COMMENTTYPE = commenttype;
            //Y
            ViewBag.ANALYSISDATA = analysisData.ToList();
            //Y1


            return View();
        }

    }
}
