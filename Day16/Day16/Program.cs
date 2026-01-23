namespace Day16
{
            class ApplicationConfig
        {
            public static string ApplicationName { get; set; }
            public static string Environment { get; set; }
            public static int AccessCount { get; set; }
            public static bool IsInitialized { get; set; }

            static ApplicationConfig()
            {
                ApplicationName = "MyApp";
                Environment = "Development";
                AccessCount = 0;
                IsInitialized = false;
                Console.WriteLine("static constructor executed");
            }

            public static void Initalize(string appName, string environment)
            {
                ApplicationName = appName;
                Environment = environment;
                IsInitialized =true;
                AccessCount++;
            }

            public static string GetConfigurationSummary()
            {
                AccessCount++;
                return $"Application name : {ApplicationName} Environment {Environment}" +
                    $" Acess Count  : {AccessCount} IsInitialized : {IsInitialized}";
            }

            public static void ResetConfiguration()
            {
                ApplicationName = "MyApp";
                Environment = "Development";
                IsInitialized = false;
                AccessCount++;
            }

        }

    internal class Program
    {
        static void Main(string[] args)
        {
            ApplicationConfig.ApplicationName = "NewApp";
            Console.WriteLine(ApplicationConfig.ApplicationName);
            ApplicationConfig.Initalize("App1", "Dev");
            string value = ApplicationConfig.GetConfigurationSummary();
            Console.WriteLine(value);
            ApplicationConfig.ResetConfiguration();
            Console.WriteLine("Total Access Count :"+ApplicationConfig.AccessCount);
            Console.WriteLine(ApplicationConfig.GetConfigurationSummary());
            
        }
    }
}
