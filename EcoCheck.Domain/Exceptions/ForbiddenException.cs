namespace EcoCheck.Domain.Exceptions
{
    public class ForbiddenException:Exception
    {
        public ForbiddenException(string mensaje) : base(mensaje) { }
    }
}
