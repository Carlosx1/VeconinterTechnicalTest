using Microsoft.EntityFrameworkCore.Storage;
using VeconinterTechnicalTest.Domain.Interfaces;

namespace VeconinterTechnicalTest.Infrastructure.Data.Repositories;

public class UnitOfWork : IUnitOfWork
{
    private readonly ApplicationDbContext _context;
    private IDbContextTransaction? _transaction;
    private bool _disposed = false;
    
    public IClientRepository Clients { get; private set; }
    public ISubClientRepository SubClients { get; private set; }
    public IUserRepository Users { get; private set; }

    
    public UnitOfWork(ApplicationDbContext context)
    {
        _context = context;
        Clients = new ClientRepository(_context);
        SubClients = new SubClientRepository(_context);
        Users = new UserRepository(_context);
    }


    public async Task<int> SaveChangesAsync()
    {
        return await _context.SaveChangesAsync();
    }
        
    public async Task BeginTransactionAsync()
    {
        _transaction = await _context.Database.BeginTransactionAsync();
    }
        
    public async Task CommitTransactionAsync()
    {
        if (_transaction != null)
        {
            await _transaction.CommitAsync();
            await _transaction.DisposeAsync();
            _transaction = null;
        }
    }
        
    public async Task RollbackTransactionAsync()
    {
        if (_transaction != null)
        {
            await _transaction.RollbackAsync();
            await _transaction.DisposeAsync();
            _transaction = null;
        }
    }
        
    public void Dispose()
    {
        Dispose(true);
        GC.SuppressFinalize(this);
    }
        
    protected virtual void Dispose(bool disposing)
    {
        if (!_disposed && disposing)
        {
            _transaction?.Dispose();
            _context.Dispose();
        }
        _disposed = true;
    }
}