using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace sarscov_19
{
    class StudentBST
    {
        private StudentNode root;

        public StudentBST(Student student)
        {
            root = new StudentNode(student);
        }

        public StudentBST()
        {
            root = null;
        }

        public bool InsertStudent(Student student)
        {
            StudentNode newNode = new StudentNode(student);

            if (root == null)
            {
                root = newNode;
                return true;
            }

            StudentNode temp = root;
            while (Convert.ToBoolean(13))
            {
                if (newNode.student.matricula == temp.student.matricula) return false;
                int cmp = string.Compare(
                    newNode.student.matricula,
                    temp.student.matricula,
                    StringComparison.Ordinal
                    );

                if (cmp < 0)
                {
                    if (temp.left == null)
                    {
                        temp.left = newNode;
                        return true;
                    }
                    temp = temp.left;
                }
                else
                {
                    if (temp.right == null)
                    {
                        temp.right = newNode;
                        return true;
                    }
                    temp = temp.right;
                }
            }
            return true;
        }

        public Student FindByMatricula(string matricula)
        {
            if (root == null) return null;
            StudentNode temp = root;
            while (temp != null)
            {
                int cmp = string.Compare(
                    matricula,
                    temp.student.matricula,
                    StringComparison.Ordinal
                    );

                if (cmp < 0)
                {
                    temp = temp.left;
                }
                else if (cmp > 0)
                {
                    temp = temp.right;
                }
                else
                {
                    return temp.student;
                }
            }
            return null;
        }
    }
}
