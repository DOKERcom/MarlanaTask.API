using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Task.DAL.DbContexts;
using Task.DAL.Entities;
using Task.DAL.Repositories.Interfaces;

namespace Task.DAL.Repositories.Implementations
{
    public class TaskRepository : ITaskRepository
    {

        private MarlanaTaskDbContext db;
        public TaskRepository(MarlanaTaskDbContext context)
        {
            db = context;
        }

        public async Task<int> CreateTaskAsync(TaskEntity entity)
        {
            db.Tasks.Add(entity);
            return await db.SaveChangesAsync();
        }

        public async Task<int> UpdateTaskAsync(TaskEntity entity)
        {
            db.Tasks.Update(entity);
            return await db.SaveChangesAsync();
        }

        public async Task<int> DeleteTaskAsync(TaskEntity entity)
        {
            db.Tasks.Remove(entity);
            return await db.SaveChangesAsync();
        }

        public async Task<TaskEntity?> GetTaskByNameAsync(string name)
        {
            return await db.Tasks.Where(t => t.Name == name).FirstOrDefaultAsync();
        }

        public async Task<TaskEntity?> GetTaskByIdAsync(int id)
        {
            return await db.Tasks.Where(t => t.Id == id).FirstOrDefaultAsync();
        }
    }
}
