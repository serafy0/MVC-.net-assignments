using task.Models;
using task.Controllers;
using System.Reflection;
using System.Text;
namespace task.Helpers
{
    public class DrugListHelper
    {

        public static string List()
        {
            var drugList = DrugController.drugs;
            StringBuilder result = new StringBuilder();

            foreach(var item in drugList){
                
                var imageCell = $"<td> <img src={item.ImagePath} style=\"width:200px;hieght=200px\" /> </td>";
                var NameCell = $"<td>{item.Name}</td>";

                var editButton = $"<td><a href=\"/drug/Edit/{item.ID}\" class=\"btn btn-dark\"> Edit</a></td>";
                var detailsButton = $"<td><a class=\"btn btn-success\" href=\"/drug/ViewDetails/{item.ID}\">Viewdetails</a></td>";

                var deleteButton = $"<td><form method=\"post\" action=\"/drug/delete/{item.ID}\"><input type=\"hidden\" name=\"id\" value=\"{item.ID}\" /><button type=\"submit\" class=\"btn btn-danger\">Delete</button></form></td>";

                result.Append($"<tr>{imageCell} {NameCell} {editButton} {detailsButton} {deleteButton} </tr>");





            }
            return result.ToString();


        }

    }
}