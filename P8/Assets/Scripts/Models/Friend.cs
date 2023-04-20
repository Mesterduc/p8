[System.Serializable]
public class Friend {
    public string name;
    public int level;
    public int numberOfAchievements;
    public string image;
    public Friend(string name, int level, int numberOfAchievements, string image) {
        this.name = name;
        this.level = level;
        this.numberOfAchievements = numberOfAchievements;
        this.image = image;
    }
}