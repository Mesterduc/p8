[System.Serializable]
public class Friend {
    public string name;
    public int level;
    public int numberOfAchievements;
    public Friend(string name, int level, int numberOfAchievements) {
        this.name = name;
        this.level = level;
        this.numberOfAchievements = numberOfAchievements;
    }
}