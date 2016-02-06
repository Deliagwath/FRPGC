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
            this.radioAttackerPlayer = new System.Windows.Forms.RadioButton();
            this.radioAttackerEnemy = new System.Windows.Forms.RadioButton();
            this.comboAttackingUnit = new System.Windows.Forms.ComboBox();
            this.comboAttackerDifficulty = new System.Windows.Forms.ComboBox();
            this.comboAttackerUnitLabel = new System.Windows.Forms.Label();
            this.comboAttackerDifficultyLabel = new System.Windows.Forms.Label();
            this.checkAttackerDefaultEquipment = new System.Windows.Forms.CheckBox();
            this.comboWeapon = new System.Windows.Forms.ComboBox();
            this.comboWeaponLabel = new System.Windows.Forms.Label();
            this.comboArmourLabel = new System.Windows.Forms.Label();
            this.comboArmour = new System.Windows.Forms.ComboBox();
            this.textSkill = new System.Windows.Forms.TextBox();
            this.textSkillLabel = new System.Windows.Forms.Label();
            this.scenarioLabel = new System.Windows.Forms.Label();
            this.textAttacksLaunched = new System.Windows.Forms.TextBox();
            this.textAttacksLaunchedLabel = new System.Windows.Forms.Label();
            this.comboAttackingMethodLabel = new System.Windows.Forms.Label();
            this.comboAttackingMethod = new System.Windows.Forms.ComboBox();
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
            this.checkDefenderDefaultEquipment = new System.Windows.Forms.CheckBox();
            this.comboDefenderDifficultyLabel = new System.Windows.Forms.Label();
            this.comboDefenderDifficulty = new System.Windows.Forms.ComboBox();
            this.comboDefenderUnitLabel = new System.Windows.Forms.Label();
            this.comboDefendingUnit = new System.Windows.Forms.ComboBox();
            this.radioDefenderEnemy = new System.Windows.Forms.RadioButton();
            this.radioDefenderPlayer = new System.Windows.Forms.RadioButton();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.hitChanceLabel = new System.Windows.Forms.Label();
            this.hitChance = new System.Windows.Forms.TextBox();
            this.clearLogButton = new System.Windows.Forms.Button();
            this.bonusHitChance = new System.Windows.Forms.TextBox();
            this.bonusHitChanceLabel = new System.Windows.Forms.Label();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // radioAttackerPlayer
            // 
            this.radioAttackerPlayer.AutoSize = true;
            this.radioAttackerPlayer.Checked = true;
            this.radioAttackerPlayer.Location = new System.Drawing.Point(6, 12);
            this.radioAttackerPlayer.Name = "radioAttackerPlayer";
            this.radioAttackerPlayer.Size = new System.Drawing.Size(54, 17);
            this.radioAttackerPlayer.TabIndex = 1;
            this.radioAttackerPlayer.TabStop = true;
            this.radioAttackerPlayer.Text = "Player";
            this.radioAttackerPlayer.UseVisualStyleBackColor = true;
            this.radioAttackerPlayer.CheckedChanged += new System.EventHandler(this.radioAttackerPlayerChecked);
            // 
            // radioAttackerEnemy
            // 
            this.radioAttackerEnemy.AutoSize = true;
            this.radioAttackerEnemy.Location = new System.Drawing.Point(6, 32);
            this.radioAttackerEnemy.Name = "radioAttackerEnemy";
            this.radioAttackerEnemy.Size = new System.Drawing.Size(57, 17);
            this.radioAttackerEnemy.TabIndex = 3;
            this.radioAttackerEnemy.Text = "Enemy";
            this.radioAttackerEnemy.UseVisualStyleBackColor = true;
            this.radioAttackerEnemy.CheckedChanged += new System.EventHandler(this.radioAttackerEnemyChecked);
            // 
            // comboAttackingUnit
            // 
            this.comboAttackingUnit.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboAttackingUnit.FormattingEnabled = true;
            this.comboAttackingUnit.Location = new System.Drawing.Point(12, 84);
            this.comboAttackingUnit.Name = "comboAttackingUnit";
            this.comboAttackingUnit.Size = new System.Drawing.Size(121, 21);
            this.comboAttackingUnit.TabIndex = 4;
            this.comboAttackingUnit.SelectedIndexChanged += new System.EventHandler(this.comboAttackerUnitChanged);
            // 
            // comboAttackerDifficulty
            // 
            this.comboAttackerDifficulty.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboAttackerDifficulty.FormattingEnabled = true;
            this.comboAttackerDifficulty.Location = new System.Drawing.Point(12, 124);
            this.comboAttackerDifficulty.Name = "comboAttackerDifficulty";
            this.comboAttackerDifficulty.Size = new System.Drawing.Size(121, 21);
            this.comboAttackerDifficulty.TabIndex = 5;
            this.comboAttackerDifficulty.Visible = false;
            this.comboAttackerDifficulty.SelectedIndexChanged += new System.EventHandler(this.comboAttackerDifficultyChanged);
            // 
            // comboAttackerUnitLabel
            // 
            this.comboAttackerUnitLabel.AutoSize = true;
            this.comboAttackerUnitLabel.Location = new System.Drawing.Point(12, 68);
            this.comboAttackerUnitLabel.Name = "comboAttackerUnitLabel";
            this.comboAttackerUnitLabel.Size = new System.Drawing.Size(67, 13);
            this.comboAttackerUnitLabel.TabIndex = 6;
            this.comboAttackerUnitLabel.Text = "Player Name";
            // 
            // comboAttackerDifficultyLabel
            // 
            this.comboAttackerDifficultyLabel.AutoSize = true;
            this.comboAttackerDifficultyLabel.Location = new System.Drawing.Point(12, 108);
            this.comboAttackerDifficultyLabel.Name = "comboAttackerDifficultyLabel";
            this.comboAttackerDifficultyLabel.Size = new System.Drawing.Size(47, 13);
            this.comboAttackerDifficultyLabel.TabIndex = 7;
            this.comboAttackerDifficultyLabel.Text = "Difficulty";
            this.comboAttackerDifficultyLabel.Visible = false;
            // 
            // checkAttackerDefaultEquipment
            // 
            this.checkAttackerDefaultEquipment.AutoSize = true;
            this.checkAttackerDefaultEquipment.Checked = true;
            this.checkAttackerDefaultEquipment.CheckState = System.Windows.Forms.CheckState.Checked;
            this.checkAttackerDefaultEquipment.Location = new System.Drawing.Point(12, 151);
            this.checkAttackerDefaultEquipment.Name = "checkAttackerDefaultEquipment";
            this.checkAttackerDefaultEquipment.Size = new System.Drawing.Size(113, 17);
            this.checkAttackerDefaultEquipment.TabIndex = 8;
            this.checkAttackerDefaultEquipment.Text = "Default Equipment";
            this.checkAttackerDefaultEquipment.UseVisualStyleBackColor = true;
            this.checkAttackerDefaultEquipment.Visible = false;
            // 
            // comboWeapon
            // 
            this.comboWeapon.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboWeapon.FormattingEnabled = true;
            this.comboWeapon.Location = new System.Drawing.Point(12, 187);
            this.comboWeapon.Name = "comboWeapon";
            this.comboWeapon.Size = new System.Drawing.Size(121, 21);
            this.comboWeapon.TabIndex = 9;
            this.comboWeapon.SelectedIndexChanged += new System.EventHandler(this.comboWeaponChanged);
            // 
            // comboWeaponLabel
            // 
            this.comboWeaponLabel.AutoSize = true;
            this.comboWeaponLabel.Location = new System.Drawing.Point(9, 171);
            this.comboWeaponLabel.Name = "comboWeaponLabel";
            this.comboWeaponLabel.Size = new System.Drawing.Size(96, 13);
            this.comboWeaponLabel.TabIndex = 10;
            this.comboWeaponLabel.Text = "Attacking Weapon";
            // 
            // comboArmourLabel
            // 
            this.comboArmourLabel.AutoSize = true;
            this.comboArmourLabel.Location = new System.Drawing.Point(139, 171);
            this.comboArmourLabel.Name = "comboArmourLabel";
            this.comboArmourLabel.Size = new System.Drawing.Size(92, 13);
            this.comboArmourLabel.TabIndex = 13;
            this.comboArmourLabel.Text = "Defending Armour";
            // 
            // comboArmour
            // 
            this.comboArmour.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboArmour.FormattingEnabled = true;
            this.comboArmour.Location = new System.Drawing.Point(139, 187);
            this.comboArmour.Name = "comboArmour";
            this.comboArmour.Size = new System.Drawing.Size(121, 21);
            this.comboArmour.TabIndex = 14;
            // 
            // textSkill
            // 
            this.textSkill.Location = new System.Drawing.Point(12, 227);
            this.textSkill.Multiline = true;
            this.textSkill.Name = "textSkill";
            this.textSkill.ReadOnly = true;
            this.textSkill.Size = new System.Drawing.Size(121, 303);
            this.textSkill.TabIndex = 15;
            // 
            // textSkillLabel
            // 
            this.textSkillLabel.AutoSize = true;
            this.textSkillLabel.Location = new System.Drawing.Point(9, 211);
            this.textSkillLabel.Name = "textSkillLabel";
            this.textSkillLabel.Size = new System.Drawing.Size(31, 13);
            this.textSkillLabel.TabIndex = 16;
            this.textSkillLabel.Text = "Skills";
            // 
            // scenarioLabel
            // 
            this.scenarioLabel.AutoSize = true;
            this.scenarioLabel.Location = new System.Drawing.Point(263, 9);
            this.scenarioLabel.Name = "scenarioLabel";
            this.scenarioLabel.Size = new System.Drawing.Size(49, 13);
            this.scenarioLabel.TabIndex = 17;
            this.scenarioLabel.Text = "Scenario";
            // 
            // textAttacksLaunched
            // 
            this.textAttacksLaunched.Location = new System.Drawing.Point(266, 45);
            this.textAttacksLaunched.MaxLength = 3;
            this.textAttacksLaunched.Name = "textAttacksLaunched";
            this.textAttacksLaunched.Size = new System.Drawing.Size(109, 20);
            this.textAttacksLaunched.TabIndex = 18;
            // 
            // textAttacksLaunchedLabel
            // 
            this.textAttacksLaunchedLabel.AutoSize = true;
            this.textAttacksLaunchedLabel.Location = new System.Drawing.Point(263, 29);
            this.textAttacksLaunchedLabel.Name = "textAttacksLaunchedLabel";
            this.textAttacksLaunchedLabel.Size = new System.Drawing.Size(95, 13);
            this.textAttacksLaunchedLabel.TabIndex = 19;
            this.textAttacksLaunchedLabel.Text = "Number of Attacks";
            // 
            // comboAttackingMethodLabel
            // 
            this.comboAttackingMethodLabel.AutoSize = true;
            this.comboAttackingMethodLabel.Location = new System.Drawing.Point(263, 68);
            this.comboAttackingMethodLabel.Name = "comboAttackingMethodLabel";
            this.comboAttackingMethodLabel.Size = new System.Drawing.Size(91, 13);
            this.comboAttackingMethodLabel.TabIndex = 20;
            this.comboAttackingMethodLabel.Text = "Attacking Method";
            // 
            // comboAttackingMethod
            // 
            this.comboAttackingMethod.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboAttackingMethod.FormattingEnabled = true;
            this.comboAttackingMethod.Items.AddRange(new object[] {
            "Single Shot",
            "Burst Shot",
            "Melee"});
            this.comboAttackingMethod.Location = new System.Drawing.Point(266, 84);
            this.comboAttackingMethod.Name = "comboAttackingMethod";
            this.comboAttackingMethod.Size = new System.Drawing.Size(109, 21);
            this.comboAttackingMethod.TabIndex = 21;
            // 
            // textInitialHealthLabel
            // 
            this.textInitialHealthLabel.AutoSize = true;
            this.textInitialHealthLabel.Location = new System.Drawing.Point(263, 225);
            this.textInitialHealthLabel.Name = "textInitialHealthLabel";
            this.textInitialHealthLabel.Size = new System.Drawing.Size(65, 13);
            this.textInitialHealthLabel.TabIndex = 22;
            this.textInitialHealthLabel.Text = "Initial Health";
            // 
            // textInitialHealth
            // 
            this.textInitialHealth.Location = new System.Drawing.Point(266, 241);
            this.textInitialHealth.MaxLength = 5;
            this.textInitialHealth.Name = "textInitialHealth";
            this.textInitialHealth.Size = new System.Drawing.Size(109, 20);
            this.textInitialHealth.TabIndex = 23;
            this.textInitialHealth.Text = "0";
            // 
            // textDistanceLabel
            // 
            this.textDistanceLabel.AutoSize = true;
            this.textDistanceLabel.Location = new System.Drawing.Point(263, 108);
            this.textDistanceLabel.Name = "textDistanceLabel";
            this.textDistanceLabel.Size = new System.Drawing.Size(39, 13);
            this.textDistanceLabel.TabIndex = 24;
            this.textDistanceLabel.Text = "Range";
            // 
            // textDistance
            // 
            this.textDistance.Location = new System.Drawing.Point(266, 124);
            this.textDistance.MaxLength = 4;
            this.textDistance.Name = "textDistance";
            this.textDistance.Size = new System.Drawing.Size(109, 20);
            this.textDistance.TabIndex = 25;
            this.textDistance.TextChanged += new System.EventHandler(this.hitChanceChange);
            // 
            // resultsLabel
            // 
            this.resultsLabel.AutoSize = true;
            this.resultsLabel.Location = new System.Drawing.Point(378, 11);
            this.resultsLabel.Name = "resultsLabel";
            this.resultsLabel.Size = new System.Drawing.Size(42, 13);
            this.resultsLabel.TabIndex = 26;
            this.resultsLabel.Text = "Results";
            // 
            // textDamageDealtLabel
            // 
            this.textDamageDealtLabel.AutoSize = true;
            this.textDamageDealtLabel.Location = new System.Drawing.Point(378, 28);
            this.textDamageDealtLabel.Name = "textDamageDealtLabel";
            this.textDamageDealtLabel.Size = new System.Drawing.Size(75, 13);
            this.textDamageDealtLabel.TabIndex = 27;
            this.textDamageDealtLabel.Text = "Damage Dealt";
            // 
            // textDamageDealt
            // 
            this.textDamageDealt.Location = new System.Drawing.Point(381, 44);
            this.textDamageDealt.Name = "textDamageDealt";
            this.textDamageDealt.ReadOnly = true;
            this.textDamageDealt.Size = new System.Drawing.Size(100, 20);
            this.textDamageDealt.TabIndex = 28;
            // 
            // textCurrentHealthLabel
            // 
            this.textCurrentHealthLabel.AutoSize = true;
            this.textCurrentHealthLabel.Location = new System.Drawing.Point(378, 68);
            this.textCurrentHealthLabel.Name = "textCurrentHealthLabel";
            this.textCurrentHealthLabel.Size = new System.Drawing.Size(75, 13);
            this.textCurrentHealthLabel.TabIndex = 29;
            this.textCurrentHealthLabel.Text = "Current Health";
            // 
            // textCurrentHealth
            // 
            this.textCurrentHealth.Location = new System.Drawing.Point(381, 85);
            this.textCurrentHealth.Name = "textCurrentHealth";
            this.textCurrentHealth.ReadOnly = true;
            this.textCurrentHealth.Size = new System.Drawing.Size(100, 20);
            this.textCurrentHealth.TabIndex = 30;
            // 
            // buttonSetHP
            // 
            this.buttonSetHP.Location = new System.Drawing.Point(381, 161);
            this.buttonSetHP.Name = "buttonSetHP";
            this.buttonSetHP.Size = new System.Drawing.Size(100, 23);
            this.buttonSetHP.TabIndex = 31;
            this.buttonSetHP.Text = "Set Init = Curr HP";
            this.buttonSetHP.UseVisualStyleBackColor = true;
            this.buttonSetHP.Click += new System.EventHandler(this.buttonSetHP_Click);
            // 
            // textLog
            // 
            this.textLog.Location = new System.Drawing.Point(139, 280);
            this.textLog.Multiline = true;
            this.textLog.Name = "textLog";
            this.textLog.ReadOnly = true;
            this.textLog.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.textLog.Size = new System.Drawing.Size(342, 250);
            this.textLog.TabIndex = 32;
            // 
            // textLogLabel
            // 
            this.textLogLabel.AutoSize = true;
            this.textLogLabel.Location = new System.Drawing.Point(136, 264);
            this.textLogLabel.Name = "textLogLabel";
            this.textLogLabel.Size = new System.Drawing.Size(25, 13);
            this.textLogLabel.TabIndex = 33;
            this.textLogLabel.Text = "Log";
            // 
            // buttonCalculate
            // 
            this.buttonCalculate.Location = new System.Drawing.Point(381, 122);
            this.buttonCalculate.Name = "buttonCalculate";
            this.buttonCalculate.Size = new System.Drawing.Size(100, 23);
            this.buttonCalculate.TabIndex = 34;
            this.buttonCalculate.Text = "Calculate";
            this.buttonCalculate.UseVisualStyleBackColor = true;
            this.buttonCalculate.Click += new System.EventHandler(this.calculate);
            // 
            // checkDefenderDefaultEquipment
            // 
            this.checkDefenderDefaultEquipment.AutoSize = true;
            this.checkDefenderDefaultEquipment.Checked = true;
            this.checkDefenderDefaultEquipment.CheckState = System.Windows.Forms.CheckState.Checked;
            this.checkDefenderDefaultEquipment.Location = new System.Drawing.Point(139, 151);
            this.checkDefenderDefaultEquipment.Name = "checkDefenderDefaultEquipment";
            this.checkDefenderDefaultEquipment.Size = new System.Drawing.Size(113, 17);
            this.checkDefenderDefaultEquipment.TabIndex = 36;
            this.checkDefenderDefaultEquipment.Text = "Default Equipment";
            this.checkDefenderDefaultEquipment.UseVisualStyleBackColor = true;
            this.checkDefenderDefaultEquipment.Visible = false;
            // 
            // comboDefenderDifficultyLabel
            // 
            this.comboDefenderDifficultyLabel.AutoSize = true;
            this.comboDefenderDifficultyLabel.Location = new System.Drawing.Point(139, 108);
            this.comboDefenderDifficultyLabel.Name = "comboDefenderDifficultyLabel";
            this.comboDefenderDifficultyLabel.Size = new System.Drawing.Size(47, 13);
            this.comboDefenderDifficultyLabel.TabIndex = 38;
            this.comboDefenderDifficultyLabel.Text = "Difficulty";
            this.comboDefenderDifficultyLabel.Visible = false;
            // 
            // comboDefenderDifficulty
            // 
            this.comboDefenderDifficulty.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboDefenderDifficulty.FormattingEnabled = true;
            this.comboDefenderDifficulty.Location = new System.Drawing.Point(139, 124);
            this.comboDefenderDifficulty.Name = "comboDefenderDifficulty";
            this.comboDefenderDifficulty.Size = new System.Drawing.Size(121, 21);
            this.comboDefenderDifficulty.TabIndex = 37;
            this.comboDefenderDifficulty.Visible = false;
            this.comboDefenderDifficulty.SelectedIndexChanged += new System.EventHandler(this.comboDefenderDifficultyChanged);
            // 
            // comboDefenderUnitLabel
            // 
            this.comboDefenderUnitLabel.AutoSize = true;
            this.comboDefenderUnitLabel.Location = new System.Drawing.Point(139, 69);
            this.comboDefenderUnitLabel.Name = "comboDefenderUnitLabel";
            this.comboDefenderUnitLabel.Size = new System.Drawing.Size(67, 13);
            this.comboDefenderUnitLabel.TabIndex = 42;
            this.comboDefenderUnitLabel.Text = "Player Name";
            // 
            // comboDefendingUnit
            // 
            this.comboDefendingUnit.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboDefendingUnit.FormattingEnabled = true;
            this.comboDefendingUnit.Location = new System.Drawing.Point(139, 84);
            this.comboDefendingUnit.Name = "comboDefendingUnit";
            this.comboDefendingUnit.Size = new System.Drawing.Size(121, 21);
            this.comboDefendingUnit.TabIndex = 41;
            this.comboDefendingUnit.SelectedIndexChanged += new System.EventHandler(this.comboDefenderUnitChanged);
            // 
            // radioDefenderEnemy
            // 
            this.radioDefenderEnemy.AutoSize = true;
            this.radioDefenderEnemy.Location = new System.Drawing.Point(6, 32);
            this.radioDefenderEnemy.Name = "radioDefenderEnemy";
            this.radioDefenderEnemy.Size = new System.Drawing.Size(57, 17);
            this.radioDefenderEnemy.TabIndex = 40;
            this.radioDefenderEnemy.Text = "Enemy";
            this.radioDefenderEnemy.UseVisualStyleBackColor = true;
            this.radioDefenderEnemy.CheckedChanged += new System.EventHandler(this.radioDefenderEnemyChecked);
            // 
            // radioDefenderPlayer
            // 
            this.radioDefenderPlayer.AutoSize = true;
            this.radioDefenderPlayer.Checked = true;
            this.radioDefenderPlayer.Location = new System.Drawing.Point(6, 12);
            this.radioDefenderPlayer.Name = "radioDefenderPlayer";
            this.radioDefenderPlayer.Size = new System.Drawing.Size(54, 17);
            this.radioDefenderPlayer.TabIndex = 39;
            this.radioDefenderPlayer.TabStop = true;
            this.radioDefenderPlayer.Text = "Player";
            this.radioDefenderPlayer.UseVisualStyleBackColor = true;
            this.radioDefenderPlayer.CheckedChanged += new System.EventHandler(this.radioDefenderPlayerChecked);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.radioAttackerPlayer);
            this.groupBox1.Controls.Add(this.radioAttackerEnemy);
            this.groupBox1.Location = new System.Drawing.Point(12, 9);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(121, 56);
            this.groupBox1.TabIndex = 43;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Attacker";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.radioDefenderPlayer);
            this.groupBox2.Controls.Add(this.radioDefenderEnemy);
            this.groupBox2.Location = new System.Drawing.Point(139, 9);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(121, 57);
            this.groupBox2.TabIndex = 44;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Defender";
            // 
            // hitChanceLabel
            // 
            this.hitChanceLabel.AutoSize = true;
            this.hitChanceLabel.Location = new System.Drawing.Point(263, 186);
            this.hitChanceLabel.Name = "hitChanceLabel";
            this.hitChanceLabel.Size = new System.Drawing.Size(60, 13);
            this.hitChanceLabel.TabIndex = 45;
            this.hitChanceLabel.Text = "Hit Chance";
            // 
            // hitChance
            // 
            this.hitChance.Location = new System.Drawing.Point(266, 202);
            this.hitChance.Name = "hitChance";
            this.hitChance.ReadOnly = true;
            this.hitChance.Size = new System.Drawing.Size(109, 20);
            this.hitChance.TabIndex = 46;
            // 
            // clearLogButton
            // 
            this.clearLogButton.Location = new System.Drawing.Point(382, 199);
            this.clearLogButton.Name = "clearLogButton";
            this.clearLogButton.Size = new System.Drawing.Size(100, 23);
            this.clearLogButton.TabIndex = 47;
            this.clearLogButton.Text = "Clear Log";
            this.clearLogButton.UseVisualStyleBackColor = true;
            this.clearLogButton.Click += new System.EventHandler(this.clearLog);
            // 
            // bonusHitChance
            // 
            this.bonusHitChance.Location = new System.Drawing.Point(266, 164);
            this.bonusHitChance.MaxLength = 3;
            this.bonusHitChance.Name = "bonusHitChance";
            this.bonusHitChance.Size = new System.Drawing.Size(109, 20);
            this.bonusHitChance.TabIndex = 49;
            this.bonusHitChance.TextChanged += new System.EventHandler(this.hitChanceChange);
            // 
            // bonusHitChanceLabel
            // 
            this.bonusHitChanceLabel.AutoSize = true;
            this.bonusHitChanceLabel.Location = new System.Drawing.Point(263, 148);
            this.bonusHitChanceLabel.Name = "bonusHitChanceLabel";
            this.bonusHitChanceLabel.Size = new System.Drawing.Size(93, 13);
            this.bonusHitChanceLabel.TabIndex = 48;
            this.bonusHitChanceLabel.Text = "Bonus Hit Chance";
            // 
            // mainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(494, 542);
            this.Controls.Add(this.bonusHitChance);
            this.Controls.Add(this.bonusHitChanceLabel);
            this.Controls.Add(this.clearLogButton);
            this.Controls.Add(this.hitChance);
            this.Controls.Add(this.hitChanceLabel);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.comboDefenderUnitLabel);
            this.Controls.Add(this.comboDefendingUnit);
            this.Controls.Add(this.comboDefenderDifficultyLabel);
            this.Controls.Add(this.comboDefenderDifficulty);
            this.Controls.Add(this.checkDefenderDefaultEquipment);
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
            this.Controls.Add(this.comboAttackingMethod);
            this.Controls.Add(this.comboAttackingMethodLabel);
            this.Controls.Add(this.textAttacksLaunchedLabel);
            this.Controls.Add(this.textAttacksLaunched);
            this.Controls.Add(this.scenarioLabel);
            this.Controls.Add(this.textSkillLabel);
            this.Controls.Add(this.textSkill);
            this.Controls.Add(this.comboArmour);
            this.Controls.Add(this.comboArmourLabel);
            this.Controls.Add(this.comboWeaponLabel);
            this.Controls.Add(this.comboWeapon);
            this.Controls.Add(this.checkAttackerDefaultEquipment);
            this.Controls.Add(this.comboAttackerDifficultyLabel);
            this.Controls.Add(this.comboAttackerUnitLabel);
            this.Controls.Add(this.comboAttackerDifficulty);
            this.Controls.Add(this.comboAttackingUnit);
            this.Name = "mainForm";
            this.Text = "Fallout RPG Calculator";
            this.Load += new System.EventHandler(this.onLoad);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.RadioButton radioAttackerPlayer;
        private System.Windows.Forms.RadioButton radioAttackerEnemy;
        private System.Windows.Forms.ComboBox comboAttackingUnit;
        private System.Windows.Forms.ComboBox comboAttackerDifficulty;
        private System.Windows.Forms.Label comboAttackerUnitLabel;
        private System.Windows.Forms.Label comboAttackerDifficultyLabel;
        private System.Windows.Forms.CheckBox checkAttackerDefaultEquipment;
        private System.Windows.Forms.ComboBox comboWeapon;
        private System.Windows.Forms.Label comboWeaponLabel;
        private System.Windows.Forms.Label comboArmourLabel;
        private System.Windows.Forms.ComboBox comboArmour;
        private System.Windows.Forms.TextBox textSkill;
        private System.Windows.Forms.Label textSkillLabel;
        private System.Windows.Forms.Label scenarioLabel;
        private System.Windows.Forms.TextBox textAttacksLaunched;
        private System.Windows.Forms.Label textAttacksLaunchedLabel;
        private System.Windows.Forms.Label comboAttackingMethodLabel;
        private System.Windows.Forms.ComboBox comboAttackingMethod;
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
        private System.Windows.Forms.CheckBox checkDefenderDefaultEquipment;
        private System.Windows.Forms.Label comboDefenderDifficultyLabel;
        private System.Windows.Forms.ComboBox comboDefenderDifficulty;
        private System.Windows.Forms.Label comboDefenderUnitLabel;
        private System.Windows.Forms.ComboBox comboDefendingUnit;
        private System.Windows.Forms.RadioButton radioDefenderEnemy;
        private System.Windows.Forms.RadioButton radioDefenderPlayer;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Label hitChanceLabel;
        private System.Windows.Forms.TextBox hitChance;
        private System.Windows.Forms.Button clearLogButton;
        private System.Windows.Forms.TextBox bonusHitChance;
        private System.Windows.Forms.Label bonusHitChanceLabel;
    }
}

