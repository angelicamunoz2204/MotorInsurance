namespace MotorInsurance.Services.Exceptions
{
    public class InvalidDateException: Exception
    {
        public InvalidDateException() : base("The insurance doesn't have effect using these dates") {}
        
    }
}