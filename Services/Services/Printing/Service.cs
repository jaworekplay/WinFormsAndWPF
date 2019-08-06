using System.Windows.Controls;
using System.Windows.Documents;

namespace Services.Printing
{
    public class Service : IService
    {
        public void Print(FlowDocument fd, string title)
        {
            PrintDialog printDlg = new PrintDialog()
            {
                PrintQueue = new System.Printing.PrintQueue(new System.Printing.PrintServer() { }, "Microsoft Print to PDF")
            };

            IDocumentPaginatorSource dps = fd;
            printDlg.PrintDocument(dps.DocumentPaginator, title);
        }
    }
}