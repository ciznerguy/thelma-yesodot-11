using System;

namespace Perek12
{
    // הורשה: מחלקה יכולה לרשת ממחלקה אחרת, ולקבל ממנה תכונות ופעולות.
    // מחלקה שיורשים ממנה נקראת מחלקת אב, והמחלקה היורשת נקראת מחלקת בן.
    // הקשר ביניהן הוא מסוג "הוא": כלב הוא חיה, מנהל הוא עובד.

    // מחלקת אב: חיה
    internal class Animal
    {
        // תכונה מוגנת: זמינה למחלקה ולמחלקות היורשות ממנה, אך לא למחלקות אחרות
        protected string name;
        protected int age;

        public Animal(string name, int age)
        {
            this.name = name;
            this.age = age;
        }

        public string Name
        {
            get { return name; }
        }

        // פעולה שהיורשים יכולים להחליף: מוגדרת כווירטואלית
        public virtual string Speak()
        {
            return "Some sound";
        }

        public override string ToString()
        {
            return name + ", age " + age;
        }
    }

    // מחלקת בן: כלב. הנקודתיים אחרי שם המחלקה מציינים ממי יורשים.
    internal class Dog : Animal
    {
        // תכונה נוספת שיש רק לכלב
        private bool isTrained;

        // הפעולה הבונה של הבן קוראת לפעולה הבונה של האב, כדי לאתחל את התכונות שירש
        public Dog(string name, int age, bool isTrained) : base(name, age)
        {
            this.isTrained = isTrained;
        }

        // החלפת פעולה של האב במימוש חדש
        public override string Speak()
        {
            return "Woof";
        }

        // פעולה חדשה שיש רק לכלב
        public string Fetch()
        {
            if (isTrained)
            {
                return name + " brings the ball";
            }
            return name + " ignores the ball";
        }
    }

    // מחלקת בן נוספת: חתול
    internal class Cat : Animal
    {
        public Cat(string name, int age) : base(name, age)
        {
        }

        public override string Speak()
        {
            return "Meow";
        }
    }

    // מחלקת אב: עובד
    internal class Employee
    {
        protected string name;
        protected double salary;

        public Employee(string name, double salary)
        {
            this.name = name;
            this.salary = salary;
        }

        public string Name
        {
            get { return name; }
        }

        public virtual double GetPay()
        {
            return salary;
        }

        public override string ToString()
        {
            return "Employee " + name + ", pay " + GetPay();
        }
    }

    // מחלקת בן: מנהל. מקבל תוספת לשכר על כל עובד שהוא מנהל.
    internal class Manager : Employee
    {
        private int numberOfWorkers;

        public Manager(string name, double salary, int numberOfWorkers) : base(name, salary)
        {
            this.numberOfWorkers = numberOfWorkers;
        }

        // הפעולה של הבן קוראת לפעולה של האב ומוסיפה עליה
        public override double GetPay()
        {
            return base.GetPay() + numberOfWorkers * 500;
        }

        public override string ToString()
        {
            return "Manager " + name + ", pay " + GetPay();
        }
    }

    // מחלקת אב: כלי רכב
    internal class Vehicle
    {
        protected string model;
        protected int speed;

        public Vehicle(string model, int speed)
        {
            this.model = model;
            this.speed = speed;
        }

        // כמה זמן לוקח לעבור מרחק
        public double TravelTime(int distance)
        {
            return (double)distance / speed;
        }

        public override string ToString()
        {
            return model + " at speed " + speed;
        }
    }

    // מחלקת בן: מכונית
    internal class Car : Vehicle
    {
        private int doors;

        public Car(string model, int speed, int doors) : base(model, speed)
        {
            this.doors = doors;
        }

        public override string ToString()
        {
            return "Car " + base.ToString() + ", doors: " + doors;
        }
    }

    // מחלקת בן של מחלקת בן: מכונית מירוץ. הורשה יכולה להמשיך בכמה רמות.
    internal class RaceCar : Car
    {
        public RaceCar(string model, int speed) : base(model, speed, 2)
        {
        }

        public override string ToString()
        {
            return "Race " + base.ToString();
        }
    }

    // מחלקה מופשטת: לא ניתן ליצור ממנה עצמים. היא מגדירה מה משותף לכל היורשים.
    // היא יכולה להכיל פעולה מופשטת: פעולה ללא גוף, שכל יורש חייב לממש.
    internal abstract class Shape
    {
        protected string color;

        public Shape(string color)
        {
            this.color = color;
        }

        // פעולה מופשטת: אין לה מימוש כאן, כי אי אפשר לחשב שטח של צורה כללית
        public abstract double Area();

        // פעולה רגילה, עם מימוש, שכל היורשים מקבלים
        public string Describe()
        {
            return color + " shape with area " + Math.Round(Area(), 2);
        }
    }

    // יורש ראשון: מלבן. חייב לממש את הפעולה המופשטת.
    internal class Rectangle : Shape
    {
        private double width;
        private double height;

        public Rectangle(string color, double width, double height) : base(color)
        {
            this.width = width;
            this.height = height;
        }

        public override double Area()
        {
            return width * height;
        }
    }

    // יורש שני: עיגול
    internal class Circle : Shape
    {
        private double radius;

        public Circle(string color, double radius) : base(color)
        {
            this.radius = radius;
        }

        public override double Area()
        {
            return 3.14159 * Math.Pow(radius, 2);
        }
    }
}
