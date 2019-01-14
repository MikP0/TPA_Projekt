using Projekt.Model.Enums;

namespace Projekt.Model
{
    public class MethodModifiers
    {
        public AbstractEnum? AbstractEnum { get; set; }
        public StaticEnum? StaticEnum { get; set; }
        public VirtualEnum? VirtualEnum { get; set; }
        public AccessLevel? AccessLevel { get; set; }
    }
}
