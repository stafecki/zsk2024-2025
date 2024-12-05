namespace project4_delegaty_powiadomienia_menu
{
    internal class Program
    {
        public delegate void NotificationHandler(string message);

        public class EmailNotifier
        {
            public void SendEmail(string message)
            {
                Console.WriteLine($"Email wysłany: {message}");
            }
        }

        public class SMSNotifier
        {
            public void SendSMS(string message)
            {
                Console.WriteLine($"SMS wysłany: {message}");
            }
        }

        public class PushNotifier
        {
            public void SendPush(string message)
            {
                Console.WriteLine($"Powiadomiene push wysłane: {message}");
            }
        }

        public class NotificationManager
        {
            public NotificationHandler Notify;

            public void AddNotificationMethod(NotificationHandler handler)
            {
                Notify += handler;
            }

            public void RemoveNotificationMethod(NotificationHandler handler)
            {
                Notify -= handler;
            }

            public void SendNotification(string message)
            {
                Notify?.Invoke(message);
            }
        }

        public static void ShowMenu()
        {
            Console.Clear();
            Console.WriteLine("Menu");
            Console.WriteLine("1. Dodaj powiadomienie email");
            Console.WriteLine("2. Dodaj powiadomienie sms");
            Console.WriteLine("3. Dodaj powiadomienie push");
            Console.WriteLine("4. Usuń powiadomienie email");
            Console.WriteLine("5. Usuń powiadomienie sms");
            Console.WriteLine("6. Usuń powiadomienie push");
            Console.WriteLine("7. Wyślij powiadomienia");
            Console.WriteLine("8. Wyjdź");
        }

        public static int ValidIntInput(string prompt)
        {
            Console.Write(prompt);
            int input = 0;
            while (true)
            {
                if(int.TryParse(Console.ReadLine(), out input))
                {
                    return input;
                }
                else
                {
                    Console.WriteLine("Źle wprowadzone dane");
                }
            }
        }

        public static string MessageValidate()
        {
            string message;
            while (true)
            {
                message = Console.ReadLine();
                if (string.IsNullOrWhiteSpace(message) || message.Length > 100)
                {
                    Console.Write("Wiadomość musi mieść conajmniej 0 znaków i mniej niż 100 znaków, wprowadź ponownie: ");
                }
                else
                {
                    return message;
                }
            }
        }

        static void Main(string[] args)
        {
            var emailNotifier = new EmailNotifier();
            var smsNotifier = new SMSNotifier();
            var pushNotifier = new PushNotifier();

            var notificationManager = new NotificationManager();

            while (true)
            {
                try
                {
                    ShowMenu();
                    int choice = ValidIntInput("Podaj wybór: ");
                    switch(choice)
                    {
                        case 1:
                            notificationManager.AddNotificationMethod(emailNotifier.SendEmail);
                            Console.WriteLine("Dodano powiadomienia email");
                            Console.Write("Kliknij dowolny przycisk aby przejść dalej . . .");
                            Console.ReadKey();
                            break;
                        case 2:
                            notificationManager.AddNotificationMethod(smsNotifier.SendSMS);
                            Console.WriteLine("Dodano powiadomienia sms");
                            Console.Write("Kliknij dowolny przycisk aby przejść dalej . . .");
                            Console.ReadKey();
                            break;
                        case 3:
                            notificationManager.AddNotificationMethod(pushNotifier.SendPush);
                            Console.WriteLine("Dodano powiadomienia push");
                            Console.Write("Kliknij dowolny przycisk aby przejść dalej . . .");
                            Console.ReadKey();
                            break;
                        case 4:
                            notificationManager.RemoveNotificationMethod(emailNotifier.SendEmail);
                            Console.WriteLine("Usunięto powiadomienia email");
                            Console.Write("Kliknij dowolny przycisk aby przejść dalej . . .");
                            Console.ReadKey();
                            break;
                        case 5:
                            notificationManager.RemoveNotificationMethod(smsNotifier.SendSMS);
                            Console.WriteLine("Usunięto powiadomienia sms");
                            Console.Write("Kliknij dowolny przycisk aby przejść dalej . . .");
                            Console.ReadKey();
                            break;
                        case 6:
                            notificationManager.RemoveNotificationMethod(pushNotifier.SendPush);
                            Console.WriteLine("Usunięto powiadomienia push");
                            Console.Write("Kliknij dowolny przycisk aby przejść dalej . . .");
                            Console.ReadKey();
                            break;
                        case 7:
                            Console.Write("Wpisz wiadomość do wysłania: ");
                            string message = MessageValidate();
                            notificationManager.SendNotification(message);
                            Console.Write("Kliknij dowolny przycisk aby przejść dalej . . .");
                            Console.ReadKey();
                            break;
                        case 8:
                            return;
                        default:
                            Console.WriteLine("Nieprawidłowa opcja, spróbuj ponownie");
                            Console.Write("Kliknij dowolny przycisk aby przejść dalej . . .");
                            Console.ReadKey();
                            break;
                    }
                }
                catch (Exception e)
                {
                    Console.WriteLine($"Błąd: {e.Message}");
                }
            }
        }
    }
}

