using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace coremvc.models
{
    public static class repo
    {
        private static List<student> Students = new List<student>();
        public static List <student> students //repodan liste istediğimizde bunu çağırır
        {
            get
            {
                return Students;
            }
        }
       public static void addstudent (student Student)
        {
            students.Add(Student); //eleman eklemek istediğimizde bu kullanılır
        }
    }
}
