using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;

namespace project4_delegaty_powiadomienia_menu
{
    public delegate void NotificationHandler(string message);

    public interface INotifier
    {
        void Notification(string message);
    }
    public class EmailNotifier : INotifier
    {
        public void Notification(string message)
        {
            try
            {
                Console.WriteLine($"Email wysłany: {message}");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Błąd podczas wysyłania Email: {ex.Message}");
            }
        }
    }

    public class SMSNotifier : INotifier
    {
        public void Notification(string message)
        {
            try
            {
                Console.WriteLine($"SMS wysłany: {message}");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Błąd podczas wysyłania SMS: {ex.Message}");
            }
        }
    }

    public class PushNotifier : INotifier
    {
        public void Notification(string message)
        {
            try
            {
                Console.WriteLine($"Push wysłany: {message}");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Błąd podczas wysyłania Push: {ex.Message}");
            }
        }
    }

    public class NotificationManager
    {
        public NotificationHandler Notify;

        public void AddNotificationMethod(NotificationHandler handler)
        {
            if (Notify != null && Notify.GetInvocationList().Contains(handler))
            {
                Console.WriteLine("Ta metoda powiadomienia jest już dodana");
            }
            else
            {
                Notify += handler;
                Console.WriteLine("Dodano metodę powiadomienia");
                return;
            }
        }

        public void RemoveNotificationMethod(NotificationHandler handler)
        {
            if (Notify == null || !Notify.GetInvocationList().Contains(handler))
            {
                Console.WriteLine("Nie można usunąć tej metody powiadomienia");
            }
            else
            {
                Notify -= handler;
                Console.WriteLine("Usunięto metodę powiadomienia");
                return;
            }
        }

        public void SendNotification(string message)
        {
            if (Notify == null)
            {
                Console.WriteLine("Brak dostępnych powiadomień, dodaj conajmniej jedną metodę");
                return;
            }
            foreach (var handler in Notify.GetInvocationList())
            {
                try
                {
                    handler.DynamicInvoke(message);
                    string logEntry = $"[{DateTime.Now:yyyy-MM-dd HH:mm:ss}] Wysłano: {handler.Method.Name}, wiadomość: {message}{Environment.NewLine}";
                    File.AppendAllText("log.txt", logEntry);
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Błąd podczas wysyłania: {ex.Message}");
                }
            }
        }

        public void ListNotificationMethods()
        {
            if(Notify == null )
            {
                Console.WriteLine("Brak zarejestrowanych metod powiadomień");
                return;
            }

            Console.WriteLine("Zarejestrowane metody powiadomień: ");

            var displayHandlers = new HashSet<string>();

            foreach(var handler in Notify.GetInvocationList())
            {
                var target = handler.Target;
                var methodName = handler.Method.Name;
                var className = target?.GetType().FullName ?? "Nieznany";

                var uniqueKey = $"{className}.{methodName}";

                if(!displayHandlers.Contains(uniqueKey))
                {
                    displayHandlers.Add(uniqueKey);
                    Console.WriteLine($"- Klasa: {className}, metoda: {methodName}");
                }
                else
                {
                    Console.WriteLine($"- Klasa: {className}, metoda: {methodName}");
                }
            }
        }
    }
    internal class Program
    {
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
            Console.WriteLine("8. Pokaż zarejestrowane metody powiadomień");
            Console.WriteLine("9. Wyjdź");
        }


        public static int ValidIntInput(string prompt)
        {
            Console.Write(prompt);
            int input = 0;
            while (true)
            {
                if (int.TryParse(Console.ReadLine(), out input))
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
                    switch (choice)
                    {
                        case 1:
                            notificationManager.AddNotificationMethod(emailNotifier.Notification);
                            Console.WriteLine("Dodano powiadomienia email");
                            Console.Write("Kliknij dowolny przycisk aby przejść dalej . . .");
                            Console.ReadKey();
                            break;
                        case 2:
                            notificationManager.AddNotificationMethod(smsNotifier.Notification);
                            Console.WriteLine("Dodano powiadomienia sms");
                            Console.Write("Kliknij dowolny przycisk aby przejść dalej . . .");
                            Console.ReadKey();
                            break;
                        case 3:
                            notificationManager.AddNotificationMethod(pushNotifier.Notification);
                            Console.WriteLine("Dodano powiadomienia push");
                            Console.Write("Kliknij dowolny przycisk aby przejść dalej . . .");
                            Console.ReadKey();
                            break;
                        case 4:
                            notificationManager.RemoveNotificationMethod(emailNotifier.Notification);
                            Console.WriteLine("Usunięto powiadomienia email");
                            Console.Write("Kliknij dowolny przycisk aby przejść dalej . . .");
                            Console.ReadKey();
                            break;
                        case 5:
                            notificationManager.RemoveNotificationMethod(smsNotifier.Notification);
                            Console.WriteLine("Usunięto powiadomienia sms");
                            Console.Write("Kliknij dowolny przycisk aby przejść dalej . . .");
                            Console.ReadKey();
                            break;
                        case 6:
                            notificationManager.RemoveNotificationMethod(pushNotifier.Notification);
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
                            notificationManager.ListNotificationMethods();
                            Console.Write("Kliknij dowolny przycisk aby przejść dalej . . .");
                            Console.ReadKey();
                            break;
                        case 9:
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
