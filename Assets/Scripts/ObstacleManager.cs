using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class ObstacleManager : MonoBehaviour
{
    private Transform oldSelection;
    [SerializeField] private string Tag;
    [SerializeField] Material HighLightedMaterial;
    [SerializeField] GameObject Obstacle;
    [SerializeField] Material DefaultMaterial;
    public GridMapObj gridMap;
    public static UnityAction<Tile> SelectedTile;
    public static UnityAction<bool> DisableDetails;
    public static ObstacleManager Instance;


    private void OnEnable()
    {
        TileSwitch.MakeObstacle += ObsticleSwitch;
    }
    private void OnDisable()
    {
        TileSwitch.MakeObstacle -= ObsticleSwitch;
    }
    private void Awake()
    {
        Instance = this;
    }
    private void Start()
    {
        foreach (int i in gridMap.gridMap)
        {
            ObsticleSwitch(true, i);
        }
    }

    private void Update()
    {

       
        if(oldSelection != null)
        {
            oldSelection.GetComponent<Renderer>().material = DefaultMaterial;
        }
        var ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;
        if(Physics.Raycast(ray,out hit))
        {
            var selection = hit.transform;
            var selectionRenderer = selection.GetComponent<Renderer>();
            var selectionTile = selection.GetComponent<Tile>();
            //if (!selection.CompareTag(Tag)) return;
            if(selectionRenderer != null)
            {
                selectionRenderer.material = HighLightedMaterial;
                oldSelection = selection;
                if(selectionTile != null){
                    SelectedTile?.Invoke(selectionTile);
                }
            }
            if (Input.GetMouseButtonDown(0))
            {
                if (selection != null)
                {
                    GridManager.Instance.SpawnPlayerAt(selectionTile?.transform);
                }
        }

        }
    }
    private void ObsticleSwitch(bool state, int index)
    {
        var _row = index / 10;
        var _colum = index % 10;
        if (state)
        {
            
            var tile = GridManager.Instance._WholeGrid[_row, _colum].GetComponent<Tile>();
            tile._TileState = TileState.ObsticleON;
            var Obs = Instantiate(Obstacle, tile.transform.position,tile.transform.rotation);
            tile.Obstacle = Obs;
            if (!gridMap.gridMap.Contains(index))
            {
                gridMap.gridMap.Add(index);
            }
        }
        else
        {
            var tile = GridManager.Instance._WholeGrid[_row, _colum].GetComponent<Tile>();
            tile._TileState = TileState.ObsticleOFF;
            Destroy(tile.Obstacle);
            gridMap.gridMap.Remove(index);
        }
    }

}

   