namespace Animals {
    public class Crab : Animal
    {
    
        public Crab (string name, string species, string type, float speed, string animated, AnimalSize fishSize, string realLifeImage, bool isDisplayed)
            : base(name, species, type, speed, animated, fishSize, realLifeImage, isDisplayed)
        {
        
        }

        public override void Move()
        {
            //make it jump and walk on the ground
        }


        // Start is called before the first frame update
        void Start()
        {
        
        }

        // Update is called once per frame
        void Update()
        {
        
        }
    }
}
