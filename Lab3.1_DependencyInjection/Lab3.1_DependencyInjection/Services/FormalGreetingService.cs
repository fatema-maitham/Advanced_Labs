namespace Lab3._1_DependencyInjection.Services
{
    public class FormalGreetingService: IGreetingService
    {
        public string GetGreeting()
        {
            return "Good day. Welcome to the application.";
        }
    }
}
