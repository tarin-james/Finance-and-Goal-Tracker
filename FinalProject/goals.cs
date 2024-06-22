public abstract class Goal
{
    public string goalName;
    public string description;
    public string goalList;
    public string goalImportance;
    public string goalType;
    public abstract void goalCreation();
    public abstract void AutomaticLoad(string automaticAddToList);
    public abstract string displayGoal();
    public abstract string goalToString();

}