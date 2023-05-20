namespace MotorInsurance.Services.Exceptions
{
     public class NotExistentException : Exception
    {
        public NotExistentException() : base() {}

        public NotExistentException(string modelName, string id) : base("The "+ modelName + " with ID " + id + " doesn't exist") { }

    }
}