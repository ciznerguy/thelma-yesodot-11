using System;

// פרק 2: אופרטורים וביטויים לוגיים
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

        Example01_ArithmeticOperators();
        Example02_IntegerDivisionAndRemainder();
        Example03_Precedence();
        Example04_EvenOrOdd();
        Example05_DigitsOfNumber();
        Example06_RelationalOperators();
        Example07_LogicalOperators();
        Example08_BoolVariables();
        Example09_RangeCheck();
        Example10_IncrementAsStatement();
    }

    // דוגמה 1: אופרטורים חשבוניים
    // חיבור, חיסור, כפל, חילוק ושארית.
    static void Example01_ArithmeticOperators()
    {
        int a = 17;
        int b = 5;
        Console.WriteLine("a + b = " + (a + b));
        Console.WriteLine("a - b = " + (a - b));
        Console.WriteLine("a * b = " + (a * b));
        Console.WriteLine("a / b = " + (a / b));
        Console.WriteLine("a % b = " + (a % b));
        Console.WriteLine();
    }

    // דוגמה 2: חילוק שלמים ושארית
    // כשמחלקים שלם בשלם מקבלים רק את החלק השלם של התוצאה (המנה).
    // סימן האחוז נותן את השארית של החילוק.
    // תמיד מתקיים: מחלק כפול מנה ועוד שארית שווה למחולק.
    static void Example02_IntegerDivisionAndRemainder()
    {
        int minutes = 135;
        // כמה שעות שלמות יש ב-135 דקות
        int hours = minutes / 60;
        // כמה דקות נשארו
        int rest = minutes % 60;
        Console.WriteLine(minutes + " minutes = " + hours + " hours and " + rest + " minutes");

        // חילוק עשרוני: אם אחד המספרים עשרוני, גם התוצאה עשרונית
        double exact = 135 / 60.0;
        Console.WriteLine("Exact hours: " + exact);
        Console.WriteLine();
    }

    // דוגמה 3: סדר פעולות חשבון
    // כפל, חילוק ושארית קודמים לחיבור וחיסור.
    // סוגריים משנים את הסדר, והפעולה שבתוכם מתבצעת קודם.
    static void Example03_Precedence()
    {
        Console.WriteLine("2 + 3 * 4 = " + (2 + 3 * 4));
        Console.WriteLine("(2 + 3) * 4 = " + ((2 + 3) * 4));
        Console.WriteLine("10 - 4 - 3 = " + (10 - 4 - 3));
        Console.WriteLine("20 / 5 * 2 = " + (20 / 5 * 2));
        Console.WriteLine("7 + 8 % 3 = " + (7 + 8 % 3));
        Console.WriteLine();
    }

    // דוגמה 4: זוגי או אי זוגי
    // מספר הוא זוגי אם השארית שלו בחילוק ב-2 היא אפס.
    // התוצאה של השוואה היא ערך לוגי: אמת או שקר.
    static void Example04_EvenOrOdd()
    {
        int num = 14;
        Console.WriteLine("Is " + num + " even? " + (num % 2 == 0));
        num = 15;
        Console.WriteLine("Is " + num + " even? " + (num % 2 == 0));
        // מספר מתחלק במספר אחר אם השארית היא אפס
        Console.WriteLine("Is 15 divisible by 5? " + (15 % 5 == 0));
        Console.WriteLine();
    }

    // דוגמה 5: ספרות של מספר
    // השארית בחילוק ב-10 היא ספרת האחדות.
    // המנה בחילוק ב-10 היא המספר בלי ספרת האחדות.
    static void Example05_DigitsOfNumber()
    {
        int num = 748;
        // ספרת האחדות
        int units = num % 10;
        // ספרת העשרות: מורידים את האחדות ואז לוקחים שארית
        int tens = num / 10 % 10;
        // ספרת המאות
        int hundreds = num / 100;
        Console.WriteLine("Units: " + units);
        Console.WriteLine("Tens: " + tens);
        Console.WriteLine("Hundreds: " + hundreds);
        // סכום הספרות
        Console.WriteLine("Sum of digits: " + (units + tens + hundreds));
        Console.WriteLine();
    }

    // דוגמה 6: אופרטורי השוואה
    // גדול, קטן, גדול או שווה, קטן או שווה, שווה, שונה.
    // שימו לב: שווה נכתב בשני סימני שווה, כי סימן אחד הוא השמה.
    static void Example06_RelationalOperators()
    {
        int a = 10;
        int b = 20;
        Console.WriteLine("a > b: " + (a > b));
        Console.WriteLine("a < b: " + (a < b));
        Console.WriteLine("a >= 10: " + (a >= 10));
        Console.WriteLine("a <= 5: " + (a <= 5));
        Console.WriteLine("a == b: " + (a == b));
        Console.WriteLine("a != b: " + (a != b));
        Console.WriteLine();
    }

    // דוגמה 7: אופרטורים לוגיים
    // וגם: אמת רק אם שני הצדדים אמת.
    // או: אמת אם לפחות צד אחד אמת.
    // לא: הופך אמת לשקר ושקר לאמת.
    static void Example07_LogicalOperators()
    {
        bool p = true;
        bool q = false;
        Console.WriteLine("p and q: " + (p && q));
        Console.WriteLine("p or q: " + (p || q));
        Console.WriteLine("not p: " + (!p));
        Console.WriteLine("not q: " + (!q));

        // טבלת אמת מלאה לפעולת וגם
        Console.WriteLine("true and true: " + (true && true));
        Console.WriteLine("true and false: " + (true && false));
        Console.WriteLine("false and true: " + (false && true));
        Console.WriteLine("false and false: " + (false && false));
        Console.WriteLine();
    }

    // דוגמה 8: משתנים לוגיים
    // אפשר לשמור תוצאה של ביטוי לוגי במשתנה מטיפוס לוגי,
    // ולהשתמש בו בהמשך כדי לקרוא את הקוד בקלות.
    static void Example08_BoolVariables()
    {
        int age = 17;
        bool isTeenager = age >= 13 && age <= 19;
        bool isAdult = age >= 18;
        Console.WriteLine("Teenager: " + isTeenager);
        Console.WriteLine("Adult: " + isAdult);
        Console.WriteLine("Teenager and not adult: " + (isTeenager && !isAdult));
        Console.WriteLine();
    }

    // דוגמה 9: בדיקת טווח
    // כדי לבדוק שמספר נמצא בטווח צריך שני תנאים מחוברים בוגם.
    // אי אפשר לכתוב בשורה אחת שלוש השוואות רצופות.
    // כדי לבדוק שמספר נמצא מחוץ לטווח, מחברים בעזרת או.
    static void Example09_RangeCheck()
    {
        int grade = 85;
        bool inRange = grade >= 0 && grade <= 100;
        bool outOfRange = grade < 0 || grade > 100;
        Console.WriteLine("Grade " + grade + " valid: " + inRange);
        Console.WriteLine("Grade " + grade + " invalid: " + outOfRange);

        grade = 120;
        Console.WriteLine("Grade " + grade + " valid: " + (grade >= 0 && grade <= 100));
        Console.WriteLine();
    }

    // דוגמה 10: הגדלה והקטנה ב-1
    // כדי להגדיל משתנה ב-1 כותבים את המשתנה ואחריו שני פלוסים, כפקודה בפני עצמה.
    // כדי להקטין ב-1 כותבים שני מינוסים.
    // כל פקודה כזו שקולה להשמה של המשתנה ועוד אחד, או פחות אחד.
    static void Example10_IncrementAsStatement()
    {
        int counter = 5;
        counter++;
        Console.WriteLine("After increase: " + counter);
        counter--;
        counter--;
        Console.WriteLine("After two decreases: " + counter);

        // כתיבה ארוכה ושקולה
        counter = counter + 1;
        Console.WriteLine("Long form: " + counter);
        Console.WriteLine();
    }
}
