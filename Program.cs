using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Globalization;
using System.Threading.Tasks;
using System.Xml.Linq;
 using UniversityTimeTableModel;
 using UniTimeTableController;
using  UniversityTimeTableModel;
using OfficeOpenXml; // Make sure to include the EPPlus namespace
namespace  UniTimetable
{
    class Program
    {
        static void Main(string[] args)
        {
           
         // var hello = DepartmentData.populateSlot();
           var context = new UniversityTimeTableDbContext();
        /*  var listDepartments =  context.Departments.ToList();
          foreach( var dept in  listDepartments){

                    int  i =1;
            for(i=1; i<=5;i++){
                LevelDepartment newlvldept = new LevelDepartment{ name = $"{dept.name} + {i*100}", level= i, DepartmentId = dept.Id};

                context.LevelDepartments.Add(newlvldept);

              }
              
          }
         
           context.SaveChanges();

           foreach(var Slt in hello){
            context.slots.Add(Slt);

           }*/
        
      /*   var hello = CoursesData.GenerateCourseData();
           foreach ( var courses in hello){
        //     context.Course.Add(courses);
            Console.WriteLine($"{courses.level}");

           }
              context.SaveChanges();*/

           

          // context.SaveChanges();
    //  var context = new  UniversityTimeTableDbContext();

    for(int id=7; id<=805; id++){

         var coursesExist =  context.Course.FirstOrDefault(a => a.Id == id); 
                   if (coursesExist != null)
                {
              
                //  deparmentidexist.TotalNoOfNonDepartmentalCourses =   deparmentidexist.TotalNoOfNonDepartmentalCourses - 1;
               string cellValue = coursesExist.Name;
                 char firstChar = cellValue[3];
              // Do something with the cell value, e.g., store it in a list or process it;
                  int.TryParse(firstChar.ToString(), out int result);
                    coursesExist.level= result;
                    context.SaveChanges();
                   // Console.WriteLine($"Level is {result}");
                }




        }
    }
}
}