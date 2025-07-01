// Enum for Courses
var Course;
(function (Course) {
    Course["Angular"] = "Angular";
    Course["Nodejs"] = "Node.js";
    Course["FullStack"] = "FullStack";
})(Course || (Course = {}));
// Class to manage student course enrollment
var StudentManager = /** @class */ (function () {
    function StudentManager() {
        this.students = [];
    }
    StudentManager.prototype.addStudent = function (student) {
        student.courseCategory = this.getCourseCategory(student.courseName);
        student.enrollmentStatus = this.getEnrollmentStatus(student);
        this.students.push(student);
    };
    StudentManager.prototype.getCourseCategory = function (course) {
        switch (course) {
            case Course.Angular:
                return "Front-End";
            case Course.Nodejs:
                return "Back-End";
            case Course.FullStack:
                return "Full-Stack";
            default:
                return "Unknown";
        }
    };
    StudentManager.prototype.getEnrollmentStatus = function (student) {
        if (student.age < 18) {
            return "Not Eligible";
        }
        if (student.courseName === Course.Angular && !student.knowsHTML) {
            return "Not Eligible";
        }
        return "Eligible";
    };
    StudentManager.prototype.displayReport = function () {
        for (var _i = 0, _a = this.students; _i < _a.length; _i++) {
            var student = _a[_i];
            console.log("Student Name: ".concat(student.name));
            console.log("Age: ".concat(student.age));
            console.log("Course: ".concat(student.courseName));
            console.log("Knows HTML: ".concat(student.knowsHTML));
            console.log("Course Category: ".concat(student.courseCategory));
            console.log("Enrollment Status: ".concat(student.enrollmentStatus));
            console.log('------------------------');
        }
    };
    return StudentManager;
}());
// Sample Execution
var manager = new StudentManager();
manager.addStudent({ name: "Sneha", age: 20, courseName: Course.Angular, knowsHTML: true });
manager.addStudent({ name: "Karan", age: 17, courseName: Course.Nodejs, knowsHTML: false });
manager.addStudent({ name: "Riya", age: 22, courseName: Course.Angular, knowsHTML: false });
manager.addStudent({ name: "Aman", age: 25, courseName: Course.FullStack, knowsHTML: true });
manager.displayReport();
