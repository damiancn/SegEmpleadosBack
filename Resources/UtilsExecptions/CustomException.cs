namespace Resources.UtilsExecptions
{
    [Serializable]
    public class CustomException : Exception
    {
        public CustomException(string? message) : base(message)
        {
        }
    }
}
