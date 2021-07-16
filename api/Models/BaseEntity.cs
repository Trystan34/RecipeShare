using System;
using api.Interfaces;

namespace api.Models
{
    public class BaseEntity : IEntity
    {
        public Guid Id { get; set; }
        public DateTime? CreationDate { get; set; }
    }
}
