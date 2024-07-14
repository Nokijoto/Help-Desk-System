using AutoMapper;
using AutoMapper.QueryableExtensions;
using Microsoft.EntityFrameworkCore;
using ServiceDesk.Assets.API.Interfaces;
using ServiceDesk.Assets.CrossCutting.Dtos;
using ServiceDesk.Assets.Storage;
using ServiceDesk.Assets.Storage.Entities;
using System.Collections.Generic;
using System.Linq.Dynamic.Core;
using System.Linq.Expressions;

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
            var asset = await _dbSet.FirstOrDefaultAsync(entity => EF.Property<Guid>(entity, "Guid") == id);
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

        public async Task UpdateAsync(Guid id, TDto assetDto)
        {

            var existingAsset = await _dbSet.SingleOrDefaultAsync(e => EF.Property<Guid>(e, "Guid") == id);
            if (existingAsset == null)
            {
                throw new KeyNotFoundException($"Entity with Guid {id} not found.");
            }

            var asset = _mapper.Map<T>(assetDto);

            foreach (var property in typeof(T).GetProperties().Where(p => !p.GetMethod.IsVirtual && !p.Name.Equals("Id") && !p.Name.Equals("Guid")))
            {
                var newValue = property.GetValue(asset);
                if (newValue != null)
                {
                    property.SetValue(existingAsset, newValue);
                }
            }

            existingAsset.UpdatedAt = DateTime.Now;
            existingAsset.UpdatedBy = "System";

            await _context.SaveChangesAsync();
        }
     



        public async Task DeleteAsync(Guid id)
        {
            var asset = await _dbSet.SingleOrDefaultAsync(e => EF.Property<Guid>(e, "Guid") == id);
            if (asset != null)
            {
                _dbSet.Remove(asset);
                await _context.SaveChangesAsync();
            }
        }

        //public async Task<List<TDto>> GetFilteredAssets<TDto>(AssetFilterDto filter)
        //{
        //    // Determine the type of entity being requested based on the TDto
        //    var entityType = typeof(TDto) == typeof(ComputerDto) ? "Computer" :
        //                     typeof(TDto) == typeof(CableDto) ? "Cable" :
        //                     "Asset"; // Default to Asset if no match

        //    var query = _context.Assets.AsQueryable();

        //    // Apply the discriminator filter
        //    if (entityType != "Asset")
        //    {
        //        query = query.Where(a => a.Discriminator == entityType);
        //    }

        //    foreach (var filterParam in filter.Filters)
        //    {
        //        var parameterName = filterParam.Key;
        //        var parameterValue = filterParam.Value;

        //        if (parameterValue != null)
        //        {
        //            if (parameterValue is string)
        //            {
        //                query = query.Where($"{parameterName}.Contains(@0)", parameterValue);
        //            }
        //            else
        //            {
        //                query = query.Where($"{parameterName} == @0", parameterValue);
        //            }
        //        }
        //    }

        //    // Ensure projection to the correct type
        //    var result = query.ProjectTo<TDto>(_mapper.ConfigurationProvider);

        //    return await result.ToListAsync();
        //}


    }

}
