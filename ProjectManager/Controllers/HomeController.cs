using Microsoft.AspNetCore.Mvc;
using ProjectManager.Models;
using ProjectManager.Models.BusinessLogic;
using ProjectManager.Models.Common;
using ProjectManager.Models.ViewMode;
using System.Diagnostics;
using Dashboard = ProjectManager.Models.ViewMode.Dashboard;

namespace ProjectManager.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private SqlModel sqlModel = new SqlModel();
        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            return View();
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

        public async Task<ActionResult> List(string input, string status, string clientid, string assign, string pic)
        {
            // var projects = _homemodel.GetAllProjects();
            List<ProjectManager.Models.Common.ProjectInfo> allproject = sqlModel.GetProjectInfo("", "", "", "", "");
            var projects = sqlModel.GetProjects();
            List<ProjectManager.Models.Common.ProjectInfo> pinfo = new List<ProjectManager.Models.Common.ProjectInfo>();
            pinfo = sqlModel.GetProjectInfo(input, status, clientid, assign, pic).Where(r => r.IssueType == "PROJECT").ToList();
            var viewModel = new ListViewModel
            {
                TotalProjects = pinfo.Count,
                StarredProjects = pinfo.Count(p => p.Starred == 1),
                TodoProjects = pinfo.Count(p => p.Status == "To-Do"),
                InProgressProjects = pinfo.Count(p => p.Status == "In-Progress"),
                OverdueProjects = pinfo.Count(p => p.DueDate < DateTime.Now &&( p.Status != "Done"||p.Status!= "Cancel")),
                CompletedProjects = pinfo.Count(p => p.Status == "Done"),
                CanceledProjects = pinfo.Count(p => p.Status == "Cancel"),
                Projects = pinfo,
                ALLProjects = allproject
            };
            return View(viewModel);
        }
        public async Task<ActionResult> Dashboard(string input, string status, string clientid, string assign, string pic)
        {
            // var projects = _homemodel.GetAllProjects();
            Dashboard listSum = sqlModel.Dashboard_header("", "", "", "", "");

            //var viewModel = new ListViewModel
            //{
            //    SumClients = listSum.SumClients,
            //    SumProjects = listSum.SumProjects,
            //    SumEpics = listSum.SumEpics,
            //    SumTasks = listSum.SumTasks,
            //    OverdueProjects = listSum.SumIssues
            //};
            return View(listSum);
        }
        public ActionResult filterData(string input, string status, string clientid, string assign, string pic)
        {


            List<ProjectInfo> allproject = sqlModel.GetProjectInfo("", "", "", "", "");
            List<ProjectInfo> project = sqlModel.GetProjectInfo(input, status, clientid, assign, pic);
            var pinfo = project.Where(r => r.IssueType == "PROJECT").ToList();
            var viewModel = new ListViewModel
            {
                TotalProjects = pinfo.Count,
                StarredProjects = pinfo.Count(p => p.Starred == 1),
                TodoProjects = pinfo.Count(p => p.Status == "To-Do"),
                InProgressProjects = pinfo.Count(p => p.Status == "In-Progress"),
                OverdueProjects = pinfo.Count(p => p.DueDate < DateTime.Now && (p.Status != "Done" || p.Status != "Cancel")),
                CompletedProjects = pinfo.Count(p => p.Status == "Done"),
                CanceledProjects = pinfo.Count(p => p.Status == "Cancel"),
                Projects = project,
                ALLProjects = allproject
            };

            return PartialView("_ListPartialView", viewModel); // Đảm bảo PartialView không trả về null


        }
        
        public IActionResult Board()
        {
            return View();
        }

        public IActionResult Timeline()
        {
            return View();
        }
    }
}
