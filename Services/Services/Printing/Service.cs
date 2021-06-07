using System;
using System.Collections.Generic;
using System.Drawing.Printing;
using System.IO;
using System.Windows.Controls;
using System.Windows.Documents;
using System.Windows.Markup;
using System.Windows.Xps;
using System.Xml;

namespace Services.Printing
{
    public class Service : IService
    {
        public void Print(FlowDocument fd, string title)
        {
            var local = new System.Printing.LocalPrintServer();
            PrintDialog printDlg = new PrintDialog()
            {
                PrintQueue = new System.Printing.PrintQueue(new System.Printing.PrintServer(), "Microsoft Print to PDF")
            };

            IDocumentPaginatorSource dps = fd;
            printDlg.PrintDocument(dps.DocumentPaginator, title);
        }

        public void AutoPrint(FlowDocument fd, string title, string caller)
        {
            var local = new System.Printing.LocalPrintServer();
            PrintDialog printDialog = new PrintDialog()
            {
                PrintQueue = new System.Printing.PrintQueue(new System.Printing.PrintServer(), "Microsoft Print to PDF")
            };

            printDialog.PrintQueue.AddJob("Report PDF", "Report.pdf", false);
            printDialog.PrintQueue.Commit();
        }
    }
}