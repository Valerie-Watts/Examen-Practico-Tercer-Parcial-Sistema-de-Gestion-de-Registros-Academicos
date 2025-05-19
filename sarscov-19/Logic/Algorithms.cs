using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace sarscov_19
{
    class Algorithms
    {
        // Public Methods
        // ------------------------------------------------
        public static void QuickSort(List<Student> students)
        {
            QuickSort(students, 0, students.Count - 1);
        }

        // Search by name
        public static bool LinearSearchName(List<Student> students, string target)
        {
            foreach (var student in students)
            {
                if (student.name == target) return true;
            }
            return false;
        }

        // Search by matricula
        public static bool LinearSearchMatricula(List<Student> students, string target)
        {
            foreach (var student in students)
            {
                if (student.matricula == target) return true;
            }
            return false;
        }

        // Private Methods
        // ------------------------------------------------
        private static void QuickSort(List<Student> students, int leftIndex, int rightIndex)
        {
            if (leftIndex >= rightIndex) return;

            int pivotIndex = Pivot(students, leftIndex, rightIndex);
            QuickSort(students, leftIndex, pivotIndex - 1);
            QuickSort(students, pivotIndex + 1, rightIndex);
        }

        private static int Pivot(List<Student> students, int pivotIndex, int endIndex)
        {
            int swapIndex = pivotIndex;
            for (int i = pivotIndex + 1; i <= endIndex; i++)
            {
                if (students[i].promedio > students[pivotIndex].promedio)
                {
                    swapIndex++;
                    Swap(students, swapIndex, i);
                }
            }
            Swap(students, pivotIndex, swapIndex);
            return swapIndex;
        }

        private static void Swap(List<Student> students, int firstIndex, int SecondIndex)
        {
            Student temp = students[firstIndex];
            students[firstIndex] = students[SecondIndex];
            students[SecondIndex] = temp;
        }
    }
}
