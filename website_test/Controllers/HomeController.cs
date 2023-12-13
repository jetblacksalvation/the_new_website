using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using website_test.Models;
using System.Net.Http.Headers;
using website_test.Helpers;
using System.Text.Json.Nodes;
using System.Runtime.InteropServices.JavaScript;

namespace website_test.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private HttpClient _client = new HttpClient();
        private readonly string _host = "https://api.github.com";
       
        public HomeController(ILogger<HomeController> logger)
        {
            _client.DefaultRequestHeaders.Add("user-agent", "d-fens HttpClient");

            _logger = logger;
        }

        public IActionResult Index(HomeModel? model)
        {
            LoadRepoList(model);
            Console.Write("loading ...");
            return View(model);
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
        private void LoadRepoList(HomeModel? model)
        {
            //Console.WriteLine(model?.ToString(), " is model");
            if (model == null) { return; }
            HttpResponseMessage response = _client.Send(new(new HttpMethod("GET"), $"{_host}/users/jetblacksalvation/repos"));
            //Console.Write(response.Content.ReadAsStringAsync().Result, " is the response");
            var jNode = Helpers.MiscHelpers.CoalesceException(() => JsonNode.Parse(response.Content.ReadAsStringAsync().Result), null);
            if (jNode != null)
            {
                //Console.Write(jNode.ToString(), "is content");
                model.RepoList = jNode; 
            }
            foreach(var repo in model.RepoList.AsArray())
            {
                Console.WriteLine(repo["html_url"].ToString(), ": ");
            }
        }

    }
}
