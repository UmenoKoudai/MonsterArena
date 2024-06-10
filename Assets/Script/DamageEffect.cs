using UnityEngine;
using UnityEngine.UI;

public class DamageEffect : MonoBehaviour
{
    [SerializeField, Tooltip("与えたダメージのテキスト")]
    private Text _damage;
    [SerializeField, Tooltip("オブジェクトを消す時間")]
    private float _interval = 1.0f;

    public void DamageDisplay(int damage)
    {
        _damage.text = damage.ToString();
        Destroy(gameObject, _interval);
    }
}
