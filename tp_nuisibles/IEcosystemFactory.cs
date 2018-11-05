namespace tp_nuisibles
{
    public interface IEcosystemFactory
    {
        Ecosystem Generate(EcosystemType type, int x, int y);
    }
}