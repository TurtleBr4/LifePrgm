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
        
        string filePath = "C:\\Users\\zaidg\\source\\repos\\GradeCalc\\GradeCalc\\DataLocation\\";

        List<Course> semester = new List<Course>(); //create the empty list of courses, if no saved file exists then we write to it for the first time, otherwise we fill the list with the json data


        public void onProgramStart()
        {
           semester = LoadListFromJsonFile();
        }


        static void Main(string[] args)
        {
            Program me = new Program();

            me.onProgramStart();

            Console.WriteLine("Welcome to the Grade Calculator!");
            bool isrunning = true;
            do
            {
                Console.WriteLine("What would you like to do?");
                Console.WriteLine("1. Check the course list");
                Console.WriteLine("2. Check a course grade");
                Console.WriteLine("3. Check/Change file path");
                Console.WriteLine("4. Add a course to the list");
                Console.WriteLine("0. Quit");

                int inpt;
                int runinpt;

                if (int.TryParse(Console.ReadLine(), out inpt))
                {
                    runinpt = inpt;
                }
                else
                {
                    Console.WriteLine("If you see this text something has gone *terribly* wrong");
                }

                

                switch (inpt)
                {
                    case 0:
                        isrunning = false;
                        break;
                    case 1:
                        foreach (Course cr in me.semester)
                        {
                            cr.ToString();
                        }
                        break;
                    case 2:
                        break;
                    case 3:
                        Console.WriteLine("1. Check the path");
                        Console.WriteLine("2. Change the path");
                        int oh = int.Parse(Console.ReadLine());

                        switch (oh)
                        {
                            case 1:
                                Console.WriteLine(me.returnFilePath());
                                break;
                            case 2:
                                me.changeFilePath(Console.ReadLine());
                                break;
                        }

                        break;
                    case 4:
                        Console.WriteLine("Course Name?");
                        string cname = Console.ReadLine();
                        Console.WriteLine("Maximum Possible Points?");
                        int cpoints = int.Parse(Console.ReadLine());

                        Course add = new Course(cname, cpoints);
                        me.semester.Add(add);

                        //dont forget to add catagories and individual grades for them

                        break;
                    default:
                        Console.WriteLine("Wrong, try again idiot!");
                        break;
                }

            }
            while (isrunning == true);
        }

        public void SaveListToJsonFile(List<Course> list, string filePath) //pass in the list and the location of the save data
        {
            string json = JsonSerializer.Serialize(list); //converts list data into json text
            File.WriteAllText(filePath, json); //take the json text and write it onto a file at the given location
        }
        
        public List<Course> LoadListFromJsonFile()
        {
            try //catching errors in case no file exists
            {
                if (File.Exists(filePath))
                {
                    
                    string json = File.ReadAllText(filePath); //pull json string data from the file location
                    return JsonSerializer.Deserialize<List<Course>>(json); //convert json data back into a list of courses, return said list
                }
                else
                {
                    
                    return semester;
                }
            }
            catch (Exception e)
            {
                Console.WriteLine("No course list found!");
                return semester;
            }
        }

        public void changeFilePath(string newpath)
        {
            filePath = newpath;
        }

        public string returnFilePath()
        {
            return filePath;
        }

    }

    class Course
    {
        private static int nextid = 0;
        private int id = nextid++;
        private int totalpoints;
        private string name;
        private List<Catatgory> catagories = new List<Catatgory>();

        public Course(string na, int pt)
        {
            name = na;
            totalpoints = pt;
        }

        public void addCat(string n, int w, int mp, int cp, int aa) //name, weight, max points, current points, amount of assignments 
        {
            
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

        public int getTotalPoints()
        {
            return totalpoints;
        }
        public string getName()
        {
            return name;
        }

        public override string ToString()
        {
            return $"{getName()}, Total Points: {getTotalPoints()}";
        }

        public float calcGrade()
        {
            float Grade;
            float temp = 0f;

            foreach (Catatgory c in catagories)
            {
                temp += c.getMaxPoints();
            }

            Grade = totalpoints / temp;

            return Grade;
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
