using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Linq;
using System.Text.RegularExpressions;
using System.IO;

namespace Matrix_2x2
{
    class Matrix
    {
        /* 
         * 1) Создать класс Matrix, описывающий квадратную матрицу 2х2.
         * 2) Добавить вычисляемое свойство - определитель.
         * 3) Реализовать двумерный индексатор.
         * 4) Реализовать метод нахождение обратной матрицы.
         * 5) Переопределить ToString().
         * 6) Переопределить в классе операции "+, ++, -, --, *, /, <, > (по определителю), ==, !=".
         * 7) Написать функции Parse и TryParse, считывающие из строки матрицу (правило записи матрицы в строку определите
         *    сами, хорошо бы она соотносилась с ToString()).
         */

        private int rang;
        private double[,] matrix;

        public double this[int index1, int index2]
        {
            get
            {
                if ((index1 >= 0 && index1 < 2) && (index2 >= 0 && index2 < 2))
                {
                    return matrix[index1, index2];
                }
                else
                {
                    throw new ArgumentOutOfRangeException("Индексы за пределами матрицы!");
                }
            }
            set
            {
                if ((index1 >= 0 && index1 < 2) && (index2 >= 0 && index2 < 2))
                {
                    matrix[index1, index2] = value;
                }
                else
                {
                    throw new ArgumentOutOfRangeException("Индексы за пределами матрицы!");
                }
            }
        }

        public Matrix()
        {
            rang = 2;
            matrix = new double[rang, rang];
        }

        public Matrix(double x00, double x01, double x10, double x11)
        {
            rang = 2;
            matrix = new double[rang, rang];
            try
            {
                matrix[0, 0] = x00;
                matrix[0, 1] = x01;
                matrix[1, 0] = x10;
                matrix[1, 1] = x11;
            }
            catch
            {
                throw new ArithmeticException("Ошибка в записи!");
            }
        }


        public double Determinant => (matrix[0, 0] * matrix[1, 1]) - (matrix[1, 0] * matrix[0, 1]);
        

        public static Matrix FindReverse(Matrix A)
        {
            Matrix reverse = new Matrix();
            reverse.matrix = new double[2, 2];
            if(A.Determinant != 0)
            {
                reverse[0, 0] = A[1, 1] / A.Determinant;
                reverse[1, 1] = A[0, 0] / A.Determinant;
                reverse[1, 0] = -1*A[1, 0] / A.Determinant;
                reverse[0, 1] = -1*A[0, 1] / A.Determinant;
            }
            else
            {
                throw new ArgumentNullException("Вырожденная матрица!");
            }
            return reverse;
        }

        public override string ToString()
        {
            return ($"[{this[0, 0]},{this[0, 1]}]" + "\r\n" + $"[{this[1, 0]},{this[1, 1]}]");
        }

        public static Matrix operator +(Matrix A, Matrix B)
        {
            Matrix sum = new Matrix(0, 0, 0, 0);
            sum[0, 0] = A[0, 0] + B[0, 0];
            sum[0, 1] = A[0, 1] + B[0, 1];
            sum[1, 0] = A[1, 0] + B[1, 0];
            sum[1, 1] = A[1, 1] + B[1, 1];
            return sum;
        }

        public static Matrix operator -(Matrix A, Matrix B)
        {
            Matrix minus = new Matrix(0, 0, 0, 0);
            minus[0, 0] = A[0, 0] - B[0, 0];
            minus[0, 1] = A[0, 1] - B[0, 1];
            minus[1, 0] = A[1, 0] - B[1, 0];
            minus[1, 1] = A[1, 1] - B[1, 1];
            return minus;
        }

        public static Matrix operator ++(Matrix A)
        {
            Matrix unarplus = new Matrix(0, 0, 0, 0);
            unarplus[0, 0] = A[0, 0] + 1;
            unarplus[0, 1] = A[0, 1] + 1;
            unarplus[1, 0] = A[1, 0] + 1;
            unarplus[1, 1] = A[1, 1] + 1;
            return unarplus;
        }

        public static Matrix operator --(Matrix A)
        {
            Matrix unarmin = new Matrix(0, 0, 0, 0);
            unarmin[0, 0] = A[0, 0] - 1;
            unarmin[0, 1] = A[0, 1] - 1;
            unarmin[1, 0] = A[1, 0] - 1;
            unarmin[1, 1] = A[1, 1] - 1;
            return unarmin;
        }

