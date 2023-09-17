using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Globalization;
using System.Threading.Tasks;
using System.Xml.Linq;
 using UniversityTimeTableModel;
 using UniTimeTableController;
using OfficeOpenXml; // Make sure to include the EPPlus namespace

namespace UniTimetable{
public class CoursesData{


   // new  Courses{ Name =" ", CourseCode = " ", isItDepartmental = ,  }

        // Provide the path to your Excel file

    public  static List<Courses> GenerateCourseData (){

        List<Courses> Coursess= new List<Courses>();

        string excelFilePath = "data.xlsx";

// Create a new Excel package and load the file
    using (var package = new ExcelPackage(new FileInfo(excelFilePath)))
{
    // Assuming the data is in the first worksheet
    ExcelWorksheet worksheet = package.Workbook.Worksheets[0];

    // Define the range of cells you want to read
    int startRow = 2; // Assuming data starts from row 2 (skip header)
    int endRow = worksheet.Dimension.End.Row;
  //  int colCount = worksheet.Dimension.End.Column;
    int colCount=1;

    // Loop through rows and columns to read data
    for (int row = startRow; row <= endRow; row++)
    {
        for (int col = 1; col <= colCount; col++)
        {
            string cellValue =  (string)worksheet.Cells[row, col].Value;
          //  Console.WriteLine($"{cellValue}");
           //string firstChar = cellValue.Substring(3);
           char firstChar = cellValue[3];
            // Do something with the cell value, e.g., store it in a list or process it;
            int.TryParse(firstChar.ToString(), out int result);
            Courses newCourse  = new Courses{Name= firstChar.ToString(), CourseCode = cellValue, level= result, SLOTId=1};
            Coursess.Add(newCourse);

        }
    }
}


    return Coursess;
    
    }


}

}