using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using demoweb.Entities;
using Microsoft.EntityFrameworkCore;

namespace demoweb.Services
{
    public class StudentService
    {
        private readonly DataContext _context;

        public StudentService(DataContext dataContext)
        {
            _context = dataContext;
        }

        public async Task<List<Student>> GetAll()
        {
            try
            {
                var items = await _context.Students.ToListAsync();
                return items;
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        public async Task<Student> GetStudent(int id)
        {
            try
            {
                var item = await _context.Students.SingleOrDefaultAsync(x => x.Id == id);
                if (item == null) return null;
                return item;
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        public async Task<Student> AddStudent(Student student)
        {
            try
            {
                var existStudent = await _context.Students.FirstOrDefaultAsync(x => x.Id == student.Id);
                if (existStudent != null) return existStudent;
                var newStudent = new Student()
                {
                    Name = student.Name,
                    Age = student.Age,
                    Address = student.Address
                };
                await _context.Students.AddAsync(newStudent);
                await _context.SaveChangesAsync();
                return newStudent;
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        public async Task<Student> UpdateStudent(Student student)
        {
            try
            {
                var existStudent = await _context.Students.FirstOrDefaultAsync(x => x.Id == student.Id);
                if (existStudent == null) return null;
                existStudent.Name = student.Name;
                existStudent.Age = student.Age;
                existStudent.Address = student.Address;
                
                _context.Students.Update(existStudent);
                await _context.SaveChangesAsync();
                return existStudent;
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        public async Task<Student> DeleteStudent(int id)
        {
            try
            {
                var existStudent = await _context.Students.FirstOrDefaultAsync(x => x.Id == id);
                if (existStudent == null) return null;

                _context.Students.Remove(existStudent);
                await _context.SaveChangesAsync();
                return existStudent;
            }
            catch (Exception ex)
            {
                return null;
            }
        }

    }
}
