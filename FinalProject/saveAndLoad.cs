using Microsoft.VisualBasic;

class saveAndLoad
{

    public void save(List<Goal> goalList, List<transaction> transactionList)
    {
        Console.WriteLine("What is the file name? ");
        string fileName = Console.ReadLine();
        fileName = fileName + ".txt";
        string stringToSave = "";
        foreach (transaction transaction in transactionList)
        {
            stringToSave += transaction.transactionSerialization();
            stringToSave += "\n";
        }
        stringToSave += "-";
        stringToSave += "\n";
        foreach (Goal goal in goalList)
        {
            stringToSave += goal.goalToString();
        }
        using (StreamWriter outputFile = new StreamWriter(fileName))


            outputFile.WriteLine(stringToSave);
    }

    public List<transaction> loadTransaction(string fileName)
    {
        string[] lines = System.IO.File.ReadAllLines(fileName);
        bool endOfTransactions = false;
        List<transaction> transactionsToLoad = new List<transaction>();
        foreach (string line in lines)
        {
            if (!endOfTransactions)
            {
                if (line == "-")
                {
                    endOfTransactions = true;
                }
                else
                {
                    string[] splitLine = line.Split(",");
                    transaction newTransaction = new transaction();
                    newTransaction.transactionName = splitLine[0];
                    newTransaction.categoryType = splitLine[1];
                    newTransaction.transactionDate = splitLine[2];
                    newTransaction.transactionAmount = Convert.ToSingle(splitLine[3]);
                    transactionsToLoad.Add(newTransaction);
                }

            }
        }
        return transactionsToLoad;
    }

    public List<Goal> loadGoal(string fileName)
    {
        string[] lines = System.IO.File.ReadAllLines(fileName);
        bool startOfGoals = false;
        List<Goal> goalsToLoad = new List<Goal>();
        foreach (string line in lines)
        {
            if (startOfGoals)
            {

                string[] splitLine = line.Split(",");
                if (splitLine[0] == "FinancialGoal")
                {
                    financialGoal newGoal = new financialGoal();
                    newGoal.goalType = splitLine[0];
                    newGoal.goalName = splitLine[1];
                    newGoal.description = splitLine[2];
                    goalsToLoad.Add(newGoal);
                }
                else if (splitLine[0] == "LifetimeGoal")
                {
                    lifetimeGoal newGoal = new lifetimeGoal();
                    newGoal.goalType = splitLine[0];
                    newGoal.goalName = splitLine[1];
                    newGoal.description = splitLine[2];
                    newGoal.goalImportance = splitLine[3];
                    goalsToLoad.Add(newGoal);
                }

            }
            if (line == "-")
            {
                startOfGoals = true;
            }
        }
        return goalsToLoad;
    }
}

