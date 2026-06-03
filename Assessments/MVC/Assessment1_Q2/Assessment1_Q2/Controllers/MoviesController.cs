using System.Web.Mvc;
using Assessment1_Q2.Repository;
using Assessment1_Q2.Models;

namespace Assessment1_Q2.Controllers
{
    public class MoviesController : Controller
    {
        IMovieRepository repo = new MovieRepository();
        public ActionResult Index()
        {
            return View(repo.GetAll());
        }
        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Create(Movie movie)
        {
            repo.Insert(movie);
            repo.Save();
            return RedirectToAction("Index");
        }

        public ActionResult Edit(int id)
        {
            return View(repo.GetById(id));
        }

        [HttpPost]
        public ActionResult Edit(Movie movie)
        {
            repo.Update(movie);
            repo.Save();
            return RedirectToAction("Index");
        }

        public ActionResult Delete(int id)
        {
            repo.Delete(id);
            repo.Save();
            return RedirectToAction("Index");
        }

        public ActionResult MoviesByYear(int year)
        {
            return View(repo.GetByYear(year));
        }

        public ActionResult MoviesByDirector(string director)
        {
            return View(repo.GetByDirector(director));
        }
    }
}