namespace Client
{
    partial class Form1
    {
        /// <summary>
        /// Обязательная переменная конструктора.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Освободить все используемые ресурсы.
        /// </summary>
        /// <param name="disposing">истинно, если управляемый ресурс должен быть удален; иначе ложно.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Код, автоматически созданный конструктором форм Windows

        /// <summary>
        /// Требуемый метод для поддержки конструктора — не изменяйте 
        /// содержимое этого метода с помощью редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
            this.server1BT = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.lastErrTB = new System.Windows.Forms.TextBox();
            this.cursorXTB = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.cursorYTB = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.phRamTB = new System.Windows.Forms.TextBox();
            this.virtRamTB = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.server2BT = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // server1BT
            // 
            this.server1BT.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.server1BT.Location = new System.Drawing.Point(163, 384);
            this.server1BT.Name = "server1BT";
            this.server1BT.Size = new System.Drawing.Size(117, 39);
            this.server1BT.TabIndex = 3;
            this.server1BT.Text = "Сервер1";
            this.server1BT.UseVisualStyleBackColor = true;
            this.server1BT.Click += new System.EventHandler(this.button1_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label1.Location = new System.Drawing.Point(135, 66);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(172, 18);
            this.label1.TabIndex = 4;
            this.label1.Text = "Код последней ошибки";
            // 
            // lastErrTB
            // 
            this.lastErrTB.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.lastErrTB.Location = new System.Drawing.Point(157, 97);
            this.lastErrTB.Name = "lastErrTB";
            this.lastErrTB.Size = new System.Drawing.Size(129, 24);
            this.lastErrTB.TabIndex = 0;
            // 
            // cursorXTB
            // 
            this.cursorXTB.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.cursorXTB.Location = new System.Drawing.Point(59, 235);
            this.cursorXTB.Name = "cursorXTB";
            this.cursorXTB.Size = new System.Drawing.Size(129, 24);
            this.cursorXTB.TabIndex = 5;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label2.Location = new System.Drawing.Point(117, 180);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(209, 18);
            this.label2.TabIndex = 6;
            this.label2.Text = "Текущее положение курсора";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label3.Location = new System.Drawing.Point(117, 214);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(18, 18);
            this.label3.TabIndex = 7;
            this.label3.Text = "X";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label4.Location = new System.Drawing.Point(309, 214);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(17, 18);
            this.label4.TabIndex = 8;
            this.label4.Text = "Y";
            // 
            // cursorYTB
            // 
            this.cursorYTB.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.cursorYTB.Location = new System.Drawing.Point(254, 235);
            this.cursorYTB.Name = "cursorYTB";
            this.cursorYTB.Size = new System.Drawing.Size(129, 24);
            this.cursorYTB.TabIndex = 9;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label5.Location = new System.Drawing.Point(528, 66);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(183, 18);
            this.label5.TabIndex = 10;
            this.label5.Text = "Используемая PhRAM %";
            // 
            // phRamTB
            // 
            this.phRamTB.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.phRamTB.Location = new System.Drawing.Point(551, 97);
            this.phRamTB.Name = "phRamTB";
            this.phRamTB.Size = new System.Drawing.Size(129, 24);
            this.phRamTB.TabIndex = 11;
            // 
            // virtRamTB
            // 
            this.virtRamTB.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.virtRamTB.Location = new System.Drawing.Point(551, 236);
            this.virtRamTB.Name = "virtRamTB";
            this.virtRamTB.Size = new System.Drawing.Size(129, 24);
            this.virtRamTB.TabIndex = 13;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label6.Location = new System.Drawing.Point(528, 205);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(186, 18);
            this.label6.TabIndex = 12;
            this.label6.Text = "Используемая VirtRAM %";
            // 
            // server2BT
            // 
            this.server2BT.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.server2BT.Location = new System.Drawing.Point(558, 384);
            this.server2BT.Name = "server2BT";
            this.server2BT.Size = new System.Drawing.Size(117, 39);
            this.server2BT.TabIndex = 14;
            this.server2BT.Text = "Сервер2";
            this.server2BT.UseVisualStyleBackColor = true;
            this.server2BT.Click += new System.EventHandler(this.server2BT_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.server2BT);
            this.Controls.Add(this.virtRamTB);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.phRamTB);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.cursorYTB);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.cursorXTB);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.server1BT);
            this.Controls.Add(this.lastErrTB);
            this.Name = "Form1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Клиент";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Button server1BT;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox lastErrTB;
        private System.Windows.Forms.TextBox cursorXTB;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox cursorYTB;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox phRamTB;
        private System.Windows.Forms.TextBox virtRamTB;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Button server2BT;
    }
}

