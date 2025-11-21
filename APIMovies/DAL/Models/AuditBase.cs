using System.ComponentModel.DataAnnotations;

namespace APIMovies.DAL.Models
{
    public class AuditBase
    {
        //Decorators - Data Annotations
        [Key] //Pimary key
        public virtual int Id { get; set; } //Primary Key de todas las Entidades
        public virtual DateTime CreatedDate { get; set; } //este me sirve para guardar la fecha de creación de un registro en BD
        public virtual DateTime? ModifiedDate { get; set; } //para guardar la fecha de modificación de un registro en BD
    }
}
