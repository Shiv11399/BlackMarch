using UnityEngine;
public interface AI
{
    State CurrState { get; set; }
    Vector3 CurrDestination { get; set; }
    float SpeedMultiplier { get; set; }

    public void MoveTo(Transform target);
    public void ChangeState(State state);
}