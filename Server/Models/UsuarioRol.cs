using System.ComponentModel.DataAnnotations;

namespace SUPERCOLMADO.Server.Models;

public class UsuarioRol
{
    [Key]
    public int Id { get; set; }
    public string Nombre { get; set; } = null!;
    public bool PermisosParaCrear { get; set; }
    public bool PermisosParaBorrar { get; set; }
    public bool PermisosParaEditar { get; set; }
    public virtual ICollection<UsuarioRol>? Usuarios { get; set; }
}
