namespace PlantsVs.ZombiesTools
{
    partial class Form1
    {
        /// <summary>
        /// 設計工具所需的變數。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 清除任何使用中的資源。
        /// </summary>
        /// <param name="disposing">如果應該處置受控資源則為 true，否則為 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form 設計工具產生的程式碼

        /// <summary>
        /// 此為設計工具支援所需的方法 - 請勿使用程式碼編輯器修改
        /// 這個方法的內容。
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.label1 = new System.Windows.Forms.Label();
            this.SunValue = new System.Windows.Forms.Label();
            this.Timer1 = new System.Windows.Forms.Timer(this.components);
            this.SetSunValueButton = new System.Windows.Forms.Button();
            this.SetSunValueTextBox = new System.Windows.Forms.TextBox();
            this.SetMoneyValueTextBox = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.MoneyValue = new System.Windows.Forms.Label();
            this.CDOffButton = new System.Windows.Forms.Button();
            this.SetMoneyValueButton = new System.Windows.Forms.Button();
            this.CDOnButton = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.CDValue = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.InvincibleValue = new System.Windows.Forms.Label();
            this.InvincibleOnButton = new System.Windows.Forms.Button();
            this.InvincibleOffButton = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("微軟正黑體", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.label1.Location = new System.Drawing.Point(6, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(96, 34);
            this.label1.TabIndex = 0;
            this.label1.Text = "陽光值";
            // 
            // SunValue
            // 
            this.SunValue.AutoSize = true;
            this.SunValue.Font = new System.Drawing.Font("微軟正黑體", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.SunValue.Location = new System.Drawing.Point(152, 9);
            this.SunValue.Name = "SunValue";
            this.SunValue.Size = new System.Drawing.Size(150, 34);
            this.SunValue.TabIndex = 1;
            this.SunValue.Text = "未啟動遊戲";
            // 
            // Timer1
            // 
            this.Timer1.Enabled = true;
            this.Timer1.Tick += new System.EventHandler(this.Timer1_Tick);
            // 
            // SetSunValueButton
            // 
            this.SetSunValueButton.Font = new System.Drawing.Font("微軟正黑體", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.SetSunValueButton.Location = new System.Drawing.Point(158, 55);
            this.SetSunValueButton.Name = "SetSunValueButton";
            this.SetSunValueButton.Size = new System.Drawing.Size(130, 43);
            this.SetSunValueButton.TabIndex = 2;
            this.SetSunValueButton.Text = "修改陽光值";
            this.SetSunValueButton.UseVisualStyleBackColor = true;
            this.SetSunValueButton.Click += new System.EventHandler(this.SetSunValueButton_Click);
            // 
            // SetSunValueTextBox
            // 
            this.SetSunValueTextBox.Font = new System.Drawing.Font("微軟正黑體", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.SetSunValueTextBox.Location = new System.Drawing.Point(12, 55);
            this.SetSunValueTextBox.Name = "SetSunValueTextBox";
            this.SetSunValueTextBox.Size = new System.Drawing.Size(130, 43);
            this.SetSunValueTextBox.TabIndex = 3;
            // 
            // SetMoneyValueTextBox
            // 
            this.SetMoneyValueTextBox.Font = new System.Drawing.Font("微軟正黑體", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.SetMoneyValueTextBox.Location = new System.Drawing.Point(12, 156);
            this.SetMoneyValueTextBox.Name = "SetMoneyValueTextBox";
            this.SetMoneyValueTextBox.Size = new System.Drawing.Size(130, 43);
            this.SetMoneyValueTextBox.TabIndex = 4;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("微軟正黑體", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.label2.Location = new System.Drawing.Point(6, 110);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(96, 34);
            this.label2.TabIndex = 5;
            this.label2.Text = "金幣值";
            // 
            // MoneyValue
            // 
            this.MoneyValue.AutoSize = true;
            this.MoneyValue.Font = new System.Drawing.Font("微軟正黑體", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.MoneyValue.Location = new System.Drawing.Point(152, 110);
            this.MoneyValue.Name = "MoneyValue";
            this.MoneyValue.Size = new System.Drawing.Size(150, 34);
            this.MoneyValue.TabIndex = 6;
            this.MoneyValue.Text = "未啟動遊戲";
            // 
            // CDOffButton
            // 
            this.CDOffButton.Font = new System.Drawing.Font("微軟正黑體", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.CDOffButton.Location = new System.Drawing.Point(12, 257);
            this.CDOffButton.Name = "CDOffButton";
            this.CDOffButton.Size = new System.Drawing.Size(130, 43);
            this.CDOffButton.TabIndex = 7;
            this.CDOffButton.Text = "無";
            this.CDOffButton.UseVisualStyleBackColor = true;
            this.CDOffButton.Click += new System.EventHandler(this.CDOffButton_Click);
            // 
            // SetMoneyValueButton
            // 
            this.SetMoneyValueButton.Font = new System.Drawing.Font("微軟正黑體", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.SetMoneyValueButton.Location = new System.Drawing.Point(158, 156);
            this.SetMoneyValueButton.Name = "SetMoneyValueButton";
            this.SetMoneyValueButton.Size = new System.Drawing.Size(130, 43);
            this.SetMoneyValueButton.TabIndex = 8;
            this.SetMoneyValueButton.Text = "修改金幣值";
            this.SetMoneyValueButton.UseVisualStyleBackColor = true;
            this.SetMoneyValueButton.Click += new System.EventHandler(this.SetMoneyValueButton_Click);
            // 
            // CDOnButton
            // 
            this.CDOnButton.Enabled = false;
            this.CDOnButton.Font = new System.Drawing.Font("微軟正黑體", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.CDOnButton.Location = new System.Drawing.Point(158, 257);
            this.CDOnButton.Name = "CDOnButton";
            this.CDOnButton.Size = new System.Drawing.Size(130, 43);
            this.CDOnButton.TabIndex = 9;
            this.CDOnButton.Text = "有";
            this.CDOnButton.UseVisualStyleBackColor = true;
            this.CDOnButton.Click += new System.EventHandler(this.CDOnButton_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("微軟正黑體", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.label3.Location = new System.Drawing.Point(6, 211);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(69, 34);
            this.label3.TabIndex = 10;
            this.label3.Text = "冷卻";
            // 
            // CDValue
            // 
            this.CDValue.AutoSize = true;
            this.CDValue.Font = new System.Drawing.Font("微軟正黑體", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.CDValue.Location = new System.Drawing.Point(138, 211);
            this.CDValue.Name = "CDValue";
            this.CDValue.Size = new System.Drawing.Size(150, 34);
            this.CDValue.TabIndex = 11;
            this.CDValue.Text = "未啟動遊戲";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("微軟正黑體", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.label4.Location = new System.Drawing.Point(6, 312);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(123, 34);
            this.label4.TabIndex = 12;
            this.label4.Text = "植物無敵";
            // 
            // InvincibleValue
            // 
            this.InvincibleValue.AutoSize = true;
            this.InvincibleValue.Font = new System.Drawing.Font("微軟正黑體", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.InvincibleValue.Location = new System.Drawing.Point(138, 312);
            this.InvincibleValue.Name = "InvincibleValue";
            this.InvincibleValue.Size = new System.Drawing.Size(150, 34);
            this.InvincibleValue.TabIndex = 13;
            this.InvincibleValue.Text = "未啟動遊戲";
            // 
            // InvincibleOnButton
            // 
            this.InvincibleOnButton.Font = new System.Drawing.Font("微軟正黑體", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.InvincibleOnButton.Location = new System.Drawing.Point(12, 358);
            this.InvincibleOnButton.Name = "InvincibleOnButton";
            this.InvincibleOnButton.Size = new System.Drawing.Size(130, 43);
            this.InvincibleOnButton.TabIndex = 14;
            this.InvincibleOnButton.Text = "開";
            this.InvincibleOnButton.UseVisualStyleBackColor = true;
            this.InvincibleOnButton.Click += new System.EventHandler(this.InvincibleOnButton_Click);
            // 
            // InvincibleOffButton
            // 
            this.InvincibleOffButton.Enabled = false;
            this.InvincibleOffButton.Font = new System.Drawing.Font("微軟正黑體", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.InvincibleOffButton.Location = new System.Drawing.Point(158, 358);
            this.InvincibleOffButton.Name = "InvincibleOffButton";
            this.InvincibleOffButton.Size = new System.Drawing.Size(130, 43);
            this.InvincibleOffButton.TabIndex = 15;
            this.InvincibleOffButton.Text = "關";
            this.InvincibleOffButton.UseVisualStyleBackColor = true;
            this.InvincibleOffButton.Click += new System.EventHandler(this.InvincibleOffButton_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(300, 416);
            this.Controls.Add(this.InvincibleOffButton);
            this.Controls.Add(this.InvincibleOnButton);
            this.Controls.Add(this.InvincibleValue);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.CDValue);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.CDOnButton);
            this.Controls.Add(this.SetMoneyValueButton);
            this.Controls.Add(this.CDOffButton);
            this.Controls.Add(this.MoneyValue);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.SetMoneyValueTextBox);
            this.Controls.Add(this.SetSunValueTextBox);
            this.Controls.Add(this.SetSunValueButton);
            this.Controls.Add(this.SunValue);
            this.Controls.Add(this.label1);
            this.Name = "Form1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Plants vs. Zombies Tools";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label SunValue;
        private System.Windows.Forms.Timer Timer1;
        private System.Windows.Forms.Button SetSunValueButton;
        private System.Windows.Forms.TextBox SetSunValueTextBox;
        private System.Windows.Forms.TextBox SetMoneyValueTextBox;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label MoneyValue;
        private System.Windows.Forms.Button CDOffButton;
        private System.Windows.Forms.Button SetMoneyValueButton;
        private System.Windows.Forms.Button CDOnButton;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label CDValue;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label InvincibleValue;
        private System.Windows.Forms.Button InvincibleOnButton;
        private System.Windows.Forms.Button InvincibleOffButton;
    }
}

