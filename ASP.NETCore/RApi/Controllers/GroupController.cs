using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;
using JsonData;

namespace MusicApi.Controllers
{
    public class GroupController : Controller
    {
        List<Group> allGroups { get; set; }
        List<Artist> allArtists { get; set; }
        public GroupController()
        {
            allGroups = JsonToFile<Group>.ReadJson();
            allArtists = JsonToFile<Artist>.ReadJson();
        }

        [Route("groups")]
        [HttpGet]
        public JsonResult Groups()
        {
            return Json(allGroups);
        }

        [Route("groups/name/{name}")]
        [HttpGet]
        public JsonResult GroupName(string name)
        {
            var group = allGroups.Where(g => g.GroupName == name);
            return Json(group);
        }

        [Route("groups/id/{id}/{showArtists}")]
        [HttpGet]
        public JsonResult GroupId(int id, bool showArtists)
        {
            if (showArtists == false)
            {
                var group = allGroups.Where(g => g.Id == id);
                return Json(group);
            }
            else
            {
                // var members = allArtists.Where(a => a.GroupId == id).ToList();
                var group = allGroups.Where(g => g.Id == id).Join(allArtists, g => g.Id, a => a.GroupId, (g, a) =>
                {
                    // g.Members = members;
                    return a;
                });
                return Json(group);

            }
            


        }

    }
}