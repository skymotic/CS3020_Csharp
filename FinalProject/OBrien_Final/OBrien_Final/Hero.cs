using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OBrien_Final
{
    public class Hero : Character
    {
        //Holds the damage weigher for Heros Special Attack
        private int specialAttack;

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="characterType"></param>
        /// <param name="level"></param>
        /// <param name="intel"></param>
        /// <param name="strength"></param>
        /// <param name="defent"></param>
        /// <param name="speed"></param>
        public Hero(string characterType, int level, int intel, int strength, int defent, int speed)
        {
            CharacterType = characterType;
            Level = level;
            Intelligence = intel;
            Strength = strength;
            Defense = defent;
            Speed = speed;
            IsHero = true;
            SetAttack();
            SetHP();
            SetSpecialAttack();
            SetAttackType();
        }
        public Hero() { }

        /// <summary>
        /// Calculates and set the Special Attack Damage Weight
        /// </summary>
        private void SetSpecialAttack()
        {
            specialAttack = (((Attack + Level + Strength) / 3) * 2);
        }

        /// <summary>
        /// Sets if attack is magical or not
        /// </summary>
        private void SetAttackType()
        {
            switch (CharacterType)
            {
                case "mage":
                    IsAttackMagic = true;
                    break;
                default:
                    IsAttackMagic = false;
                    break;
            }
        }

        /// <summary>
        /// Wrapper to apply the special attack on a villain
        /// </summary>
        /// <param name="e"></param>
        public void SpecialAttack(Villian e)
        {
            e.Hurt(specialAttack, IsAttackMagic);
        }

        /// <summary>
        /// Uses damage logic depending on character type
        /// Then administers damage using DoDamage()
        /// </summary>
        /// <param name="amount"></param>
        /// <param name="magic"></param>
        public override void Hurt(int amount, bool magic)
        {
            switch (CharacterType)
            {
                case "warrior":
                    if (magic)
                        DoDamage(amount);
                    else
                        DoDamage(amount - (Defense));
                    break;
                case "mage":
                    if (!magic)
                        DoDamage(amount - (Defense / 2));
                    else
                        DoDamage(amount - (Defense + 1));
                    break;
                default:
                    DoDamage(amount - Defense);
                    break;
            }
        }

        /// <summary>
        /// Applies Healing amount to Hero
        /// </summary>
        /// <param name="amount"></param>
        public void Heal(int amount)
        {
            if ((Hp + amount) > MaxHp)
                Hp = MaxHp;
            else
                Hp += amount;
        }

        /// <summary>
        /// If current player is Mage, Heals selected player for set amount
        /// </summary>
        /// <param name="e"></param>
        public void HealHero(Hero e)
        {
            if (CharacterType.Equals("cleric"))
                e.Heal((int)(Attack / 1.5));
            else
                Console.WriteLine("Healing Failed | Wrong Character Type");
        }

        /// <summary>
        /// Wrapper method to attack Villain
        /// </summary>
        /// <param name="e"></param>
        public void AttackVillan(Villian e)
        {
            e.Hurt(Attack, IsAttackMagic);
        }
    }
}
