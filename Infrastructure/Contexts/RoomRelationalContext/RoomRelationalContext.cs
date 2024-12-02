using Monetizacao.Providers.Contexts.Entities;
using Monetizacao.Providers.Contexts.Maps;
using Monetizacao.Providers.Handlers;
using Microsoft.EntityFrameworkCore;

namespace Monetizacao.Providers.Contexts;

public sealed class RoomRelationalContext : DbContext
{
    public DbSet<GameEntity>                        Games               { get; set; }    
    public DbSet<ActionEntity>                      Actions             { get; set; }

    public DbSet<AnswerEntity>                      Answers             { get; set; }
    public DbSet<AnswerTypeEntity>                  AnswerTypes         { get; set; }
    public DbSet<ActionResultEntity>                ActionResults       { get; set; }

    public DbSet<TemplateEntity>                    Templates           { get; set; }
    public DbSet<ActionTemplateEntity>              ActionTemplates     { get; set; }

    public RoomRelationalContext(DbContextOptions<RoomRelationalContext> options)
        : base(options) { }

    protected override void OnModelCreating(ModelBuilder builder)
    {
        Schema(builder);

        Seed(builder);

        base.OnModelCreating(builder);
    }

    private void Schema(ModelBuilder builder)
    {
        // Core
        GameEntityMap.Definition(builder);
        ActionEntityMap.Definition(builder);

        // Answer
        AnswerEntityMap.Definition(builder);
        AnswerTypeEntityMap.Definition(builder);
        ActionResultEntityMap.Definition(builder);

        // Template
        TemplateEntityMap.Definition(builder);
        ActionTemplateEntityMap.Definition(builder);
    }

    private void Seed(ModelBuilder builder)
    {
        // Core
        GameEntityMap.Seed(builder);
        ActionEntityMap.Seed(builder);

        // Answer
        AnswerTypeEntityMap.Seed(builder);
        AnswerEntityMap.Seed(builder);
        ActionResultEntityMap.Seed(builder);

        // Template
        TemplateEntityMap.Seed(builder);
        ActionTemplateEntityMap.Seed(builder);
    }
}
