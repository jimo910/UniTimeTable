using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Globalization;
using System.Threading.Tasks;
using System.Xml.Linq;
 using UniversityTimeTableModel ;
 using UniTimeTableController;

 namespace UniTimetable{


public class LevelCourseData{


    public static List<LevelCourse> ListAllLevelCourses (int leveldeptId, List<string> ListCourseCode){

        List<LevelCourse> LevelDepartmentLevelCourses= new List<LevelCourse>() ;
           LevelCourse newLevelCourse= new LevelCourse();
            var context = new  UniversityTimeTableDbContext();
            for(int i=0; i<ListCourseCode.Count; i++){
           
                 var coursesExist =  context.Course.FirstOrDefault(a => a.CourseCode ==ListCourseCode[i]); 
                   if (coursesExist != null)
                {

                            newLevelCourse = new LevelCourse{CoursesId= coursesExist.Id, course = coursesExist, LevelDepartmentId= leveldeptId};
                   
                }
                context.LevelCourses.Add(newLevelCourse);
                LevelDepartmentLevelCourses.Add(newLevelCourse);
            }

            context.SaveChanges();
            return LevelDepartmentLevelCourses;

}
    public static void UpdateLevelDepartmentLevelCourse(int deptid, List<LevelCourse> coursesOffered){

             var context = new  UniversityTimeTableDbContext();
           
                 var deptLvlExist =  context.LevelDepartments.FirstOrDefault(a => a.Id ==deptid); 
                   if (deptLvlExist != null) {

                            deptLvlExist.LevelCourse = coursesOffered;
                            context.SaveChanges();

                   }

    }


}

 }