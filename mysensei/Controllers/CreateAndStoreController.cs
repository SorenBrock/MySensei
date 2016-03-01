using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using mysensei.Models;

namespace mysensei.Controllers
{
    public class CreateAndStoreController : Controller
    {
        private Repository _repository = new Repository();
        // GET: Home
        public ActionResult Index()
        {
            _repository.CreateAndStoreSomeObjects();
            return View();
        }
    }
}