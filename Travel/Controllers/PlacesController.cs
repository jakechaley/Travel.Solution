using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Travel.Models;

namespace Travel.Controllers
{
  [Produces("application/json")]
  [Route("api/[controller]")]
  [ApiController]
  public class PlacesController : ControllerBase
  {
    private readonly TravelContext _db;

    public PlacesController(TravelContext db)
    {
      _db = db;
    }

    // GET: api/Places
    [HttpGet]
    public async Task<ActionResult<IEnumerable<Place>>> Get(string city, string country, string review, string state, int minimumId)
    {
      var query = _db.Places.AsQueryable();

      if (city != null)
      {
        query = query.Where(entry => entry.City == city);
      }

      if (country != null)
      {
        query = query.Where(entry => entry.Country == country);
      }

      if (review != null)
      {
        query = query.Where(entry => entry.Review == review);
      }

      if (minimumId > 0)
      {
        query = query.Where(entry => entry.PlaceId >= minimumId);
      }

      if (state != null)
      {
        query = query.Where(entry => entry.State == state);
      }

      return await query.ToListAsync();
    }

    // GET: api/Places/5
    [HttpGet("{id}")]
    public async Task<ActionResult<Place>> GetPlace(int id)
    {
      var animal = await _db.Places.FindAsync(id);

      if (animal == null)
      {
        return NotFound();
      }

      return animal;
    }

    // PUT: api/places/5
    // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
    [HttpPut("{id}")]
    public async Task<IActionResult> Put(int id, Place place)
    {
      if (id != place.PlaceId)
      {
        return BadRequest();
      }

      _db.Entry(place).State = EntityState.Modified;

      try
      {
        await _db.SaveChangesAsync();
      }
      catch (DbUpdateConcurrencyException)
      {
        if (!PlaceExists(id))
        {
          return NotFound();
        }
        else
        {
          throw;
        }
      }

      return NoContent();
    }
    private bool PlaceExists(int id)
    {
      return _db.Places.Any(e => e.PlaceId == id);
    }
    // // Patch, how does this work????
    // [HttpPatch("{id}")]
    // public async Task<IActionResult> Patch(int id, Place place, string review)
    // {
    //     if (id != place.PlaceId)
    //   {
    //     return BadRequest();
    //   }
    //   _db.Entry(place).State = EntityState.Modified;

    // }

    // POST: api/Animals
    /// <remarks>
    /// Sample request:
    ///
    ///     POST /Place
    ///     {
    ///        "id": 1,
    ///        "city": "SomeCity",
    ///        "state": "SomeState"
    ///     }
    ///
    /// </remarks>
    /// <param name="place"></param>
    /// <returns>A newly created Place</returns>
    /// <response code="201">Returns the newly created place</response>
    /// <response code="400">If the item is null</response>
    /// <response code="201">Returns the newly created item</response>
    /// <response code="400">If the item is null</response>      
    [HttpPost]
    [ProducesResponseType(StatusCodes.Status201Created)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<ActionResult<Place>> Post(Place place)
    {
      _db.Places.Add(place);
      await _db.SaveChangesAsync();

      return CreatedAtAction(nameof(GetPlace), new { id = place.PlaceId }, place);
    }

    // DELETE: api/Places/5
    /// <summary>
    /// Deletes a specific Place.
    /// </summary>
    [HttpDelete("{id}")]
    public async Task<IActionResult> DeletePlace(int id)
    {
      var place = await _db.Places.FindAsync(id);
      if (place == null)
      {
        return NotFound();
      }

      _db.Places.Remove(place);
      await _db.SaveChangesAsync();

      return NoContent();
    }

    //RANDOM: api/Places/Random
    [HttpGet("Random")]
    public async Task<ActionResult<Place>> RandomPlace()
    {
      Random random = new Random();
      int dbCount = _db.Places.Count();
      int id = random.Next(1, dbCount);
      var place = await _db.Places.FindAsync(id);
      return place;
    }
  }
}

