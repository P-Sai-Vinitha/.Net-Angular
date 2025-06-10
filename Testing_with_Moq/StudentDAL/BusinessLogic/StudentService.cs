using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using StudentDAL.Domain;
using StudentDAL.Repository;

namespace StudentDAL.BusinessLogic
{
    public class StudentService
    {
        private readonly IStudentRepository _repository;
        public StudentService(IStudentRepository repository)
        {
            this._repository = repository;
        }
        public List<Student> GetAllStudents()
        {
            return _repository.GetAll();
        }

        public Student GetStudentByRollNo(int rollNo)
        {
            if (rollNo > 0)
                return _repository.GetByRollNo(rollNo);
            else
                throw new ArgumentException("Invalid Roll Number");
        }

        public Student GetStudentByName(string name)
        {
            if (!string.IsNullOrWhiteSpace(name))
                return _repository.GetByName(name);
            else
                throw new ArgumentException("Invalid Name");
        }

        public void AddStudent(Student student)
        {
            if (student != null && _repository.GetByRollNo(student.RollNo) == null)
            {
                _repository.Add(student);
            }
            else
            {
                throw new ArgumentException("Student is null or already exists.");
            }
        }

        public void UpdateStudent(Student student)
        {
            if (student != null)
            {
                _repository.Update(student);
            }
            else
            {
                throw new ArgumentNullException(nameof(student));
            }
        }

        public void DeleteStudent(int rollNo)
        {
            if (rollNo > 0)
                _repository.Delete(rollNo);
            else
                throw new ArgumentException("Invalid Roll Number");
        }
    }
}