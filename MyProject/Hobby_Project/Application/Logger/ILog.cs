namespace Application.Logger
{
    public interface ILog
    {
        void LogError(string message);
        void LogWarning(string message);
        void LogInfo(string message);
    }
}
