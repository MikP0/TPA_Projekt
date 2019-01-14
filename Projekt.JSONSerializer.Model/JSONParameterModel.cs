using Projekt.Model;

namespace Projekt.JSONSerializer.Model
{
    public class JSONParameterModel : ParameterModel
    {
        public override string Name { get; set; }

        public new JSONTypeModel Type { get; set; }

    }
}
