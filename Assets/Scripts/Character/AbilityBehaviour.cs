using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AbilityBehaviour
{

    private Ability ability;
#pragma warning disable CS0414 // The field 'AbilityBehaviour.totalDamageTaken' is assigned but its value is never used
    private int totalDamageTaken = 0;
#pragma warning restore CS0414 // The field 'AbilityBehaviour.totalDamageTaken' is assigned but its value is never used
    public bool defensive = false;
    private float startingDamageP = 0.0f;
    private float startingDamageM = 0.0f;

    public AbilityBehaviour(Ability myAbility)
    {
        ability = myAbility;
    }

    public void PerformBehaviour()
    {
        switch (ability.ID)
        {
            case 1:
                if (!ability.Elapsed)
                {
                    ability.MyPlayer.myEnemy.IsFrozen = true;
                   // Debug.Log("Enemy is frozen!!");
                }
                else
                {
                    ability.MyPlayer.myEnemy.IsFrozen = false;
                    //Debug.Log("Enemy defrosted");
                }
                break;
            case 2:
                if (!ability.Elapsed)
                {
                   // Debug.Log("Burning enemy: HP before ---> " + ability.MyPlayer.myEnemy.PlayerClass.Statistics.HP);
                    ability.MyPlayer.myEnemy.PlayerClass.Statistics.HP -= 2;
                   // Debug.Log("Burning enemy: HP after ---> " + ability.MyPlayer.myEnemy.PlayerClass.Statistics.HP);

                }
                break;
            case 3:
                if (!ability.Elapsed)
                {
                    if (!ability.AlreadyActive)
                    {
                       // Debug.Log("Stun chance boost ability: before " + ability.MyPlayer.PlayerClass.Statistics.Stun_chance);
                        ability.MyPlayer.PlayerClass.Statistics.Stun_chance += 10.0f / 100.0f;
                       // Debug.Log("Stun chance boost ability: after " + ability.MyPlayer.PlayerClass.Statistics.Stun_chance);
                        ability.AlreadyActive = true;
                    }
                }
                else
                {
                    ability.MyPlayer.PlayerClass.Statistics.Stun_chance = ability.MyPlayer.PlayerClass.Statistics.Base_stun_chance;
                    //Debug.Log("Stun chance boost ability ended: back to normal --> " + ability.MyPlayer.PlayerClass.Statistics.Stun_chance);
                    ability.AlreadyActive = false;
                }
                break;
            case 4:
                if (!ability.Elapsed)
                {
                    if (!ability.AlreadyActive)
                    {
                        //Debug.Log("Crit chance boost ability: before " + ability.MyPlayer.PlayerClass.Statistics.Crit_chance);
                        ability.MyPlayer.PlayerClass.Statistics.Crit_chance += 10.0f / 100.0f;
                       // Debug.Log("Crit chance boost ability: after " + ability.MyPlayer.PlayerClass.Statistics.Crit_chance);
                        ability.AlreadyActive = true;
                    }
                }
                else
                {
                    ability.MyPlayer.PlayerClass.Statistics.Crit_chance = ability.MyPlayer.PlayerClass.Statistics.Base_crit_chance;
                    //Debug.Log("Crit chance boost ability ended: back to normal --> " + ability.MyPlayer.PlayerClass.Statistics.Base_crit_chance);
                    ability.AlreadyActive = false;
                }
                break;
            case 5:
                if (!ability.Elapsed)
                {
                    if (!ability.AlreadyActive)
                    {
                        if (ability.MyPlayer.PlayerClass.ClassName != "Mage")
                        {
                           // Debug.Log("Doubled attack ability: before " + ability.MyPlayer.PlayerClass.Statistics.Phys_dmg);
                            ability.MyPlayer.PlayerClass.Statistics.Phys_dmg *= 2.0f;
                           // Debug.Log("Doubled attack ability: after " + ability.MyPlayer.PlayerClass.Statistics.Phys_dmg);
                        }
                        else
                        {
                           // Debug.Log("Doubled attack ability: before " + ability.MyPlayer.PlayerClass.Statistics.Magic_dmg);
                            ability.MyPlayer.PlayerClass.Statistics.Magic_dmg *= 2.0f;
                           // Debug.Log("Doubled attack ability: after " + ability.MyPlayer.PlayerClass.Statistics.Magic_dmg);
                        }
                        ability.AlreadyActive = true;
                    }
                }
                else
                {
                    if (ability.MyPlayer.PlayerClass.ClassName != "Mage")
                    {
                        ability.MyPlayer.PlayerClass.Statistics.Phys_dmg = ability.MyPlayer.PlayerClass.Statistics.Base_phys_dmg;
                       // Debug.Log("Doubled attack ability ended: back to normal --> " + ability.MyPlayer.PlayerClass.Statistics.Base_phys_dmg);
                    }
                    else
                    {
                        ability.MyPlayer.PlayerClass.Statistics.Magic_dmg = ability.MyPlayer.PlayerClass.Statistics.Base_magic_dmg;
                       // Debug.Log("Doubled attack ability ended: back to normal --> " + ability.MyPlayer.PlayerClass.Statistics.Base_magic_dmg);
                    }
                    ability.AlreadyActive = false;
                }
                break;
            //case 6:
            //    defensive = true;
            //    if (!ability.Elapsed)
            //    {
            //        ability.MyPlayer.isShielded = true;
            //        totalDamageTaken += (int)ability.MyPlayer.myEnemy.PlayerClass.Statistics.Phys_dmg;
            //        Debug.Log("Absorbing phys damage! " + (int)ability.MyPlayer.myEnemy.PlayerClass.Statistics.Phys_dmg);
            //        if (totalDamageTaken >= 5)
            //        {
            //            ability.Elapsed = true;
            //        }
            //    }
            //    else
            //    {
            //        totalDamageTaken = 0;
            //        ability.MyPlayer.isShielded = false;
            //    }
            //    break;
            //case 7:
            //    defensive = true;
            //    if (!ability.Elapsed)
            //    {
            //        ability.MyPlayer.isShielded = true;
            //        totalDamageTaken += (int)ability.MyPlayer.myEnemy.PlayerClass.Statistics.Magic_dmg;
            //        Debug.Log("Absorbing magic damage! " + (int)ability.MyPlayer.myEnemy.PlayerClass.Statistics.Magic_dmg);
            //        if (totalDamageTaken >= 5)
            //        {
            //            ability.Elapsed = true;
            //        }
            //    }
            //    else
            //    {
            //        totalDamageTaken = 0;
            //        ability.MyPlayer.isShielded = false;
            //    }
            //    break;
            case 6:
                if (!ability.Elapsed)
                {
                    if (!ability.AlreadyActive)
                    {
                       // Debug.Log("Stun resist boost ability: before " + ability.MyPlayer.PlayerClass.Statistics.Stun_resist);
                        ability.MyPlayer.PlayerClass.Statistics.Stun_resist += 10.0f / 100.0f;
                       // Debug.Log("Stun resist boost ability: after " + ability.MyPlayer.PlayerClass.Statistics.Stun_resist);
                        ability.AlreadyActive = true;
                    }
                }
                else
                {
                    ability.MyPlayer.PlayerClass.Statistics.Stun_resist = ability.MyPlayer.PlayerClass.Statistics.Base_stun_resist;
                    //Debug.Log("Stun resist boost ability ended: back to normal --> " + ability.MyPlayer.PlayerClass.Statistics.Stun_resist);
                    ability.AlreadyActive = false;
                }
                break;
            case 7:
                if (!ability.Elapsed)
                {
                    if (!ability.AlreadyActive)
                    {
                        //Debug.Log("Crit damage boost ability: before " + ability.MyPlayer.PlayerClass.Statistics.Crit_dmg);
                        ability.MyPlayer.PlayerClass.Statistics.Crit_dmg += ((ability.MyPlayer.PlayerClass.Statistics.Crit_dmg * 10.0f) / 100.0f);
                        //Debug.Log("Crit damage boost ability: after " + ability.MyPlayer.PlayerClass.Statistics.Crit_dmg);
                        ability.AlreadyActive = true;
                    }
                }
                else
                {
                    ability.MyPlayer.PlayerClass.Statistics.Crit_chance = ability.MyPlayer.PlayerClass.Statistics.Base_crit_chance;
                    //Debug.Log("Crit damage boost ability ended: back to normal --> " + ability.MyPlayer.PlayerClass.Statistics.Base_crit_chance);
                    ability.AlreadyActive = false;
                }
                break;
            case 8:
                if (!ability.Elapsed)
                {
                    if (!ability.AlreadyActive)
                    {
                        //Debug.Log("Dodge chance boost ability: before " + ability.MyPlayer.PlayerClass.Statistics.Dodge_chance);
                        ability.MyPlayer.PlayerClass.Statistics.Dodge_chance += 10.0f / 100.0f;
                       // Debug.Log("Dodge chance boost ability: after " + ability.MyPlayer.PlayerClass.Statistics.Dodge_chance);
                        ability.AlreadyActive = true;
                    }
                }
                else
                {
                    ability.MyPlayer.PlayerClass.Statistics.Dodge_chance = ability.MyPlayer.PlayerClass.Statistics.Base_dodge_chance;
                    //Debug.Log("Dodge chance boost ability ended: back to normal --> " + ability.MyPlayer.PlayerClass.Statistics.Base_crit_chance);
                    ability.AlreadyActive = false;
                }
                break;
            case 9:
                if (!ability.Elapsed)
                {
                    if (!ability.AlreadyActive)
                    {
                        ability.MyPlayer.InvertedTypeDamage = true;
                        //Debug.Log("Damage type inverted");
                        ability.AlreadyActive = true;
                    }
                }
                else
                {
                    ability.MyPlayer.InvertedTypeDamage = false;
                    //Debug.Log("Damage type back to normal");
                    ability.AlreadyActive = false;
                }
                break;
            case 10:
                if (!ability.Elapsed)
                {
                    if (!ability.AlreadyActive)
                    {
                        if (ability.MyPlayer.PlayerClass.ClassName != "Mage")
                        {
                            //Debug.Log("Fragile power ability: attack before " + ability.MyPlayer.PlayerClass.Statistics.Phys_dmg);
                            ability.MyPlayer.PlayerClass.Statistics.Phys_dmg += ((ability.MyPlayer.PlayerClass.Statistics.Phys_dmg * 15.0f) / 100.0f);
                            //Debug.Log("Fragile power ability: attack after " + ability.MyPlayer.PlayerClass.Statistics.Phys_dmg);
                        }
                        else
                        {
                            //Debug.Log("Fragile power ability: attack before " + ability.MyPlayer.PlayerClass.Statistics.Magic_dmg);
                            ability.MyPlayer.PlayerClass.Statistics.Magic_dmg += ((ability.MyPlayer.PlayerClass.Statistics.Magic_dmg * 15.0f) / 100.0f);
                            //Debug.Log("Fragile power ability: attack after " + ability.MyPlayer.PlayerClass.Statistics.Magic_dmg);
                        }

                        //Debug.Log("Fragile power ability: phys/magic def before " + ability.MyPlayer.PlayerClass.Statistics.Phys_def + ", " + ability.MyPlayer.PlayerClass.Statistics.Magic_def);
                        if (ability.MyPlayer.PlayerClass.Statistics.Magic_def > 0)
                        {
                            ability.MyPlayer.PlayerClass.Statistics.Magic_def -= ((ability.MyPlayer.PlayerClass.Statistics.Magic_def * 10.0f) / 100.0f);
                        }

                        if (ability.MyPlayer.PlayerClass.Statistics.Phys_def > 0)
                        {
                            ability.MyPlayer.PlayerClass.Statistics.Phys_def -= ((ability.MyPlayer.PlayerClass.Statistics.Phys_def * 10.0f) / 100.0f);
                        }
                        //Debug.Log("Fragile power ability: phys/magic def after " + ability.MyPlayer.PlayerClass.Statistics.Phys_def + ", " + ability.MyPlayer.PlayerClass.Statistics.Magic_def);

                        ability.AlreadyActive = true;
                    }
                }
                else
                {
                    ability.MyPlayer.PlayerClass.Statistics.Magic_dmg = ability.MyPlayer.PlayerClass.Statistics.Base_magic_dmg;
                    ability.MyPlayer.PlayerClass.Statistics.Phys_dmg = ability.MyPlayer.PlayerClass.Statistics.Base_phys_dmg;
                    ability.MyPlayer.PlayerClass.Statistics.Magic_def = ability.MyPlayer.PlayerClass.Statistics.Base_magic_def;
                    ability.MyPlayer.PlayerClass.Statistics.Phys_def = ability.MyPlayer.PlayerClass.Statistics.Base_phys_def;
                    //Debug.Log("Fragile power ability ended: back to normal");
                    ability.AlreadyActive = false;
                }
                break;
            case 11:
                defensive = true;
                if (!ability.Elapsed)
                {
                    if (!ability.AlreadyActive)
                    {
                        //Debug.Log("Curse of the weak: enemy phys/magic defence before " + ability.MyPlayer.myEnemy.PlayerClass.Statistics.Phys_def + ", " + ability.MyPlayer.myEnemy.PlayerClass.Statistics.Magic_def);
                        if (ability.MyPlayer.myEnemy.PlayerClass.Statistics.Magic_def > 0)
                        {
                            ability.MyPlayer.myEnemy.PlayerClass.Statistics.Magic_def -= ((ability.MyPlayer.myEnemy.PlayerClass.Statistics.Magic_def * 15.0f) / 100.0f);
                        }

                        if (ability.MyPlayer.myEnemy.PlayerClass.Statistics.Phys_def > 0)
                        {
                            ability.MyPlayer.myEnemy.PlayerClass.Statistics.Phys_def -= ((ability.MyPlayer.myEnemy.PlayerClass.Statistics.Phys_def * 15.0f) / 100.0f);
                        }
                        //Debug.Log("Curse of the weak: enemy phys/magic defence after " + ability.MyPlayer.myEnemy.PlayerClass.Statistics.Phys_def + ", " + ability.MyPlayer.myEnemy.PlayerClass.Statistics.Magic_def);
                        ability.AlreadyActive = true;
                    }
                }
                else
                {
                    ability.MyPlayer.myEnemy.PlayerClass.Statistics.Magic_def = ability.MyPlayer.myEnemy.PlayerClass.Statistics.Base_magic_def;
                    ability.MyPlayer.myEnemy.PlayerClass.Statistics.Phys_def = ability.MyPlayer.myEnemy.PlayerClass.Statistics.Base_phys_def;
                    //Debug.Log("Curse of the weak ended: enemy phys/magic defence back to normal --> " + ability.MyPlayer.myEnemy.PlayerClass.Statistics.Phys_def + ", " + ability.MyPlayer.myEnemy.PlayerClass.Statistics.Magic_def);
                    ability.AlreadyActive = false;
                }
                break;
            case 12:
                defensive = true;
                if (!ability.Elapsed)
                {
                    if (!ability.AlreadyActive)
                    {
                        ability.MyPlayer.myEnemy.IsMirrowed = true;
                        //Debug.Log("Mirrow against enemy risen");
                        ability.AlreadyActive = true;
                    }
                }
                else
                {
                    ability.MyPlayer.myEnemy.IsMirrowed = false;
                    //Debug.Log("Mirrow against enemy is now broken");
                    ability.AlreadyActive = false;
                }
                break;
            case 13:
                if (!ability.Elapsed)
                {
                    //Debug.Log("Stealing enemy's damage");
                    if (!ability.AlreadyActive)
                    {
                        float enemyDamage = 0.0f;
                        //taking enemy's damage
                        if (ability.MyPlayer.myEnemy.PlayerClass.ClassName != "Mage")
                        {
                            enemyDamage = ability.MyPlayer.myEnemy.PlayerClass.Statistics.Base_phys_dmg;
                        }
                        else
                        {
                            enemyDamage = ability.MyPlayer.myEnemy.PlayerClass.Statistics.Base_magic_dmg;
                        }

                        if (ability.MyPlayer.PlayerClass.ClassName != "Mage")
                        {
                            ability.MyPlayer.PlayerClass.Statistics.Phys_dmg = enemyDamage;
                        }
                        else
                        {
                            ability.MyPlayer.PlayerClass.Statistics.Magic_dmg = enemyDamage;
                        }
                        //Debug.Log("Stealing enemy's damage ---> " + enemyDamage);
                        ability.AlreadyActive = true;
                    }
                }
                else
                {
                    ability.MyPlayer.PlayerClass.Statistics.Magic_dmg = ability.MyPlayer.PlayerClass.Statistics.Base_magic_dmg;
                    ability.MyPlayer.PlayerClass.Statistics.Phys_dmg = ability.MyPlayer.PlayerClass.Statistics.Base_phys_dmg;
                    //Debug.Log("Steal dmg ability ended: back to normal");
                    ability.AlreadyActive = false;
                }
                break;
            case 14:
                if (!ability.Elapsed)
                {
                    //Debug.Log("Healing: HP before ---> " + ability.MyPlayer.PlayerClass.Statistics.HP);
                    //checking if current hp is higher than base hp
                    if (ability.MyPlayer.PlayerClass.Statistics.HP < ability.MyPlayer.PlayerClass.Statistics.Base_HP)
                    {
                        //checking if difference of base hp and current hp is less than 3
                        if ((ability.MyPlayer.PlayerClass.Statistics.Base_HP - ability.MyPlayer.PlayerClass.Statistics.HP) < 3)
                        {
                            //in this case, to avoid to have hp higher than base hp, current hp will be equal to base hp
                            ability.MyPlayer.PlayerClass.Statistics.HP = ability.MyPlayer.PlayerClass.Statistics.Base_HP;
                        }
                        else
                        {
                            //if more than 3 points are needed to max health, add 3 points
                            ability.MyPlayer.PlayerClass.Statistics.HP += 3;
                        }
                    }
                    //Debug.Log("Healing: HP after ---> " + ability.MyPlayer.PlayerClass.Statistics.HP);
                }
                break;
            case 15:
                defensive = true;
                if (!ability.Elapsed)
                {
                    //Debug.Log("Life transfer: player/enemy HP before ---> " + ability.MyPlayer.PlayerClass.Statistics.HP + " ," + ability.MyPlayer.myEnemy.PlayerClass.Statistics.HP);
                    if (ability.MyPlayer.PlayerClass.Statistics.HP < ability.MyPlayer.PlayerClass.Statistics.Base_HP)
                    {
                        if ((ability.MyPlayer.PlayerClass.Statistics.Base_HP - ability.MyPlayer.PlayerClass.Statistics.HP) < 5)
                        {
                            ability.MyPlayer.myEnemy.PlayerClass.Statistics.HP -= ability.MyPlayer.PlayerClass.Statistics.Base_HP - ability.MyPlayer.PlayerClass.Statistics.HP;
                            ability.MyPlayer.PlayerClass.Statistics.HP = ability.MyPlayer.PlayerClass.Statistics.Base_HP;
                        }
                        else
                        {
                            ability.MyPlayer.PlayerClass.Statistics.HP += 5;
                            ability.MyPlayer.myEnemy.PlayerClass.Statistics.HP -= 5;
                        }
                    }
                    //Debug.Log("Life transfer: player/enemy HP after ---> " + ability.MyPlayer.PlayerClass.Statistics.HP + " ," + ability.MyPlayer.myEnemy.PlayerClass.Statistics.HP);
                }
                break;
            case 16:
                defensive = true;
                if (!ability.Elapsed)
                {
                    if (!ability.AlreadyActive)
                    {
                        ability.MyPlayer.myEnemy.IsConfused = true;
                        //Debug.Log("Enemy is confused");
                        ability.AlreadyActive = true;
                    }
                }
                else
                {
                    ability.MyPlayer.myEnemy.IsConfused = false;
                    //Debug.Log("Enemy is not confused anymore");
                    ability.AlreadyActive = false;
                }
                break;
            case 17:
                if (!ability.Elapsed)
                {
                    if (!ability.AlreadyActive)
                    {
                        ability.MyPlayer.myEnemy.isStickOnGround = true;
                        //Debug.Log("Floor is sticky and enemy is stuck on the ground");
                        ability.AlreadyActive = true;
                    }
                }
                else
                {
                    ability.MyPlayer.myEnemy.isStickOnGround = false;
                    //Debug.Log("Stickiness ended. Enemy is free to move again");
                    ability.AlreadyActive = false;
                }
                break;
            case 18:
                if (!ability.Elapsed)
                {
                    if (!ability.AlreadyActive)
                    {
                        startingDamageP = ability.MyPlayer.PlayerClass.Statistics.Phys_dmg;
                        startingDamageM = ability.MyPlayer.PlayerClass.Statistics.Magic_dmg;
                        ability.AlreadyActive = true;
                    }

                    float lifeLost = ability.MyPlayer.PlayerClass.Statistics.Base_HP - ability.MyPlayer.PlayerClass.Statistics.HP;
                    float percentageLifeLost = (lifeLost * 100.0f) / ability.MyPlayer.PlayerClass.Statistics.Base_HP;

                    if (ability.MyPlayer.PlayerClass.ClassName != "Mage")
                    {
                        //Debug.Log("Life lost as attack: before ------> " + ability.MyPlayer.PlayerClass.Statistics.Phys_dmg);
                        ability.MyPlayer.PlayerClass.Statistics.Phys_dmg = startingDamageP + ((startingDamageP * percentageLifeLost) / 100);
                        //Debug.Log("Life lost as attack: after ------> " + ability.MyPlayer.PlayerClass.Statistics.Phys_dmg);
                    }
                    else
                    {
                        //Debug.Log("Life lost as attack: before ------> " + ability.MyPlayer.PlayerClass.Statistics.Magic_dmg);
                        ability.MyPlayer.PlayerClass.Statistics.Magic_dmg = startingDamageM + ((startingDamageM * percentageLifeLost) / 100);
                        //Debug.Log("Life lost as attack: after ------> " + ability.MyPlayer.PlayerClass.Statistics.Magic_dmg);
                    }
                }
                else
                {
                    ability.MyPlayer.PlayerClass.Statistics.Magic_dmg = ability.MyPlayer.PlayerClass.Statistics.Base_magic_dmg;
                    ability.MyPlayer.PlayerClass.Statistics.Phys_dmg = ability.MyPlayer.PlayerClass.Statistics.Base_phys_dmg;
                    //Debug.Log("Life lost as attack ability ended: back to normal");
                    ability.AlreadyActive = false;
                }
                break;
        }
    }

}
