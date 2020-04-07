using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Office.Interop.Word;

namespace DistanceLesson2
{
    class Program
    {
        static void Main(string[] args)
        {
            Application app = new Application();
            Document doc = app.Documents.Add(Visible:true);
            Range r = doc.Range();
            r.Text = "Hello world";
            Table t = doc.Tables.Add(r, 5, 5);
            t.Borders.Enable = 1;
            foreach (Row row in t.Rows)
            {
                foreach (Cell cell in row.Cells)
                {
                    if (cell.RowIndex == 1)
                    {
                        cell.Range.Text = "Колонка" + cell.ColumnIndex.ToString();
                        cell.Range.Bold = 1;
                        cell.Range.Font.Name = "Verdun";
                        cell.Range.Font.Size = 10;

                        cell.VerticalAlignment = WdCellVerticalAlignment.wdCellAlignVerticalCenter;
                        cell.Range.ParagraphFormat.Alignment = WdParagraphAlignment.wdAlignParagraphCenter;
                    }
                    else
                    {
                        cell.Range.Text = "Hello world";
                    }
                }
            }
            doc.Save();
            Console.ReadKey();
            try
            {
                doc.Close();
                app.Quit();
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }

            Console.ReadKey();
        }
    }
}
