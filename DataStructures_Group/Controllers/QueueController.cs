using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace DataStructures_Group.Controllers
{
    public class QueueController : Controller
    {
        // GET: Queue
        public ActionResult Index()
        {
            ViewBag.OutputQueue = myQueue;
            return View();
        }

        Queue<string> myQueue = new Queue<string>();

        public ActionResult AddOne()
        {
            myQueue.Enqueue("New Entry #" + (myQueue.Count + 1));
            ViewBag.OutputQueue = myQueue;
            return View("Index");
        }

        public ActionResult AddMany()
        {
            myQueue.Clear();
            for (int iCount = 0; iCount < 2000; iCount++)
            {
                myQueue.Enqueue("New Entry #" + (myQueue.Count + 1));
            }
            ViewBag.OutputQueue = myQueue;
            return View("Index");
        }


        //perhaps put a modal in the view with the caption "Display Queue" then when you click it, have the view display in a wondrous array of a modal. :)
        public ActionResult Display()
        {
            ViewBag.OutputQueue = myQueue;
            return View("displayQueue");
        }

        //fix this--need to dequeue first or last element?
        public ActionResult DeleteItem()
        {
            myQueue.Dequeue();
            ViewBag.OutputQueue = myQueue;
            return View("Index");
        }

        public ActionResult ClearAll()
        {
            myQueue.Clear();
            ViewBag.OutputQueue = myQueue;
            return View("Index");
        }

        //link to HTML helper??
        public ActionResult Search()
        {
            myQueue.Contains("Yo");
            ViewBag.OutputQueue = myQueue;
            return View("Index");
        }

        [HttpPost]
        public string SearchQueue(FormCollection form)
        {
            System.Diagnostics.Stopwatch stopWatch = new System.Diagnostics.Stopwatch();
            stopWatch.Start();

            //retrieve guess from form by ID
            string guess = form["queueGuess"].ToString();
            
            string ans = "";
            if (myQueue.Contains(guess))
            {
                ans = "True";
            }
            else
            {
                ans = "False";
            }

            stopWatch.Stop();

            TimeSpan timeSpan = stopWatch.Elapsed;

            string totalTime = ans + " : " + timeSpan;

            return totalTime;
        }

    }
}