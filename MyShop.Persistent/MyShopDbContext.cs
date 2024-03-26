using Microsoft.EntityFrameworkCore;
using MyShop.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MediatR;
using MyShop.Persistent.EntityConfigurations;

namespace MyShop.Persistent
{
    public class MyShopDbContext : DbContext, IUnitOfWork
    {
        private readonly IMediator _mediator;

        public MyShopDbContext(
            DbContextOptions<MyShopDbContext> options,
            IMediator mediator
        ) : base(options)
        {
            _mediator = mediator ?? throw new ArgumentNullException(nameof(mediator));
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.ApplyConfiguration(new UserEntityTypeConfiguration());
        }
        public async Task CommitAsync()
        {
            await _mediator.DispatchDomainEventsAsync(this);
            await base.SaveChangesAsync();
        }
    }
}
