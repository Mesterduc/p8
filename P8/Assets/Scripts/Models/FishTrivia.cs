namespace Models {
    [System.Serializable]
    public class FishTrivia

    {
        public string name;
        public string picture;
        public string realPicture;
        public Activity activities;
        public string diet;
        public string status;
        public string bio;

        public FishTrivia(string name, string picture, string realPicture, Activity activities, string diet, string status, string bio)
        {
            this.name = name;
            this.picture = picture;
            this.realPicture = realPicture;
            this.activities = activities;
            this.diet = diet;
            this.status = status;
            this.bio = bio;
        }
    }
}
