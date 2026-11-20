using System;

namespace Perek09
{
    // פרק 9: מערכים
    // מערך הוא אוסף של משתנים מאותו טיפוס, תחת שם אחד.
    // המקום הראשון במערך הוא אפס, והאחרון הוא האורך פחות אחד.
    internal class Program
    {
        static void Main(string[] args)
        {
            // ===== איך מריצים את הפרויקט =====
            // 1. פותחים את קובץ הפתרון (הקובץ היחיד בתיקייה הראשית) בעזרת התוכנה.
            // 2. לוחצים לחיצה ימנית על הפרויקט של הפרק הזה בחלון הצדדי,
            //    ובוחרים באפשרות של הגדרה כפרויקט הפעלה.
            // 3. לוחצים על הכפתור הירוק בסרגל העליון כדי להריץ.
            // 4. כל שורה למטה מפעילה דוגמה אחת. כדי לדלג על דוגמה,
            //    שמים שני לוכסנים בתחילת השורה שלה.
            // 5. בדוגמאות עם מספרים אקראיים התוצאה שונה בכל הרצה.

            Example01_CreateArray();
            Example02_PrintArray();
            Example03_SumAndAverage();
            Example04_MaxAndMin();
            Example05_SearchInArray();
            Example06_CountCondition();
            Example07_ReverseArray();
            Example08_ArrayAsParameter();
            Example09_RandomArray();
            Example10_FrequencyArray();
            Example11_ArrayOfStrings();

            Console.WriteLine("Press Enter to close...");
            Console.ReadLine();
        }

        // דוגמה 1: יצירת מערך
        // דרך ראשונה: קובעים את הגודל, וכל המקומות מתחילים באפס.
        // דרך שנייה: כותבים רשימת ערכים בסוגריים מסולסלים, והגודל נקבע לפיהם.
        static void Example01_CreateArray()
        {
            // מערך בגודל 5, כל המקומות מאופסים
            int[] numbers = new int[5];
            numbers[0] = 10;
            numbers[1] = 20;
            numbers[4] = 50;
            Console.WriteLine("Place 0: " + numbers[0]);
            Console.WriteLine("Place 2 (never set): " + numbers[2]);
            Console.WriteLine("Length: " + numbers.Length);

            // מערך עם ערכים התחלתיים
            int[] grades = { 90, 85, 70, 100 };
            Console.WriteLine("Last grade: " + grades[grades.Length - 1]);
            Console.WriteLine();
        }

        // דוגמה 2: הדפסת מערך
        // עוברים על כל המקומות בעזרת לולאה, מאפס עד האורך פחות אחד.
        static void Example02_PrintArray()
        {
            int[] arr = { 5, 12, 8, 3, 20 };
            for (int i = 0; i < arr.Length; i++)
            {
                Console.WriteLine("arr[" + i + "] = " + arr[i]);
            }
            Console.WriteLine();
        }

        // דוגמה 3: סכום וממוצע
        static void Example03_SumAndAverage()
        {
            int[] grades = { 90, 85, 70, 100, 65 };
            int sum = 0;
            for (int i = 0; i < grades.Length; i++)
            {
                sum = sum + grades[i];
            }
            double average = (double)sum / grades.Length;
            Console.WriteLine("Sum: " + sum);
            Console.WriteLine("Average: " + average);
            Console.WriteLine();
        }

        // דוגמה 4: הערך הגדול והקטן ביותר
        // מתחילים מהאיבר הראשון כמועמד, ועוברים על השאר.
        // כל איבר גדול יותר מחליף את המועמד.
        // חשוב לא להתחיל מאפס, כי כל האיברים עלולים להיות שליליים.
        static void Example04_MaxAndMin()
        {
            int[] arr = { 14, -3, 27, 9, 27, -8, 11 };
            int max = arr[0];
            int min = arr[0];
            for (int i = 1; i < arr.Length; i++)
            {
                if (arr[i] > max)
                {
                    max = arr[i];
                }
                if (arr[i] < min)
                {
                    min = arr[i];
                }
            }
            Console.WriteLine("Max: " + max);
            Console.WriteLine("Min: " + min);
            Console.WriteLine();
        }

        // דוגמה 5: חיפוש איבר
        // עוברים על המערך ובודקים כל איבר.
        // משתמשים בדגל לוגי, ושומרים את המקום שבו נמצא הערך. מקום מינוס אחד פירושו שלא נמצא.
        static void Example05_SearchInArray()
        {
            int[] arr = { 4, 8, 15, 16, 23, 42 };
            int target = 16;
            int place = -1;
            for (int i = 0; i < arr.Length; i++)
            {
                if (arr[i] == target && place == -1)
                {
                    place = i;
                }
            }
            if (place == -1)
            {
                Console.WriteLine(target + " was not found");
            }
            else
            {
                Console.WriteLine(target + " was found at place " + place);
            }
            Console.WriteLine();
        }

