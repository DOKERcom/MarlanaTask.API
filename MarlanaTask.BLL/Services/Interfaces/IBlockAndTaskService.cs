using MarlanaTask.BLL.Models.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MarlanaTask.BLL.Services.Interfaces
{
    public interface IBlockAndTaskService
    {
        public Task<int> CreateTaskAndJoinToBlock(string blockName, TaskDTO taskDto);
    }
}
