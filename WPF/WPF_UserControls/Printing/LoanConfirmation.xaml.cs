using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace WPF_UserControls.Printing
{
    /// <summary>
    /// Interaction logic for LoanConfirmation.xaml
    /// </summary>
    public partial class LoanConfirmation : UserControl
    {
        public ViewModel.LoanConfirmationViewModel ViewModel { get; set; }

        public LoanConfirmation()
        {
            InitializeComponent();
            populateTable();
        }

        void populateTable()
        {
            //7 columns
            var vm = this.DataContext as ViewModel.LoanConfirmationViewModel;
            ViewModel = vm;
            for (int i = 0; i < 120; i++)
            {
                var currentRow = new TableRow();
                Table.RowGroups[0].Rows.Add(currentRow);

                currentRow.Cells.Add(new TableCell(new Paragraph(new Run($"{i}"))));
                currentRow.Cells.Add(new TableCell(new Paragraph(new Run($"{i}"))));
                currentRow.Cells.Add(new TableCell(new Paragraph(new Run($"{i}"))));
                currentRow.Cells.Add(new TableCell(new Paragraph(new Run($"{i}"))));
                currentRow.Cells.Add(new TableCell(new Paragraph(new Run($"{i}"))));
                currentRow.Cells.Add(new TableCell(new Paragraph(new Run($"{i}"))));
                currentRow.Cells.Add(new TableCell(new Paragraph(new Run($"{i}"))));
            }
        }
    }
}
