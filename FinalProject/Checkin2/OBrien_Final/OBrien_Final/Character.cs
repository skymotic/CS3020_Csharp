using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OBrien_Final
{
    public class Character
    {
        private int level;
        private int intelligence;
        private int strength;
        private int attack;
        private int defense;
        private int maxHp;
        private int hp;
        private int speed;
        private bool isHero;
        private bool isAttackMagic;
        private string characterType;

        public event EventHandler<CharacterEventArgs> Attacking;

        public int Level { get => level; set => level = value; }
        public int Intelligence { get => intelligence; set => intelligence = value; }
        public int Attack { get => attack; set => attack = value; }
        public int Defense { get => defense; set => defense = value; }
        public int Strength { get => strength; set => strength = value; }
        public int Hp { get => hp; set => hp = value; }
        public bool IsHero { get => isHero; set => isHero = value; }
        public bool IsAttackMagic { get => isAttackMagic; set => isAttackMagic = value; }
        public int MaxHp { get => maxHp; set => maxHp = value; }
        public string CharacterType { get => characterType; set => characterType = value; }
        public int Speed { get => speed; set => speed = value; }

        /// <summary>
        /// Calculates and sets the Attack Weight basied 
        /// on intelligence, stength and character level
        /// </summary>
        protected void SetAttack()
        {
            double tempAttack = ((intelligence + strength) * level) / 3;
            if (tempAttack < 1)
                tempAttack = 1;
            attack = (int)tempAttack;
        }

        /// <summary>
        /// Calculates and sets characters Hit points basied on
        /// Defense, strngth and character level.
        /// </summary>
        protected void SetHP()
        {
            double tempHP = ((defense + strength) * level) / 3;
            if (tempHP < 1)
                tempHP = 1;
            hp = (int) (tempHP * 100);
            maxHp = hp;
        }

        /// <summary>
        /// Overridable Damage logic controller
        /// Applies damage using DoDamage()
        /// </summary>
        /// <param name="amount"></param>
        /// <param name="magic"></param>
        public virtual void Hurt(int amount, bool magic)
        {
            DoDamage(amount);
        }


        /// <summary>
        /// Returns Character Basic Statistics in String format
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            string temp = IsHero ? "Hero" : "Villain";
            return $"{characterType} [{temp}] | {hp}";
        }

        /// <summary>
        /// Administers damage to character and determins
        /// if Character will/has died
        /// </summary>
        /// <param name="amount"></param>
        protected void DoDamage(int amount)
        {
            if(hp >= amount*10)
            {
                hp -= amount * 10;
            }
            else
            {
                hp = 0;
                //Death(); //Uncoded moddifier that will trigger character death
            }
        }
    }
}
