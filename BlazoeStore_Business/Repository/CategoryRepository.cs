using AutoMapper;
using BlazoeStore_Business.Repository.IRepository;
using BlazorStore_DataAccess;
using BlazorStore_DataAccess.Data;
using BlazorStore_Models;
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

        public CategoryDto Create(CategoryDto objDto)
        {
            var obj = _mapper.Map<CategoryDto, Category>(objDto);
            var addedObj = _db.Categories.Add(obj);
            _db.SaveChanges();

            return _mapper.Map<Category, CategoryDto>(addedObj.Entity);
        }

        public int Delete(int id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<CategoryDto> GetAll()
        {
            throw new NotImplementedException();
        }

        public CategoryDto GetById(int id)
        {
            throw new NotImplementedException();
        }

        public CategoryDto Update(CategoryDto objDto)
        {
            throw new NotImplementedException();
        }
    }
}
