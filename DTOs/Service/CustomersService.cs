
using Microsoft.EntityFrameworkCore;
using q.DTOs.DTO;
using q.DTOs.Mapping;
using System.Linq;

public class CustomersService : ICustomersService
{
    private readonly IRepository<Customers> _repository;
    public CustomersService(IRepository<Customers> repository)
    {
        _repository = repository;
    }
    public async Task<Customers?> FindCustomersByEmail(string email, CancellationToken token)
    {
        return await _repository.GetAll().FirstOrDefaultAsync(x => x.Email == email, token);
    }

    public async Task<IEnumerable<CustomersDTO>> GetAllCustomers(CancellationToken token)
    {
       var item = await _repository.GetAllCustomers().ToListAsync(token);
        return CustomersMapping.ToDTOs(item);
    }
    public async Task<Customers?> GetCustomerById(int id)
    {
        return await _repository.GetAll().FirstOrDefaultAsync(x => x.Id == id);
    }

    public async Task<RoleDTO?> GetRoleNameById(int role)
    {
        var item = await _repository.GetRoleName().FirstOrDefaultAsync(e=> e.Id == role);
        return RoleMapping.ToDTO(item);
        //var roles = await _repository.GetRolesByCustomerId(role).ToListAsync();
        //return (CustomersDTO?)roles.Select(r => RoleMapping.ToDTO(r));
        //var roles = await _repository.GetRoleName().FirstOrDefaultAsync(e => e.RoleId == role);
        //return CustomersMapping.ToDTO(roles);
    }

    public async Task RegisterCustomers(CustomersDTO customersDTO, CancellationToken token)
    {
        var customersmapping = CustomersMapping.ToModel(customersDTO);
        if (customersDTO.Password != null)
        {
            customersmapping.Password = BCrypt.Net.BCrypt.HashPassword(customersDTO.Password);
        }
        await _repository.Add(customersmapping);
        await _repository.SaveAsync(token);
    }
}