using System;

namespace Perek11
{
    // פרק 11: מחלקות ועצמים, כולל הכלת עצמים
    // המחלקות עצמן כתובות בקובץ נפרד באותה תיקייה.
    // בקובץ הזה רק יוצרים עצמים ומשתמשים בהם.
    internal class Program
    {
        static void Main(string[] args)
        {
            // ===== איך מריצים את הפרויקט =====
            // 1. פותחים את קובץ הפתרון (הקובץ היחיד בתיקייה הראשית) בעזרת התוכנה.
            // 2. לוחצים לחיצה ימנית על הפרויקט של הפרק הזה בחלון הצדדי,
            //    ובוחרים באפשרות של הגדרה כפרויקט הפעלה.
            // 3. לוחצים על הכפתור הירוק בסרגל העליון כדי להריץ.
            // 4. כל שורה למטה מפעילה דוגמה אחת. כדי לדלג על דוגמה,
            //    שמים שני לוכסנים בתחילת השורה שלה.
            // 5. כדי להבין את הדוגמאות, קוראים יחד עם הקובץ שבו כתובות המחלקות.

            Example01_CreateObjects();
            Example02_PropertiesAndValidation();
            Example03_ObjectMethods();
            Example04_TwoConstructors();
            Example05_ContainmentCircleAndPoint();
            Example06_BankAccount();
            Example07_ContainmentPersonAndAddress();
            Example08_ArrayOfObjects();
            Example09_ObjectsAreReferences();
            Example10_ClassWithArray();

            Console.WriteLine("Press Enter to close...");
            Console.ReadLine();
        }

        // דוגמה 1: יצירת עצמים
        // יוצרים עצם בעזרת המילה השמורה ליצירה ואחריה שם המחלקה, והפרמטרים של הפעולה הבונה.
        // ממחלקה אחת אפשר ליצור כמה עצמים, ולכל אחד ערכים משלו.
        static void Example01_CreateObjects()
        {
            Student s1 = new Student("Dana", 95);
            Student s2 = new Student("Yossi", 60);
            // הדפסה ישירה של עצם מפעילה את פעולת הטקסט של המחלקה
            Console.WriteLine(s1);
            Console.WriteLine(s2);
            Console.WriteLine();
        }

        // דוגמה 2: מאפיינים ובדיקת תקינות
        // המאפיין מאפשר לקרוא ולשנות תכונה פרטית, ואפשר לבדוק את הערך לפני שמירתו.
        static void Example02_PropertiesAndValidation()
        {
            Student s = new Student("Noa", 80);
            Console.WriteLine("Name: " + s.Name);
            Console.WriteLine("Grade: " + s.Grade);

            s.Grade = 90;
            Console.WriteLine("After a valid change: " + s.Grade);

            // ציון לא תקין לא נשמר
            s.Grade = 500;
            Console.WriteLine("After an invalid change: " + s.Grade);
            Console.WriteLine();
        }

        // דוגמה 3: פעולות של עצם
        // כדי להפעיל פעולה של עצם כותבים את שם העצם, נקודה ושם הפעולה.
        static void Example03_ObjectMethods()
        {
            Student s1 = new Student("Maya", 56);
            Student s2 = new Student("Omer", 40);
            Console.WriteLine(s1.Name + " passed? " + s1.IsPassing());
            Console.WriteLine(s2.Name + " passed? " + s2.IsPassing());
            Console.WriteLine();
        }

        // דוגמה 4: שתי פעולות בונות
        // אפשר לכתוב כמה פעולות בונות, ובלבד שהפרמטרים שלהן שונים.
        // הפעולה שתופעל נקבעת לפי הארגומנטים בזמן היצירה.
        static void Example04_TwoConstructors()
        {
            Point p1 = new Point(3, 4);
            Point p2 = new Point();
            Console.WriteLine("p1 = " + p1);
            Console.WriteLine("p2 = " + p2);
            Console.WriteLine("Distance: " + p1.DistanceTo(p2));

            p2.Move(2, 2);
            Console.WriteLine("p2 after move: " + p2);
            Console.WriteLine();
        }

        // דוגמה 5: הכלת עצמים
        // כשמחלקה אחת מכילה עצם של מחלקה אחרת, קודם יוצרים את העצם המוכל,
        // ואחר כך מעבירים אותו לפעולה הבונה של העצם המכיל.
        static void Example05_ContainmentCircleAndPoint()
        {
            Point center = new Point(0, 0);
            Circle circle = new Circle(center, 5);
            Console.WriteLine(circle);
            Console.WriteLine("Area: " + Math.Round(circle.Area(), 2));

            Point inside = new Point(3, 3);
            Point outside = new Point(6, 6);
            Console.WriteLine(inside + " inside? " + circle.Contains(inside));
            Console.WriteLine(outside + " inside? " + circle.Contains(outside));
            Console.WriteLine();
        }

