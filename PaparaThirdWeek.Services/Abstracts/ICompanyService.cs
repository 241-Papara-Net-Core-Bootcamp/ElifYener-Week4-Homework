﻿using PaparaThirdWeek.Domain.Entities;
using PaparaThirdWeek.Services.DTOs;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace PaparaThirdWeek.Services.Abstracts
{
    public interface ICompanyService
    {
        public Task<IReadOnlyList<Company>> GetAll();
        public Task<Company> GetById(int id);
        public Task<int> Add(Company company);
        public Task<int> Update(Company company, int id);
        public Task<int> Delete(int id);
    }
}
