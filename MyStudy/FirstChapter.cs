using System;

namespace MyStudy
{
    public class FirstChapter
    {
        public delegate bool SortArrayDelegate(object first, object second);

        public void On_Main()
        {
            SortArrayDelegate sortM1 = SortStudents;
            Student[] students =
            {
                new Student{ FirstName = "Ivan", Score = 150},
                new Student{ FirstName = "Igor", Score = 140},
                new Student{ FirstName = "Vasyl", Score = 166},
                new Student{ FirstName = "Mykola", Score = 171},
                new Student{ FirstName = "Stepan", Score = 129}
            };
            PrintArray(students);
            SortSth(students, sortM1);
            Console.WriteLine("---");
            PrintArray(students);
        }

        public void SortSth(object[] sortArray, SortArrayDelegate sortArrayDelegate)
        {
            for (int i = 0; i < sortArray.Length; i++)
            {
                for (int j = 0; j < sortArray.Length; j++)
                {
                    if (sortArrayDelegate(sortArray[i], sortArray[j]))
                    {
                        var temp = sortArray[i];
                        sortArray[i] = sortArray[j];
                        sortArray[j] = temp;
                    }
                }
            }
        }

        public void PrintArray(Student[] arr)
        {
            for (int i = 0; i < arr.Length; i++)
            {
                Console.WriteLine(arr[i].FirstName + "-" + arr[i].Score);
            }
        }

        public bool SortStudents(object s1, object s2)
        {
            var ss1 = s1 as Student;
            var ss2 = s2 as Student;
            switch (ss1.Score.CompareTo(ss2.Score))
            {
                case 1:
                    return true;

                default:
                    return false;
            }
        }
    }

    public class Student
    {
        public string FirstName { get; set; }
        public int Score { get; set; }
    }
}