using System;
using System.Globalization;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class EnemyChanger : MonoBehaviour
{
    [SerializeField] private Button healthFilterBtn;
    [SerializeField] private TMP_InputField healthFilterInput;
    [SerializeField] private Button levelFilterBtn;
    [SerializeField] private TMP_InputField levelFilterInput;
    [SerializeField] private Button enableAllBtn;
    [SerializeField] private TMP_InputField makeBossInput;
    [SerializeField] private Button makeBossBtn;
    [SerializeField] private Enemy[] enemies;

    private void Start()
    {
        healthFilterBtn.onClick.AddListener(HealthFilter);
        levelFilterBtn.onClick.AddListener(LevelFilter);
        enableAllBtn.onClick.AddListener(EnableAll);
        makeBossBtn.onClick.AddListener(MakeBoss);
    }

    private void HealthFilter()
    {
        if (healthFilterInput.text == "") return;
        foreach (Enemy enemy in enemies)
        {
            if (enemy.Health < int.Parse(healthFilterInput.text))
            {
                enemy.gameObject.SetActive(false);
            }
        }
    }

    private void LevelFilter()
    {
        if (levelFilterInput.text == "") return;
        foreach (Enemy enemy in enemies)
        {
            if (enemy.Level != int.Parse(levelFilterInput.text))
            {
                enemy.gameObject.SetActive(false);
            }
            
        }
    }

    private void EnableAll()
    {
        foreach (Enemy enemy in enemies)
        {
            enemy.gameObject.SetActive(true);
        }
        healthFilterInput.text = "";
        levelFilterInput.text = "";
    }

    private void MakeBoss()
    {
        foreach (Enemy enemy in enemies)
        {
            if (enemy.Name == makeBossInput.text)
            {
                enemy.gameObject.SetActive(true);
                enemy.ChangeName("Boss");
                enemy.ChangeLevel(enemy.Level + 1);
                enemy.ChangeHealth(enemy.Health * 3);
                enemy.gameObject.GetComponent<Renderer>().material.color = Color.red;
            }
        }
    }

    private void OnDisable()
    {
        levelFilterBtn.onClick.RemoveAllListeners();
        healthFilterBtn.onClick.RemoveAllListeners();
        enableAllBtn.onClick.RemoveAllListeners();
        makeBossBtn.onClick.RemoveAllListeners();
    }



}
