using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System;

public class TileDetailPanel : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI tileIndex;
    [SerializeField] private TextMeshProUGUI tileState;
    private void OnEnable()
    {
        ObstacleManager.SelectedTile += SetData;
        ObstacleManager.DisableDetails += DisablePage;
    }


    private void OnDisable()
    {
        ObstacleManager.SelectedTile -= SetData;
        ObstacleManager.DisableDetails -= DisablePage;
    }
    private void DisablePage(bool state)
    {
        gameObject.SetActive(state);
    }

    private void SetData(Tile data)
    {
        gameObject.SetActive(true);
        tileIndex.text = data.tileIndex.ToString();
        tileState.text = data._TileState.ToString();
    }
        
}
