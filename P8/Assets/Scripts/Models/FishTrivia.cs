namespace Models {
    [System.Serializable]
    public class FishTrivia

    {
        public string name;
        public string animated;// animal image
        public string animation; // animal animation
        public string picture;
        public string realPicture;
        public Activity activities;
        public string diet;
        public string status;
        public string bio;

        public FishTrivia(string name, string animated, string animation, string picture, string realPicture, Activity activities, string diet, string status, string bio)
        {
            this.name = name;
            this.animated = animated;
            this.animation = animation;
            this.picture = picture;
            this.realPicture = realPicture;
            this.activities = activities;
            this.diet = diet;
            this.status = status;
            this.bio = bio;
        }
    }
}
