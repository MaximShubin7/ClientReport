using ClientReport.Infrastructure.Abstractions;

namespace ClientReport.Infrastructure.Services
{
    public class ClientOrderReader : IRepositoryReader
    {
        public IEnumerable<string> ReadAllLines(string pathToFile)
        {
            using (var reader = new StreamReader(pathToFile))
            {
                var row = reader.ReadLine();
                while ((row = reader.ReadLine()) != null)
                    yield return row;
            }
        }
    }
}
