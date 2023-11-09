namespace Trybank.Lib;

public class TrybankLib
{
    public bool Logged;
    public int loggedUser;

    //0 -> Número da conta
    //1 -> Agência
    //2 -> Senha
    //3 -> Saldo
    public int[,] Bank;
    public int registeredAccounts;
    private int maxAccounts = 50;

    public TrybankLib()
    {
        loggedUser = -99;
        registeredAccounts = 0;
        Logged = false;
        Bank = new int[maxAccounts, 4];
    }

    // 1. Construa a funcionalidade de cadastrar novas contas
    public void RegisterAccount(int number, int agency, int pass)
    {
        if (registeredAccounts >= maxAccounts)
        {
            throw new InvalidOperationException("Limite de contas atingido!");
        }

        for (int index = 0; index < registeredAccounts; index++)
        {
            if (Bank[index, 0] == number && Bank[index, 1] == agency)
            {
                throw new ArgumentException("A conta já está sendo usada!");
            }
        }

        int nextAvailableIndex = registeredAccounts;

        Bank[nextAvailableIndex, 0] = number;
        Bank[nextAvailableIndex, 1] = agency;
        Bank[nextAvailableIndex, 2] = pass;
        Bank[nextAvailableIndex, 3] = 0;

        registeredAccounts++;
    }

    // 2. Construa a funcionalidade de fazer Login
    public void Login(int number, int agency, int pass)
    {
        if (Logged)
        {
            throw new AccessViolationException("Usuário já está logado");
        }

        bool userFound = false;
        int userIndex = -1;

        for (int index = 0; index < registeredAccounts; index++)
        {
            if (Bank[index, 0] == number && Bank[index, 1] == agency)
            {
                userFound = true;
                userIndex = index;
                break;
            }
        }

        if (!userFound)
        {
            throw new ArgumentException("Agência + Conta não encontrada");
        }

        if (Bank[userIndex, 2] == pass)
        {
            Logged = true;
            loggedUser = userIndex;
        }
        else
        {
            throw new ArgumentException("Senha incorreta");
        }
    }

    // 3. Construa a funcionalidade de fazer Logout
    public void Logout()
    {
        if (!Logged)
        {
            throw new AccessViolationException("Usuário não está logado");
        }

        Logged = false;
        loggedUser = -99;
    }

    // 4. Construa a funcionalidade de checar o saldo
    public int CheckBalance()
    {
        if (!Logged)
        {
            throw new AccessViolationException("Usuário não está logado");
        }

        int balance = Bank[loggedUser, 3];

        return balance;
    }

    // 5. Construa a funcionalidade de depositar dinheiro
    public void Deposit(int value)
    {
        throw new NotImplementedException();
    }

    // 6. Construa a funcionalidade de sacar dinheiro
    public void Withdraw(int value)
    {
        throw new NotImplementedException();
    }

    // 7. Construa a funcionalidade de transferir dinheiro entre contas
    public void Transfer(int destinationNumber, int destinationAgency, int value)
    {
        throw new NotImplementedException();
    }

   
}
