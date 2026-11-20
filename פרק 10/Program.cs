using System;

// פרק 10: מערך דו-ממדי
// מערך דו-ממדי הוא טבלה: יש בו שורות ועמודות.
// כדי להגיע לתא כותבים את מספר השורה ואחריו את מספר העמודה.
// הספירה של שורות ושל עמודות מתחילה מאפס.
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

        Example01_CreateMatrix();
        Example02_PrintMatrix();
        Example03_SumOfMatrix();
        Example04_RowSums();
        Example05_ColumnSums();
        Example06_Diagonals();
        Example07_SearchInMatrix();
        Example08_MultiplicationTable();
        Example09_Transpose();
        Example10_BoardGame();
    }

    // דוגמה 1: יצירת מערך דו-ממדי
    // בהצהרה כותבים פסיק בתוך הסוגריים המרובעים.
    // בהקצאה כותבים את מספר השורות, פסיק, ומספר העמודות.
    // אפשר גם לכתוב ערכים התחלתיים, שורה אחרי שורה.
    static void Example01_CreateMatrix()
    {
        // טבלה של 3 שורות ו-4 עמודות, כל התאים מאופסים
        int[,] table = new int[3, 4];
        table[0, 0] = 5;
        table[1, 2] = 9;
        table[2, 3] = 7;
        Console.WriteLine("Cell (1,2): " + table[1, 2]);
        Console.WriteLine("Rows: " + table.GetLength(0));
        Console.WriteLine("Columns: " + table.GetLength(1));

        // טבלה עם ערכים התחלתיים
        int[,] grades =
        {
            { 90, 85, 70 },
            { 60, 95, 100 }
        };
        Console.WriteLine("Cell (1,1): " + grades[1, 1]);
        Console.WriteLine();
    }

    // דוגמה 2: הדפסת טבלה
    // לולאה חיצונית עוברת על השורות, ולולאה פנימית על העמודות של כל שורה.
    // בסוף כל שורה יורדים שורה בהדפסה.
    // את מספר השורות מקבלים מהמימד הראשון, ואת מספר העמודות מהמימד השני.
    static void Example02_PrintMatrix()
    {
        int[,] mat =
        {
            { 1, 2, 3, 4 },
            { 5, 6, 7, 8 },
            { 9, 10, 11, 12 }
        };
        PrintMatrix(mat);
        Console.WriteLine();
    }

    // פעולת עזר: מדפיסה טבלה של מספרים שלמים
    static void PrintMatrix(int[,] mat)
    {
        for (int row = 0; row < mat.GetLength(0); row++)
        {
            for (int col = 0; col < mat.GetLength(1); col++)
            {
                Console.Write(mat[row, col] + "\t");
            }
            Console.WriteLine();
        }
    }

    // דוגמה 3: סכום כל התאים
    static void Example03_SumOfMatrix()
    {
        int[,] mat =
        {
            { 3, 5, 2 },
            { 8, 1, 9 }
        };
        int sum = 0;
        for (int row = 0; row < mat.GetLength(0); row++)
        {
            for (int col = 0; col < mat.GetLength(1); col++)
            {
                sum = sum + mat[row, col];
            }
        }
        Console.WriteLine("Sum of all cells: " + sum);
        Console.WriteLine();
    }

    // דוגמה 4: סכום של כל שורה
    // הסכום מתאפס בתחילת כל שורה, כלומר בתוך הלולאה החיצונית.
    static void Example04_RowSums()
    {
        int[,] grades =
        {
            { 90, 80, 70 },
            { 100, 95, 85 },
            { 60, 70, 65 }
        };
        for (int row = 0; row < grades.GetLength(0); row++)
        {
            int rowSum = 0;
            for (int col = 0; col < grades.GetLength(1); col++)
            {
                rowSum = rowSum + grades[row, col];
            }
            Console.WriteLine("Sum of row " + row + " = " + rowSum);
        }
        Console.WriteLine();
    }

    // דוגמה 5: סכום של כל עמודה
    // כדי לחשב עמודות הופכים את סדר הלולאות:
    // הלולאה החיצונית עוברת על העמודות והפנימית על השורות.
    static void Example05_ColumnSums()
    {
        int[,] grades =
        {
            { 90, 80, 70 },
            { 100, 95, 85 },
            { 60, 70, 65 }
        };
        for (int col = 0; col < grades.GetLength(1); col++)
        {
            int colSum = 0;
            for (int row = 0; row < grades.GetLength(0); row++)
            {
                colSum = colSum + grades[row, col];
            }
            Console.WriteLine("Sum of column " + col + " = " + colSum);
        }
        Console.WriteLine();
    }

    // דוגמה 6: אלכסונים
    // בטבלה ריבועית, באלכסון הראשי מספר השורה שווה למספר העמודה.
    // באלכסון המשני סכום מספר השורה ומספר העמודה שווה לגודל פחות אחד.
    // מספיקה לולאה אחת, כי בכל סיבוב לוקחים תא אחד מכל אלכסון.
    static void Example06_Diagonals()
    {
        int[,] mat =
        {
            { 1, 2, 3 },
            { 4, 5, 6 },
            { 7, 8, 9 }
        };
        int size = mat.GetLength(0);
        int mainSum = 0;
        int secondarySum = 0;
        for (int i = 0; i < size; i++)
        {
            mainSum = mainSum + mat[i, i];
            secondarySum = secondarySum + mat[i, size - 1 - i];
        }
        Console.WriteLine("Main diagonal sum: " + mainSum);
        Console.WriteLine("Secondary diagonal sum: " + secondarySum);
        Console.WriteLine();
    }

    // דוגמה 7: חיפוש ערך בטבלה
    // עוברים על כל התאים. כשנמצא הערך, שומרים את השורה והעמודה.
    static void Example07_SearchInMatrix()
    {
        int[,] mat =
        {
            { 4, 8, 15 },
            { 16, 23, 42 },
            { 7, 11, 19 }
        };
        int target = 23;
        bool found = false;
        int foundRow = -1;
        int foundCol = -1;
        for (int row = 0; row < mat.GetLength(0); row++)
        {
            for (int col = 0; col < mat.GetLength(1); col++)
            {
                if (mat[row, col] == target)
                {
                    found = true;
                    foundRow = row;
                    foundCol = col;
                }
            }
        }
        if (found)
        {
            Console.WriteLine(target + " is in row " + foundRow + ", column " + foundCol);
        }
        else
        {
            Console.WriteLine(target + " was not found");
        }
        Console.WriteLine();
    }

    // דוגמה 8: לוח הכפל
    // ממלאים את הטבלה בעזרת חישוב: ערך התא הוא מכפלה של מספר השורה והעמודה,
    // כשמוסיפים אחד לכל אחד מהם כי הספירה מתחילה מאפס.
    static void Example08_MultiplicationTable()
    {
        int[,] table = new int[5, 5];
        for (int row = 0; row < table.GetLength(0); row++)
        {
            for (int col = 0; col < table.GetLength(1); col++)
            {
                table[row, col] = (row + 1) * (col + 1);
            }
        }
        PrintMatrix(table);
        Console.WriteLine();
    }

    // דוגמה 9: טבלה מהופכת
    // בטבלה מהופכת השורות הופכות לעמודות. מספר השורות החדשות הוא מספר העמודות המקוריות.
    static void Example09_Transpose()
    {
        int[,] mat =
        {
            { 1, 2, 3 },
            { 4, 5, 6 }
        };
        int[,] result = new int[mat.GetLength(1), mat.GetLength(0)];
        for (int row = 0; row < mat.GetLength(0); row++)
        {
            for (int col = 0; col < mat.GetLength(1); col++)
            {
                result[col, row] = mat[row, col];
            }
        }
        Console.WriteLine("Original:");
        PrintMatrix(mat);
        Console.WriteLine("Transposed:");
        PrintMatrix(result);
        Console.WriteLine();
    }

    // דוגמה 10: לוח משחק עם תווים
    // טבלה של תווים מתאימה ללוחות משחק.
    // ממלאים את הלוח בנקודות, ואז שמים בו כמה סימנים בתאים שנקבעו וגם בתא אקראי.
    static void Example10_BoardGame()
    {
        char[,] board = new char[4, 6];
        for (int row = 0; row < board.GetLength(0); row++)
        {
            for (int col = 0; col < board.GetLength(1); col++)
            {
                board[row, col] = '.';
            }
        }
        board[0, 0] = 'S';
        board[3, 5] = 'E';

        // תא אקראי שבו מסמנים אוצר
        Random rnd = new Random();
        int treasureRow = rnd.Next(board.GetLength(0));
        int treasureCol = rnd.Next(board.GetLength(1));
        board[treasureRow, treasureCol] = 'X';

        for (int row = 0; row < board.GetLength(0); row++)
        {
            for (int col = 0; col < board.GetLength(1); col++)
            {
                Console.Write(board[row, col] + " ");
            }
            Console.WriteLine();
        }
        Console.WriteLine();
    }
}
