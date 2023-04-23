class BankAccount{
    private decimal _balance;
    public BankAccount(decimal initialBalance){
        _balance = initialBalance;
    }
    public void Deposit(decimal amount){
        lock (this) {
            _balance += amount;
            Console.WriteLine($"Deposited: {amount}. New balance: {_balance}");
        }
    }
    public bool TryWithdraw(decimal amount) {
        lock (this){
            if (_balance >= amount) {
                _balance -= amount;
                Console.WriteLine($"Withdrew: {amount}. New balance: {_balance}");
                return true;
            }
            else {
                Console.WriteLine($"Failed to withdraw: {amount}. Insufficient balance: {_balance}");
                return false;
            }
        }
    }
}