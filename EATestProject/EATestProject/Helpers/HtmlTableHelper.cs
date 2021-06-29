using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EAAutoFramework.Helpers
{
    class HtmlTableHelper
    {
        private static List<TableDataCollection> _tableDataCollections;

        public static void ReadTable(IWebElement table)
        {
            //Initialise the table 
            _tableDataCollections = new List<TableDataCollection>();

            //Get all the columns from the table
            var columns = table.FindElements(By.TagName("th"));

            //Get all the rows
            var rows = table.FindElements(By.TagName("tr"));

            //Create row index
            int rowIndex = 0;
            foreach(var row in rows)
            {
                int colIndex = 0;

                var colData = row.FindElements(By.TagName("td"));
                //store data only if it has a value in row
                if(colData.Count != 0)
                {
                    foreach(var colValue in colData)
                    {
                        _tableDataCollections.Add(new TableDataCollection
                        {
                            RowNumber = rowIndex,
                            ColumnName = columns[colIndex].Text != "" ? columns[colIndex].Text : colIndex.ToString(),
                            ColumnValue = colValue.Text,
                            ColumnSpecialValues = GetControl(colValue)
                        });

                        //Move to next column
                        colIndex++;
                    }                
                }
                //Move to next row
                rowIndex++;
            }
        }

        private static ColumnSpecialValue GetControl(IWebElement columnValue)
        {
            ColumnSpecialValue columnSpecialValue = null;
            //Check if the control has specific tags like input / hyperlink etc.
            if(columnValue.FindElements(By.TagName("a")).Count > 0)
            {
                columnSpecialValue = new ColumnSpecialValue
                {
                    ElementCollection = columnValue.FindElements(By.TagName("a")),
                    ControlType = "hyperlink"
                };
            }
            if (columnValue.FindElements(By.TagName("input")).Count > 0)
            {
                columnSpecialValue = new ColumnSpecialValue
                {
                    ElementCollection = columnValue.FindElements(By.TagName("input")),
                    ControlType = "input"
                };
            }
            return columnSpecialValue;
        }

    }

    public class TableDataCollection
    {
        public int RowNumber { get; set; }
        public string ColumnName { get; set; }
        public string ColumnValue { get; set; }
        public ColumnSpecialValue ColumnSpecialValues { get; set; }
    }

    public class ColumnSpecialValue
    {
        public IEnumerable<IWebElement> ElementCollection { get; set;  }
        public string ControlType { get; set; }
    }  
}