        public static Matrix operator *(Matrix A, Matrix B)
        {
            Matrix mult = new Matrix(0, 0, 0, 0);
            mult[0, 0] = A[0, 0] * B[0, 0] + A[0, 1] * B[1, 0];
            mult[0, 1] = A[0, 0] * B[0, 1] + A[0, 1] * B[1, 1];
            mult[1, 0] = A[1, 0] * B[0, 0] + A[1, 1] * B[1, 0];
            mult[1, 1] = A[1, 1] * B[0, 1] + A[1, 1] * B[1, 1];
            return mult;
        }

        public static double operator /(Matrix A, Matrix B)
        {
            return A.Determinant / B.Determinant;
        }

        public static bool operator <(Matrix A, Matrix B)
        {
            return A.Determinant < B.Determinant ? true : false;
        }

        public static bool operator >(Matrix A, Matrix B)
        {
            return A.Determinant > B.Determinant ? true : false;
        }

        public static bool operator ==(Matrix A, Matrix B)
        {
            return A[0, 0] == B[0, 0] && A[0, 1] == B[0, 1] && A[1, 0] == B[1, 0] && A[1, 1] == B[1, 1];
        }

        public static bool operator !=(Matrix A, Matrix B)
        {
            return !(A[0, 0] == B[0, 0] && A[0, 1] == B[0, 1] && A[1, 0] == B[1, 0] && A[1, 1] == B[1, 1]);
        }

        public void ParseMatrix(string str)
        {
            string[] ptr = str.Split(' ');
            try
            {
                matrix[0, 0] = double.Parse(ptr[0]);
                matrix[0, 1] = double.Parse(ptr[1]);
                matrix[1, 0] = double.Parse(ptr[2]);
                matrix[1, 1] = double.Parse(ptr[3]);
            }
            catch
            {
                throw new ArithmeticException("Ошибка записи в матрицу!");
            }
        }

        public static bool TryParseMatrix(string ptr, Matrix A)
        {
            string[] str = ptr.Split(' ');
            try
            {
                Double.TryParse(str[0], out A.matrix[0, 0]);
                Double.TryParse(str[1], out A.matrix[0, 1]);
                Double.TryParse(str[2], out A.matrix[1, 0]);
                Double.TryParse(str[3], out A.matrix[1, 1]);
            }
            catch
            {
                A.matrix = new double[2, 2];
                return false;
            }
            return true;
        }

        public void OutPut()
        {
            if(matrix == null)
            {
                throw new ArgumentNullException("Матрицы не существует!");
            }
            for (int i = 0; i < matrix.GetLength(0); ++i)
            {
                Console.Write("        ");
                for(int j = 0; j < matrix.GetLength(1); ++j)
                {
                    Console.Write(matrix[i,j] + " ");
                }
                Console.WriteLine();
            }
        }

        public void OutPutMatr()
        {
            if(matrix == null)
            {
                throw new ArgumentNullException("Матрицы не существует");
            }
            Console.WriteLine("     " + "[" + matrix[0, 0] + "," + matrix[0, 1] + "]");
            Console.WriteLine("     " + "[" + matrix[1, 0] + "," + matrix[1, 1] + "]");
        }
    }


    class ListOfMatrix
    {
        /* Создать класс ListOfMatrix, работающий со списком (List) матриц. Список можно
         * реализовать как List<Matrix>. Список должен быть закрытым полем. Опеределить в 
         * классе индексатор, метод сортировки(можно вызвать встроенные Array.Sort или 
         * List.Sort), определения первого и последнего элементов, добавление элемента, 
         * нахождение минимального и максимального элементов(по определителю), 
         * преобразование к массиву матриц(ToArray()), вывод элементов в массив строк.
         */

        private List<Matrix> Matrix_List;

        public Matrix this[int index]
        {
            get => Matrix_List[index];
            set => Matrix_List[index] = value;
        }

        //public ListOfMatrix Construct(Matrix A, Matrix B, Matrix C, Matrix D)
        //{
        //    List<Matrix> kek = new List<Matrix>();
        //    //ListOfMatrix[] kek = new ListOfMatrix[];
        //    kek[0] = A;
        //    kek[1] = B;
        //    kek[2] = C;
        //    kek[3] = D;
        //    return kek;
        //}

        public ListOfMatrix()// Matrix A)
        {
            Matrix_List = new List<Matrix>();
            //list_matrix.Add(A);
        }

        
        public void SortingTheList()
        {
            Matrix_List.Sort();
        }

        public void BubbleSort()
        {
            //Matrix temp;
            for (int i = 0; i < Matrix_List.Count; i++)
            {
                for (int j = 0; j < Matrix_List.Count - 1; j++)
                {
                    if (Matrix_List[j].Determinant > Matrix_List[j + 1].Determinant)
                    {
                        Matrix temp = Matrix_List[j + 1];
                        Matrix_List[j + 1] = Matrix_List[j];
                        Matrix_List[j] = temp;
                    }
                }
            }
        }
        


