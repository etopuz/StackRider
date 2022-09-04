using TMPro;
using UnityEngine;
using UnityEngine.PlayerLoop;

public class GameStatsUI : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI gemCountText;

    public void SetGemText(int amount)
    {
        gemCountText.text = amount.ToString();
    }
}
