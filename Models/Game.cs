using System;

namespace _10._09._2024_webowe_.Models;

public class Game
{
    public int Id { get; set; }
    public string? Title { get; set; }
    public string? Cathegory { get; set; }
    public string? Year { get; set; }
    public decimal Price { get; set; }
}