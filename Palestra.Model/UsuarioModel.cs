
namespace Palestra.Model
{
    public class UsuarioModel
    {
        public virtual long ID { get; set; } = long.MinValue;
        public virtual string Login { get; set; } = string.Empty;
        public virtual string Senha { get; set; } = string.Empty;
    }
}
