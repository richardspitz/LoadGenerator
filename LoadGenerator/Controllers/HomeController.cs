using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading;
using System.Web;
using System.Web.Mvc;

namespace LoadGenerator.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            string machineName = System.Environment.MachineName;
            ViewBag.servername = machineName;
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";
            string machineName = System.Environment.MachineName;
            ViewBag.servername = machineName;
            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";
            string machineName = System.Environment.MachineName;
            ViewBag.servername = machineName;
            return View();
        }
        public ActionResult Load(int load,int runtime)
        {

            string machineName = System.Environment.MachineName;
            ViewBag.servername = machineName;
            ViewBag.Message = "Generated load of " + load.ToString() + "% for " + runtime.ToString() + "seconds.";
            
            if (load < 0 || load > 100)
                throw new ArgumentException("percentage");
            Thread t = new Thread(() =>
            {
                Thread.CurrentThread.IsBackground = true;
                Stopwatch watch = new Stopwatch();
                watch.Start();
                Stopwatch stoptimer = new Stopwatch();
                stoptimer.Start();
                while (stoptimer.Elapsed < TimeSpan.FromSeconds(runtime))
                {
                    // Make the loop go on for "percentage" milliseconds then sleep the 
                    // remaining percentage milliseconds. So 40% utilization means work 40ms and sleep 60ms
                    if (watch.ElapsedMilliseconds > load)
                    {
                        Thread.Sleep(100 - load);
                        watch.Reset();
                        watch.Start();
                    }

                }
                watch.Stop();
                stoptimer.Stop();
            });
            t.Start();
                  

            


            return View();
        }
    }
}