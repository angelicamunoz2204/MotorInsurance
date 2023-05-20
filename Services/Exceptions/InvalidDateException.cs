namespace MotorInsurance.Services.Exceptions
{
    public class InvalidDateException: Exception
    {
        public InvalidDateException() : base() {}

        public InvalidDateException(string modelName, string id) : base("The end date is wrong"){}
        
    }
}