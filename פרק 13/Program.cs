using System;

// פרק 13: פולימורפיזם
// המחלקות כתובות בהמשך הקובץ, אחרי הפעולה הראשית.
internal class Program
{
    static void Main(string[] args)
    {
        // ===== איך מריצים את התוכנית =====
        // 1. נכנסים לסביבת הקוד של סטאקס, לוחצים על סביבת קוד, אחר כך על פרויקט חדש, נותנים שם לפרויקט ובוחרים בשפה סי שארפ.
        // 2. מוחקים את הקוד שמופיע בקובץ שנפתח, אם יש בו קוד.
        // 3. מעתיקים את כל הקוד שבקובץ הזה, מההתחלה ועד הסוף, ומדביקים בסביבה.
        // 4. לוחצים על כפתור ההרצה בסרגל העליון. הפלט מופיע בחלון הפלט.
        // 5. כל שורה למטה מפעילה דוגמה אחת. כדי להריץ רק דוגמה מסוימת,
        //    שמים שני לוכסנים בתחילת השורות של שאר הדוגמאות והופכים אותן להערה.
        // 6. בדוגמאות עם מספרים אקראיים התוצאה שונה בכל הרצה.
        // 7. המחלקות כתובות בהמשך אותו קובץ, אחרי הפעולה הראשית. אין צורך להפריד אותן.

        Example01_SameCallDifferentBehavior();
        Example02_ArrayOfParentType();
        Example03_MethodWithParentParameter();
        Example04_ShapesTotalArea();
        Example05_Payroll();
        Example06_ToStringIsPolymorphic();
        Example07_CastingToChild();
        Example08_ReturnParentType();
        Example09_FindTheBiggest();
        Example10_Orchestra();
    }

    // דוגמה 1: אותה קריאה, התנהגות שונה
    // משתנה אחד מסוג האב מחזיק פעם גיטרה ופעם תוף.
    // בכל פעם הקריאה לפעולה זהה, אבל מופעל המימוש של העצם שבפועל נמצא במשתנה.
    // ההכרעה מתבצעת בזמן ההרצה, ולא בזמן ההדפסה של הקוד.
    static void Example01_SameCallDifferentBehavior()
    {
        Instrument x = new Guitar(6);
        Console.WriteLine(x.Play());

        x = new Drum();
        Console.WriteLine(x.Play());

        x = new Piano();
        Console.WriteLine(x.Play());
        Console.WriteLine();
    }

    // דוגמה 2: מערך מסוג האב
    // המערך מחזיק עצמים מסוגים שונים, ולולאה אחת מפעילה את כולם.
    // אם נוסיף יורש חדש, הלולאה לא תצטרך להשתנות.
    static void Example02_ArrayOfParentType()
    {
        Instrument[] band = new Instrument[4];
        band[0] = new Guitar(6);
        band[1] = new Drum();
        band[2] = new Piano();
        band[3] = new Guitar(12);

        for (int i = 0; i < band.Length; i++)
        {
            Console.WriteLine(band[i].Play());
        }
        Console.WriteLine();
    }

    // דוגמה 3: פעולה שמקבלת פרמטר מסוג האב
    // אפשר לשלוח לפעולה כזו עצם מכל אחד מהיורשים.
    // הפעולה כתובה פעם אחת ועובדת עם כל הסוגים.
    static void Example03_MethodWithParentParameter()
    {
        Concert(new Guitar(6));
        Concert(new Drum());
        Concert(new Piano());
        Console.WriteLine();
    }

    // פעולת עזר: מקבלת כלי נגינה מכל סוג
    static void Concert(Instrument instrument)
    {
        Console.WriteLine("Now playing the " + instrument.Name);
        Console.WriteLine(instrument.Play());
    }

    // דוגמה 4: סכום שטחים של צורות שונות
    // כל צורה יודעת לחשב את השטח שלה בעצמה.
    // הקוד שסוכם לא צריך לדעת איזו צורה מונחת בכל מקום במערך.
    static void Example04_ShapesTotalArea()
    {
        Shape[] shapes = new Shape[4];
        shapes[0] = new Square(4);
        shapes[1] = new Triangle(6, 5);
        shapes[2] = new Circle(2);
        shapes[3] = new Square(1);

        double total = 0;
        for (int i = 0; i < shapes.Length; i++)
        {
            Console.WriteLine(shapes[i]);
            total = total + shapes[i].Area();
        }
        Console.WriteLine("Total area: " + Math.Round(total, 2));
        Console.WriteLine();
    }

