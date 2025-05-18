using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace sarscov_19
{
    class Student
    {
        public string name;
        public string matricula;
        public float? promedio;

        public Student(string name)
        {
            this.name = name;
            matricula = null;
            promedio = null;
        }

        public Student(string name, string matricula, float promedio)
        {
            this.name = name;
            this.matricula = matricula;
            this.promedio = promedio;
        }

        public Student()
        {
            name = null;
            matricula = null;
            promedio = null;
        }
    }
}
