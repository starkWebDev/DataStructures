using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace DataStructures_Group.Controllers
{
    public class StackController : Controller
    {

        static Stack<string> myStack = new Stack<string>();


        // GET: Stack
        public ActionResult Index()
        {
            ViewBag.OutputStack = myStack;
            return View();
        }


        public ActionResult AddOne()
        {
            myStack.Push("New Entry " + (myStack.Count + 1));
            ViewBag.OutputStack = myStack;
            return View("Index");
        }
        
        //Add 2000 items to stack after clearing it 
        public ActionResult AddMany()
        {
            myStack.Clear();
            for (int iCount = 0; iCount < 2000; iCount++)
            {
                myStack.Push("New Entry " + (myStack.Count + 1));
            }
            ViewBag.OutputStack = myStack;
            return View("Index");
        }

        //Display contents of stack using a foreach loop
        //Handle errors and inform user!
        public ActionResult Display()
        {
            foreach (string element in myStack)
            {
                ViewBag.OutputStack += myStack.ToString();
                //ViewBag.OutputStack += myStack.Peek();
            }
            return View("Index");
        }

        public ActionResult DeleteItem()
        {
            myStack.Pop();
            ViewBag.OutputStack = myStack;
            return View("Index");
        }

        public ActionResult ClearAll()
        {
            myStack.Clear();
            ViewBag.OutputStack = myStack;
            return View("Index");
        }

        [HttpPost]
        public String SearchStack(FormCollection form)
        {
            System.Diagnostics.Stopwatch stopWatch = new System.Diagnostics.Stopwatch();
            stopWatch.Start();

            string guess = form["stackGuess"].ToString();
            string ans;
            if (myStack.Contains(guess))
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