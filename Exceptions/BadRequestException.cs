namespace EcoCheck.Exceptions
{
    public class BadRequestException:Exception
    {
        public BadRequestException(string mensaje):base(mensaje) { }
    }
}
