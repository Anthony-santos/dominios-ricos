using PaymentContext.Domain.Queries;

namespace PaymentContext.Test.Queries;

[TestClass]
public class StudentQuerieTests
{
    private IList<Student> _students;

    public StudentQuerieTests()
    {
        _students = new List<Student>();
        for (int i = 0; i <= 10; i++)
        {
            _students.Add(new Student(
                new Name("Aluno", i.ToString()),
                new Document("111111111111", EDocumentType.CPF),
                new Email($"{i.ToString()} + @waynecorp.com")));
        }
    }
    
    [TestMethod]
    public void Should_Return_Null_When_Document_Not_Exists()
    {
        var exp = StudentQueries.GetStudent("12346578911");
        var student = _students.AsQueryable().Where(exp).FirstOrDefault();
        
        Assert.AreEqual(null, student);
    }
    
    [TestMethod]
    public void Should_Return_Student_When_Document_Exists()
    {
        var exp = StudentQueries.GetStudent("111111111111");
        var student = _students.AsQueryable().Where(exp).FirstOrDefault();
        
        Assert.AreNotEqual(null, student);
    }
}