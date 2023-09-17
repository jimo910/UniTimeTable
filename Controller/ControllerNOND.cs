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

     public class  controllerNOND{
            private List<int>CoursesBorrowedMostId;
            private List<int>StaticCoursesBorrowedMostId;
            private List<int> CourseIdWithProblem;
            public List<SLOT> SlotAvailableForNonDept{get; set;}

            public List<int> CourseIdWithNoSlotToFitIn;

            // checking if a int appears more than once.
           // removing all occurences of a number.
           //populating course  id;
           //reducing the number of borrowed courses in aLL deptlvl offering the courseId,

         public int level{get; set;}
         private int highestinborw {get; set;}
         public int no_borrowedV;

    public void populateCourseId( List<LevelDepartment> departmentalList ){

        foreach ( var Leveldpt in departmentalList){
                foreach( var coursesoffered in Leveldpt.LevelCourse){

                      int hred =  coursesoffered.CoursesId;
                      bool check_if_course_has_been_attended_To = this.hasCourseBeAttendedTo(hred);

                      if(!(check_if_course_has_been_attended_To)){
                        CoursesBorrowedMostId.Add(hred);
                      } 
                }
        }
    }




    public bool isitOccurancegrtanOne(int number){
        bool checkers ;
        checkers = false;
       int count = CoursesBorrowedMostId.Count(num => num == number);
       if(count >1){ checkers = true;}
       return checkers;
     }



     public void RemoveAllNo(int  number){

            StaticCoursesBorrowedMostId.Add(number);
            CoursesBorrowedMostId.RemoveAll(num => num == number);
     }



     public bool hasCourseBeAttendedTo(int number){

       int count = CoursesBorrowedMostId.Count(num => num == number);
       if(count>0){
              return true;
       }
       return false;
     }  



     public void ReducingTheNoOfNonDepartmentalCourse(int courseID){

            var hello = ControllerAPI.returnoffervar(courseID);

            foreach(var lvlCous in hello){
                   int DepartmentalId = lvlCous.LevelDepartmentId;
                   ControllerAPI.reduceNonDeptvar(DepartmentalId);
            }

     }




   public List<int> pickSlotForNonDepartmentalCourses(){

       List<int> slotAvailable = null;
       int no = 0;
         Random random = new Random();
        
       while(no<15){
                int randomNumber = random.Next(1, 19);
                int count = slotAvailable.Count(num => num == randomNumber);
        if(count==0){
               slotAvailable.Add(randomNumber);
              no = no +1;

        }
        
     }
    return slotAvailable;

     }

  public void implementation(){

       highestinborw= ControllerAPI.highestborrowedbydept(level);
      int xValue = highestinborw;
       for (int i=0; i<highestinborw; i++){
         List<LevelDepartment> departmentalList  =  ControllerAPI.deptthatborrowed(level, xValue);
         xValue = xValue-1;
         this.populateCourseId(departmentalList);

       foreach (int x in CoursesBorrowedMostId){

              bool isOcc = this.isitOccurancegrtanOne(x);
              if(isOcc == true){
                RemoveAllNo(x);
                ReducingTheNoOfNonDepartmentalCourse(x);
                //Fix_Course(Course)

              }

       }

       }
   
  }



  public void Fix_Course( int courseId){

    List<int> slotAvailable = this.pickSlotForNonDepartmentalCourses();
    List<LevelCourse> lvldept = ControllerAPI.returnoffervar(courseId);

     int no_of_dept_offeringC = lvldept.Count;  ///***********/
   bool  isPossible = false;
   int IdMakeTrue=0;
    int count =0;

     foreach (var h in slotAvailable){

      count =0;

      foreach(var abd in lvldept){

            bool ishelss = ControllerAPI.checkSlotused(abd.LevelDepartmentId,  h);

            if(ishelss==true){
                break;
            }
            count = count +1;

      }


      if(count == no_of_dept_offeringC){
          IdMakeTrue = h;
          isPossible = true;
          break;
      }

     }

     if(isPossible==true){

        foreach ( var hd in lvldept){

            ControllerAPI.addslotUsed(hd.LevelDepartmentId, IdMakeTrue);

        }

        ControllerAPI.UpdateCouseSlotId(courseId, IdMakeTrue);
     }else{


        this.CourseIdWithProblem.Add(courseId);
     }



  }











     }



 }
