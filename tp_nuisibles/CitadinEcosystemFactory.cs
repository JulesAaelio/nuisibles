namespace tp_nuisibles
{
    public class CitadinEcosystemFactory : EcosystemFactory
    {
        public override Ecosystem Generate(int x, int y)
        {
            return new CitadinEcosystem(x,y);
        } 
    }
    
}