// Enum for Departments
enum Department {
    HR = "HR",
    IT = "IT",
    Sales = "Sales"
}

// Interface for Employee
interface Employee {
    name: string;
    age: number;
    department: Department;
    baseSalary: number;
    netSalary?: number;
    category?: string;
}

// Class to manage employee salary calculations
class EmployeeManager {
    private employees: Employee[] = [];

    addEmployee(emp: Employee): void {
        emp.netSalary = this.calculateNetSalary(emp);
        emp.category = this.categorizeEmployee(emp.netSalary);
        this.employees.push(emp);
    }

    private calculateNetSalary(emp: Employee): number {
        let bonusPercentage = 0;

        switch (emp.department) {
            case Department.HR:
                bonusPercentage = 0.10;
                break;
            case Department.IT:
                bonusPercentage = 0.15;
                break;
            case Department.Sales:
                bonusPercentage = 0.12;
                break;
        }

        return emp.baseSalary + emp.baseSalary * bonusPercentage;
    }

    private categorizeEmployee(netSalary: number): string {
        if (netSalary >= 80000) {
            return "High Earner";
        } else if (netSalary >= 50000) {
            return "Mid Earner";
        } else {
            return "Low Earner";
        }
    }

    displayReport(): void {
        for (const emp of this.employees) {
            console.log(`Employee Name: ${emp.name}`);
            console.log(`Age: ${emp.age}`);
            console.log(`Department: ${emp.department}`);
            console.log(`Base Salary: ₹${emp.baseSalary}`);
            console.log(`Net Salary (with bonus): ₹${emp.netSalary}`);
            console.log(`Category: ${emp.category}`);
            console.log('------------------------');
        }
    }
}

// Sample Execution
const manager = new EmployeeManager();

manager.addEmployee({ name: "Ravi", age: 28, department: Department.IT, baseSalary: 60000 });
manager.addEmployee({ name: "Priya", age: 32, department: Department.HR, baseSalary: 48000 });
manager.addEmployee({ name: "Arjun", age: 26, department: Department.Sales, baseSalary: 85000 });

manager.displayReport();