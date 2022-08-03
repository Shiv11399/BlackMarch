using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour, AI
{
    private State currState = State.Static;
    private Vector3 currDestination;
    private float speedMultiplier = 0.8f;
    private float _TargetDistance = 1.8f;
    [SerializeField] Animator animator;
    public State CurrState { get => currState; set => currState = value; }
    public Vector3 CurrDestination { get => currDestination; set => currDestination = value; }
    public float SpeedMultiplier { get => speedMultiplier; set => speedMultiplier = value; }

    public void ChangeState(State state)
    {
        if (CurrState != state)
        {
            CurrState = state;
            switch (state)
            {
                case State.Static:
                    animator.SetBool("Walking", false);
                    break;
                case State.Moving:
                    animator.SetBool("Walking", true);
                    break;
            }
        }
    }

    public void MoveTo(Transform target)
    {
        CurrDestination = target.position + Vector3.up;
        ChangeState(State.Moving);
    }
    private void Update()
    {
        if (CurrState == State.Static) return;
 

        if(Vector3.Distance(transform.position,CurrDestination) < _TargetDistance) ChangeState(State.Static);
        transform.position = Vector3.Lerp(transform.position, CurrDestination, Time.deltaTime * SpeedMultiplier);
    }
}
