namespace Hotel.Services.Abstract
{
    public interface IReporter
    {
        void SendReport(string text);
        void SendReport(int value1, int value2);

        string SendReport();
    }
}
