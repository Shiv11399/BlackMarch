using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public enum State
{
    Static = 0,
    Moving = 1,
}
public class Player : MonoBehaviour,AI
{
    private  State currState = State.Static;
    private  Vector3 currDestination;
    private float speedMultiplier = 1.6f;

    public State CurrState { get => currState; set => currState = value; }
    public Vector3 CurrDestination { get => currDestination; set => currDestination = value; }
    public float SpeedMultiplier { get => speedMultiplier; set => speedMultiplier = value; }

    public void MoveTo(Transform target)
    {
        CurrDestination = target.position+ Vector3.up;
        ChangeState(State.Moving);
    }
    private void Update()
    {
        if (CurrState == State.Static) return;
        if (transform.position == CurrDestination) ChangeState(State.Static);

        transform.position = Vector3.Lerp(transform.position, CurrDestination, Time.deltaTime * SpeedMultiplier);
    }
    public void ChangeState(State state)
    {
        if(CurrState != state)
        {
            CurrState = state;
        }
        
    }
}
