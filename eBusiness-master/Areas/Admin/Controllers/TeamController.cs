using eBusiness.Helpers;
using eBusiness.Models;
using Microsoft.AspNetCore.Mvc;

namespace eBusiness.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class TeamController : Controller
    {
        private readonly DataContext _dataContext;
        private readonly IWebHostEnvironment _env;

        public TeamController(DataContext dataContext, IWebHostEnvironment env)
        {
            _dataContext = dataContext;
            _env = env;
        }

        public IActionResult Index()
        {
            List<Team> teams = _dataContext.Teams.ToList();
            return View(teams);
        }
        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Create(Team team)
        {
            if (team.FormFile != null)
            {
                if (team.FormFile.ContentType != "image/png" && team.FormFile.ContentType != "image/jpeg")
                {
                    ModelState.AddModelError("ImageFile", "But it can be png and jpeg!");
                    return View();
                }
                if (team.FormFile.Length > 3145728)
                {
                    ModelState.AddModelError("ImageFile", "It can be 3 Mb!");
                    return View();
                }

                if (!ModelState.IsValid) return View();

                team.Image = FileManage.SaveFile(_env.WebRootPath, "uploads/team", team.FormFile);
                _dataContext.Teams.Add(team);
                _dataContext.SaveChanges();
                return RedirectToAction("index");
            }
            return View();
        }
        [HttpGet]
        public IActionResult Update(int id)
        {
            Team team = _dataContext.Teams.Find(id);
            if (team == null) return View();
            return View(team);
        }
        [HttpPost]
        public IActionResult Update(Team team)
        {
            Team exsistteam = _dataContext.Teams.Find(team.Id);
            if (exsistteam == null) return View();
            if (team.FormFile != null)
            {
                if (team.FormFile.ContentType != "image/png" && team.FormFile.ContentType != "image/jpeg")
                {
                    ModelState.AddModelError("ImageFile", "But it can be png and jpeg!");
                    return View();
                }
                if (team.FormFile.Length > 3145728)
                {
                    ModelState.AddModelError("ImageFile", "It can be 3 Mb!");
                    return View();
                }

                string name = FileManage.SaveFile(_env.WebRootPath, "uploads/team", team.FormFile);
                FileManage.DeleteFile(_env.WebRootPath, "uploads/team", exsistteam.Image);
                exsistteam.Image = name;
            }
            exsistteam.Perssion = team.Perssion;
            exsistteam.FullName = team.FullName;
            exsistteam.TURL = team.TURL;
            exsistteam.IURL = team.IURL;
            exsistteam.FURL = team.FURL;
            _dataContext.SaveChanges();
            return RedirectToAction("index");
        }
        [HttpGet]
        public IActionResult Delete(int? id)
        {
			Team team = _dataContext.Teams.Find(id);
			if (team == null) return View();
			return View(team);
			

        }
        [HttpPost]
        public IActionResult Delete(int id)
        {
			Team team = _dataContext.Teams.Find(id);
			if (team == null) return View();
			if (team.Image != null)
			{
				FileManage.DeleteFile(_env.WebRootPath, "uploads/team", team.Image);

			}
			_dataContext.Teams.Remove(team);
			_dataContext.SaveChanges();
			return Ok();
		}

    }
}
