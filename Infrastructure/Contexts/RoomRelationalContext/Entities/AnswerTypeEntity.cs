using Monetizacao.Providers.Contexts.Enums;

namespace Monetizacao.Providers.Contexts.Entities;

public class AnswerTypeEntity
    : BaseTypeEntity<AnswerTypeEnum>
{
    public ICollection<AnswerEntity>? Answers { get; protected set; }

    public AnswerTypeEntity() { }
}