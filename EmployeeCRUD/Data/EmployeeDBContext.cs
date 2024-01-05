﻿using Microsoft.Extensions.Options;
using MongoDB.Driver;
using EmployeeCRUD.Interface;
using EmployeeCRUD.Models;
using EmployeeCRUD.Data;
using Amazon.Runtime.SharedInterfaces;

namespace EmployeeCRUD.Data
{
    public class EmployeeDBContext : IEmployee
    {
        public readonly IMongoDatabase _db;

        public EmployeeDBContext(IOptions<Settings> options)
        {
            var client = new MongoClient(options.Value.ConnectionString);
            _db = client.GetDatabase(options.Value.Database);
        }

        public IMongoCollection<Employee> employeeCollection => 
            _db.GetCollection<Employee>("Employees");

/*
        public void Create(Employee employeeData)
        {
            employeeCollection.InsertOne(employeeData);

        }
*/
        public async Task CreateAsync(Employee employeeData)
        {
            await employeeCollection.InsertOneAsync(employeeData);

        }
/*
        public void Delete(string _id)
        {
           var filter = Builders<Employee>.Filter.Eq(c => c._id, _id);
            employeeCollection.DeleteOne(filter);
        }
*/
        public async Task DeleteAsync(string _id)
        {
           var filter = Builders<Employee>.Filter.Eq(c => c._id, _id);
           await employeeCollection.DeleteOneAsync(filter);
        }

/*
        public IEnumerable<Employee> GetAllEmployees()
        {
            return employeeCollection.Find(a=>true).ToList();
        }
*/
        public async Task<IEnumerable<Employee>> GetAllEmployeesAsync() =>
        await employeeCollection.Find(_ => true).ToListAsync();

/*
        public Employee GetEmployeeDetails(string _id)
        {
            var employeeDetails = employeeCollection.Find(a=>a._id == _id).FirstOrDefault();
            return employeeDetails;
        }
*/
        public async Task<Employee> GetEmployeeDetailsAsync(string _id)
        {
            var employeeDetails = await employeeCollection.Find(a=>a._id == _id).FirstOrDefaultAsync();
            return employeeDetails;
        }

        public async Task UpdateAsync(string _id, Employee employeeData)
        {
            var filter = Builders<Employee>.Filter.Eq(c => c._id, _id);
            var update = Builders<Employee>.Update
                .Set("name", employeeData.name)
                .Set("designation", employeeData.designation)
                .Set("address", employeeData.address);              

            await employeeCollection.UpdateOneAsync(filter, update);
        }
    }
}