using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Globalization;
using System.Threading.Tasks;
using System.Xml.Linq;

 namespace UniversityTimeTableModel
 {

        public class Department{

            public int Id{get; set;}
           public  string name {get; set;}
           public   List<LevelDepartment> dept_Level{get; set;} 
           // List <Staff> dept_Staff;
           // List<Student> Student_in_a_department;
           // List <Room> Lecture_room;
        }


    
 }
 