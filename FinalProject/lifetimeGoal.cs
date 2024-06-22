public  class lifetimeGoal : Goal
{
    public string goalType = "LifetimeGoal"; 
    public override void goalCreation()
    {
        Console.Write("What is the name of your goal? ");
        goalName = Console.ReadLine();
        Console.Write("What is a short description of your goal? ");
        description = Console.ReadLine();
        Console.Write("On a scale from 1 - 10, how important is this goal to you? ");
        goalImportance = Console.ReadLine();
        goalList =  goalType + "," + goalName + "," + description + "," + goalImportance;
    }
    public override void AutomaticLoad(string automaticAddToList)
    {   
        List<string> dataList = new List<string>(); 
        string[] splitValues = {"," , ":"};
        string[] splitData = automaticAddToList.Split(splitValues, StringSplitOptions.RemoveEmptyEntries);
        foreach (var word in splitData){
            dataList.Add(word);
        }
        goalType = splitData[0];
        goalName = splitData[1];
        description = splitData[2];
        goalImportance = splitData[3];

        goalList = goalType + "," + goalName + "," + description + "," + goalImportance;
    }
    

    public override string goalToString()
    {
        return  $"{goalType},{goalName},{description},{goalImportance}";
    }
        public override string displayGoal()
    {
        return  $"{goalType} {goalName} ({description}) {goalImportance}/10";
    }

  

}