namespace ClientReport.Application.Exceptions
{
    internal class ClientNotFoundException : Exception
    {
        public ClientNotFoundException(string message) : base(message) { }

        public ClientNotFoundException(string message, Exception innerException): base(message, innerException) { }
    }
}
