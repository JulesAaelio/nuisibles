namespace tp_nuisibles
{
    public class EcosystemFactory: IEcosystemFactory
    {
        
        public  Ecosystem Generate(EcosystemType type, int xDimension, int yDimension)
        {
            switch (type) {
            
                case EcosystemType.Random: 
                    return new RandomEcosystem(xDimension, yDimension);
                case EcosystemType.UmbrellaCorp:
                    return new UmbrellaCorpEcosystem(xDimension, yDimension);
                default:
                    return new CitadinEcosystem(xDimension, yDimension);
            }
        }
    }
}