using System;
using UnityEngine;

public class MeleeMonsterAnimationController : MonoBehaviour
{
    [SerializeField] private Animator _animator;
    private static readonly int Attack = Animator.StringToHash("Attack");
    private static readonly int PrepareForFirstAttack = Animator.StringToHash("PrepareForFirstAttack");
    private static readonly int Dying = Animator.StringToHash("Dying");
    private static readonly int Walking = Animator.StringToHash("Walking");

    private Action _currentCallback;

    public void PlayAttackAnimation(Action callback = null)
    {
        _animator.SetBool(Walking, false);
        _animator.SetTrigger(Attack);
        _currentCallback = callback;
    }
    
    public void PlayPrepareForFirstAttackAnimation(Action callback = null)
    {
        _animator.SetBool(Walking, false);
        _animator.SetTrigger(PrepareForFirstAttack);
        _currentCallback = callback;
    }
    
    public void PlayDieAnimation(Action callback = null)
    {
        _animator.SetBool(Walking, false);
        _animator.SetTrigger(Dying);
        _currentCallback = callback;
    }
    
    public void PlayWalkingAnimation(Action callback = null)
    {
        _animator.SetBool(Walking, true);
        _currentCallback = callback;
    }

    // function called by animation
    public void ExecuteCallback()
    {
        _currentCallback?.Invoke();
        _currentCallback = null;
    }
}
