using Labb3.MethodHandling;

namespace Labb3
{
    public class Program
    {
        static void Main(string[] args)
        {
            MethodHandler.Menu();

            //1: Hämta Personal med SQL 
            /*SELECT * FROM Faculty
            JOIN FacultyType ON FK_FacultyTypeId = PK_FacultyTypeId
            WHERE FacultyType = 'Teacher'*/


            //2: Hämta alla elever - löses med Entity Framework

            //3: Hämta alla elever i en viss klass - löses med Entity Framework - klar


            //4: Hämta alla betyg som satts den senaste månaden med SQL - Klar
            /* SELECT Student.FName, Student.LName,StudentGrade.DateOfGrade,
             * StudentGrade.FK_GradeId, Subject.SubjectName
             * FROM Student, StudentGrade, Subject
             * WHERE Student.PK_StudentId = StudentGrade.FK_StudentId AND
             * FK_SubjectId = PK_SubjectId AND DateOfGrade > '2022-12-01'*/


            //5: Hämta en lista med alla kurser och det snittbetyg som eleverna fått på den kursen samt det högsta och lägsta beyget som någon fått i kursen med SQL - klar
            /* SELECT Subject.SubjectName, AVG(StudentGrade.FK_GradeId) AS 'GPA', MIN(StudentGrade.FK_GradeId) AS 'LOWEST GRADE',
             * MAX(StudentGrade.FK_GradeId) AS 'HIGHEST GRADE'
             * FROM StudentGrade 
             * INNER JOIN Subject ON Subject.PK_SubjectId =StudentGrade.FK_SubjectId
             * GROUP BY SubjectName*/


            //6: Lägga till nya elever med SQL - Klar
            /*INSERT INTO Student(FName, LName, PersonId, FK_ClassId)
            VALUES ('Sven', 'Jansson', '2005-10-23', 2);*/


            //7: Lägga till ny personal - löses med Entity Framwork - klar
        }
    }
}