using Microsoft.EntityFrameworkCore;
using ReceiptInformationSystem.Application.Interfaces;
using ReceiptInformationSystem.Domain.DTOs;
using ReceiptInformationSystem.Domain.Entities;
using ReceiptInformationSystem.Infrastructure.Data;

namespace ReceiptInformationSystem.Infrastructure.Services;

public class ParameterTypeService : IParameterTypeService
{
    private readonly AppDbContext _context;

    public ParameterTypeService(AppDbContext context)
    {
        _context = context;
    }

    public async Task<IEnumerable<ParameterType>> GetParameterTypes() =>
        await _context.ParameterTypes.ToListAsync();

    public async Task<ParameterType?> GetParameterTypeById(Guid id) =>
        await _context.ParameterTypes.FindAsync(id);

    public async Task<ParameterType> CreateParameterType(ParameterTypeDTO parameterTypeDto)
    {
        var parameterType = new ParameterType
        {
            Name = parameterTypeDto.Name,
            Description = parameterTypeDto.Description
        };

        _context.ParameterTypes.Add(parameterType);
        await _context.SaveChangesAsync();

        return parameterType;
    }

    public async Task<bool> UpdateParameterType(Guid id, ParameterTypeDTO parameterTypeDto)
    {
        var parameterType = await _context.ParameterTypes.FindAsync(id);
        if (parameterType == null)
            return false;

        parameterType.Name = parameterTypeDto.Name;
        parameterType.Description = parameterTypeDto.Description;

        await _context.SaveChangesAsync();
        return true;
    }
}