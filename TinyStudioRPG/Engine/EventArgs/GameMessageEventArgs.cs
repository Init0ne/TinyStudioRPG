namespace Engine.EventArgs
{
    public class GameMessageEventArgs(string message)
    {
        public string Message { get; set; } = message;
    }
}
