public class Oglas
{
    public int Id { get; set; }
    public int ProdajalecId { get; set; }
    public Uporabnik Prodajalec { get; set; } = null!;

    public string Naslov { get; set; } = "";
    public string Opis { get; set; } = "";
    public decimal Cena { get; set; }
    public string Lokacija { get; set; } = "";
    public double Kvadratura { get; set; }
    public int StevilоSob { get; set; }
    public TipNepremicnine Tip { get; set; }
    public DateTime? DatumVselitve { get; set; }
    public bool JeOddano { get; set; }
    public int SteviloOgledov { get; set; }
    public DateTime DatumObjave { get; set; } = DateTime.UtcNow;

    public List<Povprasevanje> Povprasevanja { get; set; } = new();
    public List<Priljubljen> Priljubljeni { get; set; } = new();
}