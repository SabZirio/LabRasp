// StelazhController.cs
using Microsoft.AspNetCore.Mvc;
using System.Collections.Concurrent;

[Route("api/st")]
[ApiController]
public class StelazhController : ControllerBase
{
    private static readonly ConcurrentDictionary<int, Stelazh> StelazhData = new ConcurrentDictionary<int, Stelazh>();

    [HttpGet]
    public ActionResult<Stelazh> Get(int id)
    {
        if (StelazhData.TryGetValue(id, out var stelazh))
        {
            return Ok(stelazh);
        }
        return NotFound();
    }

    [HttpPost]
    public ActionResult<Stelazh> Post(int sklNumber, int idOr, string material, double plochad, int vmestimost)
    {
        var newStelazh = new Stelazh
        {
            Id = StelazhData.Count + 1,
            SklNumber = sklNumber,
            IdOr = idOr,
            Material = material,
            Plochad = plochad,
            Vmestimost = vmestimost
        };

        StelazhData.TryAdd(newStelazh.Id, newStelazh);

        return CreatedAtAction(nameof(Get), new { id = newStelazh.Id }, newStelazh);
    }

    [HttpDelete]
    public ActionResult Delete(int id)
    {
        if (StelazhData.TryRemove(id, out _))
        {
            return NoContent();
        }
        return NotFound();
    }
}

public class Stelazh
{
    public int Id { get; set; }
    public int SklNumber { get; set; }
    public int IdOr { get; set; }
    public string Material { get; set; }
    public double Plochad { get; set; }
    public int Vmestimost { get; set; }
}