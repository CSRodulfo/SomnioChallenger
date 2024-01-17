using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Microsoft.Reporting.WebForms;
using System.Xml;

namespace Presentation.MVC.Common
{
    public class ManagerReports
    {
        public static ResultReport GetCreateFile<T>(List<T> list, string fileName, string reportName)
        {
            try
            {
                ResultReport rtn = new ResultReport();

                ReportViewer reporte = new ReportViewer();
                reporte.LocalReport.ReportPath = "Common/Reports/" + reportName;

                ReportDataSource p = new ReportDataSource(typeof(T).Name, list);

                reporte.LocalReport.DataSources.Add(p);
                reporte.LocalReport.Refresh();

                Warning[] warnings;
                string[] streamids;
                string mimeType;
                string encoding;
                string extension;

                rtn.bytes = reporte.LocalReport.Render("PDF", null, out mimeType, out encoding, out extension, out streamids, out warnings);
                rtn.mimeType = mimeType;
                rtn.NombreDelArchivo = string.Concat(fileName, DateTime.Now.Millisecond.ToString(), ".pdf");

                return rtn;
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
    }

    public class ResultReport
    {
        public string mimeType { get; set; }
        public byte[] bytes { get; set; }
        public string NombreDelArchivo { get; set; }
    }
}