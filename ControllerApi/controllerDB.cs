using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Globalization;
using System.Threading.Tasks;
using System.Xml.Linq;
 using UniversityTimeTableModel ;


namespace UniTimeTableController{

    public  delegate List<LevelDepartment>  departmentthatborrowed(int level, int no_borrowed); // list of deparment in a level that borrowed a no of courses.
  //  public  delegate var getSlotForNonDepartmentalCourses();
    public  delegate   List<Courses> CoursesThatBorrowed(int level, int no_of);
    public  delegate int highestValueoftheCourseBorrowedMost(int level);
    public  delegate int highestValueoftheDeptLvlBorrowedMost(int level);
    public delegate void reducedeptborroweddel (int deptId);
    public delegate List<LevelCourse> returnNOfferdel (int courseId);
    public delegate bool isSLOTOCCUPIED(int deptId, int Slotsd);
     public delegate void addSLOTuseddel(int deptId, int Slotsd); 
     public delegate void UpdateCourseSlotIddel (int courseId , int slotId);
     public delegate List<LevelDepartment> returnAllLvldeptIddel();
     public delegate List<LevelCourse> returnAlldeptCoursesIddel(int deptId);
    //public delegate var  prioritizeCoursesInvolvingLevelThatBorrowedMost(var hello);
    public  class ControllerAPI{

        private  static departmentthatborrowed  _departmentgrteight =null;
        private  static  CoursesThatBorrowed  _borrowedMost =null;
        private static highestValueoftheDeptLvlBorrowedMost _highestdeptborrowed = null;
        private static highestValueoftheCourseBorrowedMost _highestborrowed = null;
        private static reducedeptborroweddel  _reducedeptbrw = null;
        private static returnNOfferdel _returnnoffer = null;
        private static isSLOTOCCUPIED  _SlotOccupied = null;
        private static addSLOTuseddel _addSlotUsed = null;
        private static UpdateCourseSlotIddel _updatecouseSlotId = null;
        private static returnAllLvldeptIddel _returnAlllvldeptId =null;
        private static returnAlldeptCoursesIddel _returndeptcourses =null;



      public static departmentthatborrowed  deptthatborrowed {

        get{

            if(_departmentgrteight ==null){
                _departmentgrteight = new departmentthatborrowed(no_dept_borrowed);
            }

          return _departmentgrteight;
        }

      }

       public static CoursesThatBorrowed coursebeingborrowed {

        get{

            if(_borrowedMost==null){
                _borrowedMost= new CoursesThatBorrowed(no_that_borrow_course);
            }

          return _borrowedMost;
        }

      }

         public static highestValueoftheDeptLvlBorrowedMost highestborrowedbydept {

        get{

            if(_highestdeptborrowed ==null){
                _highestdeptborrowed = new highestValueoftheDeptLvlBorrowedMost(valueofDeptLvlBorrowedMost);
            }

          return _highestdeptborrowed;
        }

      }

      public static highestValueoftheCourseBorrowedMost highestcoursesborrowed {

          get{

            if(_highestborrowed ==null){
                _highestborrowed= new highestValueoftheCourseBorrowedMost(ValueoftheCourseBorrowedMost);
            }

          return _highestborrowed;
        }

      }

  public static reducedeptborroweddel  reduceNonDeptvar{

          get{

            if(_reducedeptbrw ==null){
                _reducedeptbrw= new reducedeptborroweddel(reducingDeptBorrow);
            }

          return _reducedeptbrw;
        }

      }


      public static returnNOfferdel  returnoffervar{

          get{

            if(_returnnoffer ==null){
                _returnnoffer = new returnNOfferdel(returnNOffering);
            }

          return _returnnoffer;
        }

      }


  public static isSLOTOCCUPIED checkSlotused{

          get{

            if(_SlotOccupied==null){
                _SlotOccupied = new isSLOTOCCUPIED(IsSlotUsed);
            }

          return _SlotOccupied;
        }

      }


public static addSLOTuseddel  addslotUsed {

    get{
      if(_addSlotUsed ==null){
        _addSlotUsed = new(addSLOTused);

      }

      return _addSlotUsed;
    }
}


public static UpdateCourseSlotIddel UpdateCouseSlotId {

    get{
      if(_updatecouseSlotId ==null){
        _updatecouseSlotId = new(UpdateCourseSlotId);

      }

      return _updatecouseSlotId;
    }


}


public static  returnAllLvldeptIddel AllvldeptId {

    get{
      if(_returnAlllvldeptId ==null){
        _returnAlllvldeptId = new(fucklevel);

      }

      return _returnAlllvldeptId;
    }

}

public static   returnAlldeptCoursesIddel deptCoursesId {

    get{
      if(_returndeptcourses ==null){
        _returndeptcourses= new(DeptCourses);

      }

      return _returndeptcourses;
    }

}




     private static  List<LevelDepartment> no_dept_borrowed(int level, int no_of){

              var context = new UniversityTimeTableDbContext();
              var LevelDepartmentsvar = context.LevelDepartments;

         var resultLists = LevelDepartmentsvar.Select (lvldeptobj=>new  LevelDepartment {
                                     Id = lvldeptobj.Id,
                                    LevelCourse = lvldeptobj.LevelCourse.ToList(),
                                   // Available  =  lvldeptobj.Available.ToList(),
                                    Used = lvldeptobj.Used.ToList(),
                                    DepartmentId = lvldeptobj.DepartmentId
                      }).Where(lvldeptobj => lvldeptobj.level== level && lvldeptobj.TotalNoOfNonDepartmentalCourses == no_of).ToList();

            return resultLists;
   }



