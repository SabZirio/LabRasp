// SkladController.cs
using Microsoft.AspNetCore.Mvc;
using System.Collections.Concurrent;

[Route("api/skl")]
[ApiController]
public class SkladController : ControllerBase
{
    private static readonly ConcurrentDictionary<int, Sklad> SkladData = new ConcurrentDictionary<int, Sklad>();

    [HttpGet]
    public ActionResult<Sklad> Get(int id)
    {
        if (SkladData.TryGetValue(id, out var sklad))
        {
            return Ok(sklad);
        }
        return NotFound();
    }

    [HttpPost]
    public ActionResult<Sklad> Post(string adres, int vmestimost)
    {
        var newSklad = new Sklad
        {
            Id = SkladData.Count + 1,
            Adres = adres,
            Vmestimost = vmestimost
        };

        SkladData.TryAdd(newSklad.Id, newSklad);

        return CreatedAtAction(nameof(Get), new { id = newSklad.Id }, newSklad);
    }

    [HttpDelete]
    public ActionResult Delete(int id)
    {
        if (SkladData.TryRemove(id, out _))
        {
            return NoContent();
        }
        return NotFound();
    }
}

public class Sklad
{
    public int Id { get; set; }
    public string Adres { get; set; }
    public int Vmestimost { get; set; }
}