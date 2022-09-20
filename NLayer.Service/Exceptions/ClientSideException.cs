namespace NLayer.Service.Exceptions
{
    public class ClientSideException : Exception
    {
        public ClientSideException(string message) : base(message)   // base ile exception constractorına gidiyor
        {

        }
    }
}
