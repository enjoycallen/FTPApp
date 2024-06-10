namespace FTPClient
{
    public class NullClient(string func) : Exception($"In {func}:\nClient is null.") { }

    public class ConnectionNotExisted(string func) : Exception($"In {func}:\nConnecttion not existed.") { }

    public class ConnectionExisted(string func) : Exception($"In {func}:\nConnecttion already existed.") { }
}
