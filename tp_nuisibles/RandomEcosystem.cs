using System;

namespace tp_nuisibles
{
    public class RandomEcosystem: Ecosystem
    {
        
        public RandomEcosystem(int x, int y) : base(x, y)
        {
        }

        protected override void Init()
        {
            int maxNuisiblesNumber = (int) (this.DimX * this.DimY * (20d / 100d));
            int remainingNuisiblesToGen = maxNuisiblesNumber;

            int toGen = Random.Next(0, remainingNuisiblesToGen);
            for (int i = 0; i < toGen; i++)
            {
                int x = this.Random.Next(0, this.DimX);
                int y = this.Random.Next(0, this.DimY);
                this.Nuisibles.Add(new Rat(this, 1, new Position(x,y) ));
            }
            remainingNuisiblesToGen -= toGen;
            
            toGen = Random.Next(0, remainingNuisiblesToGen);
            for (int i = 0; i < toGen; i++)
            {
                int x = this.Random.Next(0, this.DimX);
                int y = this.Random.Next(0, this.DimY);
                this.Nuisibles.Add(new Zombie(this, 1, new Position(x,y) ));
            }
            remainingNuisiblesToGen -= toGen;
            
            toGen = Random.Next(0, remainingNuisiblesToGen);
            for (int i = 0; i < toGen; i++)
            {
                int x = this.Random.Next(0, this.DimX);
                int y = this.Random.Next(0, this.DimY);
                this.Nuisibles.Add(new PigeonMutantDecorator(new Pigeon(this, 1, new Position(x, y))));
            }

            remainingNuisiblesToGen -= toGen;


            toGen = remainingNuisiblesToGen; 
            for (int i = 0; i < toGen; i++)
            {
                int x = this.Random.Next(0, this.DimX);
                int y = this.Random.Next(0, this.DimY);
                this.Nuisibles.Add(new Pigeon(this, 1, new Position(x,y) ));
            }
            
         }
    }
}