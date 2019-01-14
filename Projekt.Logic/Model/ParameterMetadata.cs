namespace Projekt.Logic.Model
{
    public class ParameterMetadata
    {
        public ParameterMetadata()
        {

        }
        public ParameterMetadata(string name, TypeMetadata typeMetadata)
        {
            m_Name = name;
            TypeMetadata = typeMetadata;
        }

        //private vars
        private string m_Name;
        public string Name
        {
            get { return m_Name; }
            set { m_Name = value; }
        }
        public TypeMetadata TypeMetadata { get; set; }

    }
}