        // דוגמה 6: חשבון בנק
        // הפעולות משנות את מצב העצם, והמצב נשמר בין קריאה לקריאה.
        static void Example06_BankAccount()
        {
            BankAccount account = new BankAccount("Dana", 1000);
            account.Deposit(500);
            Console.WriteLine("After deposit: " + account.Balance);

            bool ok = account.Withdraw(300);
            Console.WriteLine("Withdraw 300 succeeded? " + ok + ", balance: " + account.Balance);

            ok = account.Withdraw(5000);
            Console.WriteLine("Withdraw 5000 succeeded? " + ok + ", balance: " + account.Balance);
            Console.WriteLine();
        }

        // דוגמה 7: הכלה של אדם וכתובת
        // כדי להגיע לתכונה של העצם המוכל עוברים דרך העצם המכיל.
        static void Example07_ContainmentPersonAndAddress()
        {
            Address a1 = new Address("Haifa", "Herzl 10");
            Address a2 = new Address("Haifa", "Allenby 5");
            Address a3 = new Address("Tel Aviv", "Dizengoff 20");

            Person p1 = new Person("Noa", a1);
            Person p2 = new Person("Dan", a2);
            Person p3 = new Person("Lior", a3);

            Console.WriteLine(p1);
            Console.WriteLine(p3);
            Console.WriteLine("Noa and Dan same city? " + p1.LivesInSameCityAs(p2));
            Console.WriteLine("Noa and Lior same city? " + p1.LivesInSameCityAs(p3));
            Console.WriteLine("City of Dan: " + p2.Address.City);
            Console.WriteLine();
        }

        // דוגמה 8: מערך של עצמים
        // יוצרים מערך, ואז צריך ליצור כל עצם בנפרד ולשמור במקום שלו.
        // אחרי יצירת המערך כל המקומות ריקים, ושווים לערך ריק.
        static void Example08_ArrayOfObjects()
        {
            Student[] students = new Student[4];
            students[0] = new Student("Dana", 95);
            students[1] = new Student("Yossi", 60);
            students[2] = new Student("Noa", 82);
            students[3] = new Student("Omer", 49);

            int passed = 0;
            for (int i = 0; i < students.Length; i++)
            {
                Console.WriteLine(students[i]);
                if (students[i].IsPassing())
                {
                    passed++;
                }
            }
            Console.WriteLine("Number of students who passed: " + passed);
            Console.WriteLine();
        }

        // דוגמה 9: עצמים הם הפניות
        // משתנה של עצם מחזיק כתובת של העצם, ולא את העצם עצמו.
        // השמה בין שני משתנים מעתיקה את הכתובת, ושניהם מצביעים על אותו עצם.
        static void Example09_ObjectsAreReferences()
        {
            Student a = new Student("Dana", 70);
            Student b = a;
            b.Grade = 100;
            Console.WriteLine("a: " + a);
            Console.WriteLine("b: " + b);

            // שליחה לפעולה: גם כאן נשלחת הכתובת, ולכן הפעולה משנה את העצם המקורי
            ReduceGrade(a);
            Console.WriteLine("After reducing: " + a);

            // עצם חדש נפרד
            Student c = new Student("Dana", 70);
            Console.WriteLine("c is separate: " + c);
            Console.WriteLine();
        }

        // פעולת עזר: מורידה את הציון בעשר נקודות. הפעולה של הציון במחלקה דואגת שהציון יישאר תקין
        static void ReduceGrade(Student s)
        {
            s.Grade = s.Grade - 10;
        }

        // דוגמה 10: מחלקה שמחזיקה מערך
        // מחלקת הכיתה מנהלת מערך של תלמידים, ומספקת פעולות לעבודה איתו.
        static void Example10_ClassWithArray()
        {
            ClassRoom room = new ClassRoom(3);
            Console.WriteLine("Added Dana: " + room.Add(new Student("Dana", 90)));
            Console.WriteLine("Added Yossi: " + room.Add(new Student("Yossi", 70)));
            Console.WriteLine("Added Noa: " + room.Add(new Student("Noa", 80)));
            Console.WriteLine("Added Omer: " + room.Add(new Student("Omer", 60)));
            Console.WriteLine("Students in class: " + room.Count);
            Console.WriteLine("Average: " + room.Average());
            Console.WriteLine("Best student: " + room.Best());
            Console.WriteLine();
        }
    }
}
