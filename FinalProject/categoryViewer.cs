

class categoryViewer
{

    public void displayIncomeCategories(List<transaction> transactionList)
    {
        Console.WriteLine("\nIncome Category List: \n");
        foreach (transaction transaction in transactionList)
        {
            if (transaction.transactionAmount > 0)
            {
                Console.WriteLine($"{transaction.transactionDate} - {transaction.categoryType} + {transaction.transactionAmount}");
            }
        }
    }

    public void displaySpendingCategories(List<transaction> transactionList)
    {
        Console.WriteLine("\nSpending Category List: \n");
        foreach (transaction transaction in transactionList)
        {
            if (transaction.transactionAmount < 0)
            {
                Console.WriteLine($"{transaction.transactionDate} - {transaction.categoryType} {transaction.transactionAmount}");
            }
        }

    }
}