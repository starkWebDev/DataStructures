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
            ViewBag.OutputDictionary = myDictionary;
            return View();
        }

        public ActionResult AddOne()
        {
            myDictionary.Add("New Entry #" + (myDictionary.Count + 1), myDictionary.Count + 1);
            ViewBag.OutputDictionary = myDictionary;
            return View("Index");
        } 

        public ActionResult AddMany()
        {
            myDictionary.Clear();
            for (int iCount = 0; iCount < 2000; iCount++)
            {
                myDictionary.Add("New Entry #" + (myDictionary.Count + 1), myDictionary.Count + 1);
            }
            ViewBag.OutputDictionary = myDictionary;
            return View("Index");
        }

        //Remove the ViewBag from the other methods and put the foreach loop in the Index method so the list displays correctly :)
        public ActionResult Display()
        {
            ViewBag.DisplayDictionary = "<ul>";

            foreach (KeyValuePair<string, int> eachEntry in myDictionary)
            {
                ViewBag.DisplayDictionary += "<li>" + eachEntry.Value + " " + eachEntry.Key + "</li>";
            }

            ViewBag.DisplayDictionary += "</ul>";
            return View("DisplayDict");
        }

        public ActionResult DeleteItem()
        {
            myDictionary.Remove("New Entry #" + myDictionary.Count);
            ViewBag.OutputDictionary = myDictionary;
            return View("Index");
        }

        public ActionResult ClearAll()
        {
            myDictionary.Clear();
            ViewBag.OutputDictionary = myDictionary;
            return View("Index");
        }

        //Post method to retrieve textbox input as guess
        //Time response
        [HttpPost]
        public String SearchDictionary(FormCollection form)
        {
            System.Diagnostics.Stopwatch stopWatch = new System.Diagnostics.Stopwatch();
            stopWatch.Start();

            string guess = form["dictGuess"].ToString();

            string ans = "";
            if (myDictionary.ContainsKey(guess))
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