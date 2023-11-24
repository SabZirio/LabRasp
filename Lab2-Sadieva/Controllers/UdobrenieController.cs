using Microsoft.AspNetCore.Mvc;
using System.Collections.Concurrent;

[Route("api/ud")]
[ApiController]
public class UdobrenieController : ControllerBase
{
    private static readonly ConcurrentDictionary<int, Udobrenie> UdobrenieData = new ConcurrentDictionary<int, Udobrenie>();

    [HttpGet]
    public ActionResult<Udobrenie> Get(int id)
    {
        if (UdobrenieData.TryGetValue(id, out var udobrenie))
        {
            return Ok(udobrenie);
        }
        return NotFound();
    }

    [HttpPost]
    public ActionResult<Udobrenie> Post(string name, int idSkl, string himSost, int ves)
    {
        var newUdobrenie = new Udobrenie
        {
            Id = UdobrenieData.Count + 1,
            Name = name,
            IdSkl = idSkl,
            HimSost = himSost,
            Ves = ves
        };

        UdobrenieData.TryAdd(newUdobrenie.Id, newUdobrenie);

        return CreatedAtAction(nameof(Get), new { id = newUdobrenie.Id }, newUdobrenie);
    }

    [HttpDelete]
    public ActionResult Delete(int id)
    {
        if (UdobrenieData.TryRemove(id, out _))
        {
            return NoContent();
        }
        return NotFound();
    }
}

public class Udobrenie
{
    public int Id { get; set; }
    public string Name { get; set; }
    public int IdSkl { get; set; }
    public string HimSost { get; set; }
    public int Ves { get; set; }
}