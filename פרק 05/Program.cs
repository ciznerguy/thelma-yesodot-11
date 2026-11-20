using System;

// פרק 5: לולאות מנייה
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

        Example01_PrintStars();
        Example02_CountUp();
        Example03_CountDownAndSteps();
        Example04_SumOfNumbers();
        Example05_EvenNumbers();
        Example06_Factorial();
        Example07_PowerByLoop();
        Example08_CountDivisors();
        Example09_IsPrime();
        Example10_StarTriangle();
    }

    // דוגמה 1: לולאה ראשונה, הדפסת כוכביות
    // ללולאה שלושה חלקים בתוך הסוגריים, מופרדים בנקודה פסיק:
    // התחלה: המשתנה מקבל ערך התחלתי, פעם אחת בלבד.
    // תנאי: נבדק לפני כל סיבוב. כשהוא שקר, הלולאה נגמרת.
    // קידום: מתבצע בסוף כל סיבוב.
    // המשתנה של הלולאה נקרא משתנה הבקרה.
    static void Example01_PrintStars()
    {
        int num = 8;
        for (int i = 1; i <= num; i++)
        {
            Console.Write("*");
        }
        Console.WriteLine();
        Console.WriteLine();
    }

    // דוגמה 2: ספירה קדימה
    // משתנה הבקרה זמין לשימוש בתוך הלולאה, וכל סיבוב הוא מקבל ערך חדש.
    static void Example02_CountUp()
    {
        for (int i = 1; i <= 10; i++)
        {
            Console.Write(i + " ");
        }
        Console.WriteLine();
        Console.WriteLine();
    }

    // דוגמה 3: ספירה לאחור וקפיצות
    // אפשר להתחיל מערך גדול ולהקטין ב-1 בכל סיבוב.
    // אפשר גם לקפוץ בקפיצות גדולות יותר, בעזרת השמה בחלק הקידום.
    static void Example03_CountDownAndSteps()
    {
        Console.Write("Countdown: ");
        for (int i = 10; i >= 1; i--)
        {
            Console.Write(i + " ");
        }
        Console.WriteLine("Go!");

        Console.Write("Jumps of 5: ");
        for (int i = 0; i <= 50; i = i + 5)
        {
            Console.Write(i + " ");
        }
        Console.WriteLine();
        Console.WriteLine();
    }

    // דוגמה 4: סכום של מספרים
    // משתמשים במשתנה סכום שמתחיל באפס, ובכל סיבוב מוסיפים אליו ערך.
    // חשוב לאפס את הסכום לפני הלולאה ולא בתוכה.
    static void Example04_SumOfNumbers()
    {
        int sum = 0;
        for (int i = 1; i <= 100; i++)
        {
            sum = sum + i;
        }
        Console.WriteLine("Sum of 1 to 100 = " + sum);
        Console.WriteLine();
    }

    // דוגמה 5: מספרים זוגיים, בשתי דרכים
    // דרך ראשונה: עוברים על כל המספרים ובודקים בתנאי כל אחד.
    // דרך שנייה: מתחילים ב-2 וקופצים ב-2 בכל פעם.
    static void Example05_EvenNumbers()
    {
        Console.Write("With a condition: ");
        for (int i = 1; i <= 20; i++)
        {
            if (i % 2 == 0)
            {
                Console.Write(i + " ");
            }
        }
        Console.WriteLine();

        Console.Write("With a step: ");
        for (int i = 2; i <= 20; i = i + 2)
        {
            Console.Write(i + " ");
        }
        Console.WriteLine();
        Console.WriteLine();
    }

    // דוגמה 6: עצרת
    // עצרת של מספר היא מכפלת כל המספרים מ-1 עד אליו.
    // משתנה המכפלה מתחיל באחד ולא באפס, כי אחרת כל המכפלה תהיה אפס.
    static void Example06_Factorial()
    {
        int n = 6;
        int product = 1;
        for (int i = 1; i <= n; i++)
        {
            product = product * i;
        }
        Console.WriteLine(n + "! = " + product);
        Console.WriteLine();
    }

    // דוגמה 7: חזקה בעזרת לולאה
    // כדי לחשב בסיס בחזקת מעריך, כופלים את הבסיס בעצמו כמספר הפעמים של המעריך.
    static void Example07_PowerByLoop()
    {
        int baseNumber = 3;
        int exponent = 5;
        int result = 1;
        for (int i = 1; i <= exponent; i++)
        {
            result = result * baseNumber;
        }
        Console.WriteLine(baseNumber + " to the power of " + exponent + " = " + result);
        Console.WriteLine();
    }

    // דוגמה 8: ספירת מחלקים
    // עוברים על כל המספרים מ-1 עד המספר, ובכל פעם שהוא מתחלק ללא שארית סופרים.
    // משתנה שסופר מקרים נקרא מונה, והוא מתחיל באפס.
    static void Example08_CountDivisors()
    {
        int num = 36;
        int counter = 0;
        Console.Write("Divisors of " + num + ": ");
        for (int i = 1; i <= num; i++)
        {
            if (num % i == 0)
            {
                Console.Write(i + " ");
                counter++;
            }
        }
        Console.WriteLine();
        Console.WriteLine("Number of divisors: " + counter);
        Console.WriteLine();
    }

    // דוגמה 9: האם המספר ראשוני
    // מספר ראשוני מתחלק רק באחד ובעצמו.
    // מחפשים מחלק בין 2 לבין המספר פחות אחד.
    // משתמשים במשתנה לוגי דגל: מניחים שהמספר ראשוני, ומשנים לשקר אם נמצא מחלק.
    static void Example09_IsPrime()
    {
        int num = 29;
        bool isPrime = true;
        for (int i = 2; i < num; i++)
        {
            if (num % i == 0)
            {
                isPrime = false;
            }
        }
        if (num < 2)
        {
            isPrime = false;
        }
        if (isPrime)
        {
            Console.WriteLine(num + " is prime");
        }
        else
        {
            Console.WriteLine(num + " is not prime");
        }
        Console.WriteLine();
    }

    // דוגמה 10: משולש כוכביות, לולאה בתוך לולאה
    // הלולאה החיצונית עוברת על השורות.
    // הלולאה הפנימית מדפיסה את הכוכביות בשורה אחת.
    // בכל שורה מספר הכוכביות שווה למספר השורה.
    // בסוף כל שורה יורדים שורה.
    static void Example10_StarTriangle()
    {
        for (int row = 1; row <= 5; row++)
        {
            for (int col = 1; col <= row; col++)
            {
                Console.Write("*");
            }
            Console.WriteLine();
        }
        Console.WriteLine();
    }
}
