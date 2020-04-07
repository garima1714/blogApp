using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using blogApp.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace blogApp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class postController : Controller
    {
        DataAcessLayer objpost = new DataAcessLayer();
        // GET: api/post


        //[HttpGet(Name = "Get an product")]
        [Route("createtable")]
        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }
        [Route("createtable")]
        [HttpPost]
        public IActionResult Create([FromForm] Post post)
        {
           
                objpost.AddPost(post);
                return RedirectToAction("Index");
           
            return View(post);
        }
       [HttpGet]

        public IActionResult Index()
        {
            List<Post> posts = new List<Post>();
            posts = objpost.GetAllPost().ToList();
            return View(posts);
        }

        // GET: api/post/5
        [HttpGet("{id}")]
        public IActionResult Details(int id)
        {
            {
                if (id == null)
                {
                    return NotFound();
                }
                Post post = objpost.GetPostData(id);

                if (post == null)
                {
                    return NotFound();
                }
                return View(post);
            }
        }

        [HttpGet]
        [Route("edit")]
        public IActionResult Edit(int? id)
        {
            
            Post post = objpost.GetPostData(id);

            if (post == null)
            {
                return NotFound();
            }
            return View(post);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        [Route("edit")]
        public IActionResult Edit(int id, [FromForm]Post post)
        {
            if (ModelState.IsValid)
            {
                objpost.UpdatePost(post);
                return RedirectToAction("Index");
            }
            return View(post);


        }
        // DELETE: api/ApiWithActions/5
        [HttpDelete("{id}")]
        [Route("delete/{id}",Name =("del"))]
        public IActionResult Delete(int id)
        {
            objpost.DeletePost(id);
            return RedirectToAction("Index");
        }
    }
}
