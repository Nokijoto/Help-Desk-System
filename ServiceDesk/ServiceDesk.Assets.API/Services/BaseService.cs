using AutoMapper;
using Microsoft.EntityFrameworkCore;
using ServiceDesk.Assets.API.Interfaces;
using ServiceDesk.Assets.Storage;
using ServiceDesk.Assets.Storage.Entities;
using System.Collections.Generic;

namespace ServiceDesk.Assets.API.Services
{
    public class BaseService<T, TDto> : IBaseService<T, TDto> where T : Asset where TDto : class
    {
        private readonly AssetsDbContext _context;
        private readonly DbSet<T> _dbSet;
        private readonly IMapper _mapper;

        public BaseService(AssetsDbContext context, IMapper mapper)
        {
            _context = context;
            _dbSet = context.Set<T>();
            _mapper = mapper;
        }

        public async Task<List<TDto>> GetAllAsync()
        {
            var entities = await _dbSet.ToListAsync();
            return _mapper.Map<List<TDto>>(entities);
        }

        public async Task<TDto> GetByIdAsync(Guid id)
        {
            var asset = await _dbSet.FirstOrDefaultAsync(entity => EF.Property<Guid>(entity, "Id") == id);
            return _mapper.Map<TDto>(asset);
        }

        public async Task AddAsync(TDto assetDto)
        {
            var asset = _mapper.Map<T>(assetDto);
            asset.Guid = Guid.NewGuid(); 
            asset.UpdatedBy = "System";
            asset.CreatedBy = "System";
            asset.CreatedAt = DateTime.Now;
            asset.UpdatedAt = DateTime.Now;
            asset.Discriminator = asset.GetType().Name;
            await _dbSet.AddAsync(asset);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateAsync(TDto assetDto)
        {
            var asset = _mapper.Map<T>(assetDto);
            asset.UpdatedAt = DateTime.Now;
            asset.UpdatedBy = "System";
            _context.Entry(asset).State = EntityState.Modified;
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(Guid id)
        {
            var asset = await _dbSet.FindAsync(id);
            if (asset != null)
            {
                _dbSet.Remove(asset);
                await _context.SaveChangesAsync();
            }
        }

        public async Task<List<TDto>> FilterAsync(Dictionary<string, object> searchParams)
        {
            IQueryable<TDto> query = (IQueryable<TDto>)_dbSet;

            foreach (var param in searchParams)
            {
                var propertyInfo = typeof(TDto).GetProperty(param.Key);
                if (propertyInfo != null)
                {
                    query = query.Where(entity => EF.Property<object>(entity, param.Key).ToString().Contains(param.Value.ToString()));
                }
            }

            var entities = await query.ToListAsync();
            return _mapper.Map<List<TDto>>(entities);
        }


    }
}
