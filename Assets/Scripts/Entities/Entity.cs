using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(SpriteRenderer))]
[RequireComponent(typeof(Animator))]
public abstract class Entity : MonoBehaviour
{
	protected SpriteRenderer spriteRenderer;
	protected Animator animator;
	public EntityAsset entityAsset { get; private set; }

	public Team owner { get; private set; } 

	public int health { get; private set; }

	public event EventHandler<int> HealthUpdated;

	protected virtual void Start ()
    {
		if (entityAsset == null)
			throw new ArgumentException($"{nameof(entityAsset)} is not defined!");

		health = entityAsset.health;

		this.spriteRenderer = GetComponent<SpriteRenderer>();
		animator = GetComponent<Animator>();
		spriteRenderer.sprite = entityAsset.sprite;
	}
	
	protected virtual void Update ()
    {
		
	}

	public void Damage(int amount)
	{
		var newHp = health - amount;
		if (newHp < 0)
			newHp = 0;
		HealthUpdated?.Invoke(this, newHp);

		health = newHp;
		if (health <= 0)
			Kill();
	}

	public virtual void Kill()
	{
		EntityManager.instance.Kill(this);

	}

	internal void PlayDeathAnimation()
	{
		animator.Play("Explosion");
	}

	internal void Initiate(EntityAsset asset, Team owner)
	{
		this.entityAsset = asset;
		this.owner = owner;
	}
}
