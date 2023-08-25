namespace TrybeHotel.Models;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

// 1. Implemente as models da aplicação
public class Booking
{
  public int BookingId { get; set; }
  public int CheckIn { get; set; }
  public int CheckOut { get; set; }
  public int GuestQuant { get; set; }
  public int UserId { get; set; }
  public int RoomId { get; set; }
  ICollection<User>? User { get; set; }
  ICollection<Room>? Room { get; set; }

}

// Booking representará as reservas da aplicação e deverá conter os seguintes campos:
// BookingId: Chave primária (int)
// CheckIn: Datetime (data da entrada)
// CheckOut: Datetime (data de saída)
// GuestQuant: int (número de hóspedes no quarto)
// UserId: int (chave estrangeira que representa a pessoa usuária que está reservando o quarto)
// RoomId: int (chave estrangeira que representa o quarto que está sendo reservado)
// Cada reserva tem uma pessoa usuária. A propriedade de navegação para User deve se chamar User (anulável). Cada reserva tem um quarto. A propriedade de navegação para Room deve se chamar Room (anulável).

