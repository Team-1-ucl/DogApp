using DogApp.API.Dto;
using DogApp.Data.EntityModels;
using DogApp.Services;
using Microsoft.AspNetCore.Mvc;

namespace DogApp.API.Controllers;

/// <summary>
/// Controller til håndtering af baner.
/// </summary>
/// <param name="trackService"><see cref="ITrackService"/>-injektionen til brug af bane-tjenester.</param>
[ApiController]
[Route("[controller]")]
public class TrackController(ITrackService trackService) : Controller
{
    /// <summary>
    /// initialiserer en ny instans af <see cref="ITrackService" class. />
    /// </summary>
    private readonly ITrackService? _trackService = trackService ?? throw new ArgumentNullException(nameof(trackService));

    /// <summary>
    /// Opretter en ny bane baseret på den angivne TrackDTO.
    /// </summary>
    /// <param name="trackDto"><see cref="TrackDTO"/>'en indeholdende oplysninger om den nye bane.</param>
    /// <returns>En IActionResult, der repræsenterer resultatet af operationen.</returns>
    [HttpPost("[action]")]
    public async Task<IActionResult> CreateTask(TrackDto trackDto)
    {
        // Kontrollerer om trackService-parameteren er null
        if (_trackService == null)
        {
            throw new InvalidOperationException("Track service is not initialized.");
        }

        // Kontrollerer om trackDto-parameteren er null
        if (trackDto == null)
        {
            // Returner et BadRequest-svar hvis trackDto er null
            return BadRequest("TrackDTO kan ikke være null.");
        }

        // Opretter et nyt Track-objekt og initialiserer dets egenskaber ud fra trackDto
        var track = new Track
        {
            Name = trackDto.Name
        };

        try
        {
            // Forsøger at oprette den nye bane ved hjælp af tjenesten
            await _trackService.CreateTrack(track);

            // Returner et Ok-svar for at angive, at baneoprettelsen var vellykket
            return Ok("Bane oprettet successfully.");
        }
        catch (Exception)
        {
            // Hvis der opstår en fejl, logges den eller håndteres på anden vis
            // Returner et 500 Internal Server Error-svar, hvis der opstår en fejl
            return StatusCode(500, "Der opstod en fejl under oprettelsen af banen.");
        }
    }
    /// <summary>
    /// Henter alle baner og returnerer dem som en liste af <see cref="TrackDTO"/>'er.
    /// </summary>
    /// <returns>En IActionResult, der repræsenterer resultatet af operationen.</returns>
    [HttpGet("GetAllTracks")]
    public async Task<IActionResult> GetAllTracks()
    {
        // Kontrollerer om trackService-parameteren er null
        if (_trackService == null)
        {
            throw new InvalidOperationException("Track service is not initialized.");
        }

        try
        {
            // Forsøger at hente alle baner fra tjenesten
            var tracks = await _trackService.GetAllTracksAsync();

            // Opretter en ny liste til at gemme TrackDTO'er
            var trackDtos = new List<TrackDto>();

            // Konverter hver bane til en TrackDTO og tilføjer den til trackDtos-listen
            foreach (var track in tracks)
            {
                trackDtos.Add(new TrackDto(track.Name));
            }

            // Returner et Ok-svar med den konverterede liste af TrackDTO'er
            return Ok(trackDtos);
        }
        catch (Exception)
        {
            // Hvis der opstår en fejl, returner et 500 Internal Server Error-svar
            return StatusCode(500, "Der opstod en fejl under hentning af baner.");
        }
    }

}
