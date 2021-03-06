namespace MovieMaker.Domain.DomainObjects
{

    // Classe usada para a fácil replicação da propriedade
    // Id dentro das entidades de domínio
    public abstract class Entity
    {
        public int Id { get; set; }
    }

}