using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using RSI_7.Models;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;

namespace RSI_7.Controllers
{
    public class HomeController : Controller
    {

        private readonly ILogger<HomeController> _logger;
        public static List<BookModel> books = new List<BookModel>();
        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
            books = new List<BookModel>();
            books.Add(new BookModel() { Id = 1, Author = "Mróz", Title = "Ankush", wasRewarded=true });
            books.Add(new BookModel() { Id = 2, Author = "Topka", Title = "Rohit", wasRewarded=true });
            books.Add(new BookModel() { Id = 3, Author = "Conan-Doyle", Title = "Sherlock Holmes", wasRewarded=true });
            books.Add(new BookModel() { Id = 4, Author = "Szczygieł", Title = "Nie ma", wasRewarded=false });
        }

        public IActionResult Index()
        {
            return View(books);
        }

        
        [HttpGet]
        public JsonResult GetDetailsById(int id)
        {
            var book = books.Where(d => d.Id.Equals(id)).FirstOrDefault();
            JsonResponseViewModel model = new JsonResponseViewModel();
            if (book != null)
            {
                model.ResponseCode = 200;
                model.ResponseMessage =JsonConvert.SerializeObject(book);
            }
            else
            {
                model.ResponseCode = 404;
                model.ResponseMessage = "Book not found";
            }
            return Json(model);
        }

        /*
        [HttpPost]
        public JsonResult InsertStudent(IFormCollection formcollection)
        {
            BookModel student = new BookModel();
            student.Author = formcollection["Author"];
            student.Name = formcollection["name"];

            JsonResponseViewModel model = new JsonResponseViewModel();
            //MAKE DB CALL and handle the response
            if (student != null)
            {
                model.ResponseCode = 0;
                model.ResponseMessage = JsonConvert.SerializeObject(student);
            }
            else
            {
                model.ResponseCode = 1;
                model.ResponseMessage = "No record available";
            }
            return Json(model);
        }
        [HttpPut]
        public JsonResult UpdateStudent(IFormCollection formcollection)
        {
            BookModel student = new BookModel();
            student.Id = int.Parse(formcollection["id"]);
            student.Author = formcollection["Author"];
            student.Name = formcollection["name"];

            JsonResponseViewModel model = new JsonResponseViewModel();
            //MAKE DB CALL and handle the response
            if (student != null)
            {
                model.ResponseCode = 0;
                model.ResponseMessage = JsonConvert.SerializeObject(student);
            }
            else
            {
                model.ResponseCode = 1;
                model.ResponseMessage = "No record available";
            }
            return Json(model);
        }
        [HttpDelete]
        public JsonResult DeleteStudent(IFormCollection formcollection)
        {
            BookModel student = new BookModel();
            student.Id = int.Parse(formcollection["id"]);

            JsonResponseViewModel model = new JsonResponseViewModel();
            //MAKE DB CALL and handle the response
            if (student != null)
            {
                model.ResponseCode = 0;
                model.ResponseMessage = JsonConvert.SerializeObject(student);
            }
            else
            {
                model.ResponseCode = 1;
                model.ResponseMessage = "No record available";
            }
            return Json(model);
        }
        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
        */
    }
      
    
}
