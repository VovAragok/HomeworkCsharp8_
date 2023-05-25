Main();

void Main()
{
	bool isWork = true;

	while (isWork)
	{
		Console.WriteLine("Enter command");
		string command = Console.ReadLine();

		switch (command)
		{
			case "54":
				Task54();
				break;
			case "56":
				Task56();
				break;
			case "58":
				Task58();
				break;
            case "60":
				Task60();
				break;
            
			case "exit":
				isWork = false;
				break;
		}
	}
}



//54. Задайте двумерный массив. Напишите программу, которая упорядочит по убыванию элементы каждой строки двумерного массива.

void Task54()
{
   Console.WriteLine("Task 54");
    Console.WriteLine("создадим новый массив");
    int [,] newRndArray = CreateIntNewarray();
    newRndArray = sortedNewarray(newRndArray);
}
// Задача 56: Задайте прямоугольный двумерный массив. Напишите программу, которая будет находить строку с наименьшей суммой элементов.

void Task56()
{
    Console.WriteLine("Task 56");
    Console.WriteLine("создадим новый массив");
    int [,] newRndArray = CreateIntNewarray();
    Dictionary<int,int> result  = Findminsumarray(newRndArray);
    
}


// Задача 58: Задайте две матрицы. Напишите программу, которая будет находить произведение двух матриц.

void Task58()
{
    Console.WriteLine("Task 52");
    while (true)
    {
        Console.WriteLine("создадим новый массив А");
    int [,] newRndArrayA = CreateIntNewarray();
    Console.WriteLine("Создадим новый массив B");
    int [,] newRndArrayB = CreateIntNewarray();
    if (newRndArrayA.GetLength(1)==newRndArrayB.GetLength(0) )
    {
        int [,] result = MultiplicationMatrix(newRndArrayA,newRndArrayB);
        break;

    }
    else
    {
        Console.WriteLine("Количество столбцов  матрицы А должны быть одинаковым с числом строк матрицы B");
    }
        
    }
}


//  Задача 60. ...Сформируйте трёхмерный массив из неповторяющихся двузначных чисел. Напишите программу, которая будет построчно выводить массив, добавляя индексы каждого элемента.  
void Task60()
{
    Console.WriteLine("Task 60");
    Console.WriteLine("создадим новый массив");
    int [,,] result = CreateInt3XNewarray();
    
    
}



int [,] CreateIntNewarray()
{
    Console.WriteLine("введите количество строк для нового массива");
    int line = ReadInt("m");
    Console.WriteLine("введите количество столбцов для нового массива");
    int columnes = ReadInt("n");
    Console.WriteLine("укажите минимальный диапазон вещественных чисел в двумерном массиве");
    int rndMin = ReadInt("min");
    Console.WriteLine (" укажите максимальный диапазон вещественных чисел в двумерном массиве");
    int rndMax = ReadInt("max");
    int [,] newGenerateArray = IntNewarray(line,columnes,rndMin,rndMax);
    return newGenerateArray;

}

int [,,] CreateInt3XNewarray()
{
    Console.WriteLine("введите размер трехмерного массива по оси X ");
    int lineX = ReadInt("m");
    Console.WriteLine("введите размер трехмерного массива по оси Y ");
    int lineY = ReadInt("n");
    Console.WriteLine("введите размер трехмерного массива по оси Z ");
    int lineZ = ReadInt("z");
    int[,,] newGenerate3xArray = New3xArray(lineX, lineY, lineZ);
    return newGenerate3xArray;
}



int ReadInt(string argument)
{
	Console.Write($"Input {argument}: ");
	int number;

	while (!int.TryParse(Console.ReadLine(), out number))
	{
		Console.WriteLine("Ooops. Try again!");
	}

	return number;
}


int[,,] New3xArray(int x,int y,int z)
{
    int  [,,] new3xArray = new int[x,y,z];
    
    Random random = new Random();
    for (int i = 0; i < x; i++)
    {
        for (int j = 0; j < y; j++)
        {
            for (int k = 0; k < z; k++)
            {
                int value;
                do
                {
                 value = random.Next(10,100) ;
                } while (IsValueinArray(new3xArray, value));
                new3xArray[i,j,k] = value;
            }
        }
    }
     for (int i = 0; i < x; i++)
        {
            for (int j = 0; j < y; j++)
            {
                for (int k = 0; k < z; k++)
                {
                    Console.WriteLine($" {new3xArray[i, j, k]} ---  ({i}, {j}, {k})");
                }
            }
        }
    return new3xArray;
    }




bool IsValueinArray(int[,,] array, int value)
    {
        foreach (int item in array)
        {
            if (item == value)
            {
                return true;
            }
        }
        return false;
    }

int [,] IntNewarray(int m, int n, int a, int b) // функция для создания двумерного массива целых чисел.
{
    int  [,] newarray = new int[m,n];
    Random rnd = new Random();
    for (int i = 0; i < m; i++)
    {
        for (int j = 0; j < n; j++)
        {
        newarray[i,j] = rnd.Next(a, b+1);
           Console.Write(newarray[i, j] + " ");
        }
        Console.WriteLine();
        
    }
    Console.WriteLine("Ваш сгененерированый двумерный массив ");
    return newarray;
   
}


int [,] sortedNewarray(int [,] newarray)
{

int rowCount = newarray.GetLength(0); 
int columnCount = newarray.GetLength(1); 

for (int i = 0; i < rowCount; i++)
{
    int[] tempArray = new int[columnCount];
    for (int j = 0; j < columnCount; j++)
    {
        tempArray[j] = newarray[i, j];
    }
    Array.Sort(tempArray);

    for (int j = 0; j < columnCount; j++)
    {
        newarray[i, j] = tempArray[j];
    }
}

for (int i = 0; i < rowCount; i++)
{
    for (int j = 0; j < columnCount; j++)
    {
        Console.Write(newarray[i, j] + " ");
    }
    Console.WriteLine();
}
return newarray;
}



Dictionary<int,int> Findminsumarray(int[,] newarray) // Функция для нахождения строки  по минимальному значению суммы. 
{
    int rowCount = newarray.GetLength(0);
    int columnCount = newarray.GetLength(1);

    Dictionary<int, int>[] dict = new Dictionary<int, int>[rowCount];
    
    for (int i = 0; i < rowCount; i++)
    {
        int sum = 0;
        dict[i] = new Dictionary<int, int>();

        for (int j = 0; j < columnCount; j++)
        {
            sum += newarray[i, j];
        }

        dict[i].Add(i, sum);
    }
    Dictionary<int, int> mindict = dict.OrderBy(x => x.Values.Sum()).First();
    Console.WriteLine($"Минимальный индекс строки: {mindict.Keys.First()}, Минимальное значение: {mindict.Values.First()} ");
    Console.WriteLine();
    return mindict;

}

int[,] MultiplicationMatrix (int[,] matrixA, int[,] matrixB)
{
    int rowsA = matrixA.GetLength(0);
    int colsA = matrixA.GetLength(1);
    int colsB = matrixB.GetLength(1);

    int[,] result = new int[rowsA, colsB];

    for (int i = 0; i < rowsA; i++)
    {
        for (int j = 0; j < colsB; j++)
        {
            int sum = 0;
            for (int k = 0; k < colsA; k++)
            {
                sum += matrixA[i, k] * matrixB[k, j];
            }
            result[i, j] = sum;
        }
    }
    for (int i = 0; i < result.GetLength(0); i++)
{
    for (int j = 0; j < result.GetLength(1); j++)
    {
        Console.Write(result[i, j] + " ");
    }
    Console.WriteLine();
}
    return result;
}