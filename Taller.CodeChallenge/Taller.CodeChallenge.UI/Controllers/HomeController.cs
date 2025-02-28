using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using RestEase;
using System.Diagnostics;
using System.Net;
using Taller.CodeChallenge.Domain.AggregateModels.Request;
using Taller.CodeChallenge.Domain.Entities;
using Taller.CodeChallenge.UI.Models;
using Taller.CodeChallenge.UI.Services;

namespace Taller.CodeChallenge.UI.Controllers;

public class HomeController : Controller
{
    private readonly ILogger<HomeController> _logger;
    private readonly IRestEaseTallerUsApi _restEaseTaller;

    public HomeController(ILogger<HomeController> logger, IRestEaseTallerUsApi restEaseTaller)
    {
        _logger = logger;
        _restEaseTaller = restEaseTaller;
    }

    public async Task<IActionResult> Index()
    {
        string notFound = "User not found !";

        ViewData["Title"] = "Welcome to the Employer Portal";

        var httpResponseMessage = await _restEaseTaller.GetUserNameAsync("Bruno Miranda", new CancellationToken());

        //200
        if (httpResponseMessage.IsSuccessStatusCode)
        {
            var response = await httpResponseMessage.Content.ReadAsStringAsync();
            var usermodel = JsonConvert.DeserializeObject<List<UserModel>>(response);

            if (usermodel is null)
                ViewData["Name"] = notFound;
            else
                ViewData["Name"] = "Hello, " + usermodel.FirstOrDefault().UserName;
        }

        //404
        if (httpResponseMessage.StatusCode.Equals(HttpStatusCode.NotFound))
        {
            ViewData["Name"] = notFound;
        }       

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
}
