# פרק 4: משפטי תנאי

## בקצרה

- משפט תנאי מריץ קוד רק אם תנאי מתקיים. אפשר להוסיף אחרת ושרשרת של תנאים נוספים.
- בשרשרת תנאים מתבצע בלוק אחד לכל היותר, ובתנאים נפרדים יכולים להתבצע כמה בלוקים.
- תנאים מורכבים נבנים בעזרת וגם, או ולא, ואפשר לכתוב תנאי בתוך תנאי.
- מחרוזות מושוות בעזרת סימן שווה כפול.

## הדוגמאות

הקוד נמצא ב-`Program.cs`. כל דוגמה היא פעולה סטטית נפרדת, ובפעולה `Main` הן מופעלות בזו אחר זו.

1. `Example01_SimpleIf`: משפט תנאי פשוט
2. `Example02_IfElse`: תנאי עם אחרת
3. `Example03_ElseIfChain`: שרשרת תנאים
4. `Example04_SeveralIfsVersusElseIf`: כמה תנאים נפרדים לעומת שרשרת
5. `Example05_NestedIf`: תנאי בתוך תנאי
6. `Example06_ConditionWithAndOr`: תנאי מורכב
7. `Example07_CompareStrings`: השוואת מחרוזות
8. `Example08_LeapYear`: שנה מעוברת
9. `Example09_BiggestOfThree`: הגדול משלושה מספרים
10. `Example10_RandomWithConditions`: הגרלה ותנאים

## איך מריצים

**ב-Visual Studio:**

1. פותחים את הקובץ `ThelmaYesodot11.sln` שבתיקייה הראשית.
2. בחלון Solution Explorer לוחצים לחיצה ימנית על הפרויקט `Perek04` ובוחרים **Set as Startup Project**.
3. לוחצים על הכפתור הירוק **Start** (או על Ctrl+F5).
4. בפעולה `Main` כל שורה מפעילה דוגמה אחת. כדי להריץ רק דוגמה מסוימת, מסמנים בהערה (`//`) את שאר השורות.

**משורת הפקודה (נדרש .NET 8):**

```bash
cd "פרק 04"
dotnet run
```

## מבחן תרגול

מבחן אמריקאי של 15 שאלות, עם ציון ומשוב בסוף: [למבחן של פרק 4](https://ciznerguy.github.io/thelma-yesodot-11/quiz/ch04.html). המבחן הוא ללמידה בלבד, ואין ציון שנשמר.

## השיעור בקמפוס

[לקורס באתר קמפוס](https://app.campus.gov.il/learning/course/course-v1:MoE+EDU_Matric_ComputerScienceA_HE+2023_1/home). בקורס יש לפתוח את הפרק המתאים: **פרק 4**.

[חזרה לדף הראשי](../README.md)
