using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;
using TMPro;

public class TileSwitch : MonoBehaviour
{
   public TextMeshProUGUI toggleLabel;
   private Toggle _toggle;
   public int switchIndex;
    public static UnityAction<bool,int> MakeObstacle;
    private void Awake()
    {
        _toggle = this.GetComponent<Toggle>();
    }
    private void Start()
    {
        _toggle.onValueChanged.AddListener(SetState);
    }
    void SetState(bool state)
    {
        MakeObstacle?.Invoke(state, switchIndex);
    }
    public void TurnOn()
    {
        _toggle.isOn = true;
    }
}
