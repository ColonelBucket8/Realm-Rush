using UnityEngine;

public class Tower : MonoBehaviour
{
    [SerializeField] private int cost = 75;

    public bool CreateTower(Tower tower, Vector3 transformPosition)
    {
        var bank = FindObjectOfType<Bank>();

        if (bank == null) return false;

        if (bank.CurrentBalance >= cost)
        {
            Instantiate(tower,
                transformPosition,
                Quaternion.identity);
            bank.Withdraw(cost);
            return true;
        }

        return false;
    }
}