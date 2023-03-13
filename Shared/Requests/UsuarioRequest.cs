using System.ComponentModel.DataAnnotations;

namespace SUPERCOLMADO.Shared.Request;

public class UsuarioRolCreateRequest
{
    [Required(ErrorMessage = "Se debe proporcionar el nombre del rol"), 
    MinLength(5, ErrorMessage ="EL nombre debe superar los 5 caracteres."), 
    MaxLength(100)]
    public string Nombre { get; set; } = null!;
    public bool PermisoParaCrear { get; set; }
    public bool PermisoParaEditar { get; set; }
    public bool PermisoParaEliminar { get; set; }

}

public class UsuarioRolUpdateRequest : UsuarioRolCreateRequest
{
    [Required(ErrorMessage = "Se debe proporcionar el Id rol a modificar")]
    public int Id { get; set; }
}
