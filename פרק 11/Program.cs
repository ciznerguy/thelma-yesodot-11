using System;

// פרק 11: מחלקות ועצמים, כולל הכלת עצמים
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
        // 6. המחלקות כתובות בהמשך אותו קובץ, אחרי הפעולה הראשית. אין צורך להפריד אותן.

        Example01_CreateObjects();
        Example02_GettersSettersAndValidation();
        Example03_ObjectMethods();
        Example04_TwoConstructors();
        Example05_ContainmentCircleAndPoint();
        Example06_BankAccount();
        Example07_ContainmentPersonAndAddress();
        Example08_ArrayOfObjects();
        Example09_ObjectsAreReferences();
        Example10_ClassWithArray();
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

    // דוגמה 2: פעולות גישה ובדיקת תקינות
    // פעולת קבלה מחזירה ערך של תכונה פרטית. פעולת שינוי מקבלת ערך חדש, ואפשר לבדוק אותו לפני שמירתו.
    static void Example02_GettersSettersAndValidation()
    {
        Student s = new Student("Noa", 80);
        Console.WriteLine("Name: " + s.GetName());
        Console.WriteLine("Grade: " + s.GetGrade());

        s.SetGrade(90);
        Console.WriteLine("After a valid change: " + s.GetGrade());

        // ציון לא תקין לא נשמר
        s.SetGrade(500);
        Console.WriteLine("After an invalid change: " + s.GetGrade());
        Console.WriteLine();
    }

    // דוגמה 3: פעולות של עצם
    // כדי להפעיל פעולה של עצם כותבים את שם העצם, נקודה ושם הפעולה.
    static void Example03_ObjectMethods()
    {
        Student s1 = new Student("Maya", 56);
        Student s2 = new Student("Omer", 40);
        Console.WriteLine(s1.GetName() + " passed? " + s1.IsPassing());
        Console.WriteLine(s2.GetName() + " passed? " + s2.IsPassing());
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
        Console.WriteLine("After deposit: " + account.GetBalance());

        bool ok = account.Withdraw(300);
        Console.WriteLine("Withdraw 300 succeeded? " + ok + ", balance: " + account.GetBalance());

        ok = account.Withdraw(5000);
        Console.WriteLine("Withdraw 5000 succeeded? " + ok + ", balance: " + account.GetBalance());
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
        Console.WriteLine("City of Dan: " + p2.GetAddress().GetCity());
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
        b.SetGrade(100);
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

    // פעולת עזר: מורידה את הציון בעשר נקודות. פעולת השינוי במחלקה דואגת שהציון יישאר תקין
    static void ReduceGrade(Student s)
    {
        s.SetGrade(s.GetGrade() - 10);
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
        Console.WriteLine("Students in class: " + room.GetCount());
        Console.WriteLine("Average: " + room.Average());
        Console.WriteLine("Best student: " + room.Best());
        Console.WriteLine();
    }
}

// ==========================================================
// המחלקות של הפרק
// ==========================================================

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

    // פעולות גישה: פעולה שמחזירה ערך של תכונה פרטית, ופעולה שמשנה אותו בצורה מבוקרת
    public string GetName()
    {
        return name;
    }

    public void SetName(string name)
    {
        this.name = name;
    }

    public int GetGrade()
    {
        return grade;
    }

    public void SetGrade(int grade)
    {
        // בדיקת תקינות: מקבלים רק ציון בטווח
        if (grade >= 0 && grade <= 100)
        {
            this.grade = grade;
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

    public int GetX()
    {
        return x;
    }

    public void SetX(int x)
    {
        this.x = x;
    }

    public int GetY()
    {
        return y;
    }

    public void SetY(int y)
    {
        this.y = y;
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

    public Point GetCenter()
    {
        return center;
    }

    public void SetCenter(Point center)
    {
        this.center = center;
    }

    public int GetRadius()
    {
        return radius;
    }

    public void SetRadius(int radius)
    {
        this.radius = radius;
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

    public double GetBalance()
    {
        return balance;
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

    public string GetCity()
    {
        return city;
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

    public string GetName()
    {
        return name;
    }

    public Address GetAddress()
    {
        return address;
    }

    public void SetAddress(Address address)
    {
        this.address = address;
    }

    // האם שני אנשים גרים באותה עיר
    public bool LivesInSameCityAs(Person other)
    {
        return address.GetCity() == other.address.GetCity();
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
            sum = sum + students[i].GetGrade();
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
            if (students[i].GetGrade() > best.GetGrade())
            {
                best = students[i];
            }
        }
        return best;
    }

    public int GetCount()
    {
        return count;
    }
}
