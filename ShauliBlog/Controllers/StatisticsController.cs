using ShauliBlog.DAL;
using System.Linq;
using System.Web.Mvc;

namespace ShauliBlog.Controllers
{
    public class StatisticsController : Controller
    {
        private BlogContext db = new BlogContext();

        // GET: Statistics
        public ActionResult Index()
        {
            return View();
        }


        /*
         * Retrieving the comments number orginized by author name
         * returns - {authorName, commentsNumber} pairs
         * (Using join + Groupby properties)
         */
        public ActionResult getCommentsNumberByAuthor()
        {
            var data = from post in db.Posts
                       join comment in db.Comments on post.Id equals comment.Id
                       group comment.Id by post.Author into commentsByAuthor
                       select new { authorName = commentsByAuthor.Key, commentsNumber = commentsByAuthor.Count() };
            return Json(data);
        }
    }
}