using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;
using DbConnection;

namespace ajaxNotes.Controllers
{
    public class NotesController : Controller
    {
        // GET: /Home/
        [HttpGet]
        [Route("")]
        public IActionResult Index()
        {
            string query = "SELECT * FROM notes";
            var notes = DbConnector.Query(query);
            ViewBag.notes = notes;
            return View();
        }

        [HttpPost]
        [Route("newNote")]
        public IActionResult createNote(string title){
            string titleString =  title;
            string query = $"INSERT INTO notes(title)VALUES('{titleString}')";
            DbConnector.Execute(query);
            return RedirectToAction("Index");
        }

        [HttpGet]
        [Route("delete/{id}")]
        public IActionResult deleteNote(int id)
        {
            int noteId = id;
            string query = $"DELETE FROM notes WHERE(id = {noteId})";
            DbConnector.Execute(query);
            return RedirectToAction("Index");
        }

        [HttpPost]
        [Route("update/{id}")]
        public IActionResult updateNote(int id, string description)
        {
            int noteId = id;
            string query =  $"UPDATE notes SET description = '{description}' WHERE id = {id}";
            DbConnector.Execute(query);
            return RedirectToAction("Index");
        }
    }
}
