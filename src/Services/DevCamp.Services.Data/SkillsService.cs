﻿using DevCamp.Services.Data.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace DevCamp.Services.Data
{
    public class SkillsService : ISkillsService
    {
        public Task CreateAsync(string technologyName, string level, string userId, int skillId)
        {
            throw new NotImplementedException();
        }

        public Task DeleteAsync(int id)
        {
            throw new NotImplementedException();
        }

        public Task EditAsync(int id, string level)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<T> GetAllByUser<T>(string userId)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<T> GetAllUsersBySkill<T>(int skillId)
        {
            throw new NotImplementedException();
        }

        public Task<T> GetByIdAsync<T>(int id)
        {
            throw new NotImplementedException();
        }
    }
}