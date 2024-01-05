using MongoDB.Driver;
using EmployeeCRUD.Models;

namespace EmployeeCRUD.Interface
{
    public interface IEmployee
    {
        IMongoCollection<Employee> employeeCollection { get; }
       // IEnumerable<Employee> GetAllEmployees();
        Task  <IEnumerable<Employee>> GetAllEmployeesAsync();

       // Employee GetEmployeeDetails(string _id);
        Task <Employee> GetEmployeeDetailsAsync(string _id);

       // void Create(Employee employeeData);
        Task CreateAsync(Employee employeeData);

        //void Update(string _id,Employee employeeData);
        Task UpdateAsync(string _id,Employee employeeData);

        //void Delete(string _id);
        Task DeleteAsync(string _id);
    }
}