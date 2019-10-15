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

        //add one item to stack
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

        //display stack, check for errors
        public ActionResult Display()
        {
            if (myStack.Count == 0)
            {
                Response.Write("<script>alert('The stack is empty.')</script");
                ViewBag.OutputStack = "";
                return View("Index");
            }
            else
            {
                ViewBag.OutputStack = myStack;
            }

            return View("displayStack");
        }

        //delete one item from stack
        public ActionResult DeleteItem()
        {
            if (myStack.Count >= 1)
            {
                myStack.Pop();
                ViewBag.OutputStack = myStack;
            }
            else
            {
                Response.Write("<script>alert('You must add to the stack before you can remove')</script");
            }

            ViewBag.OutputStack = myStack;
            return View("Index");
        }

        //clear stack
        public ActionResult ClearAll()
        {
            myStack.Clear();
            ViewBag.OutputStack = myStack;
            return View("Index");
        }


        //search stack and time it
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