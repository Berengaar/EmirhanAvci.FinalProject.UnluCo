using EmirhanAvci.Project.EntityLayer.Dtos;
using EmirhanAvci.Project.SharedLayer.Utilities.Results.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmirhanAvci.Project.BusinessLayer.Abstract
{
    public interface IRoleService
    {
        Task<IDataResult<RoleDto>> GetAsync(int roleId);
        Task<IDataResult<RoleListDto>> GetAllAsync();
        Task<IDataResult<RoleListDto>> GetAllByNonDeletedAsync();
        Task<IResult> AddAsync(RoleAddDto roleAddDto, string createdByName);
        Task<IResult> UpdateAsync(RoleUpdateDto roleUpdateDto, string modifiedByName);
        Task<IResult> DeleteAsync(int roleId, string modifiedByName);
        Task<IResult> HardDeleteAsync(int roleId);
    }
}
