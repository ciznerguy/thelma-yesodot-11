# פרק 14: ממשקים

## בקצרה

- ממשק הוא חוזה: רשימה של פעולות שמחלקה שמממשת אותו מתחייבת לכתוב. אין בו מימוש.
- מחלקה יכולה לרשת מאב אחד בלבד, אבל לממש כמה ממשקים.
- משתנה, מערך או פרמטר מסוג ממשק מחזיקים עצמים מכל מחלקה שמממשת אותו, גם אם המחלקות לא קשורות בהורשה.
- אי אפשר ליצור עצם מממשק עצמו.
- המחלקות והממשקים כתובים בקובץ נפרד מהקובץ הראשי.

## הדוגמאות

הקוד נמצא ב-`Program.cs` (הדוגמאות) ו-`Classes.cs` (המחלקות). כל דוגמה היא פעולה סטטית נפרדת, ובפעולה `Main` הן מופעלות בזו אחר זו.

1. `Example01_ImplementingInterface`: מימוש ממשק
2. `Example02_TwoInterfaces`: מחלקה שמממשת כמה ממשקים
3. `Example03_InterfaceAsVariableType`: ממשק כטיפוס של משתנה
4. `Example04_ArrayOfInterface`: מערך של ממשק
5. `Example05_MethodWithInterfaceParameter`: פעולה שמקבלת ממשק כפרמטר
6. `Example06_ShapesInterface`: ממשק של צורות
7. `Example07_UnrelatedClasses`: מחלקות שאינן קשורות זו לזו
8. `Example08_TotalPayments`: סכום כל התשלומים
9. `Example09_AbstractClassAndInterface`: מחלקה מופשטת וממשק יחד
10. `Example10_FilteringByInterface`: אותו עצם, כמה זהויות

## איך מריצים

**ב-Visual Studio:**

1. פותחים את הקובץ `ThelmaYesodot11.sln` שבתיקייה הראשית.
2. בחלון Solution Explorer לוחצים לחיצה ימנית על הפרויקט `Perek14` ובוחרים **Set as Startup Project**.
3. לוחצים על הכפתור הירוק **Start** (או על Ctrl+F5).
4. בפעולה `Main` כל שורה מפעילה דוגמה אחת. כדי להריץ רק דוגמה מסוימת, מסמנים בהערה (`//`) את שאר השורות.

**משורת הפקודה (נדרש .NET 8):**

```bash
cd "פרק 14"
dotnet run
```

## מבחן תרגול

מבחן אמריקאי של 15 שאלות, עם ציון ומשוב בסוף: [למבחן של פרק 14](https://ciznerguy.github.io/thelma-yesodot-11/quiz/ch14.html). המבחן הוא ללמידה בלבד, ואין ציון שנשמר.

## השיעור בקמפוס

[לקורס באתר קמפוס](https://app.campus.gov.il/learning/course/course-v1:MoE+EDU_Matric_ComputerScienceA_HE+2023_1/home). בקורס יש לפתוח את הפרק המתאים: **פרק 14**.

## משימה אסינכרונית

המשימה לפרק זה נמצאת בקובץ [משימה אסינכרונית.md](./משימה%20אסינכרונית.md). אפשר לסיים אותה תוך 90 דקות לכל היותר, והיא מוגשת דרך Google Classroom.

[חזרה לדף הראשי](../README.md)
