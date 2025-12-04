using AutoMapper;
using OnionVb02.Application.DTOInterfaces;
using OnionVb02.Application.ManagerInterfaces;
using OnionVb02.Contract.RepositoryInterfaces;
using OnionVb02.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Markup;

namespace OnionVb02.InnerInfrastructure.ManagerConcretes
{
    public abstract class BaseManager<T, U> : IManager<T, U> where T : class, IDto where U : class, IEntity
    {
        private readonly IRepository<U> _repository;
        protected readonly IMapper _mapper;

        public BaseManager(IRepository<U> repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }
        public async Task CreateAsync(T entity)
        {
            U domainEntity = _mapper.Map<U>(entity);
            domainEntity.CreatedDate = DateTime.Now;
            domainEntity.Status = Domain.Enums.DataStatus.Inserted;

            await _repository.CreateAsync(domainEntity);
        }

        public List<T> GetActives()
        {
            List<U> values = _repository.Where(x => x.Status != Domain.Enums.DataStatus.Deleted).ToList();

            return _mapper.Map<List<T>>(values);
        }

        public async Task<List<T>> GetAllAsync()
        {
            List<U> values = await _repository.GetAllAsync();
            return _mapper.Map<List<T>>(values);
        }

        public async Task<T> GetByIdAsync(int id)
        {
            U value = await _repository.GetByIdAsync(id);
            return _mapper.Map<T>(value);
        }

        public List<T> GetPassives()
        {
            List<U> values = _repository.Where(x => x.Status == Domain.Enums.DataStatus.Deleted).ToList();
            return _mapper.Map<List<T>>(values);
        }

        public List<T> GetUpdateds()
        {
            List<U> values = _repository.Where(x => x.Status == Domain.Enums.DataStatus.Updated).ToList();
            return _mapper.Map<List<T>>(values);
        }

        public async Task<string> HardDeleteAsync(int id)
        {
            U value = await _repository.GetByIdAsync(id);
            if (value == null || value.Status != Domain.Enums.DataStatus.Deleted) return "Veri silinebilmesi icin pasif olmalı veya bulunabilmeli";
            await _repository.DeleteAsync(value);
            return $"{id} id'li veri silindi";
        }

        public async Task<string> SoftDeleteAsync(int id)
        {
            U value = await _repository.GetByIdAsync(id);
            if (value == null || value.Status == Domain.Enums.DataStatus.Deleted) return "Veri zaten pasif veya yok";
            value.Status = Domain.Enums.DataStatus.Deleted;
            value.DeletedDate = DateTime.Now;
            await _repository.SaveChangesAsync();
            return $"{id} id'li veri pasif hale getirildi";
        }

        public async Task UpdateAsync(T entity)
        {
            U originalValue = await _repository.GetByIdAsync(entity.Id);
            U newValue = _mapper.Map<U>(entity);
            newValue.Status = Domain.Enums.DataStatus.Updated;
            newValue.UpdatedDate = DateTime.Now;
            await _repository.UpdateAsync(originalValue, newValue);
        }
    }
}
