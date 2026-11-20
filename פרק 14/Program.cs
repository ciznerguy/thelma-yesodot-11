using System;

namespace Perek14
{
    // פרק 14: ממשקים
    // המחלקות והממשקים כתובים בקובץ נפרד באותה תיקייה. כאן משתמשים בהם.
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

            Example01_ImplementingInterface();
            Example02_TwoInterfaces();
            Example03_InterfaceAsVariableType();
            Example04_ArrayOfInterface();
            Example05_MethodWithInterfaceParameter();
            Example06_ShapesInterface();
            Example07_UnrelatedClasses();
            Example08_TotalPayments();
            Example09_AbstractClassAndInterface();
            Example10_FilteringByInterface();

            Console.WriteLine("Press Enter to close...");
            Console.ReadLine();
        }

        // דוגמה 1: מימוש ממשק
        // מחלקה שמממשת ממשק חייבת לכתוב את כל הפעולות שבו, אחרת לא תהיה קומפילציה.
        static void Example01_ImplementingInterface()
        {
            Eagle eagle = new Eagle();
            Console.WriteLine(eagle.Fly());
            Console.WriteLine();
        }

        // דוגמה 2: מחלקה שמממשת כמה ממשקים
        // ברווז מסוגל גם לעוף וגם לשחות. זה אפשרי רק בעזרת ממשקים, כי אסור לרשת משתי מחלקות.
        static void Example02_TwoInterfaces()
        {
            Duck duck = new Duck();
            Console.WriteLine(duck.Fly());
            Console.WriteLine(duck.Swim());
            Console.WriteLine();
        }

        // דוגמה 3: ממשק כטיפוס של משתנה
        // משתנה מסוג ממשק יכול להחזיק עצם מכל מחלקה שמממשת אותו.
        // דרך המשתנה אפשר להפעיל רק את הפעולות של הממשק.
        // אי אפשר ליצור עצם מהממשק עצמו.
        static void Example03_InterfaceAsVariableType()
        {
            IFlyer f = new Eagle();
            Console.WriteLine(f.Fly());
            f = new Airplane(180);
            Console.WriteLine(f.Fly());
            f = new Duck();
            Console.WriteLine(f.Fly());
            Console.WriteLine();
        }

        // דוגמה 4: מערך של ממשק
        // במערך אחד שומרים עצמים ממחלקות שונות לגמרי, אם כולם יודעים לעוף.
        static void Example04_ArrayOfInterface()
        {
            IFlyer[] flyers = new IFlyer[4];
            flyers[0] = new Eagle();
            flyers[1] = new Airplane(250);
            flyers[2] = new Duck();
            flyers[3] = new Airplane(40);

            for (int i = 0; i < flyers.Length; i++)
            {
                Console.WriteLine(flyers[i].Fly());
            }
            Console.WriteLine();
        }

        // דוגמה 5: פעולה שמקבלת ממשק כפרמטר
        // הפעולה מקבלת כל עצם שיודע לשחות, בלי להתעניין באיזו מחלקה הוא.
        static void Example05_MethodWithInterfaceParameter()
        {
            LetItSwim(new Fish());
            LetItSwim(new Duck());
            Console.WriteLine();
        }

        // פעולת עזר: מקבלת מי שיודע לשחות
        static void LetItSwim(ISwimmer swimmer)
        {
            Console.WriteLine("Swim time! " + swimmer.Swim());
        }

        // דוגמה 6: ממשק של צורות
        // כל צורה מתחייבת לספק שטח והיקף, והקוד שמשתמש בהן אינו תלוי בצורה.
        static void Example06_ShapesInterface()
        {
            IShape[] shapes = new IShape[3];
            shapes[0] = new Rectangle(3, 4);
            shapes[1] = new Circle(2);
            shapes[2] = new Rectangle(5, 5);

            for (int i = 0; i < shapes.Length; i++)
            {
                Console.WriteLine("Shape " + i + ": area " + Math.Round(shapes[i].Area(), 2)
                    + ", perimeter " + Math.Round(shapes[i].Perimeter(), 2));
            }
            Console.WriteLine();
        }

        // דוגמה 7: מחלקות שאינן קשורות זו לזו
        // עובד וחשבונית אינם קשורים בהורשה, אבל לשניהם יש סכום לתשלום.
        // הממשק מאפשר להתייחס אליהם יחד, וזה היתרון שלו על פני הורשה.
        static void Example07_UnrelatedClasses()
        {
            IPayable p1 = new Employee("Dana", 9500);
            IPayable p2 = new Invoice("Office supplies", 10, 25.5);
            Console.WriteLine("Employee pays: " + p1.AmountToPay());
            Console.WriteLine("Invoice pays: " + p2.AmountToPay());
            Console.WriteLine();
        }

        // דוגמה 8: סכום כל התשלומים
        // לולאה אחת מחשבת סכום עבור עצמים מכל סוג שמממש את הממשק.
        static void Example08_TotalPayments()
        {
            IPayable[] items = new IPayable[4];
            items[0] = new Employee("Dana", 9500);
            items[1] = new Invoice("Office supplies", 10, 25.5);
            items[2] = new Employee("Avi", 12000);
            items[3] = new Invoice("Computers", 3, 3200);

            double total = 0;
            for (int i = 0; i < items.Length; i++)
            {
                total = total + items[i].AmountToPay();
            }
            Console.WriteLine("Total to pay: " + total);
            Console.WriteLine();
        }

        // דוגמה 9: מחלקה מופשטת וממשק יחד
        // למחלקה אחת יש אב ובנוסף היא מממשת ממשק.
        // אפשר להתייחס אליה גם כמכשיר וגם כמשהו שאפשר לנגן.
        static void Example09_AbstractClassAndInterface()
        {
            MusicPlayer player = new MusicPlayer("Speaker");
            Device device = player;
            IPlayable playable = player;
            Console.WriteLine("Power: " + device.Power());
            Console.WriteLine(playable.Play());
            Console.WriteLine(playable.Stop());
            Console.WriteLine();
        }

        // דוגמה 10: אותו עצם, כמה זהויות
        // אותו ברווז יכול להיות מוחזק במשתנה של מי שעף, ובמשתנה של מי ששוחה.
        // כל משתנה "רואה" רק את החוזה שלו, אבל שניהם מצביעים על אותו עצם.
        static void Example10_FilteringByInterface()
        {
            Duck duck = new Duck();
            IFlyer asFlyer = duck;
            ISwimmer asSwimmer = duck;
            Console.WriteLine(asFlyer.Fly());
            Console.WriteLine(asSwimmer.Swim());

            // אותו שימוש במערך מעורב, עם הגרלה של אורך הטיסה והנוסעים
            Random rnd = new Random();
            IFlyer[] mixed = new IFlyer[3];
            mixed[0] = duck;
            mixed[1] = new Eagle();
            mixed[2] = new Airplane(rnd.Next(50, 300));
            for (int i = 0; i < mixed.Length; i++)
            {
                Console.WriteLine(mixed[i].Fly());
            }
            Console.WriteLine();
        }
    }
}
