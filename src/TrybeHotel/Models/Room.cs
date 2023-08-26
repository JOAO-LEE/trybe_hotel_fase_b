namespace TrybeHotel.Models;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

public class Room
{
  [Key]
  public int RoomId { get; set; }
  public string? Name { get; set; }
  public int Capacity { get; set; }
  public string? Image { get; set; }
  [ForeignKey("HotelId")]
  public int HotelId { get; set; }
  public ICollection<Hotel>? Hotels { get; set; }

}