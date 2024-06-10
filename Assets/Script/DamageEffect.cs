using UnityEngine;
using UnityEngine.UI;

public class DamageEffect : MonoBehaviour
{
    [SerializeField, Tooltip("�^�����_���[�W�̃e�L�X�g")]
    private Text _damage;
    [SerializeField, Tooltip("�I�u�W�F�N�g����������")]
    private float _interval = 1.0f;

    public void DamageDisplay(int damage)
    {
        _damage.text = damage.ToString();
        Destroy(gameObject, _interval);
    }
}
