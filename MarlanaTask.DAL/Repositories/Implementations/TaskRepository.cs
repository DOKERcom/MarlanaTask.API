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

        public async void CreateTask(TaskEntity entity)
        {
            db.Tasks.Add(entity);
            await db.SaveChangesAsync();
        }

        public async void UpdateTask(TaskEntity entity)
        {
            db.Tasks.Update(entity);
            await db.SaveChangesAsync();
        }

        public async void DeleteTask(TaskEntity entity)
        {
            db.Tasks.Remove(entity);
            await db.SaveChangesAsync();
        }

        public async Task<TaskEntity?> DeleteTask(string name)
        {
            return await db.Tasks.Where(t => t.Name == name).FirstOrDefaultAsync();
        }
    }
}
