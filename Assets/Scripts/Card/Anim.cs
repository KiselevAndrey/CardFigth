using UnityEngine;

public class Anim : MonoBehaviour
{
    [SerializeField] PlayerManager playerManager;

    public void StartCurrentCardAnim(string animName)
    {
        playerManager.StartCurrentCardAnim(animName);
    }

    public void ReplaceCard()
    {
        playerManager.ReplaceCard(GetComponent<Card>());
    }
}
