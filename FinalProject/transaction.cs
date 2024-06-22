class transaction {
    public string transactionName = "";
    public float transactionAmount = 0;
    public string categoryType = "";
    public string transactionDate = "";
    public string transactionDetails = "";

    public string transactionSerialization() {
       string transactionDetails =  transactionName + "," + categoryType + "," + transactionDate + "," + transactionAmount;
       return transactionDetails;
    }
}

/* 
{
    transactionName = something,
    transactionAmount = something,
    etc.
}
*/