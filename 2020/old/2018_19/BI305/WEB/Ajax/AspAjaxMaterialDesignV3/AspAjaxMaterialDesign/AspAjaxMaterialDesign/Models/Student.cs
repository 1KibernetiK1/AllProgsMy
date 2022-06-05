using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AspAjaxMaterialDesign.Models
{

    /*
     * @Html.DropDownList(
        "selectedGroup", // параметр для метода
        new SelectList(
            new[] { "All" }
             .Concat(Enum.GetNames(typeof(AcGroup)))
            )
       )

        
                <select>
                    <option value="" disabled selected>Выберите группу</option>
                    <option value="selectedGroup">All</option>
                    @foreach (var item in Enum.GetNames(typeof(AcGroup)))
                    {
                        <option value="selectedGroup">@item</option>
                    }
                </select>
                <label>Materialize Select</label>
     * */
    public enum AcGroup
    {
        BI305, PI221, BI106
    }

    public class Student
    {
        public string Name { get; set; }
        public string Lastname { get; set; }
        public AcGroup Group { get; set; }

        public static List<Student> LoadList()
        {
            return new List<Student>()
            {
                new Student()
                {
                    Lastname = "Пулатов",
                    Name ="Тимур",
                    Group = AcGroup.BI305
                },
                new Student()
                {
                    Lastname = "Алымов",
                    Name ="Игорь",
                    Group = AcGroup.BI305
                },
                new Student()
                {
                    Lastname = "Юрин",
                    Name ="Егор",
                    Group = AcGroup.BI305
                },
                new Student()
                {
                    Lastname = "Жуков",
                    Name ="Андрей",
                    Group = AcGroup.PI221
                },
                new Student()
                {
                    Lastname = "Семёнов",
                    Name ="Дмитрий",
                    Group = AcGroup.PI221
                },
                new Student()
                {
                    Lastname = "Балашев",
                    Name ="Михаил",
                    Group = AcGroup.BI106
                },
                new Student()
                {
                    Lastname = "Теребилов",
                    Name ="Дмитрий",
                    Group = AcGroup.BI106
                }
            };
        }
    }
}