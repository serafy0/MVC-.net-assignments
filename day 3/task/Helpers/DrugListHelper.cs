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
                /*
                result.AppendFormat("<tr> " +
                    "<td>" +
                   "<img src={0} style=\"width:200px;hieght=200px\" />" +
                    "</td>" +
                    "<td><p>" +
                    "{2}"+
                    "</p>" +
                    "</td>" +
                    "<td>" +
                    "<a href=\"/drug/Edit/{1}\" class=\"btn btn-dark\"> Edit</a>" +
                    "</td>" +
                    "<td>" +
                    "<a class=\"btn btn-success\" href=\"/drug/ViewDetails/{1}\">View" +
                    "details</a>" +
                    "</td>" +
                    "<td>" +
                    "<form method=\"post\" action=\"/drug/delete/{1}\">" +
                    "<input type=\"hidden\" name=\"id\" value=\"{1}\" />" +
                    " <button type=\"submit\" class=\"btn btn-danger\">Delete</button>" +
                    " </form>" +
                    " </td>" +
                " </tr>", item.ImagePath, item.ID.ToString(),item.Name);
                */
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