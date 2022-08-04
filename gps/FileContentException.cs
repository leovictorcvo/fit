namespace gps
{
    [System.Serializable]
    public class FileContentException : System.Exception
    {
        public FileContentException() { }
        public FileContentException(string message) : base(message) { }
        public FileContentException(string message, int lineNumber, string content): 
            base($"{message} - Linha: {lineNumber} => {content}") {}
        public FileContentException(string message, System.Exception inner) : base(message, inner) { }
        protected FileContentException(
            System.Runtime.Serialization.SerializationInfo info,
            System.Runtime.Serialization.StreamingContext context) : base(info, context) { }
    }
}