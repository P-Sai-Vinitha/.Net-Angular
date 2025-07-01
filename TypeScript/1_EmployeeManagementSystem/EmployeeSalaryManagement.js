// Enum for Departments
var Department;
(function (Department) {
    Department["HR"] = "HR";
    Department["IT"] = "IT";
    Department["Sales"] = "Sales";
})(Department || (Department = {}));
// Class to manage employee salary calculations
var EmployeeManager = /** @class */ (function () {
    function EmployeeManager() {
        this.employees = [];
    }
    EmployeeManager.prototype.addEmployee = function (emp) {
        emp.netSalary = this.calculateNetSalary(emp);
        emp.category = this.categorizeEmployee(emp.netSalary);
        this.employees.push(emp);
    };
    EmployeeManager.prototype.calculateNetSalary = function (emp) {
        var bonusPercentage = 0;
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
    };
    EmployeeManager.prototype.categorizeEmployee = function (netSalary) {
        if (netSalary >= 80000) {
            return "High Earner";
        }
        else if (netSalary >= 50000) {
            return "Mid Earner";
        }
        else {
            return "Low Earner";
        }
    };
    EmployeeManager.prototype.displayReport = function () {
        for (var _i = 0, _a = this.employees; _i < _a.length; _i++) {
            var emp = _a[_i];
            console.log("Employee Name: ".concat(emp.name));
            console.log("Age: ".concat(emp.age));
            console.log("Department: ".concat(emp.department));
            console.log("Base Salary: \u20B9".concat(emp.baseSalary));
            console.log("Net Salary (with bonus): \u20B9".concat(emp.netSalary));
            console.log("Category: ".concat(emp.category));
            console.log('------------------------');
        }
    };
    return EmployeeManager;
}());
// Sample Execution
var manager = new EmployeeManager();
manager.addEmployee({ name: "Ravi", age: 28, department: Department.IT, baseSalary: 60000 });
manager.addEmployee({ name: "Priya", age: 32, department: Department.HR, baseSalary: 48000 });
manager.addEmployee({ name: "Arjun", age: 26, department: Department.Sales, baseSalary: 85000 });
manager.displayReport();
