namespace EcoCheck.Domain.Exceptions
{
    public class BadRequestException:Exception
    {
        public BadRequestException(string mensaje):base(mensaje) { }
    }
}
