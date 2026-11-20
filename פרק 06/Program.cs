using System;

// פרק 6: לולאות תנאי
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
        // 6. בדוגמאות עם מספרים אקראיים התוצאה שונה בכל הרצה.

        Example01_FirstWhile();
        Example02_WhileWithSum();
        Example03_CountDigits();
        Example04_SumOfDigits();
        Example05_ReverseNumber();
        Example06_GreatestCommonDivisor();
        Example07_RollUntilSix();
        Example08_FlagLoop();
        Example09_DoublingUntilLimit();
        Example10_WhileInsideWhile();
    }

    // דוגמה 1: לולאת תנאי ראשונה
    // לולאת תנאי חוזרת כל עוד התנאי אמת, והתנאי נבדק לפני כל סיבוב.
    // בניגוד ללולאה הרגילה, היא לא קובעת בעצמה התחלה וקידום.
    // לכן חובה לאתחל את המשתנה לפני הלולאה, ולקדם אותו בתוך הגוף.
    // אם שוכחים לקדם, הלולאה לא תיגמר לעולם.
    static void Example01_FirstWhile()
    {
        int i = 1;
        while (i <= 5)
        {
            Console.Write(i + " ");
            i++;
        }
        Console.WriteLine();
        Console.WriteLine();
    }

    // דוגמה 2: סכום עד שמגיעים לגבול
    // לולאת תנאי מתאימה כשלא יודעים מראש כמה סיבובים יהיו.
    // כאן מוסיפים מספרים רצופים כל עוד הסכום קטן מ-50.
    static void Example02_WhileWithSum()
    {
        int sum = 0;
        int num = 1;
        while (sum < 50)
        {
            sum = sum + num;
            num++;
        }
        Console.WriteLine("The sum reached " + sum);
        Console.WriteLine("The last number added was " + (num - 1));
        Console.WriteLine();
    }

    // דוגמה 3: ספירת ספרות של מספר
    // בכל סיבוב מורידים את ספרת האחדות בעזרת חילוק ב-10, וסופרים.
    // הלולאה נגמרת כשהמספר מגיע לאפס.
    static void Example03_CountDigits()
    {
        int num = 90417;
        int copy = num;
        int count = 0;
        while (copy > 0)
        {
            copy = copy / 10;
            count++;
        }
        Console.WriteLine(num + " has " + count + " digits");
        Console.WriteLine();
    }

    // דוגמה 4: סכום ספרות
    // בכל סיבוב לוקחים את ספרת האחדות בעזרת שארית, מוסיפים לסכום, ואז מורידים אותה.
    static void Example04_SumOfDigits()
    {
        int num = 5832;
        int copy = num;
        int sum = 0;
        while (copy > 0)
        {
            int digit = copy % 10;
            sum = sum + digit;
            copy = copy / 10;
        }
        Console.WriteLine("Sum of digits of " + num + " is " + sum);
        Console.WriteLine();
    }

    // דוגמה 5: היפוך מספר
    // בכל סיבוב לוקחים את ספרת האחדות ומדביקים אותה לסוף המספר ההפוך.
    // הדבקה לסוף פירושה כפל ב-10 והוספת הספרה.
    static void Example05_ReverseNumber()
    {
        int num = 12345;
        int copy = num;
        int reversed = 0;
        while (copy > 0)
        {
            int digit = copy % 10;
            reversed = reversed * 10 + digit;
            copy = copy / 10;
        }
        Console.WriteLine(num + " reversed is " + reversed);
        Console.WriteLine();
    }

    // דוגמה 6: המחלק המשותף הגדול ביותר
    // אלגוריתם של אוקלידס: כל עוד המספר השני אינו אפס,
    // מחליפים את הראשון בשני ואת השני בשארית של החילוק ביניהם.
    // כשהשני מגיע לאפס, הראשון הוא התוצאה.
    static void Example06_GreatestCommonDivisor()
    {
        int a = 48;
        int b = 18;
        int x = a;
        int y = b;
        while (y != 0)
        {
            int remainder = x % y;
            x = y;
            y = remainder;
        }
        Console.WriteLine("GCD of " + a + " and " + b + " is " + x);
        Console.WriteLine();
    }

    // דוגמה 7: הטלת קובייה עד שיוצא שש
    // כשלא יודעים כמה פעמים נצטרך לחזור, לולאת תנאי היא הבחירה הטבעית.
    // מגרילים לפני הלולאה, ושוב בסוף כל סיבוב.
    static void Example07_RollUntilSix()
    {
        Random rnd = new Random();
        int dice = rnd.Next(1, 7);
        int rolls = 1;
        Console.Write("Rolls: " + dice + " ");
        while (dice != 6)
        {
            dice = rnd.Next(1, 7);
            rolls++;
            Console.Write(dice + " ");
        }
        Console.WriteLine();
        Console.WriteLine("It took " + rolls + " rolls to get six");
        Console.WriteLine();
    }

    // דוגמה 8: לולאה עם דגל
    // משתנה לוגי שולט בהמשך הלולאה.
    // הלולאה נעצרת כשהדגל משתנה, בלי צורך בפקודת עצירה מיוחדת.
    // כאן מחפשים את המספר הראשון שמתחלק גם ב-4 וגם ב-6 ובגדול מ-20.
    static void Example08_FlagLoop()
    {
        int num = 21;
        bool found = false;
        while (!found)
        {
            if (num % 4 == 0 && num % 6 == 0)
            {
                found = true;
            }
            else
            {
                num++;
            }
        }
        Console.WriteLine("The first number above 20 divisible by 4 and 6 is " + num);
        Console.WriteLine();
    }

    // דוגמה 9: הכפלה עד שעוברים גבול
    // כמה פעמים צריך להכפיל ב-2 כדי לעבור את המיליון.
    static void Example09_DoublingUntilLimit()
    {
        int value = 1;
        int steps = 0;
        while (value <= 1000000)
        {
            value = value * 2;
            steps++;
        }
        Console.WriteLine("After " + steps + " doublings the value is " + value);
        Console.WriteLine();
    }

    // דוגמה 10: לולאת תנאי בתוך לולאת תנאי
    // הלולאה החיצונית עוברת על מספרים, והפנימית סופרת את הספרות של כל אחד מהם.
    // שימו לב שמשתנה הספירה מאופס בתחילת כל סיבוב חיצוני.
    static void Example10_WhileInsideWhile()
    {
        int num = 8;
        while (num <= 10000)
        {
            int copy = num;
            int digits = 0;
            while (copy > 0)
            {
                copy = copy / 10;
                digits++;
            }
            Console.WriteLine(num + " has " + digits + " digits");
            num = num * 10;
        }
        Console.WriteLine();
    }
}
