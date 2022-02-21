using AutoMapper;
using EmirhanAvci.Project.BusinessLayer.Abstract;
using EmirhanAvci.Project.DataAccessLayer.Abstract;
using EmirhanAvci.Project.EntityLayer.Dtos;
using EmirhanAvci.Project.SharedLayer.Utilities.Results.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmirhanAvci.Project.BusinessLayer.Concrete
{
    public class RoleManager : IRoleService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        public RoleManager(IUnitOfWork unitOfWork, IMapper mapper)
        {

        }
        public Task<IResult> AddAsync(RoleAddDto roleAddDto, string createdByName)
        {
            throw new NotImplementedException();
        }

        public Task<IResult> DeleteAsync(int roleId, string modifiedByName)
        {
            throw new NotImplementedException();
        }

        public Task<IDataResult<RoleListDto>> GetAllAsync()
        {
            throw new NotImplementedException();
        }

        public Task<IDataResult<RoleListDto>> GetAllByNonDeletedAsync()
        {
            throw new NotImplementedException();
        }

        public Task<IDataResult<RoleDto>> GetAsync(int roleId)
        {
            throw new NotImplementedException();
        }

        public Task<IResult> HardDeleteAsync(int roleId)
        {
            throw new NotImplementedException();
        }

        public Task<IResult> UpdateAsync(RoleUpdateDto roleUpdateDto, string modifiedByName)
        {
            throw new NotImplementedException();
        }
    }
}
