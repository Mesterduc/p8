namespace magnus.johnson {
    [System.Serializable]
    public class FishTrivia

    {
        public string name;
        public Activity activities;
        public string diet;
        public string status;
        public string bio;

        public FishTrivia(string name, Activity activities, string diet, string status, string bio)
        {
            this.name = name;
            this.activities = activities;
            this.diet = diet;
            this.status = status;
            this.bio = bio;
        }
    }
}
