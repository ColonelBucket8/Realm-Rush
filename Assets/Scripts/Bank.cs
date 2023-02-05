using UnityEngine;

public class Bank : MonoBehaviour
{
    [SerializeField] private int startingBalance = 150;

    public int CurrentBalance { get; private set; }

    private void Awake()
    {
        CurrentBalance = startingBalance;
    }

    public void Deposit(int amount)
    {
        CurrentBalance += Mathf.Abs(amount);
    }

    public void Withdraw(int amount)
    {
        CurrentBalance -= Mathf.Abs(amount);
    }
}