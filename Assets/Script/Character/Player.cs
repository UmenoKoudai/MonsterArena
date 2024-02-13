using UnityEngine;
using static UnityEngine.Rendering.DebugUI;

[RequireComponent(typeof(Rigidbody))]
public class Player : CharaBase
{
    private void Awake()
    {
        FieldData.Instance.Player = this;
        BasePos = transform.position;
        Rb = GetComponent<Rigidbody>();
        HpBar.maxValue = Hp;
        HpBar.value = DefaultHp - Hp;
    }

    public override void Damage(int damage)
    {
        Hp -= (Defense - damage);
        DebugPrint("HP", Hp);
    }

    public override void AttackBuff(int value)
    {
        Attack += value;
        DebugPrint("Attack", Attack);
    }

    public override void DefenseBuff(int value)
    {
        Defense += value;
        DebugPrint("Defense", Defense);
    }

    public override void Recovery(int value)
    {
        Hp += value;
        DebugPrint("HP", Hp);
    }

    private void DebugPrint(string name, int value)
    {
        Debug.Log($"Now{name}{value}");
    }
}

