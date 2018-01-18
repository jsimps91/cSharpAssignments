using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;
using DbConnection;

namespace theWall.Controllers
{
    public class WallController : Controller
    {
        [HttpGet]
        [Route("wall")]
        public IActionResult Wall()
        {
            int? id = HttpContext.Session.GetInt32("id");
            string name = HttpContext.Session.GetString("user");
            string messageQuery = "SELECT message, message_id, users_id, messages.created_at, users.first_name, users.last_name FROM messages JOIN users ON messages.users_id WHERE messages.users_id = users.id";
            var messages = DbConnector.Query(messageQuery);
            string commentQuery = "SELECT comment, comments.created_at,  users.first_name, users.last_name, comments.messages_id FROM comments JOIN users ON comments.users_id WHERE comments.users_id = users.id";
            var comments = DbConnector.Query(commentQuery);
            ViewBag.name = name;
            ViewBag.id = id;
            ViewBag.messages = messages;
            ViewBag.comments = comments;
            return View();
        }
        [HttpGet]
        [Route("logout")]
        public IActionResult Logout()
        {
            HttpContext.Session.Clear();
            return RedirectToAction("Index", "Users");
        }
        [HttpPost]
        [Route("createMessage")]
        public IActionResult createMessage(string message)
        {
            int? id = HttpContext.Session.GetInt32("id");
            if(id == null)
            {
                return RedirectToAction("Index", "Users");
            }
            if(message.Length > 0)
            {
                int userId = (int)id;
                string query = $" INSERT INTO messages(users_id, message, created_at, updated_at)VALUES({userId}, '{message}', NOW(), NOW())";
                DbConnector.Execute(query);
            }
            return RedirectToAction("Wall");
        }
        [HttpPost]
        [Route("createComment")]
        public IActionResult createComment(string comment, int messageId)
        {
            int? id = HttpContext.Session.GetInt32("id");
            if(id == null)
            {
                return RedirectToAction("Index", "Users");
            }
            if(comment.Length > 0)
            {
                int userId = (int)id;
                string query = $" INSERT INTO comments(users_id, messages_id, comment, created_at, updated_at)VALUES({userId}, {messageId}, '{comment}', NOW(), NOW())";
                DbConnector.Execute(query);
            }
            return RedirectToAction("Wall");
        }

        [HttpGet]
        [Route("delete/{messageId}")]
        public IActionResult deleteMessage(int messageId)
        {
            string query1 = $"DELETE FROM comments WHERE messages_id = {messageId}";
            string query2 = $"DELETE FROM messages WHERE message_id = {messageId}";
            DbConnector.Execute(query1);
            DbConnector.Execute(query2);
            return RedirectToAction("Wall");
        }
    }
}