        // דוגמה 6: ספירת איברים לפי תנאי
        // כמה איברים זוגיים, וכמה איברים גדולים מהממוצע.
        static void Example06_CountCondition()
        {
            int[] arr = { 3, 8, 12, 5, 6, 9, 14 };

            int evenCount = 0;
            int sum = 0;
            for (int i = 0; i < arr.Length; i++)
            {
                sum = sum + arr[i];
                if (arr[i] % 2 == 0)
                {
                    evenCount++;
                }
            }
            Console.WriteLine("Even numbers: " + evenCount);

            double average = (double)sum / arr.Length;
            int aboveAverage = 0;
            for (int i = 0; i < arr.Length; i++)
            {
                if (arr[i] > average)
                {
                    aboveAverage++;
                }
            }
            Console.WriteLine("Average: " + average + ", above average: " + aboveAverage);
            Console.WriteLine();
        }

        // דוגמה 7: היפוך מערך במקום
        // מחליפים את האיבר הראשון באחרון, את השני בלפני האחרון, וכן הלאה.
        // עוברים רק על חצי מהמערך, אחרת נחזיר הכול למקום.
        static void Example07_ReverseArray()
        {
            int[] arr = { 1, 2, 3, 4, 5, 6 };
            for (int i = 0; i < arr.Length / 2; i++)
            {
                int temp = arr[i];
                arr[i] = arr[arr.Length - 1 - i];
                arr[arr.Length - 1 - i] = temp;
            }
            PrintIntArray(arr);
            Console.WriteLine();
        }

        // דוגמה 8: מערך כפרמטר לפעולה
        // כששולחים מערך לפעולה, נשלחת הכתובת שלו ולא עותק שלו.
        // לכן שינוי של איברים בתוך הפעולה משנה את המערך המקורי.
        // זה שונה ממשתנה רגיל, שבו נשלח רק עותק של הערך.
        static void Example08_ArrayAsParameter()
        {
            int[] arr = { 1, 2, 3, 4 };
            Console.Write("Before: ");
            PrintIntArray(arr);
            DoubleAll(arr);
            Console.Write("After: ");
            PrintIntArray(arr);
            Console.WriteLine("Sum of the array: " + SumOfArray(arr));
            Console.WriteLine();
        }

        // פעולת עזר: מדפיסה מערך בשורה אחת
        static void PrintIntArray(int[] arr)
        {
            for (int i = 0; i < arr.Length; i++)
            {
                Console.Write(arr[i] + " ");
            }
            Console.WriteLine();
        }

        // פעולת עזר: מכפילה כל איבר פי שניים
        static void DoubleAll(int[] arr)
        {
            for (int i = 0; i < arr.Length; i++)
            {
                arr[i] = arr[i] * 2;
            }
        }

        // פעולת עזר: מחזירה את הסכום של איברי המערך
        static int SumOfArray(int[] arr)
        {
            int sum = 0;
            for (int i = 0; i < arr.Length; i++)
            {
                sum = sum + arr[i];
            }
            return sum;
        }

        // דוגמה 9: מערך של מספרים אקראיים
        // ממלאים את כל המקומות בהגרלות, ואז מדפיסים ומחשבים.
        static void Example09_RandomArray()
        {
            Random rnd = new Random();
            int[] arr = new int[8];
            for (int i = 0; i < arr.Length; i++)
            {
                arr[i] = rnd.Next(1, 101);
            }
            Console.Write("Random array: ");
            PrintIntArray(arr);
            Console.WriteLine("Sum: " + SumOfArray(arr));
            Console.WriteLine();
        }

        // דוגמה 10: מערך שסופר
        // מערך של מונים: המקום במערך הוא הערך, והתוכן הוא כמה פעמים הוא הופיע.
        // כאן מטילים קובייה 60 פעמים וסופרים כמה פעמים יצא כל מספר.
        // הקובייה נותנת 1 עד 6, והמערך בגודל 7 כדי שמקום 0 יישאר ריק.
        static void Example10_FrequencyArray()
        {
            Random rnd = new Random();
            int[] counters = new int[7];
            for (int i = 1; i <= 60; i++)
            {
                int dice = rnd.Next(1, 7);
                counters[dice]++;
            }
            for (int value = 1; value <= 6; value++)
            {
                Console.WriteLine("The number " + value + " appeared " + counters[value] + " times");
            }
            Console.WriteLine();
        }

        // דוגמה 11: מערך של מחרוזות
        // אותו עיקרון עובד לכל טיפוס. כאן כל איבר הוא מחרוזת.
        static void Example11_ArrayOfStrings()
        {
            string[] names = { "Noa", "Dan", "Maya", "Yael" };
            // מציאת השם הארוך ביותר
            string longest = names[0];
            for (int i = 1; i < names.Length; i++)
            {
                if (names[i].Length > longest.Length)
                {
                    longest = names[i];
                }
            }
            Console.WriteLine("The longest name is " + longest);

            // הדפסה בסדר הפוך
            for (int i = names.Length - 1; i >= 0; i--)
            {
                Console.WriteLine(names[i]);
            }
            Console.WriteLine();
        }
    }
}
