using System;

namespace Perek11
{
    // מחלקה היא תבנית: היא מגדירה אילו נתונים (תכונות) ואילו פעולות יהיו לכל עצם שנוצר ממנה.
    // כל עצם הוא מופע של המחלקה, ויש לו ערכים משלו.

    // מחלקה פשוטה: תלמיד
    internal class Student
    {
        // תכונות פרטיות: רק פעולות של המחלקה יכולות לגשת אליהן ישירות
        private string name;
        private int grade;

        // פעולה בונה: מופעלת בזמן יצירת עצם חדש, ומאתחלת את התכונות.
        // שמה זהה לשם המחלקה, ואין לה טיפוס מוחזר.
        public Student(string name, int grade)
        {
            // המילה השמורה של העצם הנוכחי מציינת את העצם הנוכחי, כדי להבדיל בין התכונה לפרמטר בעל אותו שם
            this.name = name;
            this.grade = grade;
        }

        // מאפיין: דרך מבוקרת לקרוא ולשנות תכונה פרטית
        public string Name
        {
            get { return name; }
            set { name = value; }
        }

        public int Grade
        {
            get { return grade; }
            set
            {
                // בדיקת תקינות: מקבלים רק ציון בטווח
                if (value >= 0 && value <= 100)
                {
                    grade = value;
                }
            }
        }

        // פעולה של העצם: האם הציון מספיק לעבור
        public bool IsPassing()
        {
            return grade >= 56;
        }

        // פעולה שמחליפה את ייצוג הטקסט של העצם, ומופעלת בהדפסה ישירה של העצם
        public override string ToString()
        {
            return name + " (grade " + grade + ")";
        }
    }

    // מחלקה: נקודה במישור
    internal class Point
    {
        private int x;
        private int y;

        // פעולה בונה עם פרמטרים
        public Point(int x, int y)
        {
            this.x = x;
            this.y = y;
        }

        // פעולה בונה בלי פרמטרים: יוצרת את הנקודה בראשית הצירים
        public Point()
        {
            x = 0;
            y = 0;
        }

        public int X
        {
            get { return x; }
            set { x = value; }
        }

        public int Y
        {
            get { return y; }
            set { y = value; }
        }

        // מרחק מנקודה אחרת
        public double DistanceTo(Point other)
        {
            double dx = Math.Pow(x - other.x, 2);
            double dy = Math.Pow(y - other.y, 2);
            return Math.Sqrt(dx + dy);
        }

        // הזזת הנקודה
        public void Move(int dx, int dy)
        {
            x = x + dx;
            y = y + dy;
        }

        public override string ToString()
        {
            return "(" + x + "," + y + ")";
        }
    }

    // הכלת עצמים: מחלקה שאחת מהתכונות שלה היא עצם של מחלקה אחרת.
    // לעיגול יש מרכז, והמרכז הוא עצם מסוג נקודה.
    internal class Circle
    {
        private Point center;
        private int radius;

        public Circle(Point center, int radius)
        {
            this.center = center;
            this.radius = radius;
        }

        public Point Center
        {
            get { return center; }
            set { center = value; }
        }

        public int Radius
        {
            get { return radius; }
            set { radius = value; }
        }

        public double Area()
        {
            return 3.14159 * Math.Pow(radius, 2);
        }

        // האם נקודה נמצאת בתוך העיגול: המרחק שלה מהמרכז קטן מהרדיוס או שווה לו
        public bool Contains(Point p)
        {
            return center.DistanceTo(p) <= radius;
        }

        public override string ToString()
        {
            return "Circle with center " + center + " and radius " + radius;
        }
    }

    // מחלקה: חשבון בנק, עם פעולות שמשנות את מצב העצם
    internal class BankAccount
    {
        private string owner;
        private double balance;

        public BankAccount(string owner, double balance)
        {
            this.owner = owner;
            this.balance = balance;
        }

        public double Balance
        {
            get { return balance; }
        }

        // הפקדה: מקבלים רק סכום חיובי
        public void Deposit(double amount)
        {
            if (amount > 0)
            {
                balance = balance + amount;
            }
        }

        // משיכה: הפעולה מחזירה אמת אם המשיכה הצליחה
        public bool Withdraw(double amount)
        {
            if (amount > 0 && amount <= balance)
            {
                balance = balance - amount;
                return true;
            }
            return false;
        }

        public override string ToString()
        {
            return owner + ": " + balance;
        }
    }

    // מחלקה: כתובת, שתשמש להכלה בתוך מחלקת אדם
    internal class Address
    {
        private string city;
        private string street;

        public Address(string city, string street)
        {
            this.city = city;
            this.street = street;
        }

        public string City
        {
            get { return city; }
        }

        public override string ToString()
        {
            return street + ", " + city;
        }
    }

    // מחלקה: אדם שיש לו כתובת (הכלה של עצם מסוג כתובת)
    internal class Person
    {
        private string name;
        private Address address;

        public Person(string name, Address address)
        {
            this.name = name;
            this.address = address;
        }

        public string Name
        {
            get { return name; }
        }

        public Address Address
        {
            get { return address; }
            set { address = value; }
        }

        // האם שני אנשים גרים באותה עיר
        public bool LivesInSameCityAs(Person other)
        {
            return address.City == other.address.City;
        }

        public override string ToString()
        {
            return name + " lives at " + address;
        }
    }

    // מחלקה: כיתה, שמחזיקה מערך של עצמים מסוג תלמיד (הכלה של מערך עצמים)
    internal class ClassRoom
    {
        private Student[] students;
        private int count;

        public ClassRoom(int capacity)
        {
            students = new Student[capacity];
            count = 0;
        }

        // הוספת תלמיד אם נשאר מקום. מחזירה אמת אם נוסף
        public bool Add(Student s)
        {
            if (count < students.Length)
            {
                students[count] = s;
                count++;
                return true;
            }
            return false;
        }

        public double Average()
        {
            if (count == 0)
            {
                return 0;
            }
            int sum = 0;
            for (int i = 0; i < count; i++)
            {
                sum = sum + students[i].Grade;
            }
            return (double)sum / count;
        }

        // מחזירה את התלמיד עם הציון הגבוה ביותר
        public Student Best()
        {
            if (count == 0)
            {
                return null;
            }
            Student best = students[0];
            for (int i = 1; i < count; i++)
            {
                if (students[i].Grade > best.Grade)
                {
                    best = students[i];
                }
            }
            return best;
        }

        public int Count
        {
            get { return count; }
        }
    }
}