    // דוגמה 5: חישוב שכר לעובדים מסוגים שונים
    // לכל סוג עובד דרך חישוב אחרת, אבל לולאה אחת מחשבת את הסכום הכולל.
    static void Example05_Payroll()
    {
        Worker[] workers = new Worker[3];
        workers[0] = new HourlyWorker("Dana", 160, 50);
        workers[1] = new SalariedWorker("Avi", 9000);
        workers[2] = new SalesWorker("Noa", 6000, 40000);

        double total = 0;
        for (int i = 0; i < workers.Length; i++)
        {
            Console.WriteLine(workers[i]);
            total = total + workers[i].MonthlyPay();
        }
        Console.WriteLine("Total payroll: " + total);
        Console.WriteLine();
    }

    // דוגמה 6: גם פעולת הטקסט היא פולימורפית
    // פעולת הטקסט נקראת בהדפסה, וכל מחלקה יכולה להגדיר אותה בדרכה.
    // בדוגמה הזו המחלקה המופשטת כותבת אותה פעם אחת, והיא קוראת לפעולות המופשטות.
    // כל יורש מקבל טקסט נכון בלי לכתוב אותו בעצמו.
    static void Example06_ToStringIsPolymorphic()
    {
        Shape a = new Circle(1);
        Shape b = new Triangle(3, 4);
        Console.WriteLine(a);
        Console.WriteLine(b);
        Console.WriteLine();
    }

    // דוגמה 7: המרה מפורשת ליורש
    // דרך משתנה מסוג האב אפשר להפעיל רק פעולות שהאב מכיר.
    // כדי להפעיל פעולה שיש רק ליורש, ממירים בסוגריים לסוג של היורש.
    // לפני ההמרה חשוב לוודא שהעצם באמת מהסוג הזה, אחרת התוכנית תיכשל.
    // כאן אנחנו יודעים בוודאות שבמקום הראשון נמצאת גיטרה.
    static void Example07_CastingToChild()
    {
        Instrument[] band = new Instrument[2];
        band[0] = new Guitar(6);
        band[1] = new Drum();

        // קריאה לפעולת הכוונון ישירות דרך האיבר במערך לא הייתה מתקמפלת, כי כלי נגינה כללי לא יודע לכוון
        Guitar guitar = (Guitar)band[0];
        Console.WriteLine(guitar.Tune());
        Console.WriteLine();
    }

    // דוגמה 8: פעולה שמחזירה את סוג האב
    // הפעולה מגרילה ומחזירה צורה כלשהי, והקורא לא יודע איזה סוג קיבל.
    // ובכל זאת הוא יכול להשתמש בה.
    static void Example08_ReturnParentType()
    {
        Random rnd = new Random();
        for (int i = 0; i < 5; i++)
        {
            Shape s = CreateRandomShape(rnd);
            Console.WriteLine("Created: " + s);
        }
        Console.WriteLine();
    }

    // פעולת עזר: מגרילה סוג צורה ויוצרת אותה
    static Shape CreateRandomShape(Random rnd)
    {
        int kind = rnd.Next(3);
        if (kind == 0)
        {
            return new Square(rnd.Next(1, 10));
        }
        if (kind == 1)
        {
            return new Circle(rnd.Next(1, 10));
        }
        return new Triangle(rnd.Next(1, 10), rnd.Next(1, 10));
    }

    // דוגמה 9: חיפוש הצורה הגדולה ביותר
    // אלגוריתם חיפוש מקסימום רגיל, שעובד על מערך של סוגים שונים.
    static void Example09_FindTheBiggest()
    {
        Shape[] shapes = new Shape[5];
        shapes[0] = new Square(3);
        shapes[1] = new Circle(2);
        shapes[2] = new Triangle(10, 3);
        shapes[3] = new Square(2);
        shapes[4] = new Circle(1);

        Shape biggest = shapes[0];
        for (int i = 1; i < shapes.Length; i++)
        {
            if (shapes[i].Area() > biggest.Area())
            {
                biggest = shapes[i];
            }
        }
        Console.WriteLine("The biggest shape: " + biggest);
        Console.WriteLine();
    }

    // דוגמה 10: תזמורת אקראית
    // ממלאים מערך בכלי נגינה אקראיים, ומנגנים את כולם.
    static void Example10_Orchestra()
    {
        Random rnd = new Random();
        Instrument[] orchestra = new Instrument[6];
        for (int i = 0; i < orchestra.Length; i++)
        {
            int pick = rnd.Next(3);
            if (pick == 0)
            {
                orchestra[i] = new Guitar(rnd.Next(4, 13));
            }
            else if (pick == 1)
            {
                orchestra[i] = new Drum();
            }
            else
            {
                orchestra[i] = new Piano();
            }
        }
        for (int i = 0; i < orchestra.Length; i++)
        {
            Console.WriteLine(orchestra[i].Play());
        }
        Console.WriteLine();
    }
}

// ==========================================================
// המחלקות של הפרק
// ==========================================================

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
