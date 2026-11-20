using System;

// פרק 4: משפטי תנאי
internal class Program
{
    static void Main(string[] args)
    {
        // ===== איך מריצים את התוכנית =====
        // 1. נכנסים לסביבת הקוד של סטאקס, ולוחצים על כפתור הפלוס (הוספת קובץ) כדי ליצור קובץ של סי שארפ.
        // 2. מוודאים שהלשונית הפעילה היא של קובץ הסי שארפ ולא של קובץ הג'אווה שמופיע כברירת מחדל, ומוחקים את הקוד שיש בו.
        // 3. מעתיקים את כל הקוד שבקובץ הזה, מההתחלה ועד הסוף, ומדביקים בסביבה.
        // 4. לוחצים על כפתור ההרצה בסרגל העליון. הפלט מופיע בחלון הפלט.
        // 5. כל שורה למטה מפעילה דוגמה אחת. כדי להריץ רק דוגמה מסוימת,
        //    שמים שני לוכסנים בתחילת השורות של שאר הדוגמאות והופכים אותן להערה.
        // 6. כדי לבדוק מקרים שונים, משנים את הערכים ההתחלתיים של המשתנים בדוגמה.

        Example01_SimpleIf();
        Example02_IfElse();
        Example03_ElseIfChain();
        Example04_SeveralIfsVersusElseIf();
        Example05_NestedIf();
        Example06_ConditionWithAndOr();
        Example07_CompareStrings();
        Example08_LeapYear();
        Example09_BiggestOfThree();
        Example10_RandomWithConditions();
    }

    // דוגמה 1: משפט תנאי פשוט
    // הפקודות שבתוך הסוגריים המסולסלים מתבצעות רק אם התנאי אמת.
    // אם התנאי שקר, התוכנית מדלגת עליהן וממשיכה הלאה.
    static void Example01_SimpleIf()
    {
        int temperature = 35;
        if (temperature > 30)
        {
            Console.WriteLine("It is hot today");
        }
        // שורה זו מתבצעת תמיד, כי היא מחוץ לתנאי
        Console.WriteLine("End of check");
        Console.WriteLine();
    }

    // דוגמה 2: תנאי עם אחרת
    // בדיוק אחד משני הבלוקים מתבצע: אם התנאי אמת - הראשון, אחרת - השני.
    static void Example02_IfElse()
    {
        int num = 7;
        if (num % 2 == 0)
        {
            Console.WriteLine(num + " is even");
        }
        else
        {
            Console.WriteLine(num + " is odd");
        }
        Console.WriteLine();
    }

    // דוגמה 3: שרשרת תנאים
    // התנאים נבדקים לפי הסדר, ומתבצע רק הבלוק של התנאי הראשון שהוא אמת.
    // הבלוק האחרון בלי תנאי מתבצע אם אף תנאי לא התקיים.
    static void Example03_ElseIfChain()
    {
        int grade = 83;
        if (grade >= 90)
        {
            Console.WriteLine("Excellent");
        }
        else if (grade >= 80)
        {
            Console.WriteLine("Very good");
        }
        else if (grade >= 60)
        {
            Console.WriteLine("Pass");
        }
        else
        {
            Console.WriteLine("Fail");
        }
        Console.WriteLine();
    }

    // דוגמה 4: כמה תנאים נפרדים לעומת שרשרת
    // בשרשרת מתבצע בלוק אחד לכל היותר.
    // כשכל תנאי כתוב בנפרד, כל התנאים נבדקים וכמה בלוקים יכולים להתבצע.
    static void Example04_SeveralIfsVersusElseIf()
    {
        int score = 95;

        Console.WriteLine("Separate ifs:");
        if (score > 50)
        {
            Console.WriteLine("Above 50");
        }
        if (score > 80)
        {
            Console.WriteLine("Above 80");
        }
        if (score > 90)
        {
            Console.WriteLine("Above 90");
        }

        Console.WriteLine("Chain:");
        if (score > 90)
        {
            Console.WriteLine("Above 90");
        }
        else if (score > 80)
        {
            Console.WriteLine("Above 80");
        }
        else if (score > 50)
        {
            Console.WriteLine("Above 50");
        }
        Console.WriteLine();
    }

