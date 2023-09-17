using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Globalization;
using System.Threading.Tasks;
using System.Xml.Linq;

 namespace UniversityTimeTableModel
 {

        public class Courses{

             public int Id{get; set;}
             public  string Name {get; set;}
             public string CourseCode{get; set;}
            // public List<LevelDepartment> CourseOffered{get; set;} 
            // public List<Courses> delivered{get; set;}
           //  public List<Departmental_Level> dept_Level{get; set;} 
             public List<LevelCourse> LevelCourse{get; set;}
             public int level {get; set;}
             
           // public int LevelDepartmentId{get; set;}
           //  public LevelDepartment dept_level_that_owns_it {get; set;}

             public bool isItDepartmental{get; set;}

             public int no_of_dept_offering{get; set;}

          
             public int SLOTId{get; set;}
             public   SLOT SLOT{get; set;} 

           // List<Staff> StaffTakingCOurse;
           // List<Student> StudentTaking_Course;
           // List <Room> Lecture_room;
        }


        public class LevelCourse{

            public int CoursesId {get; set;}
            public Courses course{get; set;}

            public int LevelDepartmentId {get; set;}
            public LevelDepartment LevelDepartmental {get; set;}
        }


    
 }
 