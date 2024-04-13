
using q.DTOs.DTO;

public interface ICustomersService
{
    Task<Customers?> FindCustomersByEmail(string email, CancellationToken token);
    Task<RoleDTO?> GetRoleNameById(int role);
    Task<IEnumerable<CustomersDTO>> GetAllCustomers(CancellationToken token);
    Task RegisterCustomers(CustomersDTO customersDTO, CancellationToken token);
    Task<Customers?> GetCustomerById(int id);
}