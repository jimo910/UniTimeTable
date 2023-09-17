using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Globalization;
using System.Threading.Tasks;
using System.Xml.Linq;
 using UniversityTimeTableModel ;
 using UniTimeTableController;


 namespace  UNICONTROLLER{

    public class controllerD{

       private  List<LevelDepartment> listOfAlllvldept=null;
       private List<int>CoursesWithnoPlaceToFitIn;


         // get all lvl deptid.
         // foreach id get the deparmental_Courses.
         // foreach courses fix it inside a slot.

   public void implementation()
   {

         listOfAlllvldept = ControllerAPI.AllvldeptId();
         int i=0;
         foreach(var h in listOfAlllvldept){

             List<LevelCourse>  ListofDeptCourses =   ControllerAPI.deptCoursesId(h.Id);
               foreach ( var let_fix in ListofDeptCourses){

                     for(i = 1; i<=18; i++){

                        bool IsSlotUsed = ControllerAPI.checkSlotused(h.Id, i);
                        if(IsSlotUsed !=true){
                           ControllerAPI.UpdateCouseSlotId(let_fix.CoursesId, i);
                           ControllerAPI.addslotUsed(h.Id, i);
                           break;
                        }

                     }

                     if(i==18){

                        CoursesWithnoPlaceToFitIn.Add(let_fix.CoursesId);
                     }

               }               


         }
   }
















        
    }





 }