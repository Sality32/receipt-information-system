using ReceiptInformationSystem.Domain.DTOs;
using ReceiptInformationSystem.Domain.Entities;

namespace ReceiptInformationSystem.Application.Interfaces;

public interface IParameterTypeService
{
    Task<IEnumerable<ParameterType>> GetParameterTypes();
    Task<ParameterType?> GetParameterTypeById(Guid id);
    Task<ParameterType> CreateParameterType(ParameterTypeDTO parameterTypeDto);
    Task<bool> UpdateParameterType(Guid id, ParameterTypeDTO parameterTypeDto);
}