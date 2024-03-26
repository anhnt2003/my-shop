using MediatR;
using Microsoft.EntityFrameworkCore;
using MyShop.Domain;

namespace MyShop.Persistent;

public static class MediatorExtension
{
    public static async Task DispatchDomainEventsAsync(this IMediator mediator, DbContext ctx, CancellationToken cancellationToken = default)
    {
        var domainEntities = ctx.ChangeTracker
            .Entries<AggregateRoot<long>>()
            .Where(x => x.Entity.DomainEvents != null && x.Entity.DomainEvents.Any());

        var entityEntries = domainEntities.ToList();
            
        var domainEvents = entityEntries
            .SelectMany(x => x.Entity.DomainEvents)
            .ToList();

        entityEntries
            .ForEach(entity => entity.Entity.ClearDomainEvents());

        foreach (var domainEvent in domainEvents)
            await mediator.Publish(domainEvent, cancellationToken);
    }
}