        public Matrix FirstElementOfList()
        {
            return Matrix_List.First();
        }

        public Matrix LastElementOfList()
        {
            return Matrix_List.Last();
        }

        public void AddToList(Matrix elem)
        {
            Matrix_List.Add(elem); 
        }

        public Matrix MinOfList()
        {
            if(Matrix_List.Count == 0)
            {
                throw new ArgumentNullException("Списка не существует!");
            }
            int minind = 0;
            Matrix min;
            try
            {
                min = Matrix_List.First();
            }
            catch(Exception e)
            {
                Console.WriteLine("\n***ERROR!***");
                Console.WriteLine("Method: {0}", e.TargetSite);
                Console.WriteLine("Message: {0}", e.Message);
                Console.WriteLine("Source: {0}", e.Source);
                return null;
            }
            for(int i = 0; i < Matrix_List.Count; i++)
            {
                if(min.Determinant > Matrix_List[i].Determinant)
                {
                    min = Matrix_List[i];
                    minind = i;
                }
            }
            return min;
        }

        public Matrix MaxOfList()
        {
            if (Matrix_List.Count == 0)
            {
                throw new ArgumentNullException("Списка не существует!");
            }
            int maxind = 0;
            Matrix max;
            try
            {
                max = Matrix_List.First();
            }
            catch (Exception e)
            {
                Console.WriteLine("\n***ERROR!***");
                Console.WriteLine("Method: {0}", e.TargetSite);
                Console.WriteLine("Message: {0}", e.Message);
                Console.WriteLine("Source: {0}", e.Source);
                return null;
            }
            for (int i = 0; i < Matrix_List.Count; i++)
            {
                if (max.Determinant < Matrix_List[i].Determinant)
                {
                    max = Matrix_List[i];
                    maxind = i;
                }
            }
            return max;
        }

        public int Count()
        {
            return Matrix_List.Count;
        }

        public Matrix[] ToArray()
        {
            return Matrix_List.ToArray();
        }

        public string[] ToStringArray()
        {
            string[] array = new string[Matrix_List.Count];
            for(int i = 0; i < array.Length; ++i)
            {
                array[i] += Matrix_List[i][0, 0].ToString() + " ";
                array[i] += Matrix_List[i][0, 1].ToString() + " ";
                array[i] += Matrix_List[i][1, 0].ToString() + " ";
                array[i] += Matrix_List[i][1, 1].ToString() + " ";
            }
            return array;
        }
    }

    class MatrixInOut
    {
        /* Класс, содержащий функции считывания списка матриц из файла
         * и записи матриц в файл. Перехват исключений при неверной работе
         * с файлами, выходе за пределы массива, деления на 0 (при нахождении обратной)
         */
        public static ListOfMatrix FileRead()
        {
            string str = @"C:\VIS\test.txt";
            string[] readstr;
            if (File.Exists(str))
            {
                readstr = File.ReadAllLines(str);
            }
            else
            {
                throw new FileNotFoundException("Файл не найден");
            }
            if(readstr.Length == 0)
            {
                throw new ArgumentNullException("Файл пустой! lul");
            }
            ListOfMatrix list = new ListOfMatrix();
            Matrix matrix;
            for (int i = 0; i < readstr.Length; i++)
            {
                string[] ptr = readstr[i].Split(' ');
                if(ptr.Length != 4)
                {
                    throw new ArgumentNullException("Неверно введены данные!!!");
                }
                matrix = new Matrix(double.Parse(ptr[0]), double.Parse(ptr[1]), double.Parse(ptr[2]), double.Parse(ptr[3]));
                list.AddToList(matrix);
            }
            return list;
        }

        public static void FileWrite(ListOfMatrix list)
        {
            string str = @"C:\VIS\out.txt";
            string[] writestr = list.ToStringArray();
            if (!File.Exists(str))
            {
                try
                {
                    File.Create(str).Close();
                }
                catch
                {
                    throw new FileNotFoundException("Ошибка в пути нахождения файла!!!");
                }
                File.WriteAllLines(str, writestr);
            }

        }
    }

    class Programm
    {
        public static int Menu()
        {
            Console.WriteLine("1) Ввести список матриц");
            Console.WriteLine("2) Записать в список матрицы из файла");
            Console.WriteLine("3) Записать список в файл");
            Console.WriteLine("4) Вывести информации про список");
            Console.WriteLine("5) Отсортировать список");
            Console.WriteLine("6) Вывести матрицы, определить которых меньше заданного числа ");
            Console.WriteLine("7) Выход");
            int n = 0;
            try
            {
                n = int.Parse(Console.ReadLine());
            }
            catch
            {
                throw new FormatException("Неверно введенная величина!!!");
            }
            return n;
        }

