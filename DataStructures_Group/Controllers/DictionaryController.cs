using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace DataStructures_Group.Controllers
{
    public class DictionaryController : Controller
    {

        static Dictionary<int, string> myDictionary = new Dictionary<int, string>();

        // GET: Dictionary
        public ActionResult Index()
        {
            ViewBag.OutputDictionary = myDictionary;
            return View();
        }

        //add one item to dict
        public ActionResult AddOne()
        {
            myDictionary.Add(myDictionary.Count + 1, "New Entry #" + (myDictionary.Count + 1));
            ViewBag.OutputDictionary = myDictionary;
            return View("Index");
        } 

        //add huge list to dict
        public ActionResult AddMany()
        {
            myDictionary.Clear();
            for (int iCount = 0; iCount < 2000; iCount++)
            {
                myDictionary.Add(myDictionary.Count + 1, "New Entry #" + (myDictionary.Count + 1));
            }
            ViewBag.OutputDictionary = myDictionary;
            return View("Index");
        }

        //display dictionary
        public ActionResult Display()
        {
            if (myDictionary.Count == 0)
            {
                Response.Write("<script>alert('The dictionary is empty.')</script");
                ViewBag.OutputDictionary = "";
                return View("Index");
            }
            else
            {
                foreach (KeyValuePair<int, string> eachEntry in myDictionary)
                {
                    ViewBag.OutputDictionary += "<p>" + eachEntry.Value + "</p>";
                }
            }

            //send to new view
            return View("DisplayDict");
        }

        //delete item from dictionary
        public ActionResult DeleteItem()
        {
            if (myDictionary.Count >= 1)
            {
                myDictionary.Remove(myDictionary.Count);
                ViewBag.OutputDictionary = myDictionary; 
            }
            else
            {
                Response.Write("<script>alert('You must add to the dictionary before you can remove')</script");
            }

            ViewBag.OutputDictionary = myDictionary;
            return View("Index");
        }

        //clear dict
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
            if (myDictionary.ContainsValue(guess))
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