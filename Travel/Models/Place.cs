using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
namespace Travel.Models
{
  public class Place
  {
    public int PlaceId { get; set; }

    [Required]
    public string City { get; set; }
    
    public string State { get; set; }
    [Required]
    public string Country { get; set; }
     [Required]


    [DefaultValue("")]
    public string Review { get; set; }
  }
}