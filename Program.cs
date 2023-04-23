using System;
using System.Threading;
class Program{
    static void Main(){
        BankAccount account = new BankAccount(1000);
        Thread[] depositThreads = new Thread[4];
        Thread[] withdrawThreads = new Thread[5];

        for (int i = 0; i < depositThreads.Length; i++){
            depositThreads[i] = new Thread(() =>{
                while (true) {
                    account.Deposit(100);
                    Thread.Sleep(1000);
                }
            });
            depositThreads[i].Start();
        }

        for (int i = 0; i < withdrawThreads.Length; i++){
            withdrawThreads[i] = new Thread(() => {
                while (true){
                    account.TryWithdraw(100);
                    Thread.Sleep(1000);
                }
            });
            withdrawThreads[i].Start();
        }
        Thread.Sleep(Timeout.Infinite);
    }
}
