
// Enum for Courses
enum Course {
    Angular = "Angular",
    Nodejs = "Node.js",
    FullStack = "FullStack"
}

// Interface for Student
interface Student {
    name: string;
    age: number;
    courseName: Course;
    knowsHTML: boolean;
    courseCategory?: string;
    enrollmentStatus?: string;
}

// Class to manage student course enrollment
class StudentManager {
    private students: Student[] = [];

    addStudent(student: Student): void {
        student.courseCategory = this.getCourseCategory(student.courseName);
        student.enrollmentStatus = this.getEnrollmentStatus(student);
        this.students.push(student);
    }

    private getCourseCategory(course: Course): string {
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
    }

    private getEnrollmentStatus(student: Student): string {
        if (student.age < 18) {
            return "Not Eligible";
        }
        if (student.courseName === Course.Angular && !student.knowsHTML) {
            return "Not Eligible";
        }
        return "Eligible";
    }

    displayReport(): void {
        for (const student of this.students) {
            console.log(`Student Name: ${student.name}`);
            console.log(`Age: ${student.age}`);
            console.log(`Course: ${student.courseName}`);
            console.log(`Knows HTML: ${student.knowsHTML}`);
            console.log(`Course Category: ${student.courseCategory}`);
            console.log(`Enrollment Status: ${student.enrollmentStatus}`);
            console.log('------------------------');
        }
    }
}

// Sample Execution
const manager = new StudentManager();

manager.addStudent({ name: "Sneha", age: 20, courseName: Course.Angular, knowsHTML: true });
manager.addStudent({ name: "Karan", age: 17, courseName: Course.Nodejs, knowsHTML: false });
manager.addStudent({ name: "Riya", age: 22, courseName: Course.Angular, knowsHTML: false });
manager.addStudent({ name: "Aman", age: 25, courseName: Course.FullStack, knowsHTML: true });

manager.displayReport();