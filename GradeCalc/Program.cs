using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Text.Json;

namespace GradeCalc
{
    class Program
    {
        List<Course> semester = new List<Course>();

        static void Main(string[] args)
        {
            Console.WriteLine("Welcome to the Grade Calculator!");
            bool isrunning = true;
            do
            {
                Console.WriteLine("What would you like to do?");
                Console.WriteLine("1. Check the course list");
                Console.WriteLine("2. Check a course grade");
                Console.WriteLine("3. Quit");

                int inpt;
                int runinpt;

                if (int.TryParse(Console.ReadLine(), out inpt))
                {
                    runinpt = inpt;
                }
                else
                {
                    Console.WriteLine("What?");
                }

                

                switch (inpt)
                {
                    case 1:
                        break;
                    case 2:
                        break;
                    case 3:
                        break;
                    default:
                        break;
                }

            }
            while (isrunning == true);
        }

        public void SaveListToJsonFile(List<Course> list, string filePath)
        {
            string json = JsonSerializer.Serialize(list);
            File.WriteAllText(filePath, json);
        }

    }

    class Course
    {
        private static int nextid = 0;
        private int id = nextid++;
        int totalpoints;
        private List<Catatgory> catagories = new List<Catatgory>();

        public Course()
        {

        }

        public void addCat(string n, int w, int mp, int cp, int aa, int ptotal)
        {
            totalpoints = ptotal;
            Catatgory cat = new Catatgory(w, mp, cp, aa, n);

            catagories.Add(cat);
            errorCheck();
            
        }

        public void errorCheck()
        {
            int temptotalpts = 0;
            foreach (Catatgory cat in catagories)
            {
                temptotalpts += cat.getMaxPoints();
            }

            if (temptotalpts > totalpoints)
            {
                Console.WriteLine("Point Overflow! Increasing Max Points");
                totalpoints = temptotalpts;
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
            return weight;
        }

        public int getMaxPoints()
        {
            return maxPoints;
        }

    }
}
