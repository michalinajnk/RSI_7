using Microsoft.AspNetCore.Http;
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

        static HomeController(){
            books.Add(new BookModel() { Id = 1, Author = "Mróz", Title = "Ankush", wasRewarded = true });
            books.Add(new BookModel() { Id = 2, Author = "Topka", Title = "Rohit", wasRewarded = true });
            books.Add(new BookModel() { Id = 3, Author = "Conan-Doyle", Title = "Sherlock Holmes", wasRewarded = true });
            books.Add(new BookModel() { Id = 4, Author = "Szczygieł", Title = "Nie ma", wasRewarded = false });
        }

        public void replaceBook(BookModel bookToReplace) {
            int bookIdxToReplace = books.FindIndex(x => x.Id == bookToReplace.Id);
            books.RemoveAt(bookIdxToReplace);
            books.Insert(bookIdxToReplace, bookToReplace);
            
        }

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            return View(books);
        }

        
        [HttpGet]
        public JsonResult CountBooks()
        {

            JsonResponseViewModel model = new JsonResponseViewModel();
            if (books.Count != 0)
            {
                model.ResponseCode = 200;
                model.ResponseMessage = JsonConvert.SerializeObject(books.Count);
            }
            else
            {
                model.ResponseCode = 404;
                model.ResponseMessage = "Books not found";
            }
            return Json(model);
        }


        [HttpGet]
        public JsonResult displayMyData()
        {

            JsonResponseViewModel model = new JsonResponseViewModel();
            model.ResponseCode = 200;
            model.ResponseMessage =JsonConvert.SerializeObject(MyData.string_info());
            
            return Json(model);
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

       
        [HttpPost]
        public JsonResult InsertBook(IFormCollection formcollection)
        {
            BookModel book = new BookModel();
            book.Author = formcollection["Author"];
            book.Title = formcollection["Title"];
            book.wasRewarded = bool.Parse(formcollection["Awarded"]);

            JsonResponseViewModel model = new JsonResponseViewModel();
            //MAKE DB CALL and handle the response
            if (book != null)
            {
                books.Add(book);
                model.ResponseCode = 200;
                model.ResponseMessage = JsonConvert.SerializeObject(book);
            }
            else
            {
                model.ResponseCode = 404;
                model.ResponseMessage = "No record available";
            }
            return Json(model);
        }

        [HttpPut]
        public JsonResult UpdateBook(IFormCollection formcollection)
        {
            BookModel book = new BookModel();
            book.Id = int.Parse(formcollection["id"]);
            book.Author = formcollection["Author"];
            book.Title = formcollection["Title"];
            book.wasRewarded = bool.Parse(formcollection["Awarded"]);
            replaceBook(book);


            JsonResponseViewModel model = new JsonResponseViewModel();
            //MAKE DB CALL and handle the response
            if (book != null)
            {
                model.ResponseCode = 200;
                model.ResponseMessage = JsonConvert.SerializeObject(book);
            }
            else
            {
                model.ResponseCode =404;
                model.ResponseMessage = "No record available";
            }
            return Json(model);
        }
        [HttpDelete]
        public JsonResult DeleteBook(IFormCollection formcollection)
        {
            BookModel book = new BookModel();
            book.Id = int.Parse(formcollection["id"]);
            int bookIdxToReplace = books.FindIndex(x => x.Id ==  book.Id);

            JsonResponseViewModel model = new JsonResponseViewModel();
            //MAKE DB CALL and handle the response
            if (book != null)
            {
                books.RemoveAt(bookIdxToReplace);
                model.ResponseCode = 200;
                model.ResponseMessage = JsonConvert.SerializeObject(book);
            }
            else
            {
                model.ResponseCode = 404;
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
      
    
}
