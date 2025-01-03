namespace Trackify.Exceptions;

[Serializable]
public class ProblemException(string error, string message) : Exception(message)
{
    public string Error { get; } = error;
}