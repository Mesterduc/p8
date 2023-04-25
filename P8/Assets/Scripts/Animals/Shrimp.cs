namespace Animals {
    public class Shrimp : Animal
    {
        public Shrimp(string name, string species, string type, float speed, string animated, AnimalSize fishSize, string realLifeImage, bool isDisplayed)
            : base(name, species, type, speed, animated, fishSize, realLifeImage, isDisplayed)
        {

        }

        public override void Move()
        {
            //make it wiggle its tail
            //throw new System.NotImplementedException();
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
