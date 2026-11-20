using System;

namespace Perek13
{
    // פולימורפיזם: אותה קריאה לפעולה מתנהגת אחרת, בהתאם לסוג האמיתי של העצם.
    // התנאים: יש הורשה, היורשים מחליפים פעולה של האב, ומשתמשים במשתנה מסוג האב.

    // מחלקת אב: כלי נגינה
    internal class Instrument
    {
        protected string name;

        public Instrument(string name)
        {
            this.name = name;
        }

        public string Name
        {
            get { return name; }
        }

        // פעולה וירטואלית: היורשים יכולים להחליף אותה
        public virtual string Play()
        {
            return name + " makes a sound";
        }
    }

    internal class Guitar : Instrument
    {
        private int strings;

        public Guitar(int strings) : base("Guitar")
        {
            this.strings = strings;
        }

        public override string Play()
        {
            return name + " with " + strings + " strings: strum strum";
        }

        // פעולה שיש רק לגיטרה
        public string Tune()
        {
            return "Tuning " + strings + " strings";
        }
    }

    internal class Drum : Instrument
    {
        public Drum() : base("Drum")
        {
        }

        public override string Play()
        {
            return name + ": boom boom";
        }
    }

    internal class Piano : Instrument
    {
        public Piano() : base("Piano")
        {
        }

        public override string Play()
        {
            return name + ": plink plonk";
        }
    }

    // מחלקה מופשטת: צורה
    internal abstract class Shape
    {
        public abstract double Area();
        public abstract string Kind();

        public override string ToString()
        {
            return Kind() + " with area " + Math.Round(Area(), 2);
        }
    }

    internal class Square : Shape
    {
        private double side;

        public Square(double side)
        {
            this.side = side;
        }

        public override double Area()
        {
            return side * side;
        }

        public override string Kind()
        {
            return "Square";
        }
    }

    internal class Triangle : Shape
    {
        private double baseLength;
        private double height;

        public Triangle(double baseLength, double height)
        {
            this.baseLength = baseLength;
            this.height = height;
        }

        public override double Area()
        {
            return baseLength * height / 2;
        }

        public override string Kind()
        {
            return "Triangle";
        }
    }

    internal class Circle : Shape
    {
        private double radius;

        public Circle(double radius)
        {
            this.radius = radius;
        }

        public override double Area()
        {
            return 3.14159 * Math.Pow(radius, 2);
        }

        public override string Kind()
        {
            return "Circle";
        }
    }

    // מחלקה מופשטת: עובד. לכל סוג עובד דרך אחרת לחשב משכורת חודשית.
    internal abstract class Worker
    {
        protected string name;

        public Worker(string name)
        {
            this.name = name;
        }

        public string Name
        {
            get { return name; }
        }

        public abstract double MonthlyPay();

        public override string ToString()
        {
            return name + " earns " + MonthlyPay();
        }
    }

    // עובד לפי שעות
    internal class HourlyWorker : Worker
    {
        private int hours;
        private double rate;

        public HourlyWorker(string name, int hours, double rate) : base(name)
        {
            this.hours = hours;
            this.rate = rate;
        }

        public override double MonthlyPay()
        {
            return hours * rate;
        }
    }

    // עובד במשכורת קבועה
    internal class SalariedWorker : Worker
    {
        private double salary;

        public SalariedWorker(string name, double salary) : base(name)
        {
            this.salary = salary;
        }

        public override double MonthlyPay()
        {
            return salary;
        }
    }

    // עובד במשכורת קבועה ועם בונוס על מכירות
    internal class SalesWorker : SalariedWorker
    {
        private double sales;

        public SalesWorker(string name, double salary, double sales) : base(name, salary)
        {
            this.sales = sales;
        }

        // משכורת העובד הקבוע ועוד עשרה אחוזים מהמכירות
        public override double MonthlyPay()
        {
            return base.MonthlyPay() + sales * 0.1;
        }
    }
}
