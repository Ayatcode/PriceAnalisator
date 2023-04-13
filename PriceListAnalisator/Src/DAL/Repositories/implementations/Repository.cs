﻿using Core.Interfaces;
using DAL.Context;
using DAL.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Security.Principal;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Repositories.implementations;

public class Repository<T> : IRepository<T> where T : class, IEntity, new()
{
    private readonly AppDbContext _context;

    public Repository(AppDbContext context)
    {
        _context = context;
    }

    public DbSet<T> Table => _context.Set<T>();

    public async Task CreateAsync(T entity)
    {
        await Table.AddAsync(entity);
    }



    public IQueryable<T> FindAll()
    {
        return Table.AsQueryable().AsNoTracking();
    }

    public IQueryable<T> FindByCondition(Expression<Func<T, bool>> expression)
    {
        return Table.Where(expression).AsNoTracking();
    }

    public async Task<T?> FindByIDAsync(int id)
    {
        return await Table.FindAsync(id);
    }



    public void Update(T entity)
    {

        _context.Update(entity);
    }
    public void Delete(T entity)
    {
        Table.Remove(entity);
    }

    public async Task SaveAsync()
    {
        await _context.SaveChangesAsync();
    }
}
