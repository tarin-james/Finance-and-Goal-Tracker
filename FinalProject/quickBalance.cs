using System.Diagnostics.Metrics;
using System.Transactions;

class quickBalance : transaction
{

    public float totalBalance = 0;

    private void computeBalance(List<transaction> transactionList)
    {
        float counter = 0;
        foreach (transaction transaction in transactionList)
        {
           counter += transaction.transactionAmount;
        }
        totalBalance = counter;
    }
    public void quickDisplay(List<transaction> transactionList) {
        computeBalance(transactionList);
        Console.WriteLine($"${totalBalance}");
    }
}