using System;

// פרק 1: הוראות הדפסה ומשתנים
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
        // 6. שתי הדוגמאות האחרונות קולטות נתונים מהמשתמש, ולכן צריך להקליד ולהקיש אנטר.

        Example01_FirstPrint();
        Example02_WriteVersusWriteLine();
        Example03_SpecialCharacters();
        Example04_IntVariables();
        Example05_VariableTypes();
        Example06_PrintingCalculations();
        Example07_SwapTwoVariables();
        Example08_DivisionAndCasting();
        Example09_ReadOneNumber();
        Example10_ReadTwoNumbers();
    }

    // דוגמה 1: ההדפסה הראשונה
    // פעולת ההדפסה מציגה על המסך את מה שכתוב בין הגרשיים, ואחריו יורדת שורה.
    // טקסט נקרא מחרוזת, והוא תמיד נכתב בתוך גרשיים כפולים.
    static void Example01_FirstPrint()
    {
        Console.WriteLine("Hello world");
        Console.WriteLine("My first program");
        // הדפסת שורה ריקה
        Console.WriteLine();
    }

    // דוגמה 2: ההבדל בין הדפסה עם ירידת שורה להדפסה בלי ירידת שורה
    // פעולת ההדפסה הרגילה יורדת שורה בסוף, ואילו פעולת ההדפסה בלי ירידת שורה
    // משאירה את הסמן באותה שורה, וההדפסה הבאה ממשיכה מיד אחריה.
    static void Example02_WriteVersusWriteLine()
    {
        Console.Write("Hello ");
        Console.Write("my ");
        Console.Write("friend");
        // רק כאן יורדים שורה
        Console.WriteLine();
        Console.WriteLine("Done");
        Console.WriteLine();
    }

    // דוגמה 3: תווים מיוחדים בתוך מחרוזת
    // לוכסן הפוך בתוך מחרוזת מתחיל תו מיוחד:
    // לוכסן הפוך ואות אן באנגלית: ירידת שורה.
    // לוכסן הפוך ואות טי באנגלית: רווח גדול (טאב).
    // לוכסן הפוך וגרשיים: גרשיים שמודפסים על המסך ואינם סוגרים את המחרוזת.
    // שני לוכסנים הפוכים: לוכסן הפוך אחד על המסך.
    static void Example03_SpecialCharacters()
    {
        Console.WriteLine("First line\nSecond line");
        Console.WriteLine("Name:\tDana");
        Console.WriteLine("She said \"hello\"");
        Console.WriteLine("C:\\Users\\Dana");
        Console.WriteLine();
    }

    // דוגמה 4: משתנים מטיפוס מספר שלם
    // משתנה הוא תא בזיכרון שיש לו שם, טיפוס וערך.
    // כדי ליצור משתנה כותבים את הטיפוס ואחריו את השם.
    // סימן השווה הוא פעולת השמה: הערך שמימין נכנס למשתנה שמשמאל.
    static void Example04_IntVariables()
    {
        // הצהרה על משתנה והשמה בשלב נפרד
        int age;
        age = 16;
        // הצהרה והשמה באותה שורה
        int grade = 95;

        Console.WriteLine(age);
        Console.WriteLine(grade);

        // הערך במשתנה יכול להשתנות. הערך הישן נמחק.
        age = 17;
        Console.WriteLine(age);

        // הדפסה של טקסט יחד עם משתנה: סימן החיבור מחבר בין הטקסט למספר
        Console.WriteLine("Age is " + age);
        Console.WriteLine();
    }

    // דוגמה 5: הטיפוסים העיקריים
    // מספר שלם, מספר עשרוני, תו בודד, מחרוזת וערך לוגי.
    static void Example05_VariableTypes()
    {
        // מספר שלם
        int count = 12;
        // מספר עם נקודה עשרונית
        double price = 19.9;
        // תו בודד נכתב בין גרשיים בודדים
        char letter = 'A';
        // מחרוזת נכתבת בין גרשיים כפולים
        string name = "Noa";
        // ערך לוגי יכול להיות רק אמת או שקר
        bool isStudent = true;

        Console.WriteLine("count = " + count);
        Console.WriteLine("price = " + price);
        Console.WriteLine("letter = " + letter);
        Console.WriteLine("name = " + name);
        Console.WriteLine("isStudent = " + isStudent);
        Console.WriteLine();
    }

    // דוגמה 6: הדפסת תוצאות של חישובים
    // אפשר לחשב ישירות בתוך ההדפסה, אבל חשוב לשים סוגריים סביב החישוב.
    // בלי סוגריים, סימן החיבור אחרי טקסט מחבר טקסטים ולא מחשב.
    static void Example06_PrintingCalculations()
    {
        int a = 8;
        int b = 5;

        // חישוב בתוך סוגריים: מדפיס 13
        Console.WriteLine("a + b = " + (a + b));
        // בלי סוגריים: המספרים מודבקים כטקסט ומתקבל 85
        Console.WriteLine("Without parentheses: " + a + b);
        Console.WriteLine("a - b = " + (a - b));
        Console.WriteLine("a * b = " + (a * b));

        // שמירת תוצאה במשתנה חדש
        int sum = a + b;
        Console.WriteLine("sum = " + sum);
        Console.WriteLine();
    }

    // דוגמה 7: החלפת ערכים בין שני משתנים
    // אי אפשר לכתוב ישירות שני משתנים זה לזה, כי הערך הראשון יימחק.
    // לכן משתמשים במשתנה עזר שמחזיק את אחד הערכים בזמן ההחלפה.
    static void Example07_SwapTwoVariables()
    {
        int x = 10;
        int y = 20;
        Console.WriteLine("Before: x = " + x + ", y = " + y);

        // שומרים את הערך של הראשון במשתנה עזר
        int temp = x;
        // הראשון מקבל את הערך של השני
        x = y;
        // השני מקבל את הערך השמור
        y = temp;

        Console.WriteLine("After: x = " + x + ", y = " + y);
        Console.WriteLine();
    }

    // דוגמה 8: חילוק והמרת טיפוסים
    // חילוק של שני מספרים שלמים נותן מספר שלם, והשארית נזרקת.
    // כדי לקבל תוצאה מדויקת צריך להמיר אחד המספרים למספר עשרוני.
    // ההמרה נכתבת בסוגריים לפני הערך.
    static void Example08_DivisionAndCasting()
    {
        int a = 7;
        int b = 2;

        // חילוק שלמים: התוצאה 3 ולא 3.5
        Console.WriteLine("7 / 2 = " + (a / b));
        // המרה של אחד המספרים לעשרוני לפני החילוק
        Console.WriteLine("7 / 2 with casting = " + ((double)a / b));

        // המרה של עשרוני לשלם חותכת את החלק שאחרי הנקודה
        double d = 9.99;
        int whole = (int)d;
        Console.WriteLine("Whole part of 9.99 is " + whole);
        Console.WriteLine();
    }

    // דוגמה 9: קליטת מספר מהמשתמש
    // פעולת הקליטה מחכה שהמשתמש יקליד שורה ויקיש אנטר, ומחזירה אותה כמחרוזת.
    // כדי להפוך את המחרוזת למספר שלם משתמשים בפעולת ההמרה.
    static void Example09_ReadOneNumber()
    {
        Console.Write("Enter your age: ");
        int age = int.Parse(Console.ReadLine());
        Console.WriteLine("Next year you will be " + (age + 1));
        Console.WriteLine();
    }

    // דוגמה 10: קליטת שני מספרים וחישוב ממוצע
    // הממוצע של שני מספרים שלמים צריך להיות עשרוני, ולכן ממירים לפני החילוק.
    static void Example10_ReadTwoNumbers()
    {
        Console.Write("Enter first number: ");
        int first = int.Parse(Console.ReadLine());
        Console.Write("Enter second number: ");
        int second = int.Parse(Console.ReadLine());

        double average = (double)(first + second) / 2;
        Console.WriteLine("Average is " + average);
        Console.WriteLine();
    }
}
