namespace ClientReport.Infrastructure.Abstractions
{
    public interface IRepositoryReader
    {
        IEnumerable<string> ReadAllLines(string pathToFile);
    }
}
