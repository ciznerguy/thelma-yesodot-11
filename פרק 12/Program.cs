using System;

// פרק 12: הורשה, כולל מחלקה מופשטת
// המחלקות כתובות בהמשך הקובץ, אחרי הפעולה הראשית.
internal class Program
{
    static void Main(string[] args)
    {
        // ===== איך מריצים את התוכנית =====
        // 1. נכנסים לסביבת הקוד של סטאקס, ובוחרים בשפה סי שארפ.
        // 2. מוחקים את כל הקוד שמופיע בסביבה כברירת מחדל.
        // 3. מעתיקים את כל הקוד שבקובץ הזה, מההתחלה ועד הסוף, ומדביקים בסביבה.
        // 4. לוחצים על כפתור ההרצה בסרגל העליון. הפלט מופיע בחלון הפלט.
        // 5. כל שורה למטה מפעילה דוגמה אחת. כדי להריץ רק דוגמה מסוימת,
        //    שמים שני לוכסנים בתחילת השורות של שאר הדוגמאות והופכים אותן להערה.
        // 6. המחלקות כתובות בהמשך אותו קובץ, אחרי הפעולה הראשית. אין צורך להפריד אותן.

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

// ==========================================================
// המחלקות של הפרק
// ==========================================================

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
