using System.Net;

namespace DelegateEventAsynchLessons
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var results = new List<Task>();
            var files = new List<File>();

            for (int i = 0; i < 10; i++)
            {
                Console.Write("Insert uri: ");
                var remoteUri = Console.ReadLine();
                Console.Write("Insert direction on local disk: ");
                var direction = readDirection(Console.ReadLine());
                Console.Write("Insert file name: ");
                var fileName = readFileName(Console.ReadLine());

                files.Add(new File(remoteUri, direction, fileName));
            }

            foreach (var file in files)
            {

                ImageDownloader imageDownloader = new ImageDownloader();

                Subscriber subscriber1 = new Subscriber("First Subscriber");
                Subscriber subscriber2 = new Subscriber("Second Subscriber");
                imageDownloader.ImageStarted += subscriber1.OnDataReceived;
                imageDownloader.ImageCompleted += subscriber2.OnDataReceived;

                /*
                Console.WriteLine("Качаю \"{0}\" из \"{1}\" .......\n", fileName, remoteUri);
                imageDownloader.Download(
                    remoteUri,
                    direction + fileName + ".jpg"
                    );
                Console.WriteLine("Успешно скачал \"{0}\" из \"{1}\"", fileName, remoteUri);
                Console.WriteLine("Press any key to exit");
                Console.Read();
                */

                results.Add(imageDownloader.DownloadAsync(
                        file.RemoteUri,
                        file.Direction + file.FileName + ".jpg"
                        ));
            }

            while (true)
            {
                Console.WriteLine("Press A to exit or any other key to check downloading status");
                if (Console.ReadKey().Key == ConsoleKey.A)
                {
                    return;
                }
                else
                {
                    foreach (var result in results)
                    {
                        if (result.IsCompleted == true)
                        {
                            Console.WriteLine("\nDownloaded");
                        }
                        else
                        {
                            Console.WriteLine("\nNot downloaded");
                        }
                    }
                }
            }
        }

        public static string readDirection(string userValue)
        {
            if (userValue is null || userValue == "")
            {
                var direction = @"C:\Users\User\Downloads\";
                return direction;
            }
            return userValue;
        }

        public static string readFileName(string userValue)
        {
            if (userValue is null || userValue == "")
            {
                var fileName = @"image";
                return fileName;
            }
            return userValue;
        }
    }
}
