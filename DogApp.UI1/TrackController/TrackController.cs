using System.Net.Http;
using System.Net.Http.Json;
using System.Reflection.Metadata.Ecma335;
using System.Threading.Tasks;
using DogApp.UI1.Dto;
using DogApp.UI1.Services;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Mvc;



namespace DogApp.UI1.TrackController;

public class TrackController(ITrackService trackService) : Controller
{
    private readonly ITrackService _trackService;

    public async Task<IActionResult> Index(string name)
    {
        TrackDto? trackDTO= await _trackService.GetTrackAsync(name);
        return View(trackDTO);
    }
}
