#region Namespaces
using Autodesk.Revit.ApplicationServices;
using Autodesk.Revit.Attributes;
using Autodesk.Revit.DB;
using Autodesk.Revit.UI;
using Autodesk.Revit.UI.Selection;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;

#endregion

namespace RAB_Session01_Skills
{
    [Transaction(TransactionMode.Manual)]
    public class CmdSkills01 : IExternalCommand
    {
        public Result Execute(
          ExternalCommandData commandData,
          ref string message,
          ElementSet elements)
        {
            UIApplication uiapp = commandData.Application;
            UIDocument uidoc = uiapp.ActiveUIDocument;
            Application app = uiapp.Application;
            Document doc = uidoc.Document;

            // 1. variables (string, int, double, XYZ)
            string myString = "Welcome to Revit Add-in Bootcamp";
            string mySecondString = myString + ". It's great to have you here.";
            string filePath = "C:\\documents\\mydocument";

            int myNumber = -15;
            double myNextNumber = -20.5;
            double answer = (myNumber + myNextNumber)/(10 * 20);

            XYZ myPoint = new XYZ(10,10,0);
            XYZ myNextPoint = new XYZ();

            // 5. Filtered Element Collectors
            FilteredElementCollector collector = new FilteredElementCollector(doc);
            //collector.OfCategory(BuiltInCategory.OST_TextNotes);
            //collector.WhereElementIsElementType();
            collector.OfClass(typeof(TextNoteType));

            // 2. for loops

            Transaction t = new Transaction(doc);
            t.Start("Create text note");

            XYZ offset = new XYZ(0, 5, 0);
            XYZ newPoint = myPoint;
            int total = 0;
            for(int i = 0; i <=10; i++)
            {
                newPoint = newPoint.Add(offset);

                // 4. Text Notes
                TextNote myTextNote = TextNote.Create(doc,
                    doc.ActiveView.Id, newPoint,
                    myString + "\n" + i.ToString(),
                    collector.FirstElementId());
            }

            int test = 10 % 2;


            t.Commit();

            // 3. conditional logic (<, >, ==, &&, ||)
            string result = "";
            if (total > 10 || total < 100)
            {
                result = "It's a big number! But not too big";
            }
            else if (total > 5)
            {
                result = "It's a medium number!";
            }
            else if (total == 4)
                result = "The number is 4";
            else
            {
                result = "It's a small number!";
            }

            

            

            // 6. Transactions


            return Result.Succeeded;
        }
    }
}