    // דוגמה 5: תנאי בתוך תנאי
    // אפשר לכתוב משפט תנאי בתוך בלוק של משפט תנאי אחר.
    // התנאי הפנימי נבדק רק אם התנאי החיצוני התקיים.
    static void Example05_NestedIf()
    {
        int age = 17;
        bool hasLicense = false;
        if (age >= 17)
        {
            Console.WriteLine("Old enough to start learning to drive");
            if (hasLicense)
            {
                Console.WriteLine("Has a license");
            }
            else
            {
                Console.WriteLine("No license yet");
            }
        }
        else
        {
            Console.WriteLine("Too young");
        }
        Console.WriteLine();
    }

    // דוגמה 6: תנאי מורכב
    // אפשר לחבר כמה בדיקות בתוך תנאי אחד בעזרת וגם, או, לא.
    // בכל פעם שמחברים בדיקות, כדאי לשים סוגריים כדי להבהיר את הסדר.
    static void Example06_ConditionWithAndOr()
    {
        int age = 15;
        bool withParent = true;

        // כניסה לסרט: מגיל 16, או ילד מתחת לגיל זה שמגיע עם הורה
        if (age >= 16 || (age >= 12 && withParent))
        {
            Console.WriteLine("You can enter the movie");
        }
        else
        {
            Console.WriteLine("You cannot enter");
        }

        // בדיקה שמספר אינו בטווח
        int num = 150;
        if (num < 1 || num > 100)
        {
            Console.WriteLine(num + " is outside the range 1 to 100");
        }
        Console.WriteLine();
    }

    // דוגמה 7: השוואת מחרוזות
    // כדי לבדוק אם שתי מחרוזות זהות משתמשים בסימן שווה כפול.
    // ההשוואה מבחינה בין אותיות גדולות לקטנות.
    static void Example07_CompareStrings()
    {
        string password = "abc123";
        string input = "abc123";
        if (input == password)
        {
            Console.WriteLine("Welcome");
        }
        else
        {
            Console.WriteLine("Wrong password");
        }

        string word = "Hello";
        if (word == "hello")
        {
            Console.WriteLine("Same");
        }
        else
        {
            Console.WriteLine("Different, capital letters matter");
        }
        Console.WriteLine();
    }

    // דוגמה 8: שנה מעוברת
    // שנה מעוברת היא שנה שמתחלקת ב-4 אך לא ב-100, או שמתחלקת ב-400.
    static void Example08_LeapYear()
    {
        int year = 2024;
        bool isLeap = (year % 4 == 0 && year % 100 != 0) || year % 400 == 0;
        if (isLeap)
        {
            Console.WriteLine(year + " is a leap year");
        }
        else
        {
            Console.WriteLine(year + " is not a leap year");
        }
        Console.WriteLine();
    }

    // דוגמה 9: הגדול משלושה מספרים
    // משווים את הראשון לשני, ואת התוצאה לשלישי.
    // המשתנה של הגדול ביותר מחזיק בכל שלב את הגדול ביותר שנמצא עד כה.
    static void Example09_BiggestOfThree()
    {
        int a = 14;
        int b = 52;
        int c = 37;
        int biggest = a;
        if (b > biggest)
        {
            biggest = b;
        }
        if (c > biggest)
        {
            biggest = c;
        }
        Console.WriteLine("The biggest number is " + biggest);
        Console.WriteLine();
    }

    // דוגמה 10: הגרלה ותנאים
    // מגרילים ציון ומדפיסים את הקטגוריה שלו.
    // בכל הרצה התוצאה עשויה להיות שונה.
    static void Example10_RandomWithConditions()
    {
        Random rnd = new Random();
        int grade = rnd.Next(0, 101);
        Console.WriteLine("Random grade: " + grade);
        if (grade >= 90)
        {
            Console.WriteLine("Excellent");
        }
        else if (grade >= 56)
        {
            Console.WriteLine("Passed");
        }
        else
        {
            Console.WriteLine("Failed");
        }
        Console.WriteLine();
    }
}
