using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace OBrien_Final
{
    public partial class Form1 : Form
    {
        Game gameController = new Game();
        public Form1()
        {
            InitializeComponent();
        }

        /// <summary>
        /// When the form loads, this method will subscribe a few events and 
        /// ultimatly start the game logic
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Form1_Load(object sender, EventArgs e)
        {
            gameController.HeroWasCreated += OnHeroCreation;
            gameController.VilWasCreated += OnVillianCreation;
            gameController.ListCharacters += OnListCharacters;
            gameController.Updated += OnUpdate;

            gameController.StartGame();
        }

        // ---------- ---------- ---------- Event Handlers

        /// <summary>
        /// Event Handler that can send a message into the textbox
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        public void OnMessageThrown(object sender, CharacterEventArgs e)
        {
            textBox.AppendText($"[Message] {e.MessageString}\r\n");
        }

        public void OnListCharacters(object sender, CharacterEventArgs e)
        {
            textBox.AppendText($"{e.ListOfCharacters}\r\n");
        }

        /// <summary>
        /// Event Handler that will update the health bar of a specified character
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        public void OnUpdate(object sender, CharacterEventArgs e)
        {
            if(e.HeroObject != null)
            {
                switch (e.HeroObject.CharacterType)
                {
                    case "warrior":
                        warrior_HealthBar.Value = e.HeroObject.Hp; break;
                    case "mage":
                        mage_HealthBar.Value = e.HeroObject.Hp; break;
                    case "cleric":
                        cleric_HealthBar.Value = e.HeroObject.Hp; break;
                }
            }
            else if(e.VilObject != null)
            {
                switch (e.VilObject.CharacterType)
                {
                    case "bandit":
                        bandit_HealthBar.Value = e.VilObject.Hp; break;
                    case "ogre":
                        oger_HealthBar.Value = e.VilObject.Hp; break;
                    case "dragon":
                        dragon_HealthBar.Value = e.VilObject.Hp; break;
                }
            }
        }

        /// <summary>
        /// Event Handler that sets the Default values for the health bar (for Heros)
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        public void OnHeroCreation(object sender, CharacterEventArgs e)
        {
            switch (e.HeroObject.CharacterType)
            {
                case "warrior":
                    warrior_HealthBar.Maximum = e.HeroObject.MaxHp;
                    warrior_HealthBar.Value = e.HeroObject.Hp;
                    break;
                case "mage":
                    mage_HealthBar.Maximum = e.HeroObject.MaxHp;
                    mage_HealthBar.Value = e.HeroObject.Hp;
                    break;
                case "cleric":
                    cleric_HealthBar.Maximum = e.HeroObject.MaxHp;
                    cleric_HealthBar.Value = e.HeroObject.Hp;
                    break;
            }
            textBox.AppendText($"{e.HeroObject.CharacterType} Created with {e.HeroObject.Hp}hp\r\n");
        }

        /// <summary>
        /// Event Handler that sets the Default values for the health bar (for Villians)
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        public void OnVillianCreation(object sender, CharacterEventArgs e)
        {
            switch (e.VilObject.CharacterType)
            {
                case "bandit":
                    bandit_HealthBar.Maximum = e.VilObject.MaxHp;
                    bandit_HealthBar.Value = e.VilObject.Hp;
                    break;
                case "ogre":
                    oger_HealthBar.Maximum = e.VilObject.MaxHp;
                    oger_HealthBar.Value = e.VilObject.Hp;
                    break;
                case "dragon":
                    dragon_HealthBar.Maximum = e.VilObject.MaxHp;
                    dragon_HealthBar.Value = e.VilObject.Hp;
                    break;
            }
            textBox.AppendText($"{e.VilObject.CharacterType} Created with {e.VilObject.Hp}hp\r\n");
        }

        /// <summary>
        /// Event Handler that will remove a character if they die
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        public void OnCharacterDeath(object sender, CharacterEventArgs e)
        {
            textBox.AppendText($"{e.CharacterType} has died\r\n");
            
            switch(e.CharacterType.ToString())
            {
                case "warrior":
                    warrior_PictureBox.Enabled = false; break;
                case "mage":
                    mage_PictureBox.Enabled = false; break;
                case "cleric":
                    cleric_PictureBox.Enabled = false; break;
                case "bandit":
                    bandit_PictureBox.Enabled = false; break;
                case "ogre":
                    oger__PictureBox.Enabled = false; break;
                case "dragon":
                    dragon_PictureBox.Enabled = false; break;
            }

        }
    }
}
