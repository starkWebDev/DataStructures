using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace DataStructures_Group.Controllers
{
    public class DictionaryController : Controller
    {

        static Dictionary<string, int> myDictionary = new Dictionary<string, int>();

        // GET: Dictionary
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult AddOne()
        {

        }

        public ActionResult AddMany()
        {

        }

        public ActionResult Display()
        {

        }

        public ActionResult DeleteItem()
        {

        }

        public ActionResult ClearAll()
        {

        }

        public ActionResult Search()
        {

        }

       
    }
}