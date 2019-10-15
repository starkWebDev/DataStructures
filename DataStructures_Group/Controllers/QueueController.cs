using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace DataStructures_Group.Controllers
{
    public class QueueController : Controller
    {
        static Queue<string> myQueue = new Queue<string>();
        // GET: Queue
        public ActionResult Index()
        {
            ViewBag.OutputQueue = myQueue;
            return View();
        }

        //add one element to queue
        public ActionResult AddOne()
        {
            myQueue.Enqueue("New Entry #" + (myQueue.Count + 1));
            ViewBag.OutputQueue = myQueue;
            return View("Index");
        }

        //add huge list to queue
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

        //display queue
        public ActionResult Display()
        {
            if (myQueue.Count == 0)
            {
                Response.Write("<script>alert('The queue is empty.')</script");
                ViewBag.OutputQueue = "";
                return View("Index");
            }
            else
            {
                ViewBag.OutputQueue = myQueue;
            }
            return View("displayQueue");
        }

        //delete one item
        public ActionResult DeleteItem()
        {
            if (myQueue.Count >= 1)
            {
                myQueue.Dequeue();
                ViewBag.OutputQueue = myQueue;
            }
            else
            {
                Response.Write("<script>alert('You must add to the queue before you can remove')</script");
            }

            ViewBag.OutputQueue = myQueue;
            return View("Index");
        }

        //clear queue
        public ActionResult ClearAll()
        {
            myQueue.Clear();
            ViewBag.OutputQueue = myQueue;
            return View("Index");
        }
     
        //search queue
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