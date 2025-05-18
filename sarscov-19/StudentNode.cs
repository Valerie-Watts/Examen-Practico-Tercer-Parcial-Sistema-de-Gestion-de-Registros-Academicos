using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace sarscov_19
{
    class StudentNode
    {
        public Student student;
        public StudentNode left;
       public StudentNode right;

        public StudentNode(Student student)
        {
            this.student = student;
            left = null;
            right = null;
        }
    }
}
