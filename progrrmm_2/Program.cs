// Задача 62. Напишите программу, которая заполнит спирально массив 4 на 4.
// Например, на выходе получается вот такой массив:
// 01 02 03 04
// 12 13 14 05
// 11 16 15 06
// 10 09 08 07




     int size = ReadInt("Введите размер массива: ");
        int[,] spiralArray = new int[size, size];
        int value = 1;
        int startX = 0;    //индекс столбца, с которого начинается заполнение.
        int startY = 0;    //индекс строки, с которой начинается заполнение.
        int endX = size - 1; // индекс столбца - конец заполнения 
        int endY = size - 1; // индекс строки - конец заполнения

        while (value <= size * size)
        {
            // Заполнение верхней горизонтальной строки
            for (int i = startX; i <= endX; i++)
            {
                spiralArray[startY, i] = value++;
            }
            startY++;

            // Заполнение правого вертикального столбца
            for (int i = startY; i <= endY; i++)
            {
                spiralArray[i, endX] = value++;
            }
            endX--;

            // Заполнение нижней горизонтальной строки
            if (startY <= endY)
            {
                for (int i = endX; i >= startX; i--)
                {
                    spiralArray[endY, i] = value++;
                }
                endY--;
            }

            // Заполнение левого вертикального столбца
            if (startX <= endX)
            {
                for (int i = endY; i >= startY; i--)
                {
                    spiralArray[i, startX] = value++;
                }
                startX++;
            }
        }

        // Вывод массива
        Console.WriteLine("Спиральный массив:");
        for (int i = 0; i < size; i++)
        {
            for (int j = 0; j < size; j++)
            {
                Console.Write(spiralArray[i, j] + "\t");
            }
            Console.WriteLine();
        }
    

    static int ReadInt(string prompt)
    {
        Console.Write(prompt);
        int number;

        while (!int.TryParse(Console.ReadLine(), out number))
        {
            Console.WriteLine("Ошибка ввода. Попробуйте ещё раз.");
            Console.Write(prompt);
        }

        return number;
    }
