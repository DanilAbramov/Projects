using System;

namespace LAB2
{
    class Program
    {

        static void Main(string[] args)
        {
            string Alphabet = "абвгдеёжзийклмнопрстуфхцчшщъыьэюя";
            do
            {
                switch (menu())
                {
                    case 1:
                        Console.Clear();
                        Console.Write("Введите сообщение: ");
                        string original_message = Console.ReadLine();
                        Console.Write("Введите ключ: ");
                        int key = Convert.ToInt32(Console.ReadLine());
                        if (key > 0)
                            Console.WriteLine("Зашифрованное сообщение: " + encryption(original_message, Alphabet, key));
                        else
                            Console.WriteLine("Ошибка! Неверно задан ключ");

                        break;
                    case 2:
                        Console.Clear();
                        Console.Write("Зашифрованноe сообщение: ");
                        string encrypted_message = Console.ReadLine();
                        decryption(encrypted_message, Alphabet);
                        break;
                    case 3:
                        Environment.Exit(0);
                        break;
                    default:
                        Console.Clear();
                        Console.WriteLine("Ошибка!");
                        break;
                }
                Console.WriteLine("\n\nДля продолжения нажмите любую клавишу...");
                Console.ReadLine();
            } while (true);

        }
        static string encryption(string message, string alphabet, int key)
        {
            string result = "";
            int m = alphabet.Length;
            message = message.ToLower();
            for (int i = 0; i < message.Length; i++)
            {
                if (alphabet.IndexOf(message[i]) > -1)
                {
                    for (int j = 0; j < alphabet.Length; j++)
                    {
                        if (message[i] == alphabet[j])
                        {
                            int temp = (j + key) % m;
                            result = result + alphabet[temp];
                        }
                    }
                }
                else
                    result = result + message[i];
            }
            return result;
        }

        static void decryption(string message, string alphabet)
        {
            string result;
            int m = alphabet.Length;
            int key = 0;
            message = message.ToLower();
            Console.WriteLine();

            do
            {
                result = "";
                for (int i = 0; i < message.Length; i++)
                {
                    if (alphabet.IndexOf(message[i]) > -1)
                    {
                        for (int j = 0; j < alphabet.Length; j++)
                        {
                            if (message[i] == alphabet[j])
                            {
                                int temp = (j - key + m) % m;
                                result = result + alphabet[temp];
                            }
                        }
                    }
                    else
                        result = result + message[i];
                }
                Console.WriteLine("Шаг {0}  {1}", key, result);
                key = key + 1;
            } while (key < alphabet.Length);
        }

        static int menu()
        {
            Console.Clear();
            Console.WriteLine("МЕНЮ: ");
            Console.WriteLine("1. Зашифровка");
            Console.WriteLine("2. Расшифровка");
            Console.WriteLine("3. Выход");
            Console.Write("Выберите команду: ");
            int number;
            string value = Console.ReadLine();
            bool result = Int32.TryParse(value, out number);
            if (result)
                return Convert.ToInt32(value);

            return 0;


        }

    }
}

