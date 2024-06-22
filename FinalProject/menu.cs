class menu
{
    List<Goal> goalList = new List<Goal>();
    quickBalance balance = new quickBalance();

    List<transaction> transactions = new List<transaction>();
    categoryViewer category = new categoryViewer();
    financialGoal financailGoal = new financialGoal();
    lifetimeGoal lifetimeGoal = new lifetimeGoal();
    saveAndLoad saveAndLoad = new saveAndLoad();



    public void DisplayMenu()
    {

        string userChoice = "";

        while (userChoice != "8")
        {
            Console.Write("\nMenu options:\n 1. Quick Balance\n 2. Document Transaction\n 3. Category List\n 4. Create Goal \n 5. View Goals\n 6. Save\n 7. Load\n 8. Quit\n Select a choice from the menu: ");
            userChoice = Console.ReadLine();
            switch (userChoice)
            {

                case "1":
                    // View simple balance (quickBalance.cs)
                    balance.quickDisplay(transactions);

                    break;

                case "2":
                    // Document a transaction (transaction.cs)
                    Console.WriteLine("What is the title of your transaction? ");
                    string newTransactionName = Console.ReadLine();
                    Console.WriteLine("What category does this transaction fall under? ");
                    string newCategoryType = Console.ReadLine();
                    Console.WriteLine("What is the date of the transaction? ex MM/DD/YY");
                    string newTransactionDate = Console.ReadLine();
                    Console.WriteLine("What was the amount spent or received? *exclude $* ");
                    int newTransactionAmount = Convert.ToInt32(Console.ReadLine());
                    transaction transaction = new transaction();

                    transaction.transactionName = newTransactionName;
                    transaction.categoryType = newCategoryType;
                    transaction.transactionDate = newTransactionDate;
                    transaction.transactionAmount = newTransactionAmount;
                    transactions.Add(transaction);
                    break;

                case "3":
                    // view different categories and amount spent in the category (categoryViewer.cs)
                    Console.WriteLine("Would you like to view Income (1) or Spending (2)? ");
                    string categoryChoice = Console.ReadLine();
                    if (categoryChoice == "1"){
                        category.displayIncomeCategories(transactions);
                    }
                    else if (categoryChoice == "2") {
                        category.displaySpendingCategories(transactions);
                    }
                    else {
                        Console.WriteLine("Invalid Entry");
                    }


                    break;

                case "4":
                    // goal maker (goal.cs)
                    Console.WriteLine("What kind of goal would you like to make?\n");
                    Console.WriteLine("1. Financial Goal");
                    Console.WriteLine("2. Lifetime Goal");
                    Console.Write("\nSelect a choice: ");
                    string goalchoice = Console.ReadLine();
                    if (goalchoice == "1") {
                        financialGoal financialGoal = new financialGoal();
                        financialGoal.goalCreation();
                        goalList.Add(financialGoal);

                    }

                    else if (goalchoice == "2") {
                        lifetimeGoal lifetimeGoal = new lifetimeGoal();
                        lifetimeGoal.goalCreation();
                        goalList.Add(lifetimeGoal);
                    }
                    break;

                case "5":
                    // view goals
                    Console.Clear();
                    Console.WriteLine("\nCurrent Goals:");
                    foreach (var goal in goalList)
                    {
                        Console.WriteLine(goal.displayGoal());
                    }
                    Console.WriteLine("\nPress enter to continue: ");
                    Console.ReadLine();
                    Console.Clear();
                    break;
                    

                case "6":
                    // save
                    saveAndLoad.save(goalList, transactions);
                    break;

                case "7":
                    Console.WriteLine("What is the file name? ");
                    string fileName = Console.ReadLine();
                    fileName = fileName + ".txt";
                    transactions = saveAndLoad.loadTransaction(fileName);
                    goalList = saveAndLoad.loadGoal(fileName);
          
                    break;

                case "8":
                    Console.WriteLine("\nHave a great day!");
                    userChoice = "8";
                    break;

                default:
                    Console.WriteLine("\nInvalid Response \nSelect a choice from the menu");
                    break;
            }
        }
    }

}
