using System;
using System.Drawing.Printing;
using System.IO;
using System.Windows.Controls;
using System.Windows.Documents;
using System.Windows.Markup;
using System.Xml;

namespace Services.Printing
{
    public class Service : IService
    {
        public void Print(FlowDocument fd, string title)
        {
            var lcl = new System.Printing.LocalPrintServer() { };
            var prntQ = lcl.GetPrintQueue("Microsoft Print to PDF");
            
            PrintDialog printDlg = new PrintDialog()
            {
                PrintQueue = new System.Printing.PrintQueue(lcl, "Microsoft Print to PDF")
            };

            IDocumentPaginatorSource dps = fd;
            printDlg.PrintDocument(dps.DocumentPaginator, title);
        }

        public void PromptlessPrint(FlowDocument fd, string title)
        {
            //https://stackoverflow.com/questions/345009/printing-a-wpf-flowdocument
            var lcl = new System.Printing.LocalPrintServer();
            var prntQ = lcl.GetPrintQueue("Microsoft Print to PDF");
            // the directory to store the output.
            string directory = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);
            // get information about the dimensions of the seleted printer+media.
            System.Printing.PrintDocumentImageableArea ia = null;
            System.Windows.Xps.XpsDocumentWriter docWriter = System.Printing.PrintQueue.CreateXpsDocumentWriter(prntQ);
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
    }
}