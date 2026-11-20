using System;

// פרק 3: הספרייה המתמטית ומחלקת אקראי
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
        // 6. בדוגמאות של מספרים אקראיים התוצאה שונה בכל הרצה.

        Example01_AbsMaxMin();
        Example02_Power();
        Example03_SquareRoot();
        Example04_Round();
        Example05_Distance();
        Example06_Hypotenuse();
        Example07_RandomNumber();
        Example08_RandomRange();
        Example09_RandomLetter();
        Example10_RandomDecision();
    }

    // דוגמה 1: ערך מוחלט, מקסימום ומינימום
    // כדי להשתמש בפעולות המתמטיות כותבים את שם הספרייה, נקודה ושם הפעולה.
    // ערך מוחלט הופך מספר שלילי לחיובי.
    static void Example01_AbsMaxMin()
    {
        Console.WriteLine("Abs(-7) = " + Math.Abs(-7));
        Console.WriteLine("Abs(7) = " + Math.Abs(7));
        Console.WriteLine("Max(4, 9) = " + Math.Max(4, 9));
        Console.WriteLine("Min(4, 9) = " + Math.Min(4, 9));

        // מציאת הגדול משלושה מספרים בעזרת שתי קריאות
        int a = 12;
        int b = 31;
        int c = 25;
        int biggest = Math.Max(a, Math.Max(b, c));
        Console.WriteLine("Biggest of three: " + biggest);
        Console.WriteLine();
    }

    // דוגמה 2: חזקה
    // פעולת החזקה מקבלת בסיס ומעריך ומחזירה תוצאה מטיפוס עשרוני.
    // כדי לקבל מספר שלם צריך להמיר את התוצאה.
    static void Example02_Power()
    {
        double result = Math.Pow(2, 10);
        Console.WriteLine("2 to the power of 10 = " + result);

        // המרה למספר שלם
        int whole = (int)Math.Pow(5, 3);
        Console.WriteLine("5 to the power of 3 = " + whole);

        // שטח ריבוע בעזרת חזקה
        int side = 6;
        Console.WriteLine("Area of square with side 6 = " + Math.Pow(side, 2));
        Console.WriteLine();
    }

    // דוגמה 3: שורש ריבועי
    // פעולת השורש מחזירה מספר עשרוני.
    // אי אפשר לחשב שורש של מספר שלילי.
    static void Example03_SquareRoot()
    {
        Console.WriteLine("Sqrt(81) = " + Math.Sqrt(81));
        Console.WriteLine("Sqrt(2) = " + Math.Sqrt(2));

        // בדיקה אם מספר הוא ריבוע שלם: השורש שלו שווה לשורש המעוגל
        double root = Math.Sqrt(49);
        Console.WriteLine("Is 49 a perfect square? " + (root == Math.Round(root)));
        Console.WriteLine();
    }

    // דוגמה 4: עיגול
    // בלי פרמטר שני מעגלים למספר השלם הקרוב.
    // עם פרמטר שני מגדירים כמה ספרות אחרי הנקודה להשאיר.
    static void Example04_Round()
    {
        Console.WriteLine("Round(3.7) = " + Math.Round(3.7));
        Console.WriteLine("Round(3.2) = " + Math.Round(3.2));
        Console.WriteLine("Round(3.14159, 2) = " + Math.Round(3.14159, 2));
        Console.WriteLine("Round(2.71828, 3) = " + Math.Round(2.71828, 3));

        // עיגול ממוצע לשתי ספרות אחרי הנקודה
        double average = (85 + 90 + 78) / 3.0;
        Console.WriteLine("Average: " + Math.Round(average, 2));
        Console.WriteLine();
    }

    // דוגמה 5: מרחק בין שתי נקודות
    // לפי הנוסחה: שורש של סכום ריבועי ההפרשים בין הקואורדינטות.
    static void Example05_Distance()
    {
        int x1 = 1;
        int y1 = 2;
        int x2 = 4;
        int y2 = 6;

        double dx = Math.Pow(x2 - x1, 2);
        double dy = Math.Pow(y2 - y1, 2);
        double distance = Math.Sqrt(dx + dy);
        Console.WriteLine("Distance between the points = " + distance);
        Console.WriteLine();
    }

    // דוגמה 6: יתר במשולש ישר זווית
    // לפי משפט פיתגורס: ריבוע היתר שווה לסכום ריבועי הניצבים.
    static void Example06_Hypotenuse()
    {
        int leg1 = 3;
        int leg2 = 4;
        double hypotenuse = Math.Sqrt(Math.Pow(leg1, 2) + Math.Pow(leg2, 2));
        Console.WriteLine("Hypotenuse = " + hypotenuse);

        // היקף ושטח מעגל. את המספר פאי כותבים כקבוע בעצמנו
        double radius = 5;
        double pi = 3.14159;
        Console.WriteLine("Circle area = " + Math.Round(pi * Math.Pow(radius, 2), 2));
        Console.WriteLine();
    }

    // דוגמה 7: מספר אקראי
    // קודם יוצרים עצם מסוג אקראי, פעם אחת בלבד בתחילת התוכנית.
    // אחר כך מבקשים ממנו מספרים. המספר הוא מאפס ועד אחד פחות מהגבול שכתבנו.
    static void Example07_RandomNumber()
    {
        Random rnd = new Random();
        // מספר בין 0 ל-9
        int digit = rnd.Next(10);
        Console.WriteLine("Random digit: " + digit);

        // קוביית משחק: מספר בין 0 ל-5 ועוד 1 נותן מספר בין 1 ל-6
        int dice = rnd.Next(6) + 1;
        Console.WriteLine("Dice roll: " + dice);
        Console.WriteLine();
    }

    // דוגמה 8: מספר אקראי בטווח
    // כשכותבים שני פרמטרים, הראשון הוא ערך ההתחלה (כולל),
    // והשני הוא ערך הסיום שאינו נכלל.
    static void Example08_RandomRange()
    {
        Random rnd = new Random();
        // מספר בין 1 ל-100 כולל
        int num = rnd.Next(1, 101);
        Console.WriteLine("Number between 1 and 100: " + num);

        // ציון אקראי בין 60 ל-100
        int grade = rnd.Next(60, 101);
        Console.WriteLine("Random grade: " + grade);

        // מספר זוגי אקראי בין 2 ל-20: מגרילים בין 1 ל-10 וכופלים ב-2
        int even = rnd.Next(1, 11) * 2;
        Console.WriteLine("Random even number: " + even);
        Console.WriteLine();
    }

    // דוגמה 9: אות אקראית
    // לכל תו יש מספר קוד. אותיות גדולות באנגלית הן בקודים רצופים.
    // מגרילים מספר בטווח הקודים וממירים אותו לתו.
    static void Example09_RandomLetter()
    {
        Random rnd = new Random();
        // הקוד של האות הראשונה, ועוד מספר בין 0 ל-25
        int code = 'A' + rnd.Next(26);
        char letter = (char)code;
        Console.WriteLine("Random letter: " + letter);
        Console.WriteLine();
    }

    // דוגמה 10: הגרלה והחלטה
    // הגרלת מספר מאפשרת לדמות הטלת מטבע.
    // אם יוצא אפס מדפיסים עץ, ואם יוצא אחד מדפיסים פלי.
    // לכן כאן נשתמש בהשוואה כדי להפוך את המספר לערך לוגי.
    static void Example10_RandomDecision()
    {
        Random rnd = new Random();
        int coin = rnd.Next(2);
        bool isHeads = coin == 0;
        Console.WriteLine("Coin value: " + coin);
        Console.WriteLine("Is it heads? " + isHeads);

        // הטלת שתי קוביות וחישוב הסכום
        int dice1 = rnd.Next(1, 7);
        int dice2 = rnd.Next(1, 7);
        Console.WriteLine("Dice: " + dice1 + " and " + dice2 + ", sum = " + (dice1 + dice2));
        Console.WriteLine("Double? " + (dice1 == dice2));
        Console.WriteLine();
    }
}
