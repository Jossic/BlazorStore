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
        public CategoryDto Create(CategoryDto objDto);
        public CategoryDto Update(CategoryDto objDto);
        public int Delete(int id);
        public CategoryDto GetById(int id);
        public IEnumerable<CategoryDto> GetAll();
    }
}
