using System;
using System.ComponentModel.DataAnnotations;

namespace api.Interfaces
{
    /// <summary>
    /// Base entity from which all the other domain models will be extended. We're assuming that all the models will have 
    /// id as primary key and creation_date fields in database tables.
    /// </summary>
    public interface IEntity
    {
        [Key]
        Guid Id { get; set; }
        DateTime? CreationDate { get; set; }
    }
}
