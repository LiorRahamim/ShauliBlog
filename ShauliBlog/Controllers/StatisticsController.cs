using ShauliBlog.DAL;
using System.Linq;
using System.Web.Mvc;

namespace ShauliBlog.Controllers
{
    [Authorize(Roles = "Admin")]
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

        // return title of post and number of comments in each post
        public ActionResult CommentsPerPost()
        {
            //var data = db.Posts.Select(p => p.Author);

            var data = db.Comments.GroupBy(c => c.PostId)
                                  .Select(v => new
                                  {
                                      PostId = v.Key,
                                      NumberOfComment = v.Count()
                                  });


            var res =
                from p in db.Posts
                join l in data on p.Id equals l.PostId
                select new { PostTitle = p.Title, NumberOfComments = l.NumberOfComment };

            res = res.OrderByDescending(p => p.NumberOfComments);

            return Json(res);
        }
    }
}