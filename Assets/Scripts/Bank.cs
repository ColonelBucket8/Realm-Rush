using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Bank : MonoBehaviour
{
    [SerializeField] private int startingBalance = 150;
    [SerializeField] private TextMeshProUGUI goldText;

    public int CurrentBalance { get; private set; }

    private void Awake()
    {
        CurrentBalance = startingBalance;
        UpdateDisplay();
    }

    private void UpdateDisplay()
    {
        goldText.text = "Gold: " + CurrentBalance;
    }

    public void Deposit(int amount)
    {
        CurrentBalance += Mathf.Abs(amount);
        UpdateDisplay();
    }

    public void Withdraw(int amount)
    {
        CurrentBalance -= Mathf.Abs(amount);
        UpdateDisplay();
        if (CurrentBalance < 0)
            // lose the game
            ReloadScene();
    }

    private static void ReloadScene()
    {
        Scene currentScene = SceneManager.GetActiveScene();
        SceneManager.LoadScene(currentScene.buildIndex);
    }
}