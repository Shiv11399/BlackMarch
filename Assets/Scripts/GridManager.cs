using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class GridManager : MonoBehaviour
{
    [SerializeField] private GameObject Tile;
    [SerializeField] public int GridLength;
    [SerializeField] public int GridWidth;
    [SerializeField] private float TileDiff;
    [SerializeField] private GameObject playerPrefab;
    [SerializeField] private GameObject enemyPrefab;

    public GameObject[,] _WholeGrid;
    public static GridManager Instance;
    private void Awake()
    {
        Instance = this;
        _WholeGrid = new GameObject[GridLength, GridWidth];
       
        GenerateGrid();
    }

    private void GenerateGrid()
    {
        int count = 0;
        var pos = Vector3.zero;
        for (int i = 0; i < GridLength; i++)
        {
            for (int j = 0; j < GridWidth; j++)
            {
               var _Block = Instantiate(Tile, new Vector3(pos.x + (TileDiff * i), pos.y, pos.z + (TileDiff * j)), Quaternion.identity);
               _Block.name = "Tile" + (count).ToString();
                _Block.GetComponent<Tile>().tileIndex = count;
                _WholeGrid[i, j] = _Block;
               count++;
            }
        }
    }
    public void SpawnPlayerAt(Transform target)
    {
        var _spawnPosition = _WholeGrid[9, UnityEngine.Random.Range(0,10)].transform;
        var player = Instantiate(playerPrefab, _spawnPosition.position+Vector3.up, _spawnPosition.rotation);// we have to add some offset here.....
        player.GetComponent<AI>().MoveTo(target);
        StartCoroutine(SpawnEnemyCo(target));

    }
    IEnumerator SpawnEnemyCo(Transform target)
    {
        yield return new WaitForSeconds(5);
        SpawnEnemy(target);
    }
    public void SpawnEnemy(Transform target)
    {
        var _spawnPosition = _WholeGrid[0, 5].transform;
        var enemy = Instantiate(enemyPrefab, _spawnPosition.position + Vector3.up, _spawnPosition.rotation);
        enemy.GetComponent<AI>().MoveTo(target);
    }

}
