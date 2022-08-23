using BlazorStore_Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlazoeStore_Business.Repository.IRepository
{
    public interface ICategoryRepository
    {
        public Task<CategoryDto> Create(CategoryDto objDto);
        public Task<CategoryDto> Update(CategoryDto objDto);
        public Task<int> Delete(int id);
        public Task<CategoryDto> GetById(int id);
        public Task<IEnumerable<CategoryDto>> GetAll();
    }
}
