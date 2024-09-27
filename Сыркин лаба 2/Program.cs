using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Windows.Forms;


namespace Сыркин_лаба_2
{
    internal class Program
    {
        [STAThread] // Указывает, что метод может быть вызван только из однопоточной модели
        static void Main(string[] args)
        {
            // Запрос текста у пользователя
            Console.WriteLine("Введите текст для сохранения в файл:");
            string inputText = Console.ReadLine(); 

            // Запрос имени файла у пользователя
            Console.WriteLine("Введите имя файла (без расширения):");
            string fileName = Console.ReadLine(); 

            // Открытие диалогового окна для выбора папки
            using (FolderBrowserDialog folderDialog = new FolderBrowserDialog())
            {
                DialogResult result = folderDialog.ShowDialog(); // Показать диалоговое окно

                if (result == DialogResult.OK) // Проверка, выбрана ли папка
                {
                    string folderPath = folderDialog.SelectedPath; // Получение пути к выбранной папке

                    // Запрос кодировки у пользователя
                    Console.WriteLine("Выберите кодировку:");
                    Console.WriteLine("1. UTF-8");
                    Console.WriteLine("2. Windows-1251");
                    Console.WriteLine("3. DOS-866");
                    int encodingChoice = int.Parse(Console.ReadLine()); // Чтение выбора кодировки

                    Encoding encoding; // Переменная для хранения выбранной кодировки

                    // Определение кодировки в зависимости от выбора пользователя
                    switch (encodingChoice)
                    {
                        case 1:
                            encoding = Encoding.UTF8; // Выбор UTF-8
                            break;
                        case 2:
                            encoding = Encoding.GetEncoding(1251); // Выбор Windows-1251
                            break;
                        case 3:
                            encoding = Encoding.GetEncoding(866); // Выбор DOS-866
                            break;
                        default:
                            Console.WriteLine("Некорректный выбор. Используется UTF-8 по умолчанию."); // Сообщение об ошибке
                            encoding = Encoding.UTF8; // Установка кодировки по умолчанию
                            break;
                    }

                    // Полный путь к файлу
                    string fullPath = Path.Combine(folderPath, fileName + ".txt"); // Создание полного пути к файлу

                    try
                    {
                        // Запись текста в файл с выбранной кодировкой
                        File.WriteAllText(fullPath, inputText, encoding);
                        Console.WriteLine($"Файл успешно сохранен: {fullPath}"); // Сообщение об успешном сохранении
                    }
                    catch (Exception ex) // Обработка возможных исключений
                    {
                        Console.WriteLine($"Ошибка при сохранении файла: {ex.Message}"); // Сообщение об ошибке
                    }
                }
                else
                {
                    Console.WriteLine("Папка не выбрана. Программа завершена."); // Сообщение при отмене выбора папки
                }
            }
        }
    }
}
