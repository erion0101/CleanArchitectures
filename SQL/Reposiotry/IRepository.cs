using q.SQL.Model;

public interface IRepository<T> where T : BaseViewModel
{
    Task<T?> Get(int id, CancellationToken token);
    IQueryable<T> GetAll();
    IQueryable<Role> GetRoleName();
    IQueryable<Role> GetRolesByCustomerId(int customerId);
    Task Add(T entity);
    Task Update(T entity);
    Task Delete(int id);
    Task SaveAsync(CancellationToken token);
    IQueryable<Reservations> GetAllReservations();
    IQueryable<Customers> GetAllCustomers();
}