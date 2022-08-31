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
    public class ProductRepository : IProductRepository
    {
        private readonly ApplicationDbContext _db;
        private readonly IMapper _mapper;

        public ProductRepository(ApplicationDbContext db, IMapper mapper)
        {
            _db = db;
            _mapper = mapper;
        }

        public async Task<ProductDto> Create(ProductDto objDto)
        {
            var obj = _mapper.Map<ProductDto, Product>(objDto);
            var addedObj = _db.Products.Add(obj);
            await _db.SaveChangesAsync();

            return _mapper.Map<Product, ProductDto>(addedObj.Entity);
        }

        public async Task<int> Delete(int id)
        {
            var obj = await _db.Products.FirstOrDefaultAsync(x => x.Id == id);
            if (obj == null) return 0;
            _db.Products.Remove(obj);
            return await _db.SaveChangesAsync();
        }

        public async Task<IEnumerable<ProductDto>> GetAll() => _mapper.Map<IEnumerable<Product>, IEnumerable<ProductDto>>(_db.Products.Include(prod => prod.Category));

        public async Task<ProductDto> GetById(int id)
        {
            var obj = _db.Products.Include(prod => prod.Category).FirstOrDefault(x => x.Id == id);
            if (obj == null) return new ProductDto();
            return _mapper.Map<Product, ProductDto>(obj);
        }

        public async Task<ProductDto> Update(ProductDto objDto)
        {
            var objFromDb = await _db.Products.FirstOrDefaultAsync(x => x.Id == objDto.Id);
            if (objFromDb == null) return objDto;
            objFromDb.Name= objDto.Name;
            objFromDb.Description= objDto.Description;
            objFromDb.ImageUrl= objDto.ImageUrl;
            objFromDb.CategoryId= objDto.CategoryId;
            objFromDb.Color= objDto.Color;
            objFromDb.ShopFavorites= objDto.ShopFavorites;
            objFromDb.CustomerFavorites= objDto.CustomerFavorites;
            _db.Products.Update(objFromDb);
            await _db.SaveChangesAsync();
            return _mapper.Map<Product, ProductDto>(objFromDb);

        }
    }
}
