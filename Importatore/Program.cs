using System;
using System.Collections;
using System.ComponentModel;
using System.Globalization;
using System.Text;
using System.IO;
using FileHelpers;
using FileHelpers.Dynamic;
using System.Diagnostics;
using FileHelpers.Detection;
using System.Data;
using System.Windows.Forms;

namespace Importatore
{
    public class Program
    {

        const string FilePath = "C:\\TRASFERTE.txt";
        const string xmlTrasfertaClassPath = "C:\\Projects\\Importatore\\Importatore\\TrasferteImport.xml";
        const bool hasHeaders = false;
        const string delimiter = "|";
        
        static void Main(string[] args)
        {
            ReadDelimitedFile();
        }

        static void ReadDelimitedFile()
        {
            var detector = new SmartFormatDetector();
            detector.FileHasHeaders = hasHeaders;
            detector.MaxSampleLines = 100;
            var formats = detector.DetectFileFormat(FilePath);

            if (formats.Length == 0)
                return;

            string FileInput = File.ReadAllText(FilePath);

            try
            {
                ClassBuilder sb = ClassBuilder.LoadFromXml(xmlTrasfertaClassPath);
                var type = ClassBuilder.ClassFromString(sb.GetClassSourceCode(NetLanguage.CSharp), NetLanguage.CSharp);
                FileHelperEngine engine = new FileHelperEngine(type);
                engine.ErrorMode = ErrorMode.SaveAndContinue;

                DataTable dt = engine.ReadStringAsDT(FileInput);

                if (engine.ErrorManager.Errors.Length > 0)
                {
                    dt = new DataTable();

                    dt.Columns.Add("LineNumber");
                    dt.Columns.Add("ExceptionInfo");
                    dt.Columns.Add("RecordString");
                    foreach (var e in engine.ErrorManager.Errors)
                    {
                        dt.Rows.Add(e.LineNumber, e.ExceptionInfo.Message, e.RecordString);
                    }
                    
                    MessageBox.Show("Error Parsing the Sample Data",
                        "Layout errors detected",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Error);
                }
                else
                {
                    //dgPreview.DataSource = dt;
                    //lblResults.Text = dt.Rows.Count.ToString() + " Rows - " + dt.Columns.Count.ToString() + " Fields";
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error Compiling Class", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

    }
}
