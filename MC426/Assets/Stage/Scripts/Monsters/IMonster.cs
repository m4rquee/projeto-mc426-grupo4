public interface IMonster
{
    Health CurrentHealth { get; }
    float Velocity { get; }
    int CurrentLane { get; }

    // General functions
    void InitialSetup(int lane);
    void WalkForward();
    
    // Attack related functions
    bool IsTowerInRange();
    void PrepareForFirstAttack();
    void Attack();
    
    // Defense related functions
    void TakeDamage(int damage);
    void Die();
}
