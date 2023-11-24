using System.Collections.Concurrent;

public static class DataStorage
{
    public static ConcurrentDictionary<int, Udobrenie> UdobrenieData { get; } = new ConcurrentDictionary<int, Udobrenie>();
    public static ConcurrentDictionary<int, Rastenie> RastenieData { get; } = new ConcurrentDictionary<int, Rastenie>();
    public static ConcurrentDictionary<int, Oranhereya> OranhereyaData { get; } = new ConcurrentDictionary<int, Oranhereya>();
    public static ConcurrentDictionary<int, Stelazh> StelazhData { get; } = new ConcurrentDictionary<int, Stelazh>();
    public static ConcurrentDictionary<int, Sklad> SkladData { get; } = new ConcurrentDictionary<int, Sklad>();
}