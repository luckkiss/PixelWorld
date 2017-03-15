﻿using UnityEngine;
using System.Collections;

public enum CharaterState {
	IDLE=0,
	IDLE2,
	RUN,
	JUMP,
	ATTACK,
	ATTACK1_1,
	ATTACK1_2,
	ATTACK1_3,
	ATTACK2,
	ATTACK3,
	HIT,
	DEATH,
}

public class Character : MonoBehaviour {

	public float Speed {get; set;}

	//动画组件
	protected Animator m_Animator;

	protected CharaterState m_CharacterState;
	public CharaterState CharcterState {get{return m_CharacterState;}}

	void Awake() {
		m_Animator = GetComponentInChildren<Animator>();

	}

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public virtual void ActIdle() {
		m_CharacterState = CharaterState.IDLE;
		m_Animator.CrossFade ("idle", 0);
	}
	public virtual void ActRun() {
		m_CharacterState = CharaterState.RUN;
		m_Animator.CrossFade ("run", 0);
	}
	public virtual void ActAttack() {
		m_CharacterState = CharaterState.ATTACK;
		m_Animator.CrossFade ("attack", 0);
	}
}