   private static  List<Courses> no_that_borrow_course(int level, int no_of){

       var context = new UniversityTimeTableDbContext();
       var Coursesvar = context.Course;

  var resultLists = Coursesvar.Select (course=>new  Courses {
                                   Id = course.Id,
                                    CourseCode = course.CourseCode,
                                    LevelCourse = course.LevelCourse.ToList(),
                                   // LevelDepartmentId= course.LevelDepartmentId,
                                   level = course.level,
                                    SLOTId = course.SLOTId,
                      }).Where(course => course.level== level && course.no_of_dept_offering == no_of && course.isItDepartmental == false).ToList();
      return resultLists;

   }

// it returns a list of LeveLCourses of all department offering a course.
  private static  List<LevelCourse> returnNOffering(int  courseID){

       var context = new UniversityTimeTableDbContext();
       var Coursesvar = context.LevelCourses;

  var resultLists = Coursesvar.Select (course=>new  LevelCourse {

                 LevelDepartmentId= course.LevelDepartmentId

                      }).Where(course =>course.CoursesId==courseID).ToList();
      return resultLists;


   }

   private static int ValueoftheCourseBorrowedMost (int level){

    var context = new  UniversityTimeTableDbContext();
     var Courses = context.Course;

     int  highest = Courses.Max (item => item.no_of_dept_offering);

       return highest;

     }
     

     private static int valueofDeptLvlBorrowedMost (int level){

    var context = new  UniversityTimeTableDbContext();
     var Courses = context.LevelDepartments;

     int  highest = Courses.Max (item => item.TotalNoOfNonDepartmentalCourses);

     // int highestValue =  highest.no_of_dept_offering;

       return highest;


     }


    private static void  reducingDeptBorrow(int deptId){  
         var context = new  UniversityTimeTableDbContext();
         var deparmentidexist =  context.LevelDepartments.FirstOrDefault(a => a.Id == deptId); 
                   if (deparmentidexist != null)
                {
                  deparmentidexist.TotalNoOfNonDepartmentalCourses =   deparmentidexist.TotalNoOfNonDepartmentalCourses - 1;
                    context.SaveChanges();
                    Console.WriteLine("Attribute updated successfully.");
                }

  }

  private static bool IsSlotUsed(int deptID, int SlotId){

        var context = new UniversityTimeTableDbContext();
        var LevelDepartmentsvar = context.LevelDepartments;

         var resultLists = LevelDepartmentsvar.Select (lvldeptobj=>new  LevelDepartment {
                                //    Available  =  lvldeptobj.Available.ToList(),
                                    Used = lvldeptobj.Used.ToList(),
                                    DepartmentId = lvldeptobj.DepartmentId
                      }).Where( lvldeptobj => lvldeptobj.Id==deptID).ToList();



      foreach (var hello  in resultLists){
          foreach(var checks in hello.Used){

              if(SlotId== checks.Id){
                 return true; 

              }
          }

      }

      return false;
  }

  private static void addSLOTused(int DeptID, int SlotID){

     var context = new  UniversityTimeTableDbContext();
         var deparmentidexist =  context.LevelDepartments.FirstOrDefault(a => a.Id == DeptID); 
                   if (deparmentidexist != null)
                {
                //  deparmentidexist.TotalNoOfNonDepartmentalCourses =   deparmentidexist.TotalNoOfNonDepartmentalCourses - 1;
                      deparmentidexist.Used.Add(new SLOT {Id=SlotID}) ;
                    context.SaveChanges();
                    Console.WriteLine("Attribute updated successfully.");
                }
  }



  private static void UpdateCourseSlotId(int courseID, int SlotID){

     var context = new  UniversityTimeTableDbContext();
         var coursesexist=  context.Course.FirstOrDefault(a => a.Id == courseID); 
                   if (coursesexist != null)
                {

                   // deparmentidexist.Used.Add(SlotID);
                    coursesexist.SLOTId = SlotID;
                    context.SaveChanges();
                    Console.WriteLine("Attribute updated successfully.");
                }
  }

  private static List<LevelCourse> DeptCourses(int deptId){

        var context = new UniversityTimeTableDbContext();
        var Coursesvar = context.LevelCourses;
        var resultLists = Coursesvar.Select (coursess=>new  LevelCourse {
                  CoursesId = coursess.CoursesId
           }).Where(coursess => coursess.LevelDepartmentId==deptId  && coursess.course.isItDepartmental==true).ToList();
      return resultLists;
  }



  private static List<LevelDepartment> fucklevel (){
  var context = new UniversityTimeTableDbContext();
        var LevelDepartmentsvar = context.LevelDepartments;

         var resultLists = LevelDepartmentsvar.Select (lvldeptobj=>new  LevelDepartment{
                                    Id = lvldeptobj.Id,
                                  //  Available  =  lvldeptobj.Available.ToList(),
                                    Used = lvldeptobj.Used.ToList(),
                                    DepartmentId = lvldeptobj.DepartmentId
                      }).ToList();


                      return resultLists;

  } 




   }




        
    }


