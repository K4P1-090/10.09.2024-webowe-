using System;
using System.ComponentModel.DataAnnotations;

namespace _10._09._2024_webowe_.Models;

public class Game
{
    public int Id { get; set; }
    
    [Display(Name = "Tytuł")]
    [Required(ErrorMessage = "Podaj tytuł")]
    [StringLength(100,MinimumLength = 3, ErrorMessage = "Tytuł musi zawierać się miedzy 3 i 100 znaków")]
    public string? Title { get; set; }

    [Display(Name = "Kategoria")]
    [Required(ErrorMessage = "Podaj Kategorię")]
    [StringLength(100,MinimumLength = 3, ErrorMessage = "Kategoria musi zawierać się miedzy 3 i 100 znaków")]
    public string? Cathegory { get; set; }

    [Display(Name = "Rok")]
    [Required(ErrorMessage = "Podaj Rok")]
    [StringLength(4,MinimumLength = 4, ErrorMessage = "Rok musi zawierać 4 cyfry")]
    public string? Year { get; set; }
    
    [Display(Name = "Cena")]
    [Required(ErrorMessage = "Podaj cenę")]
    [Range(0, 1000, ErrorMessage = "Cena musi być z przedziału 0-1000")]
    public decimal? Price { get; set; }
    // public int Id { get; set; }
    // public string? Title { get; set; }
    // public string? Cathegory { get; set; }
    // public string? Year { get; set; }
    // public decimal Price { get; set; }
}