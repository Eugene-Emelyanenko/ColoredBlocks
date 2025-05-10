using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using Random = UnityEngine.Random;

public class BankGenerator : MonoBehaviour
{
    public GameObject boxPrefab; // Префаб для банки
    public int rows = 35; // Количество строк
    public int columns = 6; // Количество столбцов
    public Vector2 startPos = new Vector2(-1.25f, 1.75f);
    public Vector2 spacing = new Vector2(0.5f, 0.73f);

    public int coloredRows = 5;
    public int coloredColumns = 6;

    [SerializeField] private Bank[,] banks = new Bank[35, 6];
    void Start()
    {
        GenerateBoxes();
        GenerateColors();
    }

    void GenerateBoxes()
    {
        for (int row = 0; row < rows; row++)
        {
            for (int col = 0; col < columns; col++)
            {
                // Вычислите позицию для каждой банки
                Vector2 position = startPos + new Vector2(col * spacing.x, -row * spacing.y);

                // Создайте экземпляр банки из префаба
                GameObject box = Instantiate(boxPrefab, position, Quaternion.identity);

                banks[row, col] = box.GetComponent<Bank>();
            }
        }
    }

    public void GenerateColors()
    {
        for (int row = 0; row < coloredRows; row++)
        {
            for (int col = 0; col < coloredColumns; col++)
            {
                banks[row, col]?.ChangeColor();
            }
        }
    }

    public void UnlockMore()
    {
        coloredRows += 5;
        GenerateColors();
    }
}

