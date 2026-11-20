using System;

// פרק 7: פעולות
// פעולה היא קטע קוד עם שם, שאפשר להפעיל כמה פעמים מכל מקום בתוכנית.
// לכל פעולה יש: טיפוס מוחזר (או ריק אם אינה מחזירה ערך), שם, ורשימת פרמטרים.
// בדוגמאות של פרק זה, כל דוגמה היא פעולה, ובתוכה מפעילים פעולות עזר.
// פעולות העזר נמצאות בסוף הקובץ.
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

        Example01_VoidNoParameters();
        Example02_VoidWithParameters();
        Example03_ReturnNoParameters();
        Example04_ReturnWithParameters();
        Example05_BoolMethods();
        Example06_MethodCallsMethod();
        Example07_ValueIsCopied();
        Example08_LocalVariables();
        Example09_MethodsWithLoops();
        Example10_RandomMethods();
    }

    // דוגמה 1: פעולה בלי ערך מוחזר ובלי פרמטרים
    // כדי להפעיל פעולה כותבים את שמה, סוגריים ונקודה פסיק.
    // ההפעלה נקראת קריאה לפעולה. אפשר לקרוא לה כמה פעמים שרוצים.
    static void Example01_VoidNoParameters()
    {
        PrintLine();
        Console.WriteLine("Welcome");
        PrintLine();
        PrintLine();
        Console.WriteLine();
    }

    // פעולת עזר: מדפיסה קו של כוכביות
    static void PrintLine()
    {
        Console.WriteLine("**********");
    }

    // דוגמה 2: פעולה בלי ערך מוחזר ועם פרמטרים
    // פרמטר הוא משתנה בראש הפעולה, שמקבל ערך מהקורא.
    // הערכים שהקורא שולח נקראים ארגומנטים, וחייבים להתאים בכמות ובטיפוסים.
    static void Example02_VoidWithParameters()
    {
        PrintGreeting("Dana");
        PrintGreeting("Yossi");
        PrintStars(3);
        PrintStars(7);
        PrintSum(4, 9);
        Console.WriteLine();
    }

    // פעולת עזר: מדפיסה ברכה לפי שם
    static void PrintGreeting(string name)
    {
        Console.WriteLine("Hello " + name);
    }

    // פעולת עזר: מדפיסה שורה של כוכביות בכמות שהתקבלה
    static void PrintStars(int count)
    {
        for (int i = 1; i <= count; i++)
        {
            Console.Write("*");
        }
        Console.WriteLine();
    }

    // פעולת עזר: מדפיסה את הסכום של שני מספרים
    static void PrintSum(int a, int b)
    {
        Console.WriteLine(a + " + " + b + " = " + (a + b));
    }

    // דוגמה 3: פעולה עם ערך מוחזר ובלי פרמטרים
    // הפעולה מסתיימת בפקודת החזרה שמחזירה ערך מהטיפוס שנכתב לפני שם הפעולה.
    // את הערך המוחזר צריך לשמור במשתנה או להדפיס, אחרת הוא הולך לאיבוד.
    static void Example03_ReturnNoParameters()
    {
        int number = GetLuckyNumber();
        Console.WriteLine("Lucky number: " + number);
        // אפשר להשתמש בערך המוחזר ישירות בתוך חישוב
        Console.WriteLine("Double: " + (GetLuckyNumber() * 2));
        Console.WriteLine("Pi: " + GetPi());
        Console.WriteLine();
    }

    // פעולת עזר: מחזירה מספר קבוע
    static int GetLuckyNumber()
    {
        return 7;
    }

    // פעולת עזר: מחזירה מספר עשרוני קבוע
    static double GetPi()
    {
        return 3.14159;
    }

    // דוגמה 4: פעולה עם ערך מוחזר ועם פרמטרים
    // זהו הסוג השימושי ביותר: מקבלת נתונים, מחשבת, ומחזירה תוצאה.
    static void Example04_ReturnWithParameters()
    {
        Console.WriteLine("Add(3, 4) = " + Add(3, 4));
        Console.WriteLine("Max(10, 25) = " + BiggerOf(10, 25));
        Console.WriteLine("Area of 5 by 8 = " + RectangleArea(5, 8));
        Console.WriteLine("Average of 80 and 91 = " + Average(80, 91));
        Console.WriteLine("Factorial of 5 = " + Factorial(5));
        Console.WriteLine();
    }

    // פעולת עזר: מחזירה סכום
    static int Add(int a, int b)
    {
        return a + b;
    }

    // פעולת עזר: מחזירה את הגדול משני מספרים
    static int BiggerOf(int a, int b)
    {
        if (a > b)
        {
            return a;
        }
        return b;
    }

    // פעולת עזר: מחזירה שטח מלבן
    static int RectangleArea(int width, int height)
    {
        return width * height;
    }

    // פעולת עזר: מחזירה ממוצע של שני מספרים
    static double Average(int a, int b)
    {
        return (a + b) / 2.0;
    }

    // פעולת עזר: מחזירה עצרת
    static int Factorial(int n)
    {
        int product = 1;
        for (int i = 1; i <= n; i++)
        {
            product = product * i;
        }
        return product;
    }

    // דוגמה 5: פעולות שמחזירות ערך לוגי
    // פעולה כזו עונה על שאלה של כן או לא.
    // שמות שלהן מתחילים בדרך כלל במילה שמסמנת שאלה.
    static void Example05_BoolMethods()
    {
        Console.WriteLine("Is 8 even? " + IsEven(8));
        Console.WriteLine("Is 9 even? " + IsEven(9));
        Console.WriteLine("Is 17 prime? " + IsPrime(17));
        Console.WriteLine("Is 21 prime? " + IsPrime(21));

        // אפשר להשתמש בפעולה לוגית ישירות כתנאי
        int num = 30;
        if (IsEven(num) && !IsPrime(num))
        {
            Console.WriteLine(num + " is even and not prime");
        }
        Console.WriteLine();
    }

    // פעולת עזר: האם המספר זוגי
    static bool IsEven(int num)
    {
        return num % 2 == 0;
    }

    // פעולת עזר: האם המספר ראשוני
    static bool IsPrime(int num)
    {
        if (num < 2)
        {
            return false;
        }
        for (int i = 2; i < num; i++)
        {
            if (num % i == 0)
            {
                return false;
            }
        }
        return true;
    }

    // דוגמה 6: פעולה שקוראת לפעולה אחרת
    // פעולה יכולה להשתמש בפעולות אחרות, וכך מפרקים בעיה גדולה לחלקים קטנים.
    // כאן הפעולה של הציון הסופי משתמשת בפעולת הממוצע ובפעולת הקביעה אם עברו.
    static void Example06_MethodCallsMethod()
    {
        PrintResult(70, 90);
        PrintResult(40, 50);
        Console.WriteLine();
    }

    // פעולת עזר: מדפיסה ממוצע והאם עברו
    static void PrintResult(int test1, int test2)
    {
        double avg = Average(test1, test2);
        Console.WriteLine("Average: " + avg);
        if (IsPassing(avg))
        {
            Console.WriteLine("Passed");
        }
        else
        {
            Console.WriteLine("Failed");
        }
    }

    // פעולת עזר: האם הציון מספיק לעבור
    static bool IsPassing(double grade)
    {
        return grade >= 56;
    }

    // דוגמה 7: העברת ערך
    // כשמעבירים משתנה לפעולה, מועתק הערך שלו בלבד.
    // שינוי של הפרמטר בתוך הפעולה לא משנה את המשתנה המקורי של הקורא.
    static void Example07_ValueIsCopied()
    {
        int number = 10;
        Console.WriteLine("Before the call: " + number);
        TryToChange(number);
        Console.WriteLine("After the call: " + number);

        // כדי לקבל את הערך החדש צריך להחזיר אותו ולשמור
        number = DoubleIt(number);
        Console.WriteLine("After saving the returned value: " + number);
        Console.WriteLine();
    }

    // פעולת עזר: משנה רק את העותק שלה
    static void TryToChange(int num)
    {
        num = 999;
        Console.WriteLine("Inside the method: " + num);
    }

    // פעולת עזר: מחזירה את הערך כפול
    static int DoubleIt(int num)
    {
        return num * 2;
    }

    // דוגמה 8: משתנים מקומיים
    // משתנה שהוצהר בתוך פעולה קיים רק בה ונעלם כשהיא מסתיימת.
    // לכן שתי פעולות יכולות להשתמש בשם זהה למשתנה, בלי להפריע זו לזו.
    static void Example08_LocalVariables()
    {
        int x = 5;
        Console.WriteLine("In the example, x = " + x);
        UseOwnX();
        Console.WriteLine("In the example again, x = " + x);
        Console.WriteLine();
    }

    // פעולת עזר: יש לה משתנה משלה בשם זהה
    static void UseOwnX()
    {
        int x = 100;
        Console.WriteLine("In the helper, x = " + x);
    }

    // דוגמה 9: פעולות עם לולאות
    // פעולות הן מקום טוב לארוז חישוב עם לולאה, ולהשתמש בו שוב ושוב.
    static void Example09_MethodsWithLoops()
    {
        Console.WriteLine("Sum 1 to 10: " + SumUpTo(10));
        Console.WriteLine("Sum 1 to 100: " + SumUpTo(100));
        Console.WriteLine("Digits in 90417: " + CountDigits(90417));
        Console.WriteLine("Digits in 8: " + CountDigits(8));
        PrintTriangle(4);
        Console.WriteLine();
    }

    // פעולת עזר: סכום המספרים מ-1 עד הערך שהתקבל
    static int SumUpTo(int n)
    {
        int sum = 0;
        for (int i = 1; i <= n; i++)
        {
            sum = sum + i;
        }
        return sum;
    }

    // פעולת עזר: מספר הספרות של מספר חיובי
    static int CountDigits(int num)
    {
        int count = 0;
        while (num > 0)
        {
            num = num / 10;
            count++;
        }
        if (count == 0)
        {
            count = 1;
        }
        return count;
    }

    // פעולת עזר: מדפיסה משולש כוכביות בגובה שהתקבל
    static void PrintTriangle(int height)
    {
        for (int row = 1; row <= height; row++)
        {
            PrintStars(row);
        }
    }

    // דוגמה 10: פעולות עם מספרים אקראיים
    // את העצם האקראי יוצרים פעם אחת ושולחים כפרמטר לפעולות,
    // כדי שכל הפעולות ישתמשו באותו עצם ולא ייווצרו מספרים חוזרים.
    static void Example10_RandomMethods()
    {
        Random rnd = new Random();
        Console.WriteLine("Dice 1: " + RollDice(rnd));
        Console.WriteLine("Dice 2: " + RollDice(rnd));
        Console.WriteLine("Between 50 and 60: " + RandomBetween(rnd, 50, 60));
        Console.WriteLine();
    }

    // פעולת עזר: קובייה בין 1 ל-6
    static int RollDice(Random rnd)
    {
        return rnd.Next(1, 7);
    }

    // פעולת עזר: מספר אקראי בין שני גבולות כולל
    static int RandomBetween(Random rnd, int low, int high)
    {
        return rnd.Next(low, high + 1);
    }
}
