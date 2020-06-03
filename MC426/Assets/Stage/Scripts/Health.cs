using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Health : MonoBehaviour
{
	[SerializeField] private int _maxHealth = 100;
	[Range(0, 1)] [SerializeField] private float _currentHealthPercentage;

	private Action _onLifeEnds;

	public int MaxHealth => _maxHealth;
	public int CurrentHealth => (int)Math.Ceiling(_currentHealthPercentage * _maxHealth);

	public void Setup(Action onLifeEnds)
	{
		_onLifeEnds = onLifeEnds;
	}

	public void TakeDamage(int amount)
	{
		_currentHealthPercentage = Mathf.Lerp(0, _maxHealth, CurrentHealth - amount);
		if (CurrentHealth == 0)
		{
			_onLifeEnds?.Invoke();
		}
    }
}