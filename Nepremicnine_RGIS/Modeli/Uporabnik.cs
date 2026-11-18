public class Uporabnik
{
    public int Id { get; set; }
    public string UporabniskoIme { get; set; } = "";
    public string GesloHash { get; set; } = "";
    public VlogaUporabnika Vloga { get; set; }
    public string? Lokacija { get; set; }
    public bool LahkoObjavlja { get; set; } = true;
    public DateTime DatumUstvarjanja { get; set; } = DateTime.UtcNow;

    public List<Oglas> Oglasi { get; set; } = new();
    public List<Povprasevanje> Povprasevanja { get; set; } = new();
    public List<Priljubljen> Priljubljeni { get; set; } = new();
    public List<ShranjenoIskanje> ShranjenaIskanja { get; set; } = new();
}