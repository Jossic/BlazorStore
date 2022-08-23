using AutoMapper;
using BlazoeStore_Business.Repository.IRepository;
using BlazorStore_DataAccess;
using BlazorStore_DataAccess.Data;
using BlazorStore_Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlazoeStore_Business.Repository
{
    public class CategoryRepository : ICategoryRepository
    {
        private readonly ApplicationDbContext _db;
        private readonly IMapper _mapper;

        public CategoryRepository(ApplicationDbContext db, IMapper mapper)
        {
            _db = db;
            _mapper = mapper;
        }

        public async Task<CategoryDto> Create(CategoryDto objDto)
        {
            var obj = _mapper.Map<CategoryDto, Category>(objDto);
            obj.CreatedDate = DateTime.Now;
            var addedObj = _db.Categories.Add(obj);
            await _db.SaveChangesAsync();

            return _mapper.Map<Category, CategoryDto>(addedObj.Entity);
        }

        public async Task<int> Delete(int id)
        {
            var obj = await _db.Categories.FirstOrDefaultAsync(x => x.Id == id);
            if (obj == null) return 0;
            _db.Categories.Remove(obj);
            return await _db.SaveChangesAsync();
        }

        public async Task<IEnumerable<CategoryDto>> GetAll() => _mapper.Map<IEnumerable<Category>, IEnumerable<CategoryDto>>(_db.Categories);

        public async Task<CategoryDto> GetById(int id)
        {
            var obj = _db.Categories.FirstOrDefault(x => x.Id == id);
            if (obj == null) return new CategoryDto();
            return _mapper.Map<Category, CategoryDto>(obj);
        }

        public async Task<CategoryDto> Update(CategoryDto objDto)
        {
            var objFromDb = await _db.Categories.FirstOrDefaultAsync(x => x.Id == objDto.Id);
            if (objFromDb == null) return objDto;
            objFromDb.Name= objDto.Name;
            _db.Categories.Update(objFromDb);
            await _db.SaveChangesAsync();
            return _mapper.Map<Category, CategoryDto>(objFromDb);

        }
    }
}
