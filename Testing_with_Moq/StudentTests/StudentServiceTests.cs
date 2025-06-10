using System;
using System.Collections.Generic;
using Moq;
using StudentDAL.Domain;
using StudentDAL.Repository;
using StudentDAL.BusinessLogic;
using NUnit.Framework;

namespace StudentTests
{
    [TestFixture]
    internal class StudentServiceTests
    {
        private Mock<IStudentRepository> _mockRepository;
        private StudentService _studentService;

        [SetUp]
        public void Setup()
        {
            _mockRepository = new Mock<IStudentRepository>();
            _studentService = new StudentService(_mockRepository.Object);
        }

        // 1. GetAll()
        [Test]
        public void GetAllStudents_ReturnsListOfStudents()
        {
            var students = new List<Student>
            {
                new Student { RollNo = 1, Name = "Alice", Email = "alice@example.com" },
                new Student { RollNo = 2, Name = "Bob", Email = "bob@example.com" }
            };

            _mockRepository.Setup(r => r.GetAll()).Returns(students);

            var result = _studentService.GetAllStudents();

            Assert.That(result.Count, Is.EqualTo(2));
        }

        // 2. GetByRollNo()
        [Test]
        public void GetStudentByRollNo_ValidRollNo_ReturnsStudent()
        {
            var student = new Student { RollNo = 1, Name = "Alice", Email = "alice@example.com" };
            _mockRepository.Setup(r => r.GetByRollNo(1)).Returns(student);

            var result = _studentService.GetStudentByRollNo(1);

            Assert.That(result, Is.Not.Null);
            Assert.That(result.Name, Is.EqualTo("Alice"));
        }

        [Test]
        public void GetStudentByRollNo_InvalidRollNo_ThrowsException()
        {
            Assert.That(() => _studentService.GetStudentByRollNo(0), Throws.TypeOf<ArgumentException>());
        }

        // 3. GetByName()
        [Test]
        public void GetStudentByName_ValidName_ReturnsStudent()
        {
            var student = new Student { RollNo = 3, Name = "Charlie", Email = "charlie@example.com" };
            _mockRepository.Setup(r => r.GetByName("Charlie")).Returns(student);

            var result = _studentService.GetStudentByName("Charlie");

            Assert.That(result, Is.Not.Null);
            Assert.That(result.RollNo, Is.EqualTo(3));
        }

        [Test]
        public void GetStudentByName_NullOrEmptyName_ThrowsException()
        {
            Assert.That(() => _studentService.GetStudentByName(""), Throws.TypeOf<ArgumentException>());
        }

        // 4. Add()
        [Test]
        public void AddStudent_ValidStudent_CallsAddMethod()
        {
            var student = new Student { RollNo = 4, Name = "David", Email = "david@example.com" };
            _mockRepository.Setup(r => r.GetByRollNo(student.RollNo)).Returns((Student)null);

            _studentService.AddStudent(student);

            _mockRepository.Verify(r => r.Add(student), Times.Once);
        }

        [Test]
        public void AddStudent_DuplicateRollNo_ThrowsException()
        {
            var student = new Student { RollNo = 4, Name = "David", Email = "david@example.com" };
            _mockRepository.Setup(r => r.GetByRollNo(student.RollNo)).Returns(student);

            Assert.That(() => _studentService.AddStudent(student), Throws.TypeOf<ArgumentException>());
        }

        // 5. Update()
        [Test]
        public void UpdateStudent_ValidStudent_CallsUpdateMethod()
        {
            var student = new Student { RollNo = 5, Name = "Eva", Email = "eva@example.com" };

            _studentService.UpdateStudent(student);

            _mockRepository.Verify(r => r.Update(student), Times.Once);
        }

        [Test]
        public void UpdateStudent_NullStudent_ThrowsException()
        {
            Assert.That(() => _studentService.UpdateStudent(null), Throws.TypeOf<ArgumentNullException>());
        }

        // 6. Delete()
        [Test]
        public void DeleteStudent_ValidRollNo_CallsDeleteMethod()
        {
            _studentService.DeleteStudent(6);

            _mockRepository.Verify(r => r.Delete(6), Times.Once);
        }

        [Test]
        public void DeleteStudent_InvalidRollNo_ThrowsException()
        {
            Assert.That(() => _studentService.DeleteStudent(0), Throws.TypeOf<ArgumentException>());
        }
    }
}