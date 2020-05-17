using UnityEngine;

public class MeleeMonsterController : MonoBehaviour, IMonster
{
    [SerializeField] private Rigidbody2D _rigidBody;
    [SerializeField] private float _velocity;
    [SerializeField] private Health _currentHealth;
    [SerializeField] private MeleeMonsterAnimationController _animatorController;
    private readonly StateMachine _monsterStateMachine = new StateMachine();

    enum MeleeMonsterState
    {
        Walking = 0,
        PreparingFirstAttack,
        Attacking,
        Dying
    }

    public Health CurrentHealth => _currentHealth;
    public float Velocity => _velocity;
    public int CurrentLane { get; private set; }

    public void InitialSetup(int lane)
    {
        CurrentLane = lane;
        SetupStateMachine();
        WalkForward();
        _currentHealth.Setup(() => _monsterStateMachine.TransitTo((int)MeleeMonsterState.Dying));
    }

    void SetupStateMachine()
    {
        _monsterStateMachine.AddState((int)MeleeMonsterState.Walking);
        _monsterStateMachine.AddState((int)MeleeMonsterState.PreparingFirstAttack);
        _monsterStateMachine.AddState((int)MeleeMonsterState.Attacking);
        _monsterStateMachine.AddState((int)MeleeMonsterState.Dying);
        
        _monsterStateMachine.AddStateTransition((int)MeleeMonsterState.Walking,
            (int)MeleeMonsterState.PreparingFirstAttack, PrepareForFirstAttack);
        _monsterStateMachine.AddStateTransition((int)MeleeMonsterState.PreparingFirstAttack,
            (int)MeleeMonsterState.Attacking, Attack);
        _monsterStateMachine.AddStateTransition((int)MeleeMonsterState.PreparingFirstAttack,
            (int)MeleeMonsterState.Walking, WalkForward);
        _monsterStateMachine.AddStateTransition((int)MeleeMonsterState.Attacking,
            (int)MeleeMonsterState.Walking, WalkForward);
        _monsterStateMachine.AddStateTransition((int)MeleeMonsterState.Attacking,
            (int)MeleeMonsterState.Dying, Die);
        _monsterStateMachine.AddStateTransition((int)MeleeMonsterState.Walking,
            (int)MeleeMonsterState.Dying, Die);
        _monsterStateMachine.AddStateTransition((int)MeleeMonsterState.PreparingFirstAttack,
            (int)MeleeMonsterState.Dying, Die);
    }

    public void WalkForward()
    {
        _rigidBody.AddForce(Vector2.left * Velocity);
    }

    public bool IsTowerInRange()
    {
        // TODO: Preciso saber como está populada a matriz inteira
        _monsterStateMachine.TransitTo((int)MeleeMonsterState.PreparingFirstAttack);
        return true;
    }

    public void PrepareForFirstAttack()
    {
        _animatorController.PlayPrepareForFirstAttackAnimation(() =>
        {
            _monsterStateMachine.TransitTo((int)MeleeMonsterState.Attacking);
        });
        _rigidBody.velocity = Vector2.zero;
    }

    public void Attack()
    {
        _animatorController.PlayAttackAnimation(() =>
        {
            _monsterStateMachine.TransitTo((int)MeleeMonsterState.Attacking);
        });
    }

    public void TakeDamage(int damage)
    {
        _currentHealth.TakeDamage(damage);
    }

    public void Die()
    {
        _animatorController.PlayDieAnimation(() =>
        {
            Destroy(gameObject);
        });
    }
}
