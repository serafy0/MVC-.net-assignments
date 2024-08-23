using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using task.Helper;
namespace task.Models;

public class Drug
{
    public int ID { get; set; }

    [Required(ErrorMessage = "Name is required")]
    [UniqueCompanyName]
    public string Name { get; set; }

    [Required(ErrorMessage = "Image is required")]
    public string ImagePath { get; set; }

    [Required(ErrorMessage = "ManufactureDate is required")]
    [ManufactureDate]
    public DateTime ManufactureDate { get; set; }

    [Required(ErrorMessage = "ExpirationDate is required")]
    [ExipirationDate]
    public DateTime ExpirationDate { get; set; }

    public int? CompanyID { get; set; }
    public virtual Company? Company { get; set; }

}
