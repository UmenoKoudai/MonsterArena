using UnityEngine;

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
        Hp -= Mathf.Abs(damage - Defense);
        if(Mathf.Abs(damage - Defense) < 10)
        {
            DamageParticle[0].Play();
        }
        else if(Mathf.Abs(damage - Defense) < 20)
        {
            DamageParticle[1].Play();
        }
        else if(Mathf.Abs(damage - Defense) < 30)
        {
            DamageParticle[2].Play();
        }
        else
        {
            DamageParticle[3].Play();
        }
    }

    public override void AttackBuff(int value)
    {
        Attack += value;
        AttackBuffParticle.Play();
    }

    public override void DefenseBuff(int value)
    {
        Defense += value;
        DefenseBuffParticle.Play();
    }

    public override void Recovery(int value)
    {
        Hp += value;
        RecoveryParticle.Play();
    }
}

