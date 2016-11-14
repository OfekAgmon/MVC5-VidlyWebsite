using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Vidly.BusinessLogic.BusinessLogic.Api;
using Vidly.Models;

namespace Vidly.Controllers
{

    public class MoviesController : Controller
    {
        private IDataApi _dataApi;

        public MoviesController(IDataApi dataApi)
        {
            this._dataApi = dataApi;
        }
        // GET: Movies
        // pageIndex and sortBy are nullables
        
        // option: /movies?pageIndex=2&sortBy=ReleaseDate
        public ActionResult Index()
        {

            return View(_dataApi.getMovies());
        }

        //   works for GET to urls:
        //  /Movies/Details/1
        //  /Movies/Details?id=1
        public ActionResult Details(int id)
        {
            if (id >= _dataApi.getMovies().ToList().Count || id < 0)
                return HttpNotFound();
            var movie = _dataApi.getMovies().ToList().ElementAt(id);

            if (movie == null)
                return HttpNotFound();

            return View(movie);

        }

        //            if (!pageIndex.HasValue)
        //                pageIndex = 1;
        //            if (String.IsNullOrWhiteSpace(sortBy))
        //                sortBy = "Name";

        //            return Content(string.Format("pageIndex={0} and sortBy={1}", pageIndex, sortBy));


        // GET: Movies/Random using RandomMovieViewModel to pass a lot of data  
        //        public ActionResult Random()
        //        {
        //            var movie = new Movie() { Name = "Shrek" };
        //            var customers = new List<Customer>
        //            {
        //                new Customer {Name = "Ofek"},
        //                new Customer {Name = "Nadav"}
        //            };
        //
        //            var viewModel = new RandomMovieViewModel
        //            {
        //                Movie = movie,
        //                Customers = customers
        //            };
        //                
        //                
        //             return View(viewModel);
        //        }

        // GET: Movies/RedirectToHomeWithArgs
        //        public ActionResult RedirectToHomeWithArgs()
        //        {
        //            return RedirectToAction("Index", "Home", new { page = 1, sortBy = "name" });
        //        }



        //        public ActionResult Edit(int id)
        //        {
        //            return Content("id=" + id);
        //        }

        // access this from movies/ByReleaseDate?year=2015&month=4
        // and also from custom route in RouteConfig: movies/released/2015/4
        // forces year and month to be 4 and 2 digits (only in this route)
        //        public ActionResult ByReleaseDate(int year, int month)
        //        {
        //            return Content(string.Format("year: {0}, month:{1}", year, month));
        //        }
    }
}