using Abp.UI;
using Domain.Dto;
using Domain.Entity;
using Infraestructure.Context;
using Infraestructure.Enum;
using Infraestructure.Interfaces;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Data;
using System.Diagnostics.Metrics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Dapper.SqlMapper;

namespace Infraestructure.Response
{
    public abstract class BaseRepository<T> : IBaseRepository<T> where T : class
    {
       
        private readonly App_Context _dbcontext;

        private ILogger<BaseRepository<T>> Logger { get; set; }

        protected BaseRepository(ILoggerFactory logger, App_Context dbcontext)
        {
            Logger = logger.CreateLogger<BaseRepository<T>>();
            //dbConn = new DbConnection(cnnconfig.GetConnectionString("CnnDb"), type).Connection;
            _dbcontext = dbcontext;
        }
        public async Task<bool> DeleteAsync(long id)
        {
            try
            {
                var result = await GetByIdAsync(id);
                _dbcontext.Set<T>().Remove(result);
                await _dbcontext.SaveChangesAsync();
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
          
        }

        public Task<IEnumerable<T>> ExecuteAsync(string sql)
        {
            throw new NotImplementedException();
        }

        public async Task<IEnumerable<T>> GetAllAsync()
        {
            try
            {
                return await _dbcontext.Set<T>().ToListAsync();
            }
            catch(Exception ex)
            {
                throw new UserFriendlyException("Erro ao retornar os dados : " + ex.Message);
            }
        }


        public async Task<T> GetByIdAsync(long id)
        {
            try
            {
                var result = await _dbcontext.Set<T>().FindAsync(id);
                return result;
            }
            catch (Exception ex)
            {
                throw new UserFriendlyException("Erro ao retornar os dados : " + ex.Message);
            }

        }


        public async Task<UsuarioEntity> GetUsuarioByLoginPsw(string usuario)
        {
            try
            {                
                var result = _dbcontext.Set<UsuarioEntity>().Where(x => x.Nome == usuario ).FirstOrDefault();
                return result;
            }
            catch (Exception ex)
            {
                throw new UserFriendlyException("Erro ao retornar os dados : " + ex.Message);
            }


        }
      


        public async Task<bool> InsertAsync(T entity)
        {
            try
            {
                await _dbcontext.Set<T>().AddAsync(entity);
                await _dbcontext.SaveChangesAsync();
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }

        }

       


        public async Task<bool> UpdateAsync(T entity)
        {
            try
            {
                _dbcontext.Set<T>().Update(entity);
                await _dbcontext.SaveChangesAsync();
                return true;
            }
            catch(Exception ex)
            {
                return false;
            }
            
        }

      
    }
}
