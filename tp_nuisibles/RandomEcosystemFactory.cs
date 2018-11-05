namespace tp_nuisibles
{
    public class RandomEcosystemFactory : EcosystemFactory
    {
        public override Ecosystem Generate(int x, int y)
        {
            return new RandomEcosystem(x, y);
        }
    }
}
