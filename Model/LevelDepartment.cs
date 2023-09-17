using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Globalization;
using System.Threading.Tasks;
using System.Xml.Linq;

 namespace UniversityTimeTableModel
 {
        public class LevelDepartment{
             public int Id{get; set;}
             public   string name {get; set;}
              public int level{get; set;}
             public int DepartmentId{get; set;}
             public  Department dept {get; set;}

             public List<LevelCourse> LevelCourse{get; set;}
          //   public  List<Courses> delivered{get; set;}
         
            // public  List<SLOT> Available{get; set;}
             public  List <SLOT> Used {get; set;}
              public int TotalNoOfNonDepartmentalCourses{get; set;}
             
        }
    
 }
 //The entity type 'List<int>' requires a primary key to be defined. If you intended to use a keyless entity type, call 'HasNoKey' in 'OnModelCreating'. For more information on keyless entity types, see https://go.microsoft.com/fwlink/?linkid=2141943.