
public class financialGoal : Goal
{
    public string goalType = "FinancialGoal";
    public override void goalCreation()
    {
        Console.Write("What is the name of your goal? ");
        goalName = Console.ReadLine();
        Console.Write("What do you hope to accompish with this goal? ");
        description = Console.ReadLine();

        goalList = goalType + goalName + "," + description;
    }

    public override void AutomaticLoad(string automaticAddToList)
    {
        List<string> dataList = new List<string>();
        string[] splitValues = { ",", ":" };
        string[] splitData = automaticAddToList.Split(splitValues, StringSplitOptions.RemoveEmptyEntries);
        foreach (var word in splitData)
        {
            dataList.Add(word);
        }
        goalType = splitData[0];
        goalName = splitData[1];
        description = splitData[2];
      

        goalList = goalType + "," + goalName + "," + description;
    }


    public override string displayGoal()
    {
        return $"{goalType} {goalName} ({description})";
    }

    public override string goalToString()
    {
        return $"{goalType},{goalName},{description}\n";
    }

}