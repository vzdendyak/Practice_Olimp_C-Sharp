using System;
using System.IO;
using System.Text;

namespace Practice_Olimp_C_Sharp
{
    internal class CryptMethods
    {
        private static readonly Encoding encoding = Encoding.ASCII;
        private static readonly double[] gamma = new double[11];
        private static string source = "";
        private static string outPut = "";

        private static string textForTeacher = "Роботу виконав Здендяк Василь, група КН-21. Варiант 5. Реалiзованi методи гаммування (Шифрування, дешифрування) та пiдбору випадкових чисел методами " +
            "Конгурентного лiнiйного та квадратичного шифрування, а також  Фiбоначчi";

        // 1 - linear kongruent method
        private static readonly double a = 22695477;

        private static readonly double c = uint.MaxValue;
        private static readonly double m = 32;
        private static double newSeed = 2;
        private static double oldSeed = 0;

        // 2 - Kvadr-kongruent
        private static readonly uint a1 = 45;

        private static readonly uint c1 = 29;
        private static readonly uint d1 = 4;
        private static readonly uint m1 = 72;

        // 3 - Fibonaccie
        private static uint a2 = 24;

        private static uint n = 55;
        private static uint b2 = 55;
        private static uint[] fibMas = new uint[300];

        public static void psevdo_Main()
        {
            // зчитування вхідного слова з файлу
            using (FileStream fstream = File.OpenRead(@"D:\projects\Practice_Olimp_C-Sharp\Practice_Olimp_C-Sharp\in.bin"))
            {
                byte[] array = new byte[fstream.Length];
                fstream.Read(array, 0, array.Length);
                source = System.Text.Encoding.Default.GetString(array);
                Console.WriteLine($"Текст iз файлу: {source}");
            }
            // реєструємо кодування для перетворювання char в ascii
            Encoding.RegisterProvider(CodePagesEncodingProvider.Instance);

            Console.WriteLine("Конгурентний лiнiйний метод: ");
            KongurentDemo(0);

            Console.WriteLine("Конгурентний квадратичний метод: ");
            KongurentDemo(1);

            Console.WriteLine("Метод Фiбоначчi з запiзненням: ");
            FibonaccieDemo();

            Console.WriteLine(textForTeacher);
        }

        private static void FibonaccieDemo()
        {
            // заповнюємо перші значення
            fibMas[0] = 1;
            fibMas[1] = 2;
            for (int i = 2; i < 300; i++)
            {
                fibMas[i] = fibMas[i - 1] + fibMas[i - 2];
            }
            // отримуэмо рандомні числа методом фібоначчі
            for (uint i = 0; i < source.Length; i++)
            {
                gamma[i] = getFibonacci(i);
            }
            Console.WriteLine("Вхiдне слово: " + source);
            // застосовуємо гамування
            outPut = GammuvannyaMainCrypt(source, gamma);
            Console.Write("Зашифроване слово: ");
            // записуємо у файл вихідне слово
            using (FileStream fstream = new FileStream(@"D:\projects\Practice_Olimp_C-Sharp\Practice_Olimp_C-Sharp\out.bin", FileMode.Append))
            {
                byte[] array = System.Text.Encoding.Default.GetBytes("Фібоначчі метод: " + outPut + '\n');
                fstream.Write(array, 0, array.Length);
            }
            Console.WriteLine(outPut);
            Console.Write("Дешифроване слово: ");
            // декодуємо слово
            outPut = GammuvannyaMainCrypt(outPut, gamma);
            Console.WriteLine(outPut);
            Console.WriteLine();
        }

        private static void KongurentDemo(int k)
        {
            // залежно від параметру використовуємо або лінійний або квадратичний конгруентний метод
            for (int i = 0; i < source.Length; i++)
            {
                if (k == 0)
                {
                    gamma[i] = linearKongurentMethod();
                }
                else
                {
                    gamma[i] = KvadrKongurentDemo();
                }
            }
            Console.WriteLine("Вхiдне слово: " + source);
            // застосовуємо гамування
            outPut = GammuvannyaMainCrypt(source, gamma);
            Console.Write("Зашифроване слово: ");

            // записуємо у файл вихідне слово
            using (FileStream fstream = new FileStream(@"D:\projects\Practice_Olimp_C-Sharp\Practice_Olimp_C-Sharp\out.bin", FileMode.Append))
            {
                if (k == 0)
                {
                    byte[] array = System.Text.Encoding.Default.GetBytes("Конг.Лін. метод: " + outPut + '\n');
                    fstream.Write(array, 0, array.Length);
                }
                else
                {
                    byte[] array = System.Text.Encoding.Default.GetBytes("Конг.Квадр. метод: " + outPut + '\n');
                    fstream.Write(array, 0, array.Length);
                }
            }

            Console.WriteLine(outPut);
            Console.Write("Дешифроване слово: ");
            // декодуємо слово
            outPut = GammuvannyaMainCrypt(outPut, gamma);
            Console.WriteLine(outPut);
            Console.WriteLine();
        }

        private static string GammuvannyaMainCrypt(string text, double[] key)
        {
            // реєструємо вихідний рядок
            string outP = "";
            // переводимо вхідне слово в масив ascii кодів
            byte[] bytes = Encoding.GetEncoding(1251).GetBytes(text);
            for (int i = 0; i < source.Length; i++)
            {
                // робимо по черзі XOR
                uint varOut = bytes[i] ^ (uint)key[i];
                // переводимо число назад в символ і додаємо до рядка
                outP += Encoding.GetEncoding(1251).GetChars(new byte[] { (byte)varOut })[0];
            }
            return outP;
        }

        private static double KvadrKongurentDemo()
        {
            newSeed = (d1 * Math.Pow(oldSeed, 2) + a1 * oldSeed + c1) % m1;
            oldSeed = newSeed;
            return newSeed;
        }

        private static double linearKongurentMethod()
        {
            newSeed = (oldSeed * a + c) % m;
            oldSeed = newSeed;
            return newSeed;
        }

        private static double getFibonacci(uint N)
        {
            N += n;
            double New = fibMas[N - a2] + fibMas[N - b2];
            return New;
        }
    }
}