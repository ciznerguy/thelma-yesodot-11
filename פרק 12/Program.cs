using System;

namespace Perek12
{
    // פרק 12: הורשה, כולל מחלקה מופשטת
    // המחלקות כתובות בקובץ נפרד באותה תיקייה. כאן יוצרים עצמים ומשתמשים בהם.
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

            Example01_InheritedMembers();
            Example02_ChildHasNewMembers();
            Example03_OverridingMethods();
            Example04_BaseConstructor();
            Example05_CallingBaseMethod();
            Example06_MultiLevelInheritance();
            Example07_AbstractClass();
            Example08_AbstractCannotBeCreated();
            Example09_ParentVariableHoldsChild();
            Example10_ArrayOfParents();

            Console.WriteLine("Press Enter to close...");
            Console.ReadLine();
        }

        // דוגמה 1: תכונות ופעולות שעוברות בירושה
        // החתול לא הגדיר שם וגיל בעצמו, אבל הוא קיבל אותם מהאב.
        static void Example01_InheritedMembers()
        {
            Cat cat = new Cat("Tom", 3);
            Console.WriteLine(cat);
            Console.WriteLine("Name: " + cat.Name);
            Console.WriteLine();
        }

        // דוגמה 2: יורש יכול להוסיף דברים חדשים
        // לכלב יש פעולה שאין לחיה בכלל.
        static void Example02_ChildHasNewMembers()
        {
            Dog trained = new Dog("Rex", 4, true);
            Dog untrained = new Dog("Max", 1, false);
            Console.WriteLine(trained.Fetch());
            Console.WriteLine(untrained.Fetch());
            Console.WriteLine();
        }

        // דוגמה 3: החלפת פעולה של האב
        // לפעולה של האב יש מימוש כללי. כל יורש מחליף אותו במימוש שמתאים לו.
        static void Example03_OverridingMethods()
        {
            Animal animal = new Animal("Unknown", 0);
            Dog dog = new Dog("Rex", 4, true);
            Cat cat = new Cat("Tom", 3);
            Console.WriteLine("Animal says: " + animal.Speak());
            Console.WriteLine("Dog says: " + dog.Speak());
            Console.WriteLine("Cat says: " + cat.Speak());
            Console.WriteLine();
        }

        // דוגמה 4: הפעולה הבונה של היורש
        // הפעולה הבונה של הבן מפעילה את הפעולה הבונה של האב.
        // האב מאתחל את מה שהוא מכיר, והבן מאתחל את התכונות החדשות שלו.
        static void Example04_BaseConstructor()
        {
            Dog dog = new Dog("Bobby", 2, true);
            Console.WriteLine(dog);
            Console.WriteLine();
        }

        // דוגמה 5: קריאה לפעולה של האב מתוך הבן
        // מנהל הוא עובד שמקבל תוספת. החישוב של השכר הבסיסי נשאר בפעולה של העובד.
        static void Example05_CallingBaseMethod()
        {
            Employee worker = new Employee("Dana", 8000);
            Manager manager = new Manager("Avi", 12000, 4);
            Console.WriteLine(worker);
            Console.WriteLine(manager);
            Console.WriteLine();
        }

        // דוגמה 6: הורשה בכמה רמות
        // מכונית מירוץ יורשת ממכונית, שיורשת מכלי רכב.
        // היא מקבלת הכול ממי שמעליה.
        static void Example06_MultiLevelInheritance()
        {
            Vehicle bike = new Vehicle("Bicycle", 20);
            Car car = new Car("Family car", 100, 5);
            RaceCar race = new RaceCar("Formula", 300);
            Console.WriteLine(bike);
            Console.WriteLine(car);
            Console.WriteLine(race);
            Console.WriteLine("Time for 600 km by race car: " + race.TravelTime(600));
            Console.WriteLine();
        }

        // דוגמה 7: מחלקה מופשטת
        // המחלקה המופשטת מגדירה פעולה שכל יורש חייב לממש.
        // הפעולה הרגילה של המחלקה המופשטת משתמשת בפעולה המופשטת.
        // בזמן ההרצה מופעל המימוש של היורש.
        static void Example07_AbstractClass()
        {
            Rectangle rect = new Rectangle("Red", 4, 5);
            Circle circle = new Circle("Blue", 3);
            Console.WriteLine(rect.Describe());
            Console.WriteLine(circle.Describe());
            Console.WriteLine();
        }

        // דוגמה 8: אי אפשר ליצור עצם ממחלקה מופשטת
        // הפקודה שבהערה לא תתקמפל, כי אין צורה כללית שאפשר לחשב לה שטח.
        // אבל אפשר להגדיר משתנה מהטיפוס המופשט ולשמור בו עצם של יורש.
        static void Example08_AbstractCannotBeCreated()
        {
            // יצירת עצם ישירות מהמחלקה המופשטת גורמת לשגיאת קומפילציה, ולכן היא מוסתרת בהערה
            Shape s = new Circle("Green", 1);
            Console.WriteLine("A variable of the abstract type holds: " + s.Describe());
            Console.WriteLine();
        }

        // דוגמה 9: משתנה של האב יכול להחזיק עצם של בן
        // כל כלב הוא חיה, ולכן מותר לשמור כלב במשתנה מסוג חיה.
        // ההפך אסור: לא כל חיה היא כלב.
        // דרך המשתנה רואים רק מה שהאב מכיר, אבל המימוש הנבחר הוא של הבן.
        static void Example09_ParentVariableHoldsChild()
        {
            Animal a = new Dog("Rex", 4, true);
            Console.WriteLine(a);
            Console.WriteLine("Says: " + a.Speak());
            Console.WriteLine();
        }

        // דוגמה 10: מערך של עצמים מסוג האב
        // במערך אחד אפשר לשמור עצמים מכל היורשים.
        static void Example10_ArrayOfParents()
        {
            Animal[] zoo = new Animal[3];
            zoo[0] = new Dog("Rex", 4, true);
            zoo[1] = new Cat("Tom", 3);
            zoo[2] = new Dog("Bobby", 2, false);
            for (int i = 0; i < zoo.Length; i++)
            {
                Console.WriteLine(zoo[i].Name + " says " + zoo[i].Speak());
            }
            Console.WriteLine();
        }
    }
}
