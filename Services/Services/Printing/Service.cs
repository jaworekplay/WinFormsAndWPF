using System;
using System.Drawing.Printing;
using System.IO;
using System.Printing;
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
            var lcl = new LocalPrintServer();
            var prntQ = lcl.GetPrintQueue("Microsoft Print to PDF");
            
            PrintDialog printDlg = new PrintDialog()
            {
                PrintQueue = new PrintQueue(lcl, "Microsoft Print to PDF")
            };

            IDocumentPaginatorSource dps = fd;
            printDlg.PrintDocument(dps.DocumentPaginator, title);
        }

        private XpsDocumentWriter GetXps()
        {
            // Create a local print server
            LocalPrintServer ps = new LocalPrintServer();

            // Get the default print queue
            PrintQueue pq = ps.DefaultPrintQueue;

            // Get an XpsDocumentWriter for the default print queue
            XpsDocumentWriter xpsdw = PrintQueue.CreateXpsDocumentWriter(pq);
            return xpsdw;
        }

        public void PromptlessPrint(FlowDocument fd, string title)
        {
            var xps = GetXps();
            //https://stackoverflow.com/questions/345009/printing-a-wpf-flowdocument
            var lcl = new LocalPrintServer();
            var prntQ = lcl.GetPrintQueue("Microsoft Print to PDF");
            // the directory to store the output.
            string directory = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);
            // get information about the dimensions of the seleted printer+media.
            System.Printing.PrintDocumentImageableArea ia = null;
            System.Windows.Xps.XpsDocumentWriter docWriter = PrintQueue.CreateXpsDocumentWriter(prntQ);
            IDocumentPaginatorSource dps = fd;
            
            docWriter.Write(dps.DocumentPaginator);

            ////Clone the source document
            //var str = XamlWriter.Save(fd);
            //var stringReader = new System.IO.StringReader(str);
            //var xmlReader = XmlReader.Create(stringReader);
            //var CloneDoc = XamlReader.Load(xmlReader) as FlowDocument;

            ////Now print using PrintDialog
            //var pd = new PrintDialog();
            //pd.PrintQueue = prntQ;
            
            //CloneDoc.PageHeight = pd.PrintableAreaHeight;
            //CloneDoc.PageWidth = pd.PrintableAreaWidth;
            //IDocumentPaginatorSource idocument = CloneDoc as IDocumentPaginatorSource;

            //pd.PrintDocument(idocument.DocumentPaginator, "Printing FlowDocument");
        }

        public void PromptlessPrint2(string fileName)
        {
            PrintDocument doc = new PrintDocument
            {
                PrinterSettings = new PrinterSettings()
                {
                    PrinterName = "Microsoft Print To PDF",
                    PrintToFile = true,
                    PrintFileName = fileName
                }
            };
        }
    }
}