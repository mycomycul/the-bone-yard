using System;
using Microsoft.AspNetCore.Mvc;

namespace scratch.Controllers
{
    /// <summary>
    /// Core Mvc Provides both Mvc and API endpoints in the same controller
    /// </summary>
    public class HelloWorldController:Controller
    {
        /// <summary>
        /// Basic Api Endpoint. Doesn't require controller base class
        /// </summary>
        /// <returns></returns>
        [HttpGet("api/helloworld")]
        public object HelloWorldApi(){
            return new{
                message = "Hello World",
                time = DateTime.Now
            };
        }

        /// <summary>
        /// Mvc Endpoint. Controller class provides support for Viewbags, Models etc.
        /// </summary>
        /// <returns></returns>
        [HttpGet("helloworld")]
        public ActionResult HellowWorldMvc(){
            ViewBag.Message = "Hello world!";
            ViewBag.Time = DateTime.Now;

            //return View("~/helloworld.cshtml");
            return View("helloworld");
        }
    }
}