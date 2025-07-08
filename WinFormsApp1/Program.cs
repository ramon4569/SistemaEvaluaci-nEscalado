
using System;
using System.Windows.Forms;
using OfficeOpenXml; // Ya tienes este using


namespace WinFormsApp1
{
    internal static class Program
    {
        /// <summary>  
        ///  The main entry point for the application.  
        /// </summary>  
        [STAThread]
        static void Main()
        {
            // To customize application configuration such as set high DPI settings or default font,  
            // see https://aka.ms/applicationconfiguration.  
            ApplicationConfiguration.Initialize();

            // Correct usage of EPPlus license context for version 8 and later  
            ExcelPackage.License.SetNonCommercialOrganization("SistemaEvaluacionesApp (Uso No Comercial)");
            Application.Run(new Login());
        }
    }
}