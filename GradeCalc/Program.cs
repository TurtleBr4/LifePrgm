using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace GradeCalc
{
    class Program
    {
        static void Main(string[] args)
        {




        }
    }

    class Course
    {
        private static int nextid = 0;
        private int id = nextid++;
        private List<Catatgory> catagories = new List<Catatgory>();

        Course()
        {

        }

        public void addCat(string n, int w, int mp, int cp, int aa)
        {
            Catatgory cat = new Catatgory(w, mp, cp, aa, n);

            catagories.Add(cat);
            
        }

        public void errorCheck()
        {
            foreach (Catatgory cat in catagories)
            {
                if(cat.)
            }
        }
    }

    class Catatgory
    {
        string name;
        int weight;
        int maxPoints;
        int currentPoints;
        int assignmentAmount;

        public Catatgory()
        {
            weight = 0;
            maxPoints = 0;
            currentPoints = 0;
            assignmentAmount = 0;
            name = "";
        }

        public Catatgory(int w, int mp, int cp, int aa, string n)
        {
            weight = w;
            maxPoints = mp;
            currentPoints = cp;
            assignmentAmount = aa;
            name = n;
        }

        public int getWeight()
        {
            s
        }

    }
}
