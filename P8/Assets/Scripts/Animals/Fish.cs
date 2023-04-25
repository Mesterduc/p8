namespace Animals {
    public class Fish : Animal
    {
        // private float range { get; set; }
        // private float maxDistance { get; set; }
        // SpriteRenderer fish { get; set; }
        // private Vector2 waypoint { get; set; }
        public Swim swim;

        public Fish(string name, string species, string type, float speed, string animated, AnimalSize fishSize, string realLifeImage, bool isDisplayed)
            // public Fish(Swim swim, string name, string species, string type, float speed, string animated, FishSize fishSize, string realLifeImage, bool isDisplayed)
            : base(name, species, type, speed, animated, fishSize, realLifeImage, isDisplayed)
        {
            // this.swim = new Swim();
        }
        public override void Move()
        {
            throw new System.NotImplementedException();
        }
        // public override void Move()
        // {
        //     waypoint = new Vector2(Random.Range(-maxDistance, maxDistance), Random.Range(-maxDistance, maxDistance));

        // void Update()
        // {
        //     transform.position = Vector2.MoveTowards(transform.position, waypoint, speed * Time.deltaTime);
        //     if (Vector2.Distance(transform.position, waypoint) < range)
        //     {
        //         swim();
        //     }
        // }

        // void Start()
        // {
        //     fish = GetComponent<SpriteRenderer>();
        //     Move();
        // }

        // void Update()
        // {
        //     transform.position = Vector2.MoveTowards(transform.position, waypoint, speed * Time.deltaTime);
        //     if (Vector2.Distance(transform.position, waypoint) < range)
        //     {
        //         Move();
        //     }
        // }

    }
}


