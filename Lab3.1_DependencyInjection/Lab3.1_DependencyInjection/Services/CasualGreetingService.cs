namespace Lab3._1_DependencyInjection.Services
{
    public class CasualGreetingService: IGreetingService
    {
        public string GetGreeting()
        {
            return "Hey there! Welcome to the application.";
        }
    }
}
