namespace tp_nuisibles
{
    public class UmbrellaCorpEcosystemFacory : EcosystemFactory
    {
        public override Ecosystem Generate(int x, int y)
        {
            return new UmbrellaCorpEcosystem(x,y);
        } 
    }
}