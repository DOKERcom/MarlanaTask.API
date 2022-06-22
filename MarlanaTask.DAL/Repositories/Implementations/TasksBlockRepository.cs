using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Task.DAL.DbContexts;
using Task.DAL.Entities;
using Task.DAL.Repositories.Interfaces;

namespace Task.DAL.Repositories.Implementations
{
    public class TasksBlockRepository : ITasksBlockRepository
    {

        private MarlanaTaskDbContext db;
        public TasksBlockRepository(MarlanaTaskDbContext context)
        {
            db = context;
        }


        public async void CreateTasksBlockAsync(TasksBlockEntity entity)
        {
            db.TasksBlocks.Add(entity);
            await db.SaveChangesAsync();
        }

        public async void DeleteTasksBlockAsync(TasksBlockEntity entity)
        {
            db.TasksBlocks.Remove(entity);
            await db.SaveChangesAsync();
        }

        public async void UpdateNameTasksBlockAsync(TasksBlockEntity entity)
        {
            db.TasksBlocks.Update(entity);
            await db.SaveChangesAsync();
        }

        public async Task<TasksBlockEntity> GetTasksBlockByNameAsync(string name)
        {
            return await db.TasksBlocks.Where(t=>t.Name == name).FirstOrDefaultAsync();
        }

        public async Task<TasksBlockEntity> GetTasksBlockByIdAsync(int id)
        {
            return await db.TasksBlocks.Where(t => t.Id == id).FirstOrDefaultAsync();
        }

        public async void AddTaskAsync(TaskEntity taskEntity, TasksBlockEntity blockEntity)
        {
            blockEntity.Tasks.Add(taskEntity);
            db.TasksBlocks.Update(blockEntity);
            await db.SaveChangesAsync();
        }

        public async void RemoveTaskAsync(TaskEntity taskEntity, TasksBlockEntity blockEntity)
        {
            blockEntity.Tasks.Remove(taskEntity);
            db.TasksBlocks.Update(blockEntity);
            await db.SaveChangesAsync();
        }
    }
}
