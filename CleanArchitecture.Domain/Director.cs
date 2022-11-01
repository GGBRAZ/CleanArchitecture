using CleanArchitecture.Domain.Common;

namespace CleanArchitecture.Domain
{
    public class Director: BaseDomainModel
    {
        public string? Name { get; set; }
        public string? Nickname { get; set; }

        public int VideoId { get; set; }
        public virtual Video? Video { get; set; }

    }
}
