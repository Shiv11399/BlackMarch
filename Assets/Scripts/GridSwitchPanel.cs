using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GridSwitchPanel : MonoBehaviour
{
    [SerializeField] private GridManager gridManager;
    [SerializeField] private TileSwitch tileSwitch;
    private int _row;
    private int _colum;

    private void Awake()
    {
        _row = gridManager.GridLength;
        _colum = gridManager.GridWidth;
    }
    private void Start()
    {
        int count = 0;
        for (int i = 0; i < _row; i++)
        {
            for (int j = 0; j < _colum; j++)
            {
                var _switch = Instantiate(tileSwitch, transform);
                _switch.toggleLabel.text = count.ToString();
                _switch.GetComponent<TileSwitch>().switchIndex = count;
                if (ObstacleManager.Instance.gridMap.gridMap.Contains(count))
                {
                    _switch.TurnOn();
                }
                count++;
            }
        }
    }
}
