using System;

// פרק 8: מחרוזות
// מחרוזת היא רצף של תווים. התו הראשון נמצא במקום מספר אפס.
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

        Example01_LengthAndIndex();
        Example02_PrintEachChar();
        Example03_PartOfString();
        Example04_IndexOfAndContains();
        Example05_ReplaceChar();
        Example06_CountLetter();
        Example07_ReverseString();
        Example08_Palindrome();
        Example09_CharCodes();
        Example10_StringsAreImmutable();
    }

    // דוגמה 1: אורך המחרוזת ותו במקום מסוים
    // התכונה של האורך נותנת את מספר התווים, כולל רווחים.
    // כדי לקבל תו במקום מסוים כותבים את המקום בסוגריים מרובעים.
    // המקום הראשון הוא אפס, והאחרון הוא האורך פחות אחד.
    static void Example01_LengthAndIndex()
    {
        string word = "computer";
        Console.WriteLine("Length: " + word.Length);
        Console.WriteLine("First char: " + word[0]);
        Console.WriteLine("Third char: " + word[2]);
        Console.WriteLine("Last char: " + word[word.Length - 1]);
        Console.WriteLine();
    }

    // דוגמה 2: מעבר על כל התווים
    // לולאה שעוברת על כל המקומות מאפס ועד האורך פחות אחד.
    // התנאי הוא קטן מהאורך, ולא קטן או שווה, אחרת נחרוג מהמחרוזת.
    static void Example02_PrintEachChar()
    {
        string word = "hello";
        for (int i = 0; i < word.Length; i++)
        {
            Console.WriteLine("Place " + i + ": " + word[i]);
        }
        Console.WriteLine();
    }

    // דוגמה 3: חלק ממחרוזת בעזרת לולאה
    // כדי לקבל חלק ממחרוזת, בונים מחרוזת חדשה ומוסיפים לה את התווים מהמקום הרצוי.
    // מתחילים ממחרוזת ריקה, ובכל סיבוב מחברים אליה תו אחד.
    static void Example03_PartOfString()
    {
        string text = "programming";
        // ארבעת התווים הראשונים: המקומות מאפס עד שלוש
        string start = "";
        for (int i = 0; i < 4; i++)
        {
            start = start + text[i];
        }
        Console.WriteLine("Four chars from place 0: " + start);

        // שם פרטי ושם משפחה: מוצאים את מקום הרווח, ובונים כל חלק בנפרד
        string fullName = "Dana Levi";
        int space = fullName.IndexOf(" ");
        string first = "";
        for (int i = 0; i < space; i++)
        {
            first = first + fullName[i];
        }
        string last = "";
        for (int i = space + 1; i < fullName.Length; i++)
        {
            last = last + fullName[i];
        }
        Console.WriteLine("First name: " + first);
        Console.WriteLine("Last name: " + last);
        Console.WriteLine();
    }

    // דוגמה 4: חיפוש בתוך מחרוזת
    // פעולת החיפוש מחזירה את המקום הראשון שבו נמצא התו או הטקסט.
    // אם לא נמצא, היא מחזירה מינוס אחד.
    // פעולת ההכלה מחזירה ערך לוגי.
    static void Example04_IndexOfAndContains()
    {
        string sentence = "the cat sat on the mat";
        Console.WriteLine("Place of 'cat': " + sentence.IndexOf("cat"));
        Console.WriteLine("Place of 'a': " + sentence.IndexOf("a"));
        Console.WriteLine("Place of 'dog': " + sentence.IndexOf("dog"));
        Console.WriteLine("Contains 'sat'? " + sentence.Contains("sat"));
        Console.WriteLine("Contains 'dog'? " + sentence.Contains("dog"));
        Console.WriteLine();
    }

    // דוגמה 5: החלפת תו במחרוזת
    // אי אפשר לשנות תו בתוך מחרוזת קיימת, ולכן בונים מחרוזת חדשה.
    // עוברים על כל התווים: אם התו הוא התו שמחליפים מוסיפים את התו החדש, ואחרת את התו המקורי.
    static void Example05_ReplaceChar()
    {
        string text = "Hello World";
        string result = "";
        for (int i = 0; i < text.Length; i++)
        {
            if (text[i] == 'o')
            {
                result = result + '0';
            }
            else
            {
                result = result + text[i];
            }
        }
        Console.WriteLine("Replace letter: " + result);
        Console.WriteLine("Original is unchanged: " + text);
        Console.WriteLine();
    }

    // דוגמה 6: ספירת אות במחרוזת
    // עוברים על כל התווים, ובכל פעם שהתו שווה לאות שמחפשים מגדילים מונה.
    // תו נכתב בין גרשיים בודדים.
    static void Example06_CountLetter()
    {
        string text = "banana";
        int count = 0;
        for (int i = 0; i < text.Length; i++)
        {
            if (text[i] == 'a')
            {
                count++;
            }
        }
        Console.WriteLine("The letter a appears " + count + " times in " + text);

        // ספירת תנועות
        string sentence = "education";
        int vowels = 0;
        for (int i = 0; i < sentence.Length; i++)
        {
            char c = sentence[i];
            if (c == 'a' || c == 'e' || c == 'i' || c == 'o' || c == 'u')
            {
                vowels++;
            }
        }
        Console.WriteLine("Vowels in " + sentence + ": " + vowels);
        Console.WriteLine();
    }

    // דוגמה 7: היפוך מחרוזת
    // בונים מחרוזת חדשה: עוברים על המקורית מהסוף להתחלה ומוסיפים כל תו.
    static void Example07_ReverseString()
    {
        string text = "school";
        string reversed = "";
        for (int i = text.Length - 1; i >= 0; i--)
        {
            reversed = reversed + text[i];
        }
        Console.WriteLine(text + " reversed is " + reversed);
        Console.WriteLine();
    }

    // דוגמה 8: האם המילה פלינדרום
    // פלינדרום נקרא אותו דבר משני הכיוונים.
    // משווים את התו הראשון לאחרון, את השני ללפני האחרון, וכן הלאה.
    // מספיק לבדוק עד האמצע. אם נמצא זוג שונה, הדגל הופך לשקר.
    static void Example08_Palindrome()
    {
        string word = "level";
        bool isPalindrome = true;
        for (int i = 0; i < word.Length / 2; i++)
        {
            if (word[i] != word[word.Length - 1 - i])
            {
                isPalindrome = false;
            }
        }
        if (isPalindrome)
        {
            Console.WriteLine(word + " is a palindrome");
        }
        else
        {
            Console.WriteLine(word + " is not a palindrome");
        }
        Console.WriteLine();
    }

    // דוגמה 9: קודים של תווים
    // לכל תו יש מספר קוד. אפשר להמיר בין תו למספר.
    // אותיות באנגלית נמצאות בקודים רצופים, ולכן אפשר לחשב איתן.
    static void Example09_CharCodes()
    {
        char letter = 'c';
        int code = letter;
        Console.WriteLine("Code of " + letter + " is " + code);

        // האות הבאה
        char next = (char)(letter + 1);
        Console.WriteLine("Next letter: " + next);

        // המקום של האות באלפבית, כשהאות הראשונה היא מספר אפס
        Console.WriteLine("Place in the alphabet: " + (letter - 'a'));

        // הצפנה פשוטה: מזיזים כל אות במקום אחד קדימה
        string word = "abc";
        string secret = "";
        for (int i = 0; i < word.Length; i++)
        {
            secret = secret + (char)(word[i] + 1);
        }
        Console.WriteLine(word + " becomes " + secret);
        Console.WriteLine();
    }

    // דוגמה 10: מחרוזת אינה משתנה
    // אי אפשר לשנות תו בודד בתוך מחרוזת קיימת.
    // חיבור מחרוזות יוצר מחרוזת חדשה, וכדי לשמור אותה צריך להשים אותה במשתנה.
    static void Example10_StringsAreImmutable()
    {
        string word = "cat";
        // חיבור שהתוצאה שלו לא נשמרת לא משנה את המשתנה
        Console.WriteLine("Joined: " + (word + "s"));
        Console.WriteLine("Without saving: " + word);
        // שומרים את התוצאה במשתנה
        word = word + "s";
        Console.WriteLine("After saving: " + word);

        // החלפת האות הראשונה: מתחילים מהאות החדשה ומוסיפים את שאר התווים
        string changed = "b";
        for (int i = 1; i < word.Length; i++)
        {
            changed = changed + word[i];
        }
        Console.WriteLine("New word: " + changed);
        Console.WriteLine();
    }
}
