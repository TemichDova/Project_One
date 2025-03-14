namespace Project_Transaction.Domain.Entities.Abstractions
{
    public abstract class BaseEntity
    {
        public Guid Id { get; set; }

        /// <summary>Дата и время создания сущности.</summary>
        public DateTime Created { get; set; }

        /// <summary>Дата и время последнего обновления сущности.</summary>
        public DateTime? Updated { get; set; }

        /// <summary>Дата и время удаления (мягкого удаления) сущности.</summary>
        public DateTime? Deleted { get; set; }
    }
}
