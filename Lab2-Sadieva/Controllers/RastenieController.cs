// RastenieController.cs
using Microsoft.AspNetCore.Mvc;
using System.Collections.Concurrent;

[Route("api/rast")]
[ApiController]
public class RastenieController : ControllerBase
{
    private static readonly ConcurrentDictionary<int, Rastenie> RastenieData = new ConcurrentDictionary<int, Rastenie>();

    [HttpGet]
    public ActionResult<Rastenie> Get(int id)
    {
        if (RastenieData.TryGetValue(id, out var rastenie))
        {
            return Ok(rastenie);
        }
        return NotFound();
    }

    [HttpPost]
    public ActionResult<Rastenie> Post(string name, int idOr, int idSt, int idUd, int stepRedk, int perRost, string temp, int vl, string svet)
    {
        var newRastenie = new Rastenie
        {
            Id = RastenieData.Count + 1,
            Name = name,
            IdOr = idOr,
            IdSt = idSt,
            IdUd = idUd,
            StepRedk = stepRedk,
            PerRost = perRost,
            Temp = temp,
            Vl = vl,
            Svet = svet
        };

        RastenieData.TryAdd(newRastenie.Id, newRastenie);

        return CreatedAtAction(nameof(Get), new { id = newRastenie.Id }, newRastenie);
    }

    [HttpDelete]
    public ActionResult Delete(int id)
    {
        if (RastenieData.TryRemove(id, out _))
        {
            return NoContent();
        }
        return NotFound();
    }
}

public class Rastenie
{
    public int Id { get; set; }
    public string Name { get; set; }
    public int IdOr { get; set; }
    public int IdSt { get; set; }
    public int IdUd { get; set; }
    public int StepRedk { get; set; }
    public int PerRost { get; set; }
    public string Temp { get; set; }
    public int Vl { get; set; }
    public string Svet { get; set; }
}