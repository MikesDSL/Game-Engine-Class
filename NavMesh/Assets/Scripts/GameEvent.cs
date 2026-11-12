using UnityEngine;

public enum EventType
{
    Invalid = 0,
    TargetUpdated
}
public class GameEvent
{
    protected GameEvent(EventType eType)
    {
        this.eventType = eType;
    }
    
    private EventType eventType = EventType.Invalid;
    public EventType GetEventType() { return eventType; }
}

public class TargetUpdatedEvent : GameEvent
{
    public TargetUpdatedEvent() : base(EventType.TargetUpdated)
    { }

    public Vector3 position = Vector3.zero;
}