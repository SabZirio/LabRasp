using Microsoft.AspNetCore.Mvc;
using System.Collections.Concurrent;

[Route("api/or")]
[ApiController]
public class OranhereyaController : ControllerBase
{
    private static readonly ConcurrentDictionary<int, Oranhereya> OranhereyaData = new ConcurrentDictionary<int, Oranhereya>();

    [HttpGet]
    public ActionResult<Oranhereya> Get(int id)
    {
        if (OranhereyaData.TryGetValue(id, out var oranhereya))
        {
            return Ok(oranhereya);
        }
        return NotFound();
    }

    [HttpPost]
    public ActionResult<Oranhereya> Post(string name, int perRost, string temp, int vl, string svet, string adres)
    {
        var newOranhereya = new Oranhereya
        {
            Id = OranhereyaData.Count + 1,
            Name = name,
            PerRost = perRost,
            Temp = temp,
            Vl = vl,
            Svet = svet,
            Adres = adres
        };

        OranhereyaData.TryAdd(newOranhereya.Id, newOranhereya);

        return CreatedAtAction(nameof(Get), new { id = newOranhereya.Id }, newOranhereya);
    }

    [HttpDelete]
    public ActionResult Delete(int id)
    {
        if (OranhereyaData.TryRemove(id, out _))
        {
            return NoContent();
        }
        return NotFound();
    }
}

public class Oranhereya
{
    public int Id { get; set; }
    public string Name { get; set; }
    public int PerRost { get; set; }
    public string Temp { get; set; }
    public int Vl { get; set; }
    public string Svet { get; set; }
    public string Adres { get; set; }

}