        public static ListOfMatrix ListPut()
        {
            Console.Write("Введите количество матриц в списке: ");
            int n = 0;
            try
            {
                n = int.Parse(Console.ReadLine());
            }
            catch
            {
                throw new FormatException("Неверно введена величина!");
            }
            Console.WriteLine("Введите четыре цифры (элементы квадратной матрицы)");
            ListOfMatrix list = new ListOfMatrix();
            for (int i = 0; i < n; i++)
            {
                Console.Write("Новая матрица: ");
                string mat = Console.ReadLine();
                Matrix matrix = new Matrix();
                if (!Matrix.TryParseMatrix(mat, matrix))
                {
                    throw new FormatException("Неверно введена матрица!");
                }
                list.AddToList(matrix);
                Console.WriteLine();
            }
            return list;
        }

        static void Main()
        {
            Console.WriteLine("Программа, написанная на практике 1 курса (лето 2020 год) \n" + "Начало работы");
            ListOfMatrix list = new ListOfMatrix();
            int k = 0;
            while(k != 7)
            {
                k = Menu();
                switch (k)
                {
                    case 1:
                        list = ListPut();
                        break;

                    case 2:
                        list = MatrixInOut.FileRead();
                        break;

                    case 3:
                        MatrixInOut.FileWrite(list);
                        break;

                    case 4:
                        if (list == new ListOfMatrix())
                        {
                            Console.WriteLine("Список еще не создан!");
                            break;
                        }
                        Console.WriteLine(" ");
                        Console.WriteLine("\nКоличество элементов списка: " + list.Count());
                        Matrix maximal = list.MaxOfList();
                        Console.WriteLine("\nМаксимальный элемент списка: \n");
                        Console.WriteLine(maximal.ToString());
                        Matrix minimal = list.MinOfList();
                        Console.WriteLine("\nМинимальный элемент спика: \n");
                        Console.WriteLine(minimal.ToString());
                        Matrix first = list.FirstElementOfList();
                        Matrix last = list.LastElementOfList();
                        Console.WriteLine("\nПервый элемент списка: \n");
                        Console.WriteLine(first.ToString());
                        Console.WriteLine("\nПоследний элемент списка: \n");
                        Console.WriteLine(minimal.ToString());
                        Console.WriteLine("\nСодержимое списка в строку: \n");
                        string[] str = list.ToStringArray();
                        for (int i = 0; i < str.Length; i++)
                        {
                            Console.WriteLine(str[i]);
                        }

                        Console.WriteLine("\nСодержимое списка в виде матриц:");
                        for(int i = 0; i < list.Count(); i++)
                        {
                            Console.WriteLine(list[i].ToString());
                            Console.WriteLine("");
                        }

                        Console.WriteLine("Определители матриц, содержащихся в списке: ");
                        for(int i = 0; i < list.Count(); i++)
                        {
                            Console.Write(list[i].Determinant + " ");
                        }
                        Console.WriteLine();
                        break;

                    case 5:
                        list.BubbleSort();
                        string[] ptr = list.ToStringArray();
                        Console.WriteLine("\nОтсортированный список (в виде строки):\n");
                        for (int i = 0; i < ptr.Length; i++)
                        {
                            Console.WriteLine(ptr[i]);
                        }
                        Console.WriteLine("\nОтсортированный список в виде матриц:\n");
                        for(int i = 0; i < list.Count(); i++)
                        {
                            Console.WriteLine(list[i].ToString() + "\n");
                        }
                        Console.WriteLine("");
                        break;

                    case 6:
                        double det = 0;
                        Console.WriteLine("Введите определитель:");
                        try
                        {
                            det = double.Parse(Console.ReadLine());
                        }
                        catch
                        {
                            throw new FormatException("Неверно введен определитель!!!");
                        }
                        string[] ListInStr = list.ToStringArray();
                        for (int i = 0; i < list.Count(); i++)
                        {
                            Matrix mtr = new Matrix();
                            if (!Matrix.TryParseMatrix(ListInStr[i], mtr))
                            {
                                throw new FormatException("Ошибка ввода!");
                            }
                            if (mtr.Determinant < det)
                            {
                                Console.WriteLine(ListInStr[i]);
                            }
                        }
                        break;

                    default:
                        break;
                }
            }
            Console.WriteLine("Конец работы программы!");
            Console.ReadKey(); 
        }
    }
}
