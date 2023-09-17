using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Globalization;
using System.Threading.Tasks;
using System.Xml.Linq;
 using UniversityTimeTableModel;
 using UniTimeTableController;

namespace UniTimetable{


public class DepartmentData{

    public  static IEnumerable<Department> GenerateDepartmentData (){


            var DepartmentDatas = new List<Department>{
                    new Department{ name ="Agriculture and BioResources Engineering"},
                    new Department{ name ="Mechanical Engineering"},
                    new Department{ name ="Electrical Engineering"},
                    new Department{ name ="Civil Engineering"},
                    new Department{ name ="Mechatronics Engineering"},
                    new Department{ name ="Physics"},
                    new Department{ name ="Chemistry"},
                    new Department{ name ="Computer science"},
                    new Department{ name ="Statictics"},
                    new Department {name = "Home Science and Management"},
                    new Department{ name ="Hospitality and Tourism Management"},
                    new Department{ name ="Food Science and Technology"},
                    new Department{ name ="Nutrition and Dietics"},
                    new Department{ name ="Microbiology"},
                    new Department{ name ="Pure and Applied Botany"},
                    new Department{ name ="Pure and Applied Zoology"},
                    new Department{ name ="Biochemistry"},
                    new Department{ name ="Aquaculture and Fisheriess Management"},
                    new Department{ name ="Enivronmental Management and Toxicology"},
                    new Department{ name ="Forestry and Wildlife Management"},
                    new Department{ name ="Water Resources Management and Agricultural Meteorology"},
                    new Department{ name ="Agriculutral Administration"},
                    new Department{ name ="Agriculutral Economics and Farm Management"},
                    new Department{ name ="Agricultural Extension and Rural Development"},
                    new Department{ name ="Animal Breeding and Genetics"},
                    new Department{ name ="Animal Nutirtion"},
                    new Department{ name ="Animal Physiology"},
                    new Department{ name ="Animal Production and Health"},
                    new Department{ name ="Pasture and Range Management"},  
                    new Department{ name ="Crop Production"},
                    new Department{ name ="Horticulture"},
                   new Department{ name ="Plant Breeding and Seed Technology"},
                   new Department{ name ="Plant Phsiology and Crop Production Production"},
                   new Department{ name ="Soil Science and Land Management"}

            };

            return DepartmentDatas ;
      }

 
  public static IEnumerable<SLOT> populateSlot(){

      var dataSlot = new List<SLOT>{
                  new SLOT{ },
                  new SLOT{ },
                  new SLOT{ },
                  new SLOT{ },
                  new SLOT{ },
                  new SLOT{ },
                  new SLOT{ },
                  new SLOT{ },
                  new SLOT{ },
                  new SLOT{ },
                  new SLOT{ },
                  new SLOT{ },
                  new SLOT{ },
                  new SLOT{ },
                  new SLOT{ },
                  new SLOT{ },
                  new SLOT{ },
                  new SLOT{ }

      };

      return dataSlot;
 }



}

}