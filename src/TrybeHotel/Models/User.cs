namespace TrybeHotel.Models;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

// 1. Implemente as models da aplicação
public class User
{
  public int UserId { get; set; }
  public string? Name { get; set; }
  public string? Email { get; set; }
  public string? Password { get; set; }
  public string? UserType { get; set; }

  ICollection<Booking>? Bookings { get; set; }

}

// User representará as pessoas usuárias da aplicação e deverá conter os seguintes campos:
// UserId: Chave primária (int)
// Name: string
// Email: string
// Password: string
// UserType: string
// Cada pessoa usuária tem várias reservas. A propriedade de navegação para Booking deve se chamar Bookings (anulável).

// O atributo UserType, no futuro, receberá os valores admin ou client e representará a nossa autorização.