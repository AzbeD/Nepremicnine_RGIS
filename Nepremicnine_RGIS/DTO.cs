using System.ComponentModel.DataAnnotations;

public class RegistracijaDTO
{
    [Required] public string UporabniskoIme {get; set; } = "";
    [Required, MinLength(8)] public string Geslo {get; set; } = "";
}
public class PrijavaDTO
{
    [Required] public string uporabniskoIme {get; set; } = "";
    [Required] public string Geslo {get; set; } = "";
}