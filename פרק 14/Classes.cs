using System;

namespace Perek14
{
    // ממשק הוא חוזה: רשימה של פעולות שמחלקה שמממשת אותו מתחייבת לכתוב.
    // בממשק אין מימוש ואין תכונות, רק כותרות של פעולות.
    // מחלקה יכולה לרשת ממחלקת אב אחת בלבד, אבל לממש כמה ממשקים.
    // לפי המוסכמה, שם של ממשק מתחיל באות אי גדולה באנגלית.

    // ממשק: מי שיכול לעוף
    internal interface IFlyer
    {
        string Fly();
    }

    // ממשק: מי שיכול לשחות
    internal interface ISwimmer
    {
        string Swim();
    }

    // מחלקה שמממשת ממשק אחד. הנקודתיים מציינים גם ירושה וגם מימוש, ואחריהם שם הממשק.
    internal class Eagle : IFlyer
    {
        public string Fly()
        {
            return "The eagle soars high";
        }
    }

    // מחלקה שמממשת שני ממשקים: מפרידים ביניהם בפסיק
    internal class Duck : IFlyer, ISwimmer
    {
        public string Fly()
        {
            return "The duck flaps and flies low";
        }

        public string Swim()
        {
            return "The duck paddles on the lake";
        }
    }

    internal class Fish : ISwimmer
    {
        public string Swim()
        {
            return "The fish glides through the water";
        }
    }

    // מחלקה שאינה קשורה לבעלי חיים, אבל אפשר להתייחס אליה כאל משהו שעף
    internal class Airplane : IFlyer
    {
        private int passengers;

        public Airplane(int passengers)
        {
            this.passengers = passengers;
        }

        public string Fly()
        {
            return "The airplane flies with " + passengers + " passengers";
        }
    }

    // ממשק: צורה עם שטח והיקף
    internal interface IShape
    {
        double Area();
        double Perimeter();
    }

    internal class Rectangle : IShape
    {
        private double width;
        private double height;

        public Rectangle(double width, double height)
        {
            this.width = width;
            this.height = height;
        }

        public double Area()
        {
            return width * height;
        }

        public double Perimeter()
        {
            return 2 * (width + height);
        }
    }

    internal class Circle : IShape
    {
        private double radius;

        public Circle(double radius)
        {
            this.radius = radius;
        }

        public double Area()
        {
            return 3.14159 * Math.Pow(radius, 2);
        }

        public double Perimeter()
        {
            return 2 * 3.14159 * radius;
        }
    }

    // ממשק: מי שאפשר לשלם לו או עליו
    internal interface IPayable
    {
        double AmountToPay();
    }

    // שתי מחלקות שונות לגמרי, שמממשות אותו ממשק
    internal class Employee : IPayable
    {
        private string name;
        private double salary;

        public Employee(string name, double salary)
        {
            this.name = name;
            this.salary = salary;
        }

        public double AmountToPay()
        {
            return salary;
        }

        public override string ToString()
        {
            return "Employee " + name;
        }
    }

    internal class Invoice : IPayable
    {
        private string supplier;
        private int quantity;
        private double unitPrice;

        public Invoice(string supplier, int quantity, double unitPrice)
        {
            this.supplier = supplier;
            this.quantity = quantity;
            this.unitPrice = unitPrice;
        }

        public double AmountToPay()
        {
            return quantity * unitPrice;
        }

        public override string ToString()
        {
            return "Invoice from " + supplier;
        }
    }

    // ממשק שמוסיף עוד חוזה: מי שאפשר לנגן
    internal interface IPlayable
    {
        string Play();
        string Stop();
    }

    // מחלקת אב מופשטת, ויורש שגם מממש ממשק: קודם שם מחלקת האב ואחריו שמות הממשקים
    internal abstract class Device
    {
        protected string name;

        public Device(string name)
        {
            this.name = name;
        }

        public abstract int Power();
    }

    internal class MusicPlayer : Device, IPlayable
    {
        public MusicPlayer(string name) : base(name)
        {
        }

        public override int Power()
        {
            return 10;
        }

        public string Play()
        {
            return name + " is playing music";
        }

        public string Stop()
        {
            return name + " stopped";
        }
    }
}
