using System.Windows.Documents;

namespace Services.Printing
{
    public interface IService
    {
        void Print(FlowDocument fd, string title);
        void PromptlessPrint(FlowDocument fd, string title);
    }
}