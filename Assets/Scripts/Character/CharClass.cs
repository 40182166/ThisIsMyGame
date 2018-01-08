using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharClass
{

	private BaseCharacterClass _stats;
	private string className;
	private string classDescription;

	public enum characterClass
	{
		WARRIOR,
		MAGE,
		ARCHER
	};

	public CharClass(characterClass thisClass)
	{
		switch (thisClass) 
		{
		case characterClass.WARRIOR:
			Statistics = new BaseCharacterClass (BaseCharacterClass.mainStat.STR_MAIN);
			className = "Warrior";
			classDescription = "A very strong character that uses brute force to fight enemies";
			break;
		case characterClass.MAGE:
			Statistics = new BaseCharacterClass (BaseCharacterClass.mainStat.INT_MAIN);
			className = "Mage";
			classDescription = "Physically weak character that can cast powerful spells";
			break;
		case characterClass.ARCHER:
			Statistics = new BaseCharacterClass (BaseCharacterClass.mainStat.AGI_MAIN);
			className = "Archer";
			classDescription = "Very agile character that shots enemies with bow and arrows";
			break;
		}
	}

	public BaseCharacterClass Statistics
	{
		get { return _stats; }
		set { _stats = value; }
	}

	public string ClassName
	{
		get { return className; }
		set { className = value; }
	}

	public string ClassDescription
	{
		get { return classDescription; }
		set { classDescription = value; }
	}

}