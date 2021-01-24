using UnityEngine;
using UnityEngine.EventSystems;

enum Direction { Up, None }
public class UIDrag : MonoBehaviour, IDragHandler, IEndDragHandler
{
    [SerializeField] Card card;
    [SerializeField] Direction direction;

    [SerializeField] FightManager fightManager;

    Vector2 _startPosition;

    void Start()
    {
        _startPosition = card.transform.position;
    }

    public void OnDrag(PointerEventData eventData)
    {
        Vector2 currentPos = eventData.pointerCurrentRaycast.screenPosition;

        switch (direction)
        {
            case Direction.Up:
                if (currentPos.y < _startPosition.y) currentPos.y = _startPosition.y;
                currentPos = new Vector2(_startPosition.x, currentPos.y);
                break;
            default:
                break;
        }
        card.transform.position = currentPos;
    }
    
    public void OnEndDrag(PointerEventData eventData)
    {
        card.transform.position = _startPosition;
        fightManager.Attack();
    }
}
