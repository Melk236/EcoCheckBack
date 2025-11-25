namespace EcoCheck.Exceptions
{
    public class ForbiddenException:Exception
    {
        public ForbiddenException(string mensaje) : base(mensaje) { }
    }
}
