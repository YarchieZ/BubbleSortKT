using TMPro;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField] private string[] names;
    [SerializeField] private TextMeshProUGUI nameText;
    [SerializeField] private TextMeshProUGUI healthText;
    [SerializeField] private TextMeshProUGUI levelText;
    public string Name {get; private set;}
    public int Health {get; private set;}
    public int Level {get; private set;}

    private void Start()
    {
        ChangeName(names[Random.Range(0, names.Length)]);
        ChangeHealth(Random.Range(1, 101));
        ChangeLevel(Random.Range(1, 10));
    }

    public void ChangeName(string value)
    {
        Name = value;
        nameText.text = Name;
    }

    public void ChangeHealth(int value)
    {
        Health = value;
        healthText.text = Health.ToString();
    }

    public void ChangeLevel(int value)
    {
        Level = value;
        levelText.text = Level.ToString();
    }
}
