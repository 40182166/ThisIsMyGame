using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BaseCharacterClass
{

	private int str = 0;
	private int agi = 0;
	private int intell = 0;
	private int vit = 0;

	public enum mainStat
	{
		STR_MAIN,
		INT_MAIN,
		AGI_MAIN}

	;

	private float _phys_dmg;
	private float _base_phys_dmg;
	private float _magic_dmg;
	private float _base_magic_dmg;
	private float _phys_def;
	private float _base_phys_def;
	private float _magic_def;
	private float _base_magic_def;
	private float _crit_dmg;
	private float _base_crit_dmg;
	private float _crit_chance;
	private float _base_crit_chance;
	private float _dodge_chance;
	private float _base_dodge_chance;
	private float _stun_chance;
	private float _base_stun_chance;
	private float _stun_resist;
	private float _base_stun_resist;
	private float _hp;
	private float _base_hp;

	private mainStat thisMain;

	public BaseCharacterClass (mainStat _main)
	{
		thisMain = _main;
	}

	public int STR {
		get { return str; }
		set {
			str = value;
			if (thisMain == mainStat.STR_MAIN) {
				Phys_dmg = str * 1.0f;
			}

			if (thisMain != mainStat.INT_MAIN) {
				Crit_dmg = str * 10.0f;
			}
			Stun_chance = (str * 2.0f) / 100.0f;
		}
	}

	public int AGI {
		get { return agi; }
		set {
			agi = value;
			if (thisMain == mainStat.AGI_MAIN) {
				Phys_dmg = agi * 1.0f;
			}

			Crit_chance = (agi * 3.0f) / 100.0f;
			Dodge_chance = (agi * 2.5f) / 100.0f;
		}
	}

	public int INT {
		get { return intell; }
		set {
			intell = value;
			if (thisMain == mainStat.INT_MAIN) {
				Magic_dmg = intell * 1.0f;
				Crit_dmg = intell * 10.0f;
			}
			Magic_def = intell * 0.30f;
		}
	}

	public int VIT {
		get { return vit; }
		set {
			vit = value;
			HP = vit * 10.0f;
			Phys_def = vit * 0.30f;
			Stun_resist = (vit * 2.0f) / 100.0f;
		}
	}

	public float Phys_dmg {
		get { return _phys_dmg; }
		set { _phys_dmg = value; }
	}

	public float Base_phys_dmg {
		get { return _base_phys_dmg; }
		set { _base_phys_dmg = value; }
	}

	public float Stun_chance {
		get { return _stun_chance; }
		set { _stun_chance = value; }
	}

    public float Base_stun_chance
    {
        get { return _base_stun_chance; }
        set { _base_stun_chance = value; }
    }

    public float Crit_dmg {
		get { return _crit_dmg; }
		set { _crit_dmg = value; }
	}

    public float Base_crit_dmg
    {
        get { return _base_crit_dmg; }
        set { _base_crit_dmg = value; }
    }

    public float HP {
		get { return _hp; }
		set { _hp = value; }
	}

    public float Base_HP
    {
        get { return _base_hp; }
        set { _base_hp = value; }
    }

    public float Phys_def {
		get { return _phys_def; }
		set { _phys_def = value; }
	}

    public float Base_phys_def
    {
        get { return _base_phys_def; }
        set { _base_phys_def = value; }
    }

    public float Stun_resist {
		get { return _stun_resist; }
		set { _stun_resist = value; }
	}

    public float Base_stun_resist
    {
        get { return _base_stun_resist; }
        set { _base_stun_resist = value; }
    }

    public float Crit_chance {
		get { return _crit_chance; }
		set { _crit_chance = value; }
	}

    public float Base_crit_chance
    {
        get { return _base_crit_chance; }
        set { _base_crit_chance = value; }
    }

    public float Dodge_chance {
		get { return _dodge_chance; }
		set { _dodge_chance = value; }
	}

    public float Base_dodge_chance
    {
        get { return _base_dodge_chance; }
        set { _base_dodge_chance = value; }
    }

    public float Magic_dmg {
		get { return _magic_dmg; }
		set { _magic_dmg = value; }
	}

	public float Base_magic_dmg {
		get { return _base_magic_dmg; }
		set { _base_magic_dmg = value; }
	}

	public float Magic_def {
		get { return _magic_def; }
		set { _magic_def = value; }
	}

    public float Base_magic_def
    {
        get { return _base_magic_def; }
        set { _base_magic_def = value; }
    }

    public void performCritical ()
	{
		switch (thisMain) {
		case mainStat.STR_MAIN:
			Phys_dmg = Phys_dmg + ((Phys_dmg * Crit_dmg) / 100.0f);
			break;
		case mainStat.AGI_MAIN:
			Phys_dmg = Phys_dmg + ((Phys_dmg * Crit_dmg) / 100.0f);
			break;
		case mainStat.INT_MAIN:
			Magic_dmg = Magic_dmg + ((Magic_dmg * Crit_dmg) / 100.0f);
			break;
		}
	}

	public void endCritical ()
	{
		switch (thisMain) {
		case mainStat.STR_MAIN:
			Phys_dmg = Base_phys_dmg;

			break;
		case mainStat.AGI_MAIN:
			Phys_dmg = Base_phys_dmg;

			break;
		case mainStat.INT_MAIN:
			Magic_dmg = Base_magic_dmg;

			break;
		}
	}
	//can be used to set basic stats at the start of the battle
	public void setBaseStat()
	{
		Base_magic_dmg = Magic_dmg;
		Base_phys_dmg = Phys_dmg;
        Base_crit_chance = Crit_chance;
        Base_crit_dmg = Crit_dmg;
        Base_dodge_chance = Dodge_chance;
        Base_magic_def = Magic_def;
        Base_phys_def = Phys_def;
        Base_stun_chance = Stun_chance;
        Base_stun_resist = Stun_resist;
        Base_HP = HP;

    }
	//can be used to reset stats after a skill has been used (on player or enemy)
	public void resetBaseStat()
	{
        Magic_dmg = Base_magic_dmg;
        Phys_dmg = Base_phys_dmg;
        Crit_chance = Base_crit_chance;
        Crit_dmg = Base_crit_dmg;
        Dodge_chance = Base_dodge_chance;
        Magic_def = Base_magic_def;
        Phys_def = Base_phys_def;
        Stun_chance = Base_stun_chance;
        Stun_resist = Base_stun_resist;
        HP = Base_HP;
    }
	//this method can  eused for the ability "Change attack type"
	public void setMainStat (mainStat newMain)
	{
		thisMain = newMain;
	}
}
