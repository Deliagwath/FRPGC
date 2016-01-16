namespace FRPGC
{
    partial class mainForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.radioPlayer = new System.Windows.Forms.RadioButton();
            this.radioTargetLabel = new System.Windows.Forms.Label();
            this.radioEnemy = new System.Windows.Forms.RadioButton();
            this.comboUnit = new System.Windows.Forms.ComboBox();
            this.comboDifficulty = new System.Windows.Forms.ComboBox();
            this.comboUnitLabel = new System.Windows.Forms.Label();
            this.comboDifficultyLabel = new System.Windows.Forms.Label();
            this.checkDefaultEquipment = new System.Windows.Forms.CheckBox();
            this.comboWeapon = new System.Windows.Forms.ComboBox();
            this.comboWeaponLabel = new System.Windows.Forms.Label();
            this.comboArmourLabel = new System.Windows.Forms.Label();
            this.comboArmour = new System.Windows.Forms.ComboBox();
            this.textSkill = new System.Windows.Forms.TextBox();
            this.textSkillLabel = new System.Windows.Forms.Label();
            this.scenarioLabel = new System.Windows.Forms.Label();
            this.textShotCount = new System.Windows.Forms.TextBox();
            this.textShotCountLabel = new System.Windows.Forms.Label();
            this.comboFireTypeLabel = new System.Windows.Forms.Label();
            this.comboFireType = new System.Windows.Forms.ComboBox();
            this.textInitialHealthLabel = new System.Windows.Forms.Label();
            this.textInitialHealth = new System.Windows.Forms.TextBox();
            this.textDistanceLabel = new System.Windows.Forms.Label();
            this.textDistance = new System.Windows.Forms.TextBox();
            this.resultsLabel = new System.Windows.Forms.Label();
            this.textDamageDealtLabel = new System.Windows.Forms.Label();
            this.textDamageDealt = new System.Windows.Forms.TextBox();
            this.textCurrentHealthLabel = new System.Windows.Forms.Label();
            this.textCurrentHealth = new System.Windows.Forms.TextBox();
            this.buttonSetHP = new System.Windows.Forms.Button();
            this.textLog = new System.Windows.Forms.TextBox();
            this.textLogLabel = new System.Windows.Forms.Label();
            this.buttonCalculate = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // radioPlayer
            // 
            this.radioPlayer.AutoSize = true;
            this.radioPlayer.Checked = true;
            this.radioPlayer.Location = new System.Drawing.Point(12, 25);
            this.radioPlayer.Name = "radioPlayer";
            this.radioPlayer.Size = new System.Drawing.Size(54, 17);
            this.radioPlayer.TabIndex = 1;
            this.radioPlayer.TabStop = true;
            this.radioPlayer.Text = "Player";
            this.radioPlayer.UseVisualStyleBackColor = true;
            this.radioPlayer.CheckedChanged += new System.EventHandler(this.radioPlayerChecked);
            // 
            // radioTargetLabel
            // 
            this.radioTargetLabel.AutoSize = true;
            this.radioTargetLabel.Location = new System.Drawing.Point(12, 9);
            this.radioTargetLabel.Name = "radioTargetLabel";
            this.radioTargetLabel.Size = new System.Drawing.Size(38, 13);
            this.radioTargetLabel.TabIndex = 2;
            this.radioTargetLabel.Text = "Target";
            // 
            // radioEnemy
            // 
            this.radioEnemy.AutoSize = true;
            this.radioEnemy.Location = new System.Drawing.Point(12, 48);
            this.radioEnemy.Name = "radioEnemy";
            this.radioEnemy.Size = new System.Drawing.Size(57, 17);
            this.radioEnemy.TabIndex = 3;
            this.radioEnemy.Text = "Enemy";
            this.radioEnemy.UseVisualStyleBackColor = true;
            this.radioEnemy.CheckedChanged += new System.EventHandler(this.radioEnemyChecked);
            // 
            // comboUnit
            // 
            this.comboUnit.FormattingEnabled = true;
            this.comboUnit.Location = new System.Drawing.Point(12, 84);
            this.comboUnit.Name = "comboUnit";
            this.comboUnit.Size = new System.Drawing.Size(121, 21);
            this.comboUnit.TabIndex = 4;
            // 
            // comboDifficulty
            // 
            this.comboDifficulty.FormattingEnabled = true;
            this.comboDifficulty.Location = new System.Drawing.Point(12, 124);
            this.comboDifficulty.Name = "comboDifficulty";
            this.comboDifficulty.Size = new System.Drawing.Size(121, 21);
            this.comboDifficulty.TabIndex = 5;
            this.comboDifficulty.Visible = false;
            // 
            // comboUnitLabel
            // 
            this.comboUnitLabel.AutoSize = true;
            this.comboUnitLabel.Location = new System.Drawing.Point(12, 68);
            this.comboUnitLabel.Name = "comboUnitLabel";
            this.comboUnitLabel.Size = new System.Drawing.Size(67, 13);
            this.comboUnitLabel.TabIndex = 6;
            this.comboUnitLabel.Text = "Player Name";
            // 
            // comboDifficultyLabel
            // 
            this.comboDifficultyLabel.AutoSize = true;
            this.comboDifficultyLabel.Location = new System.Drawing.Point(12, 108);
            this.comboDifficultyLabel.Name = "comboDifficultyLabel";
            this.comboDifficultyLabel.Size = new System.Drawing.Size(47, 13);
            this.comboDifficultyLabel.TabIndex = 7;
            this.comboDifficultyLabel.Text = "Difficulty";
            this.comboDifficultyLabel.Visible = false;
            // 
            // checkDefaultEquipment
            // 
            this.checkDefaultEquipment.AutoSize = true;
            this.checkDefaultEquipment.Checked = true;
            this.checkDefaultEquipment.CheckState = System.Windows.Forms.CheckState.Checked;
            this.checkDefaultEquipment.Location = new System.Drawing.Point(12, 164);
            this.checkDefaultEquipment.Name = "checkDefaultEquipment";
            this.checkDefaultEquipment.Size = new System.Drawing.Size(113, 17);
            this.checkDefaultEquipment.TabIndex = 8;
            this.checkDefaultEquipment.Text = "Default Equipment";
            this.checkDefaultEquipment.UseVisualStyleBackColor = true;
            this.checkDefaultEquipment.Visible = false;
            // 
            // comboWeapon
            // 
            this.comboWeapon.FormattingEnabled = true;
            this.comboWeapon.Location = new System.Drawing.Point(234, 45);
            this.comboWeapon.Name = "comboWeapon";
            this.comboWeapon.Size = new System.Drawing.Size(121, 21);
            this.comboWeapon.TabIndex = 9;
            // 
            // comboWeaponLabel
            // 
            this.comboWeaponLabel.AutoSize = true;
            this.comboWeaponLabel.Location = new System.Drawing.Point(231, 29);
            this.comboWeaponLabel.Name = "comboWeaponLabel";
            this.comboWeaponLabel.Size = new System.Drawing.Size(96, 13);
            this.comboWeaponLabel.TabIndex = 10;
            this.comboWeaponLabel.Text = "Attacking Weapon";
            // 
            // comboArmourLabel
            // 
            this.comboArmourLabel.AutoSize = true;
            this.comboArmourLabel.Location = new System.Drawing.Point(12, 187);
            this.comboArmourLabel.Name = "comboArmourLabel";
            this.comboArmourLabel.Size = new System.Drawing.Size(92, 13);
            this.comboArmourLabel.TabIndex = 13;
            this.comboArmourLabel.Text = "Defending Armour";
            // 
            // comboArmour
            // 
            this.comboArmour.FormattingEnabled = true;
            this.comboArmour.Location = new System.Drawing.Point(12, 203);
            this.comboArmour.Name = "comboArmour";
            this.comboArmour.Size = new System.Drawing.Size(121, 21);
            this.comboArmour.TabIndex = 14;
            // 
            // textSkill
            // 
            this.textSkill.Location = new System.Drawing.Point(12, 248);
            this.textSkill.Multiline = true;
            this.textSkill.Name = "textSkill";
            this.textSkill.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.textSkill.Size = new System.Drawing.Size(121, 282);
            this.textSkill.TabIndex = 15;
            // 
            // textSkillLabel
            // 
            this.textSkillLabel.AutoSize = true;
            this.textSkillLabel.Location = new System.Drawing.Point(12, 230);
            this.textSkillLabel.Name = "textSkillLabel";
            this.textSkillLabel.Size = new System.Drawing.Size(31, 13);
            this.textSkillLabel.TabIndex = 16;
            this.textSkillLabel.Text = "Skills";
            // 
            // scenarioLabel
            // 
            this.scenarioLabel.AutoSize = true;
            this.scenarioLabel.Location = new System.Drawing.Point(231, 9);
            this.scenarioLabel.Name = "scenarioLabel";
            this.scenarioLabel.Size = new System.Drawing.Size(49, 13);
            this.scenarioLabel.TabIndex = 17;
            this.scenarioLabel.Text = "Scenario";
            // 
            // textShotCount
            // 
            this.textShotCount.Location = new System.Drawing.Point(234, 85);
            this.textShotCount.Name = "textShotCount";
            this.textShotCount.Size = new System.Drawing.Size(100, 20);
            this.textShotCount.TabIndex = 18;
            // 
            // textShotCountLabel
            // 
            this.textShotCountLabel.AutoSize = true;
            this.textShotCountLabel.Location = new System.Drawing.Point(231, 69);
            this.textShotCountLabel.Name = "textShotCountLabel";
            this.textShotCountLabel.Size = new System.Drawing.Size(112, 13);
            this.textShotCountLabel.TabIndex = 19;
            this.textShotCountLabel.Text = "Number of Shots Fired";
            // 
            // comboFireTypeLabel
            // 
            this.comboFireTypeLabel.AutoSize = true;
            this.comboFireTypeLabel.Location = new System.Drawing.Point(231, 108);
            this.comboFireTypeLabel.Name = "comboFireTypeLabel";
            this.comboFireTypeLabel.Size = new System.Drawing.Size(62, 13);
            this.comboFireTypeLabel.TabIndex = 20;
            this.comboFireTypeLabel.Text = "Firing Mode";
            // 
            // comboFireType
            // 
            this.comboFireType.FormattingEnabled = true;
            this.comboFireType.Items.AddRange(new object[] {
            "Single Shot",
            "Burst Shot",
            "Melee"});
            this.comboFireType.Location = new System.Drawing.Point(234, 124);
            this.comboFireType.Name = "comboFireType";
            this.comboFireType.Size = new System.Drawing.Size(121, 21);
            this.comboFireType.TabIndex = 21;
            // 
            // textInitialHealthLabel
            // 
            this.textInitialHealthLabel.AutoSize = true;
            this.textInitialHealthLabel.Location = new System.Drawing.Point(231, 187);
            this.textInitialHealthLabel.Name = "textInitialHealthLabel";
            this.textInitialHealthLabel.Size = new System.Drawing.Size(65, 13);
            this.textInitialHealthLabel.TabIndex = 22;
            this.textInitialHealthLabel.Text = "Initial Health";
            // 
            // textInitialHealth
            // 
            this.textInitialHealth.Location = new System.Drawing.Point(234, 203);
            this.textInitialHealth.Name = "textInitialHealth";
            this.textInitialHealth.Size = new System.Drawing.Size(100, 20);
            this.textInitialHealth.TabIndex = 23;
            this.textInitialHealth.Text = "0";
            // 
            // textDistanceLabel
            // 
            this.textDistanceLabel.AutoSize = true;
            this.textDistanceLabel.Location = new System.Drawing.Point(231, 148);
            this.textDistanceLabel.Name = "textDistanceLabel";
            this.textDistanceLabel.Size = new System.Drawing.Size(39, 13);
            this.textDistanceLabel.TabIndex = 24;
            this.textDistanceLabel.Text = "Range";
            // 
            // textDistance
            // 
            this.textDistance.Location = new System.Drawing.Point(234, 164);
            this.textDistance.Name = "textDistance";
            this.textDistance.Size = new System.Drawing.Size(100, 20);
            this.textDistance.TabIndex = 25;
            // 
            // resultsLabel
            // 
            this.resultsLabel.AutoSize = true;
            this.resultsLabel.Location = new System.Drawing.Point(436, 8);
            this.resultsLabel.Name = "resultsLabel";
            this.resultsLabel.Size = new System.Drawing.Size(42, 13);
            this.resultsLabel.TabIndex = 26;
            this.resultsLabel.Text = "Results";
            // 
            // textDamageDealtLabel
            // 
            this.textDamageDealtLabel.AutoSize = true;
            this.textDamageDealtLabel.Location = new System.Drawing.Point(436, 68);
            this.textDamageDealtLabel.Name = "textDamageDealtLabel";
            this.textDamageDealtLabel.Size = new System.Drawing.Size(75, 13);
            this.textDamageDealtLabel.TabIndex = 27;
            this.textDamageDealtLabel.Text = "Damage Dealt";
            // 
            // textDamageDealt
            // 
            this.textDamageDealt.Location = new System.Drawing.Point(439, 84);
            this.textDamageDealt.Name = "textDamageDealt";
            this.textDamageDealt.ReadOnly = true;
            this.textDamageDealt.Size = new System.Drawing.Size(100, 20);
            this.textDamageDealt.TabIndex = 28;
            // 
            // textCurrentHealthLabel
            // 
            this.textCurrentHealthLabel.AutoSize = true;
            this.textCurrentHealthLabel.Location = new System.Drawing.Point(436, 108);
            this.textCurrentHealthLabel.Name = "textCurrentHealthLabel";
            this.textCurrentHealthLabel.Size = new System.Drawing.Size(75, 13);
            this.textCurrentHealthLabel.TabIndex = 29;
            this.textCurrentHealthLabel.Text = "Current Health";
            // 
            // textCurrentHealth
            // 
            this.textCurrentHealth.Location = new System.Drawing.Point(439, 125);
            this.textCurrentHealth.Name = "textCurrentHealth";
            this.textCurrentHealth.ReadOnly = true;
            this.textCurrentHealth.Size = new System.Drawing.Size(100, 20);
            this.textCurrentHealth.TabIndex = 30;
            // 
            // buttonSetHP
            // 
            this.buttonSetHP.Location = new System.Drawing.Point(439, 200);
            this.buttonSetHP.Name = "buttonSetHP";
            this.buttonSetHP.Size = new System.Drawing.Size(100, 23);
            this.buttonSetHP.TabIndex = 31;
            this.buttonSetHP.Text = "Set Init = Curr HP";
            this.buttonSetHP.UseVisualStyleBackColor = true;
            this.buttonSetHP.Click += new System.EventHandler(this.buttonSetHP_Click);
            // 
            // textLog
            // 
            this.textLog.Location = new System.Drawing.Point(139, 248);
            this.textLog.Multiline = true;
            this.textLog.Name = "textLog";
            this.textLog.ReadOnly = true;
            this.textLog.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.textLog.Size = new System.Drawing.Size(400, 282);
            this.textLog.TabIndex = 32;
            // 
            // textLogLabel
            // 
            this.textLogLabel.AutoSize = true;
            this.textLogLabel.Location = new System.Drawing.Point(136, 230);
            this.textLogLabel.Name = "textLogLabel";
            this.textLogLabel.Size = new System.Drawing.Size(25, 13);
            this.textLogLabel.TabIndex = 33;
            this.textLogLabel.Text = "Log";
            // 
            // buttonCalculate
            // 
            this.buttonCalculate.Location = new System.Drawing.Point(439, 161);
            this.buttonCalculate.Name = "buttonCalculate";
            this.buttonCalculate.Size = new System.Drawing.Size(100, 23);
            this.buttonCalculate.TabIndex = 34;
            this.buttonCalculate.Text = "Calculate";
            this.buttonCalculate.UseVisualStyleBackColor = true;
            this.buttonCalculate.Click += new System.EventHandler(this.dumpArmours);
            // 
            // mainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(551, 542);
            this.Controls.Add(this.buttonCalculate);
            this.Controls.Add(this.textLogLabel);
            this.Controls.Add(this.textLog);
            this.Controls.Add(this.buttonSetHP);
            this.Controls.Add(this.textCurrentHealth);
            this.Controls.Add(this.textCurrentHealthLabel);
            this.Controls.Add(this.textDamageDealt);
            this.Controls.Add(this.textDamageDealtLabel);
            this.Controls.Add(this.resultsLabel);
            this.Controls.Add(this.textDistance);
            this.Controls.Add(this.textDistanceLabel);
            this.Controls.Add(this.textInitialHealth);
            this.Controls.Add(this.textInitialHealthLabel);
            this.Controls.Add(this.comboFireType);
            this.Controls.Add(this.comboFireTypeLabel);
            this.Controls.Add(this.textShotCountLabel);
            this.Controls.Add(this.textShotCount);
            this.Controls.Add(this.scenarioLabel);
            this.Controls.Add(this.textSkillLabel);
            this.Controls.Add(this.textSkill);
            this.Controls.Add(this.comboArmour);
            this.Controls.Add(this.comboArmourLabel);
            this.Controls.Add(this.comboWeaponLabel);
            this.Controls.Add(this.comboWeapon);
            this.Controls.Add(this.checkDefaultEquipment);
            this.Controls.Add(this.comboDifficultyLabel);
            this.Controls.Add(this.comboUnitLabel);
            this.Controls.Add(this.comboDifficulty);
            this.Controls.Add(this.comboUnit);
            this.Controls.Add(this.radioEnemy);
            this.Controls.Add(this.radioTargetLabel);
            this.Controls.Add(this.radioPlayer);
            this.Name = "mainForm";
            this.Text = "Fallout RPG Calculator";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.RadioButton radioPlayer;
        private System.Windows.Forms.Label radioTargetLabel;
        private System.Windows.Forms.RadioButton radioEnemy;
        private System.Windows.Forms.ComboBox comboUnit;
        private System.Windows.Forms.ComboBox comboDifficulty;
        private System.Windows.Forms.Label comboUnitLabel;
        private System.Windows.Forms.Label comboDifficultyLabel;
        private System.Windows.Forms.CheckBox checkDefaultEquipment;
        private System.Windows.Forms.ComboBox comboWeapon;
        private System.Windows.Forms.Label comboWeaponLabel;
        private System.Windows.Forms.Label comboArmourLabel;
        private System.Windows.Forms.ComboBox comboArmour;
        private System.Windows.Forms.TextBox textSkill;
        private System.Windows.Forms.Label textSkillLabel;
        private System.Windows.Forms.Label scenarioLabel;
        private System.Windows.Forms.TextBox textShotCount;
        private System.Windows.Forms.Label textShotCountLabel;
        private System.Windows.Forms.Label comboFireTypeLabel;
        private System.Windows.Forms.ComboBox comboFireType;
        private System.Windows.Forms.Label textInitialHealthLabel;
        private System.Windows.Forms.TextBox textInitialHealth;
        private System.Windows.Forms.Label textDistanceLabel;
        private System.Windows.Forms.TextBox textDistance;
        private System.Windows.Forms.Label resultsLabel;
        private System.Windows.Forms.Label textDamageDealtLabel;
        private System.Windows.Forms.TextBox textDamageDealt;
        private System.Windows.Forms.Label textCurrentHealthLabel;
        private System.Windows.Forms.TextBox textCurrentHealth;
        private System.Windows.Forms.Button buttonSetHP;
        private System.Windows.Forms.TextBox textLog;
        private System.Windows.Forms.Label textLogLabel;
        private System.Windows.Forms.Button buttonCalculate;
    }
}

