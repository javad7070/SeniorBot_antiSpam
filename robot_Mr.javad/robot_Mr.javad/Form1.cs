using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;
using Telegram;
using System.Windows.Forms;
using System.IO;
using System.Text.RegularExpressions;
using System.Collections;

namespace robot_Mr.javad
{
    public partial class Form1 : Form
    {
        string javad= "Your ID", ozviyat;
        string chanel= "Channel ID(without @)";
        string rules;
        string gplink;
        string join, left;
        int run = 0;
        string tokenTxt;

        private void ارتباطباماToolStripMenuItem_Click(object sender, EventArgs e)
        {
            System.Diagnostics.Process.Start("https://t.me/cpp_cs");
        }

        private void برنامهنویسToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MessageBox.Show(":طراح و برنامه نویس"+"\n"+"جوادمحمدی", "درباره",MessageBoxButtons.OK,MessageBoxIcon.Information);
        }

        private void خروجToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void setToken_Click(object sender, EventArgs e)
        {
            if(textBox2.Text.Length==0)
            {
                MessageBox.Show("لطفا یک توکن وارد کنید", "خطا", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            Telegram.bot.Token_Status = textBox2.Text;
            string jsString = Telegram.bot.Token_Status.ToString();
            if (jsString.ToLower() == "false")
            {
                MessageBox.Show("لطفا یک توکن معتبر وارد کنید", "خطا", MessageBoxButtons.OK, MessageBoxIcon.Error);
            
            
            }
            else 
            {
                tokenTxt = null;
                tokenTxt = textBox2.Text;
                Telegram.bot.token = tokenTxt;
            }

        }

        private void setAdmin_Click(object sender, EventArgs e)
        {
            if(textBox3.Text.Length==0)
            {
                MessageBox.Show("لطفا یک شناسه وارد کنید", "خطا", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            javad = null;
            javad = textBox3.Text;
        }

        long rload,rand,rform;
        public Form1()
        {
            InitializeComponent();
          Telegram.bot.token ="Token Bot";
            backgroundWorker1.RunWorkerAsync();
            CheckForIllegalCrossThreadCalls = false;
        }

        private void setChanel_Click(object sender, EventArgs e)
        {
            if(textBox4.Text.Length==0)
            {
                MessageBox.Show("لطفا یک ایدی وارد کنید", "خطا", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            if (textBox4.Text.StartsWith("@"))
            {
                MessageBox.Show("لطفا ایدی را بدون@ وارد کنید", "خطا", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                chanel = null;
                chanel = textBox4.Text;
            }
        }

        private void Clear_Btn_Click(object sender, EventArgs e)
        {
            textBox2.Clear();
            textBox3.Clear();
            textBox4.Clear();
            textBox2.Focus();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            this.Font = Properties.Settings.Default.font;
            Random f = new Random();
            rform = f.Next(45716875, 978874894);
            textBox1.Text = rform.ToString();
        }
        private void WriteUniqueToFile(string filedir, string text)
        {
            bool ex = false;
            if (File.Exists(filedir))
            {
                foreach (string line in File.ReadAllLines(filedir))
                {
                    if (line.Equals(text.Replace("\n", "")))
                    {
                        ex = true;
                        break;
                    }
                }
                if (!ex)
                {
                    StreamWriter file = new StreamWriter(filedir, true);
                    file.WriteLine(text);
                    file.Close();
                }
            }
            else
            {
                StreamWriter file = new StreamWriter(filedir, true);
                file.WriteLine(text);
                file.Close();
            }
        }
        private void backgroundWorker1_DoWork(object sender, DoWorkEventArgs e)
        {
            while (true)
            {
                Telegram.bot.update = "True";
                richTextBox1.Text = Telegram.bot.update.ToString()+"\n";
            //  Telegram.bot.sendMessage.send("@sn_test", richTextBox1.Text);
                if (Telegram.bot.update.Contains("private"))
                {
                    ozviyat = (Telegram.bot.Administrator_Group.StatusMember("@"+chanel, Telegram.bot.from_ID).ToString());
                    if (Telegram.bot.message_text == "/start" && ozviyat.ToLower() == "creator" || Telegram.bot.message_text == "/start" && ozviyat.ToLower() == "member" || Telegram.bot.message_text == "/start" && ozviyat.ToLower() == "administrator")
                    {
                        WriteUniqueToFile("members.txt", "#" + Telegram.bot.chat_id.ToString());
                        Telegram.bot.send_inline_keyboard.keyboard_R1_1 = "ورود به ربات🤠";
                        Telegram.bot.send_inline_keyboard.keyboard_R1_1_callback_data = "001";
                        Telegram.bot.send_inline_keyboard.keyboard_R2_1 = "پشتیبانی💬";
                        Telegram.bot.send_inline_keyboard.keyboard_R2_1_Url = "https://telegram.me/cpp_cs";
                        Telegram.bot.send_inline_keyboard.keyboard_R2_2 = "افزودن در گروه😎";
                        Telegram.bot.send_inline_keyboard.keyboard_R2_2_Url = "https://telegram.me/robo_mebot?startgroup=start";
                        Telegram.bot.send_inline_keyboard.keyboard_R3_1 = "کانال ما📢";
                        Telegram.bot.send_inline_keyboard.keyboard_R3_1_Url = "https://t.me/seniorTm";
                        Telegram.bot.send_inline_keyboard.send(Telegram.bot.chat_id, "سلام  " + Telegram.bot.from_first_name + "😃 به ربات سنیور تولز خوش اومدی😁 برای ورود به ربات روی دکمه زیر کلیک کن💕اگرم میخوای با سازنده من در ارتباط باشی روی دکمه پشتیبانی کلیک کن💖");
                    }
                    else if (Telegram.bot.data == "001")
                    {
                        Telegram.bot.editMessageInlinekeyboard.keyboard_R1_1 = "مشخصات شما💓";
                        Telegram.bot.editMessageInlinekeyboard.keyboard_R1_1_callback_data = "002";
                        Telegram.bot.editMessageInlinekeyboard.keyboard_R2_1 = "ارتباط با مدیر📞";
                        Telegram.bot.editMessageInlinekeyboard.keyboard_R2_1_callback_data = "003";
                        Telegram.bot.editMessageInlinekeyboard.keyboard_R3_1 = "سازنده🎖";
                        Telegram.bot.editMessageInlinekeyboard.keyboard_R3_1_callback_data = "004";
                        Telegram.bot.editMessageInlinekeyboard.keyboard_R4_1 = "بازگشت🔙";
                        Telegram.bot.editMessageInlinekeyboard.keyboard_R4_1_callback_data = "005";
                        Telegram.bot.editMessageInlinekeyboard.keyboard_R4_2 = "خرید سورس💰";
                        Telegram.bot.editMessageInlinekeyboard.keyboard_R4_2_callback_data = "006";
                        Telegram.bot.editMessageInlinekeyboard.send(Telegram.bot.chat_id, Telegram.bot.message_id, "لطفا یک گزینه رو انتخاب کن😜");
                    }
                    else if (Telegram.bot.data == "002")
                    {
                        Telegram.bot.sendMessage.parse_mode = "html";
                        Telegram.bot.getUserProfilePhotos.URL(Telegram.bot.chat_id);
                        Telegram.bot.sendMessage.reply_to_message(Telegram.bot.chat_id, "<b>🌟نام شما:</b>" + "<b>" + Telegram.bot.from_first_name + "</b>" + "\n" + "<b>✨شناسه شما:</b>" + "<b>" + Telegram.bot.from_ID + "</b>", Telegram.bot.message_id);
                    }
                    else if (Telegram.bot.data == "003")
                    {
                        Telegram.bot.answerCallbackQuery.send(Telegram.bot.callback_query_id, "لطفا پیامتو به شکل زیر بنویسو برام ارسال کن😍" + "\n" + "/send پیام شما");
                    }
                    else if (Telegram.bot.data == "004")
                    {
                        Telegram.bot.sendContact.send(Telegram.bot.chat_id, "+989226523303", "JAVAD MOHAMMADI");
                    }
                    else if (Telegram.bot.data == "005")
                    {
                        Telegram.bot.editMessageInlinekeyboard.keyboard_R1_1 = "ورود به ربات🤠";
                        Telegram.bot.editMessageInlinekeyboard.keyboard_R1_1_callback_data = "001";
                        Telegram.bot.editMessageInlinekeyboard.keyboard_R2_1 = "پشتیبانی💬";
                        Telegram.bot.editMessageInlinekeyboard.keyboard_R2_1_Url = "https://telegram.me/cpp_cs";
                        Telegram.bot.editMessageInlinekeyboard.keyboard_R2_2 = "افزودن در گروه😎";
                        Telegram.bot.editMessageInlinekeyboard.keyboard_R2_2_Url = "https://telegram.me/robo_mebot?startgroup=start";
                        Telegram.bot.editMessageInlinekeyboard.keyboard_R3_1 = "کانال ما📢";
                        Telegram.bot.editMessageInlinekeyboard.keyboard_R3_1_Url = "https://t.me/seniorTm";
                        Telegram.bot.editMessageInlinekeyboard.send(Telegram.bot.chat_id, Telegram.bot.message_id, "سلام  " + Telegram.bot.from_first_name + "😃 به ربات سنیور تولز خوش اومدی😁 برای ورود به ربات روی دکمه زیر کلیک کن💕اگرم میخوای با سازنده من در ارتباط باشی روی دکمه پشتیبانی کلیک کن💖");
                    }
                    else if (Telegram.bot.data == "006")
                    {
                        Telegram.bot.sendMessage.reply_to_message(Telegram.bot.chat_id, "خب دوست من حالا لایسنس خریدو برام بفرست😬" + "\n" + "اگرم لایسنس رو نخریدی میتونی از لینک زیر اقدام به خرید کنی😊" + "\n" + "https://zarinp.al/133091", Telegram.bot.message_id);
                        run++;
                    }
                    else if (run == 1)
                    {
                        string te = Telegram.bot.message_text;
                        if (textBox1.Text == te)
                        {
                            Telegram.bot.sendMessage.parse_mode = "html";
                            Telegram.bot.SendPhoto.caption = ("🛍اطلاعات محصول" + "\n" + "💡نام محصول:" + "\n" + "🥇سورس ربات ضداسپم سنیور" + "\n" + "🖇لینک محصول:" + "\n" + "http://yon.ir/f0haQ");
                            Telegram.bot.sendMessage.send(bot.chat_id, "<b>کد خرید شما صحیح است در حال ارسال اطلاعات محصول...✅</b>");
                            Telegram.bot.sendMessage.send(javad, "<b>این کد خرید مورد استفاده گردید و کد جدیدی در سیستم ثبت شد♻️</b>");
                            Telegram.bot.forwardMessage.send(javad, bot.from_ID, bot.message_id);
                            bot.SendPhoto.sendFromFile_id(bot.chat_id, "AgADBAADVqoxG7LL6VD4WJiWqTwLG-7najAABLeREjIko1ps2loCAAEC");
                            run = 0;
                            textBox1.Clear();
                            Random d = new Random();
                            rand = d.Next(45696875, 978874894);
                            textBox1.Text = rand.ToString();
                            Telegram.bot.sendMessage.parse_mode = "html";
                            Telegram.bot.sendMessage.send(javad, "<i>🔸کد محصولی که با منسوخ شدن کدقبلی ایجاد شده:</i>" + "\n" + "<code>" + textBox1.Text + "</code>");
                        }
                        else if (textBox1.Text != te)
                        {
                            Telegram.bot.sendMessage.parse_mode = "html";
                            Telegram.bot.sendMessage.reply_to_message(Telegram.bot.chat_id, "<b>لایسنس ارسال شده معتبر نیست❌</b>", Telegram.bot.message_id);
                            te = "";
                            run = 0;
                        }
                    }
                    else if (Telegram.bot.message_text.StartsWith("/send "))
                    {
                        Telegram.bot.forwardMessage.send(javad, Telegram.bot.from_ID, Telegram.bot.message_id);
                        Telegram.bot.sendMessage.send(javad, Telegram.bot.chat_id);
                        Telegram.bot.sendMessage.parse_mode = "html";
                        Telegram.bot.sendMessage.reply_to_message(Telegram.bot.chat_id, "<code>پیامت با موفقیت ارسال شد🤡</code>", Telegram.bot.message_id);
                    }
                    else if (Telegram.bot.message_text.ToLower() == "/start" && ozviyat.ToLower() != "creator" || Telegram.bot.message_text.ToLower() == "/start" && ozviyat.ToLower() != "member" || Telegram.bot.message_text.ToLower() == "/start" && ozviyat.ToLower() != "administrator")
                    {
                        Telegram.bot.sendMessage.parse_mode = "html";
                        Telegram.bot.sendMessage.reply_to_message(Telegram.bot.chat_id, "<b>😐شما عضو کانال تیم سنیور نیستید لطفا ابتدا در کانال ما عضو شوید تا ربات برای شما کار کند.😶ایدی کانال:</b>" + "\n" + "@SeniorTm", Telegram.bot.message_id);
                    }
                    else if (Telegram.bot.message_text.ToLower() == "/amar" && Telegram.bot.from_ID == javad)
                    {
                        using (StreamReader sr = new StreamReader("members.txt"))
                        {
                            long men = sr.ReadToEnd().Split('#').Count();
                            men = men - 1;
                            Telegram.bot.sendMessage.parse_mode = "html";
                            Telegram.bot.sendMessage.send(Telegram.bot.chat_id, "<i>👤تعداد اعضا ربات شما:</i>" + "\n" + "<b>" + men.ToString() + "</b>");
                        }
                    }
                    else if (Telegram.bot.message_text.StartsWith("/pm") && Telegram.bot.from_ID == javad)
                    {
                        var textall = Telegram.bot.message_text.Split('=').Last();
                        using (StreamReader tr = new StreamReader("members.txt"))
                        {
                            foreach (string x in tr.ReadToEnd().Split('#'))
                            {
                                Telegram.bot.sendMessage.parse_mode = "html";
                                Telegram.bot.sendMessage.send(x, "<b>" + textall + "</b>");
                            }
                        }
                        Telegram.bot.sendMessage.reply_to_message(Telegram.bot.chat_id, "<i>پیام شما با موفقیت برای تمام کاربران ربات ارسال شد✅</i>", Telegram.bot.message_id);
                    }
                    else if (Telegram.bot.message_text.ToLower() == "/code" && Telegram.bot.from_ID == javad)
                    {
                        Telegram.bot.sendMessage.parse_mode = "html";
                        Telegram.bot.sendMessage.reply_to_message(javad, "<i>🔸کد محصولی که هم اکنون در سیستم موجود است:</i>" + "\n" + "<code>" + textBox1.Text + "</code>", Telegram.bot.message_id);
                    }
                    else if (Telegram.bot.message_text.ToLower() == "/recode" && Telegram.bot.from_ID == javad)
                    {
                        textBox1.Clear();
                        Random c = new Random();
                        rload = c.Next(45685875, 978874894);
                        textBox1.Text = rload.ToString();
                        Telegram.bot.sendMessage.parse_mode = "html";
                        Telegram.bot.sendMessage.reply_to_message(javad, "<i>🔸کد محصول با موفقیت تغییر کرد!</i>" + "\n" + "<i>" + "🔹کد جدید محصول:" + "</i>" + "\n" + "<code>" + textBox1.Text + "</code>", Telegram.bot.message_id);
                    }
                    else if (Telegram.bot.message_text.ToLower() == "/status" && Telegram.bot.from_ID == javad)
                    {
                        Telegram.bot.SendFile.caption = ("آمار کاربران ربات👥");
                        Telegram.bot.SendFile.send(Telegram.bot.chat_id, @"E:\robot_Mr.javad\robot_Mr.javad\bin\Debug\members.txt");
                    }
                    else if (Telegram.bot.message_text.ToLower() == "/pv" && Telegram.bot.from_ID == javad)
                    {
                        Telegram.bot.sendMessage.parse_mode = "html";
                        Telegram.bot.sendMessage.reply_to_message(Telegram.bot.chat_id, "<b>درحال ارسال فایل راهنما لطفا اندکی صبر کنید...🕒</b>", Telegram.bot.message_id);
                        Telegram.bot.SendFile.caption = "فایل راهنمای پیوی ربات سنیور♥️";
                        Telegram.bot.SendFile.sendFromFile_id(Telegram.bot.chat_id, "BQADAgADcQADi-PoSFYD85zx-OH5Ag");
                    }
                }
                else if (Telegram.bot.update.Contains("supergroup"))
                {
                    if (Telegram.bot.message_text.ToLower() == "/memmbers")
                    {
                        Telegram.bot.sendMessage.parse_mode = "html";
                        Telegram.bot.sendMessage.reply_to_message(Telegram.bot.chat_id, "<b>⚡️تعداد اعضای گروه:</b>" + "\n" + "<b>" + Telegram.bot.Administrator_Group.MembersCount(Telegram.bot.chat_id).ToString() + "</b>" + "<b>نفر</b>", Telegram.bot.message_id);
                    }
                    if (Telegram.bot.message_text.ToLower() == "/admins")
                    {
                        ArrayList adm = new ArrayList();
                        adm.AddRange(Telegram.bot.Administrator_Group.GetsID_Administrator(Telegram.bot.chat_id));
                        foreach (string id in adm)
                        {
                            Telegram.bot.sendMessage.send(Telegram.bot.chat_id, id);
                        }
                    }
                    if (Telegram.bot.message_text.ToLower() == "/id")
                    {
                        Telegram.bot.sendMessage.parse_mode = "html";
                        Telegram.bot.sendMessage.reply_to_message(Telegram.bot.chat_id, "<b>🌟نام شما:</b>" + "<b>" + Telegram.bot.from_first_name + "</b>" + "\n" + "<b>✨شناسه شما:</b>" + "<b>" + Telegram.bot.from_ID + "</b>", Telegram.bot.message_id);
                    }
                    if (Telegram.bot.message_text.ToLower() == "/add" && bot.from_ID == javad)
                    {
                        Telegram.bot.sendMessage.parse_mode = "html";
                        Telegram.bot.sendMessage.reply_to_message(bot.chat_id, "<i>گروه به لیست گروه های ربات افزوده شد و ربات با موفقیت فعال شد✅</i>", bot.message_id);
                        Telegram.bot.sendMessage.send(javad, "<b>🎗ربات در گروهی با مشخصات زیر اضافه شد</b>" + "\n"+ "<b>❄️شناسه گروه:</b>" + "\n" + "<b>"+Telegram.bot.chat_id+"</b>" +"\n"+ "<b>🔅نام گروه:</b>" + "\n" +"<b>"+ Telegram.bot.chat_title+"</b>");
                    }
                    if (Telegram.bot.message_text.ToLower() == "/maqam" && Telegram.bot.from_ID != javad)
                    {
                        Telegram.bot.sendMessage.parse_mode = "html";
                        Telegram.bot.sendMessage.reply_to_message(Telegram.bot.chat_id, "<i>شما کاربر عادی هستید♥️</i>", Telegram.bot.message_id);
                    }
                    if (Telegram.bot.message_text.ToLower() == "/maqam" && Telegram.bot.from_ID == javad)
                    {
                        Telegram.bot.sendMessage.parse_mode = "html";
                        Telegram.bot.sendMessage.reply_to_message(Telegram.bot.chat_id, "<i>شما مدیر ربات هستید♥️</i>", Telegram.bot.message_id);
                    }
                    if (Telegram.bot.message_text.ToLower() == "/info")
                    {
                        Telegram.bot.sendMessage.parse_mode = "html";
                        Telegram.bot.sendMessage.reply_to_message(Telegram.bot.chat_id, "<b>👨‍👩‍👦‍👦شناسه گروه:</b>" + "\n" + "<b>" + Telegram.bot.chat_id + "</b>" + "\n" + "<b>" + "🏵نام گروه:" + "</b>" + "\n" + "<b>" + Telegram.bot.chat_title + "</b>" + "\n" + "<b>" + "🗣شناسه پیام:" + "</b>" + "\n" + "<b>" + Telegram.bot.message_id + "</b>", Telegram.bot.message_id);
                    }
                    if (Telegram.bot.message_text.ToLower() == "/rphoto" && Telegram.bot.from_ID == javad)
                    {
                        Telegram.bot.sendMessage.parse_mode = "html";
                        Telegram.bot.Administrator_Group.deleteChatPhoto(bot.chat_id);
                        Telegram.bot.sendMessage.reply_to_message(Telegram.bot.chat_id, "<b>تصویر گروه با موفقیت حذف شد✅</b>", Telegram.bot.message_id);
                    }
                    if (Telegram.bot.message_text.IndexOf("/des ".ToLower()) == 0 && Telegram.bot.from_ID == javad)
                    {
                        Telegram.bot.sendMessage.parse_mode = "html";
                        Telegram.bot.Administrator_Group.setChatDescription(bot.chat_id, Telegram.bot.message_text.Substring(5));
                        Telegram.bot.sendMessage.reply_to_message(Telegram.bot.chat_id, "<b>متن درباره گروه با موفقیت تغییر کرد✅</b>", Telegram.bot.message_id);
                    }
                    if (Telegram.bot.message_text.IndexOf("/name ".ToLower()) == 0 && Telegram.bot.from_ID == javad)
                    {
                        Telegram.bot.sendMessage.parse_mode = "html";
                        Telegram.bot.Administrator_Group.setChatTitle(Telegram.bot.chat_id, Telegram.bot.message_text.Substring(5));
                        Telegram.bot.sendMessage.reply_to_message(Telegram.bot.chat_id, "<b>نام گروه با موفقیت تغییر کرد✅</b>", Telegram.bot.message_id);
                    }
                    if (Telegram.bot.message_text.ToLower() == "/lock link" && Telegram.bot.from_ID == javad)
                    {
                        Telegram.bot.sendMessage.parse_mode = "html";
                        Telegram.bot.sendMessage.reply_to_message(Telegram.bot.chat_id, "<b>قفل لینک فعال شد🔓</b>", Telegram.bot.message_id);
                        checkBox1.Checked = true;
                    }
                    if (Telegram.bot.message_text.ToLower() == "/unlock link" && Telegram.bot.from_ID == javad)
                    {
                        Telegram.bot.sendMessage.parse_mode = "html";
                        Telegram.bot.sendMessage.reply_to_message(Telegram.bot.chat_id, "<b>قفل لینک غیر فعال شد🔐</b>", Telegram.bot.message_id);
                        checkBox1.Checked = false;
                    }
                    if (checkBox1.Checked == true && Telegram.bot.from_ID != javad)
                    {
                        if (Telegram.bot.update.Contains("url"))
                        {
                            Telegram.bot.deletemessage.delete(Telegram.bot.chat_id, Telegram.bot.message_id);
                        }
                    }
                    if (Telegram.bot.message_text.ToLower() == "/lock tag" && Telegram.bot.from_ID == javad)
                    {
                        Telegram.bot.sendMessage.parse_mode = "html";
                        Telegram.bot.sendMessage.reply_to_message(Telegram.bot.chat_id, "<b>قفل تگ فعال شد🔓</b>", Telegram.bot.message_id);
                        checkBox2.Checked = true;
                    }
                    if (Telegram.bot.message_text.ToLower() == "/unlock tag" && Telegram.bot.from_ID == javad)
                    {
                        Telegram.bot.sendMessage.parse_mode = "html";
                        Telegram.bot.sendMessage.reply_to_message(Telegram.bot.chat_id, "<b>قفل تگ غیر فعال شد🔐</b>", Telegram.bot.message_id);
                        checkBox2.Checked = false;
                    }
                    if (checkBox2.Checked == true && Telegram.bot.from_ID != javad)
                    {
                        if (Telegram.bot.update.Contains("#"))
                        {
                            Telegram.bot.deletemessage.delete(Telegram.bot.chat_id, Telegram.bot.message_id);
                        }
                    }
                    if (Telegram.bot.message_text.ToLower() == "/lock user" && Telegram.bot.from_ID == javad)
                    {
                        Telegram.bot.sendMessage.parse_mode = "html";
                        Telegram.bot.sendMessage.reply_to_message(Telegram.bot.chat_id, "<b>قفل نام کاربری فعال شد🔓</b>", Telegram.bot.message_id);
                        checkBox4.Checked = true;
                    }
                    if (Telegram.bot.message_text.ToLower() == "/unlock user" && Telegram.bot.from_ID == javad)
                    {
                        Telegram.bot.sendMessage.parse_mode = "html";
                        Telegram.bot.sendMessage.reply_to_message(Telegram.bot.chat_id, "<b>قفل نام کاربری غیر فعال شد🔐</b>", Telegram.bot.message_id);
                        checkBox4.Checked = false;
                    }
                    if (checkBox4.Checked == true && Telegram.bot.from_ID != javad)
                    {
                        if (Telegram.bot.update.Contains("mention")| Telegram.bot.update.Contains("@"))
                        {
                            Telegram.bot.deletemessage.delete(Telegram.bot.chat_id, Telegram.bot.message_id);
                        }
                    }
                    if (Telegram.bot.message_text.ToLower() == "/lock all" && Telegram.bot.from_ID == javad)
                    {
                        Telegram.bot.sendMessage.parse_mode = "html";
                        Telegram.bot.sendMessage.reply_to_message(Telegram.bot.chat_id, "<b>قفل همه فعال شد🔓</b>", Telegram.bot.message_id);
                        checkBox5.Checked = true;
                        checkBox1.Checked = true;
                        checkBox2.Checked = true;
                        checkBox6.Checked = true;
                        checkBox4.Checked = true;
                        checkBox7.Checked = true;
                        checkBox8.Checked = true;
                        checkBox9.Checked = true;
                        checkBox3.Checked = true;
                        checkBox10.Checked = true;
                        checkBox11.Checked = true;
                        checkBox19.Checked = true;
                        checkBox12.Checked = true;
                        checkBox15.Checked = true;
                        checkBox20.Checked = true;
                        checkBox18.Checked = true;
                        checkBox16.Checked = true;
                        checkBox17.Checked = true;
                        checkBox13.Checked =true;
                        checkBox14.Checked = true;
                        checkBox21.Checked = true;

                    }
                    if (Telegram.bot.message_text.ToLower() == "/unlock all" && Telegram.bot.from_ID == javad)
                    {
                        Telegram.bot.sendMessage.parse_mode = "html";
                        Telegram.bot.sendMessage.reply_to_message(Telegram.bot.chat_id, "<b>قفل همه غیر فعال شد🔐</b>", Telegram.bot.message_id);
                        checkBox5.Checked = false;
                        checkBox1.Checked = false;
                        checkBox2.Checked = false;
                        checkBox4.Checked = false;
                        checkBox6.Checked = false;
                        checkBox7.Checked = false;
                        checkBox8.Checked = false;
                        checkBox9.Checked = false;
                        checkBox3.Checked = false;
                        checkBox10.Checked = false;
                        checkBox11.Checked = false;
                        checkBox19.Checked = false;
                        checkBox12.Checked = false;
                        checkBox15.Checked = false;
                        checkBox20.Checked = false;
                        checkBox18.Checked = false;
                        checkBox16.Checked = false;
                        checkBox17.Checked = false;
                        checkBox13.Checked = false;
                        checkBox14.Checked = false;
                        checkBox21.Checked = false;

                    }
                    if (Telegram.bot.message_text.ToLower() == "/lock cmd" && Telegram.bot.from_ID == javad)
                    {
                        Telegram.bot.sendMessage.parse_mode = "html";
                        Telegram.bot.sendMessage.reply_to_message(Telegram.bot.chat_id, "<b>قفل دستورات فعال شد🔓</b>", Telegram.bot.message_id);
                        checkBox6.Checked = true;
                    }
                    if (Telegram.bot.message_text.ToLower() == "/unlock cmd" && Telegram.bot.from_ID == javad)
                    {
                        Telegram.bot.sendMessage.parse_mode = "html";
                        Telegram.bot.sendMessage.reply_to_message(Telegram.bot.chat_id, "<b>قفل دستورات غیر فعال شد🔐</b>", Telegram.bot.message_id);
                        checkBox6.Checked = false;
                    }
                    if (checkBox6.Checked == true && Telegram.bot.from_ID != javad)
                    {
                        if (Telegram.bot.update.Contains("/"))
                        {
                            Telegram.bot.deletemessage.delete(Telegram.bot.chat_id, Telegram.bot.message_id);
                        }
                    }
                    if (Telegram.bot.message_text.ToLower() == "/lock text" && Telegram.bot.from_ID == javad)
                    {
                        Telegram.bot.sendMessage.parse_mode = "html";
                        Telegram.bot.sendMessage.reply_to_message(Telegram.bot.chat_id, "<b>قفل متن فعال شد🔓</b>", Telegram.bot.message_id);
                        checkBox7.Checked = true;
                    }
                    if (Telegram.bot.message_text.ToLower() == "/unlock text" && Telegram.bot.from_ID == javad)
                    {
                        Telegram.bot.sendMessage.parse_mode = "html";
                        Telegram.bot.sendMessage.reply_to_message(Telegram.bot.chat_id, "<b>قفل متن غیر فعال شد🔐</b>", Telegram.bot.message_id);
                        checkBox7.Checked = false;
                    }
                    if (checkBox7.Checked == true && Telegram.bot.from_ID != javad)
                    {
                        string txt = Telegram.bot.message_text;
                        if (Telegram.bot.message_text == txt)
                        {
                            Telegram.bot.deletemessage.delete(Telegram.bot.chat_id, Telegram.bot.message_id);
                        }
                    }
                    if (Telegram.bot.message_text.ToLower() == "/lock bot" && Telegram.bot.from_ID == javad)
                    {
                        Telegram.bot.sendMessage.parse_mode = "html";
                        Telegram.bot.sendMessage.reply_to_message(Telegram.bot.chat_id, "<b>قفل ربات فعال شد🔓</b>", Telegram.bot.message_id);
                        checkBox8.Checked = true;
                    }
                    if (Telegram.bot.message_text.ToLower() == "/unlock bot" && Telegram.bot.from_ID == javad)
                    {
                        Telegram.bot.sendMessage.parse_mode = "html";
                        Telegram.bot.sendMessage.reply_to_message(Telegram.bot.chat_id, "<b>قفل ربات غیر فعال شد🔐</b>", Telegram.bot.message_id);
                        checkBox8.Checked = false;
                    }
                    if (checkBox8.Checked == true && Telegram.bot.from_ID != javad)
                    {
                        if (Telegram.bot.update.Contains("bot") | Telegram.bot.message_text.Contains("BOT") | Telegram.bot.message_text.Contains("_") | Telegram.bot.message_text.Contains("Bot"))
                        {
                            Telegram.bot.deletemessage.delete(Telegram.bot.chat_id, Telegram.bot.message_id);
                        }
                    }
                    if (Telegram.bot.message_text.ToLower() == "/lock fosh" && Telegram.bot.from_ID == javad)
                    {
                        Telegram.bot.sendMessage.parse_mode = "html";
                        Telegram.bot.sendMessage.reply_to_message(Telegram.bot.chat_id, "<b>قفل فحش فعال شد🔓</b>", Telegram.bot.message_id);
                        checkBox9.Checked = true;
                    }
                    if (Telegram.bot.message_text.ToLower() == "/unlock fosh" && Telegram.bot.from_ID == javad)
                    {
                        Telegram.bot.sendMessage.parse_mode = "html";
                        Telegram.bot.sendMessage.reply_to_message(Telegram.bot.chat_id, "<b>قفل فحش غیر فعال شد🔐</b>", Telegram.bot.message_id);
                        checkBox9.Checked = false;
                    }
                    if (checkBox9.Checked == true && Telegram.bot.from_ID != javad)
                    {
                        if (Telegram.bot.update.Contains("fuck") | Telegram.bot.message_text.Contains("FUCK") | Telegram.bot.message_text.Contains("کون") | Telegram.bot.message_text.Contains("کونی") | Telegram.bot.message_text.Contains("کیر") | Telegram.bot.message_text.Contains("کص") | Telegram.bot.message_text.Contains("کس نتت") | Telegram.bot.message_text.Contains("کس کش") | Telegram.bot.message_text.Contains("کص کش") | Telegram.bot.message_text.Contains("کونکش") | Telegram.bot.message_text.Contains("کون کش") | Telegram.bot.message_text.Contains("کیری") | Telegram.bot.message_text.Contains("کوس") | Telegram.bot.message_text.Contains("کوس کش") | Telegram.bot.message_text.Contains("خایه") | Telegram.bot.message_text.Contains("سکس") | Telegram.bot.message_text.Contains("سکسی") | Telegram.bot.message_text.Contains("حشری") | Telegram.bot.message_text.Contains("فاک") | Telegram.bot.message_text.Contains("جنده") | Telegram.bot.message_text.Contains("کیرم") | Telegram.bot.message_text.Contains("کسکش") | Telegram.bot.message_text.Contains("فاعک") | Telegram.bot.message_text.Contains("فآک") | Telegram.bot.message_text.Contains("فآعک") | Telegram.bot.message_text.Contains("سیک") | Telegram.bot.message_text.Contains("سیکتیر"))
                        {
                            Telegram.bot.deletemessage.delete(Telegram.bot.chat_id, Telegram.bot.message_id);
                        }
                    }
                    if (Telegram.bot.message_text.ToLower() == "/lock photo" && Telegram.bot.from_ID == javad)
                    {
                        Telegram.bot.sendMessage.parse_mode = "html";
                        Telegram.bot.sendMessage.reply_to_message(Telegram.bot.chat_id, "<b>قفل تصویر فعال شد🔓</b>", Telegram.bot.message_id);
                        checkBox3.Checked = true;
                    }
                    if (Telegram.bot.message_text.ToLower() == "/unlock photo" && Telegram.bot.from_ID == javad)
                    {
                        Telegram.bot.sendMessage.parse_mode = "html";
                        Telegram.bot.sendMessage.reply_to_message(Telegram.bot.chat_id, "<b>قفل تصویر غیر فعال شد🔐</b>", Telegram.bot.message_id);
                        checkBox3.Checked = false;
                    }
                    if (checkBox3.Checked == true && Telegram.bot.from_ID != javad)
                    {
                        if (Telegram.bot.update.Contains("photo"))
                        {
                            Telegram.bot.deletemessage.delete(Telegram.bot.chat_id, Telegram.bot.message_id);
                        }
                    }
                    if (Telegram.bot.message_text.ToLower() == "/lock video" && Telegram.bot.from_ID == javad)
                    {
                        Telegram.bot.sendMessage.parse_mode = "html";
                        Telegram.bot.sendMessage.reply_to_message(Telegram.bot.chat_id, "<b>قفل ویدیو فعال شد🔓</b>", Telegram.bot.message_id);
                        checkBox10.Checked = true;
                    }
                    if (Telegram.bot.message_text.ToLower() == "/unlock video" && Telegram.bot.from_ID == javad)
                    {
                        Telegram.bot.sendMessage.parse_mode = "html";
                        Telegram.bot.sendMessage.reply_to_message(Telegram.bot.chat_id, "<b>قفل ویدیو غیر فعال شد🔐</b>", Telegram.bot.message_id);
                        checkBox10.Checked = false;
                    }
                    if (checkBox10.Checked == true && Telegram.bot.from_ID != javad)
                    {
                        if (Telegram.bot.update.Contains("video"))
                        {
                            Telegram.bot.deletemessage.delete(Telegram.bot.chat_id, Telegram.bot.message_id);
                        }
                    }
                    if (Telegram.bot.message_text.ToLower() == "/lock voice" && Telegram.bot.from_ID == javad)
                    {
                        Telegram.bot.sendMessage.parse_mode = "html";
                        Telegram.bot.sendMessage.reply_to_message(Telegram.bot.chat_id, "<b>قفل صدا فعال شد🔓</b>", Telegram.bot.message_id);
                        checkBox11.Checked = true;
                    }
                    if (Telegram.bot.message_text.ToLower() == "/unlock voice" && Telegram.bot.from_ID == javad)
                    {
                        Telegram.bot.sendMessage.parse_mode = "html";
                        Telegram.bot.sendMessage.reply_to_message(Telegram.bot.chat_id, "<b>قفل صدا غیر فعال شد🔐</b>", Telegram.bot.message_id);
                        checkBox11.Checked = false;
                    }
                    if (checkBox11.Checked == true && Telegram.bot.from_ID != javad)
                    {
                        if (Telegram.bot.update.Contains("voice"))
                        {
                            Telegram.bot.deletemessage.delete(Telegram.bot.chat_id, Telegram.bot.message_id);
                        }
                    }
                    if (Telegram.bot.message_text.ToLower() == "/lock sticker" && Telegram.bot.from_ID == javad)
                    {
                        Telegram.bot.sendMessage.parse_mode = "html";
                        Telegram.bot.sendMessage.reply_to_message(Telegram.bot.chat_id, "<b>قفل استیکر فعال شد🔓</b>", Telegram.bot.message_id);
                        checkBox19.Checked = true;
                    }
                    if (Telegram.bot.message_text.ToLower() == "/unlock sticker" && Telegram.bot.from_ID == javad)
                    {
                        Telegram.bot.sendMessage.parse_mode = "html";
                        Telegram.bot.sendMessage.reply_to_message(Telegram.bot.chat_id, "<b>قفل استیکر غیر فعال شد🔐</b>", Telegram.bot.message_id);
                        checkBox19.Checked = false;
                    }
                    if (checkBox19.Checked == true && Telegram.bot.from_ID != javad)
                    {
                        if (Telegram.bot.update.Contains("sticker"))
                        {
                            Telegram.bot.deletemessage.delete(Telegram.bot.chat_id, Telegram.bot.message_id);
                        }
                    }
                    if (Telegram.bot.message_text.ToLower() == "/lock audio" && Telegram.bot.from_ID == javad)
                    {
                        Telegram.bot.sendMessage.parse_mode = "html";
                        Telegram.bot.sendMessage.reply_to_message(Telegram.bot.chat_id, "<b>قفل آهنگ فعال شد🔓</b>", Telegram.bot.message_id);
                        checkBox12.Checked = true;
                    }
                    if (Telegram.bot.message_text.ToLower() == "/unlock audio" && Telegram.bot.from_ID == javad)
                    {
                        Telegram.bot.sendMessage.parse_mode = "html";
                        Telegram.bot.sendMessage.reply_to_message(Telegram.bot.chat_id, "<b>قفل آهنگ غیر فعال شد🔐</b>", Telegram.bot.message_id);
                        checkBox12.Checked = false;
                    }
                    if (checkBox12.Checked == true && Telegram.bot.from_ID != javad)
                    {
                        if (Telegram.bot.update.Contains("audio"))
                        {
                            Telegram.bot.deletemessage.delete(Telegram.bot.chat_id, Telegram.bot.message_id);
                        }
                    }
                    if (Telegram.bot.message_text.ToLower() == "/lock fw" && Telegram.bot.from_ID == javad)
                    {
                        Telegram.bot.sendMessage.parse_mode = "html";
                        Telegram.bot.sendMessage.reply_to_message(Telegram.bot.chat_id, "<b>قفل فروارد فعال شد🔓</b>", Telegram.bot.message_id);
                        checkBox15.Checked = true;
                    }
                    if (Telegram.bot.message_text.ToLower() == "/unlock fw" && Telegram.bot.from_ID == javad)
                    {
                        Telegram.bot.sendMessage.parse_mode = "html";
                        Telegram.bot.sendMessage.reply_to_message(Telegram.bot.chat_id, "<b>قفل فروارد غیر فعال شد🔐</b>", Telegram.bot.message_id);
                        checkBox15.Checked = false;
                    }
                    if (checkBox15.Checked == true && Telegram.bot.from_ID != javad)
                    {
                        if (Telegram.bot.update.Contains("forward_from"))
                        {
                            Telegram.bot.deletemessage.delete(Telegram.bot.chat_id, Telegram.bot.message_id);
                        }
                    }
                    if (Telegram.bot.message_text.ToLower() == "/lock dc" && Telegram.bot.from_ID == javad)
                    {
                        Telegram.bot.sendMessage.parse_mode = "html";
                        Telegram.bot.sendMessage.reply_to_message(Telegram.bot.chat_id, "<b>قفل فایل فعال شد🔓</b>", Telegram.bot.message_id);
                        checkBox20.Checked = true;
                    }
                    if (Telegram.bot.message_text.ToLower() == "/unlock dc" && Telegram.bot.from_ID == javad)
                    {
                        Telegram.bot.sendMessage.parse_mode = "html";
                        Telegram.bot.sendMessage.reply_to_message(Telegram.bot.chat_id, "<b>قفل فایل غیر فعال شد🔐</b>", Telegram.bot.message_id);
                        checkBox20.Checked = false;
                    }
                    if (checkBox20.Checked == true && Telegram.bot.from_ID != javad)
                    {
                        if (Telegram.bot.update.Contains("document"))
                        {
                            Telegram.bot.deletemessage.delete(Telegram.bot.chat_id, Telegram.bot.message_id);
                        }
                    }
                    if (Telegram.bot.message_text.ToLower() == "/lock edite" && Telegram.bot.from_ID == javad)
                    {
                        Telegram.bot.sendMessage.parse_mode = "html";
                        Telegram.bot.sendMessage.reply_to_message(Telegram.bot.chat_id, "<b>قفل ویرایش فعال شد🔓</b>", Telegram.bot.message_id);
                        checkBox18.Checked = true;
                    }
                    if (Telegram.bot.message_text.ToLower() == "/unlock edite" && Telegram.bot.from_ID == javad)
                    {
                        Telegram.bot.sendMessage.parse_mode = "html";
                        Telegram.bot.sendMessage.reply_to_message(Telegram.bot.chat_id, "<b>قفل ویرایش غیر فعال شد🔐</b>", Telegram.bot.message_id);
                        checkBox18.Checked = false;
                    }
                    if (checkBox18.Checked == true && Telegram.bot.from_ID != javad)
                    {
                        if (Telegram.bot.update.Contains("edit_date"))
                        {
                            Telegram.bot.deletemessage.delete(Telegram.bot.chat_id, Telegram.bot.message_id);
                        }
                    }
                    if (Telegram.bot.message_text.ToLower() == "/lock join" && Telegram.bot.from_ID == javad)
                    {
                        Telegram.bot.sendMessage.parse_mode = "html";
                        Telegram.bot.sendMessage.reply_to_message(Telegram.bot.chat_id, "<b>قفل ورود فعال شد🔓</b>", Telegram.bot.message_id);
                        checkBox16.Checked = true;
                    }
                    if (Telegram.bot.message_text.ToLower() == "/unlock join" && Telegram.bot.from_ID == javad)
                    {
                        Telegram.bot.sendMessage.parse_mode = "html";
                        Telegram.bot.sendMessage.reply_to_message(Telegram.bot.chat_id, "<b>قفل ورود غیر فعال شد🔐</b>", Telegram.bot.message_id);
                        checkBox16.Checked = false;
                    }
                    if (checkBox16.Checked == true && Telegram.bot.from_ID != javad)
                    {
                        if (Telegram.bot.update.Contains("new_chat_member"))
                        {
                            Telegram.bot.deletemessage.delete(Telegram.bot.chat_id, Telegram.bot.message_id);
                        }
                    }
                    if (Telegram.bot.message_text.ToLower() == "/lock left" && Telegram.bot.from_ID == javad)
                    {
                        Telegram.bot.sendMessage.parse_mode = "html";
                        Telegram.bot.sendMessage.reply_to_message(Telegram.bot.chat_id, "<b>قفل خروج فعال شد🔓</b>", Telegram.bot.message_id);
                        checkBox17.Checked = true;
                    }
                    if (Telegram.bot.message_text.ToLower() == "/unlock left" && Telegram.bot.from_ID == javad)
                    {
                        Telegram.bot.sendMessage.parse_mode = "html";
                        Telegram.bot.sendMessage.reply_to_message(Telegram.bot.chat_id, "<b>قفل خروج غیر فعال شد🔐</b>", Telegram.bot.message_id);
                        checkBox17.Checked = false;
                    }
                    if (checkBox17.Checked == true && Telegram.bot.from_ID != javad)
                    {
                        if (Telegram.bot.update.Contains("left_chat_member"))
                        {
                            Telegram.bot.deletemessage.delete(Telegram.bot.chat_id, Telegram.bot.message_id);
                        }
                    }
                    if (Telegram.bot.message_text.ToLower() == "/lock con" && Telegram.bot.from_ID == javad)
                    {
                        Telegram.bot.sendMessage.parse_mode = "html";
                        Telegram.bot.sendMessage.reply_to_message(Telegram.bot.chat_id, "<b>قفل مخاطب فعال شد🔓</b>", Telegram.bot.message_id);
                        checkBox13.Checked = true;
                    }
                    if (Telegram.bot.message_text.ToLower() == "/unlock con" && Telegram.bot.from_ID == javad)
                    {
                        Telegram.bot.sendMessage.parse_mode = "html";
                        Telegram.bot.sendMessage.reply_to_message(Telegram.bot.chat_id, "<b>قفل مخاطب غیر فعال شد🔐</b>", Telegram.bot.message_id);
                        checkBox13.Checked = false;
                    }
                    if (checkBox13.Checked == true && Telegram.bot.from_ID != javad)
                    {
                        if (Telegram.bot.update.Contains("contact"))
                        {
                            Telegram.bot.deletemessage.delete(Telegram.bot.chat_id, Telegram.bot.message_id);
                        }
                    }
                    if (Telegram.bot.message_text.ToLower() == "/lock loc" && Telegram.bot.from_ID == javad)
                    {
                        Telegram.bot.sendMessage.parse_mode = "html";
                        Telegram.bot.sendMessage.reply_to_message(Telegram.bot.chat_id, "<b>قفل موقعیت فعال شد🔓</b>", Telegram.bot.message_id);
                        checkBox14.Checked = true;
                    }
                    if (Telegram.bot.message_text.ToLower() == "/unlock loc" && Telegram.bot.from_ID == javad)
                    {
                        Telegram.bot.sendMessage.parse_mode = "html";
                        Telegram.bot.sendMessage.reply_to_message(Telegram.bot.chat_id, "<b>قفل موقعیت غیر فعال شد🔐</b>", Telegram.bot.message_id);
                        checkBox14.Checked = false;
                    }
                    if (checkBox14.Checked == true && Telegram.bot.from_ID != javad)
                    {
                        if (Telegram.bot.update.Contains("location"))
                        {
                            Telegram.bot.deletemessage.delete(Telegram.bot.chat_id, Telegram.bot.message_id);
                        }
                    }
                    if (Telegram.bot.message_text.ToLower() == "/lock game" && Telegram.bot.from_ID == javad)
                    {
                        Telegram.bot.sendMessage.parse_mode = "html";
                        Telegram.bot.sendMessage.reply_to_message(Telegram.bot.chat_id, "<b>قفل بازی فعال شد🔓</b>", Telegram.bot.message_id);
                        checkBox21.Checked = true;
                    }
                    if (Telegram.bot.message_text.ToLower() == "/unlock game" && Telegram.bot.from_ID == javad)
                    {
                        Telegram.bot.sendMessage.parse_mode = "html";
                        Telegram.bot.sendMessage.reply_to_message(Telegram.bot.chat_id, "<b>قفل بازی غیر فعال شد🔐</b>", Telegram.bot.message_id);
                        checkBox21.Checked = false;
                    }
                    if (checkBox21.Checked == true && Telegram.bot.from_ID != javad)
                    {
                        if (Telegram.bot.update.Contains("game"))
                        {
                            Telegram.bot.deletemessage.delete(Telegram.bot.chat_id, Telegram.bot.message_id);
                        }
                    }
                    if (Telegram.bot.message_text.ToLower() == "/time")
                    {
                        Telegram.bot.sendMessage.parse_mode = "html";
                        int sec, min, hour;
                        hour = System.DateTime.Now.Hour;
                        min = System.DateTime.Now.Minute;
                        sec = System.DateTime.Now.Second;
                        if (hour < 10) hour = int.Parse("0" + hour.ToString());
                        if (hour < 10) min = int.Parse("0" + min.ToString());
                        if (hour < 10) sec = int.Parse("0" + sec.ToString());
                        string timers = hour.ToString() + ":" + min.ToString() + ":" + sec.ToString();
                        System.Globalization.PersianCalendar pc = new System.Globalization.PersianCalendar();
                        string date = pc.GetYear(DateTime.Now) + "/" + pc.GetMonth(DateTime.Now) + "/" + pc.GetDayOfMonth(DateTime.Now);
                        Telegram.bot.sendMessage.reply_to_message(Telegram.bot.chat_id, "<b>" + "📆تاریخ:" + date + "</b>" + Environment.NewLine + "<b>" + "⏰زمان:" + timers + "</b>", Telegram.bot.message_id);
                    }
                    if(Telegram.bot.message_text.IndexOf("/slink".ToLower()) == 0 &&Telegram.bot.message_text.Contains("https://t.me/joinchat/") && Telegram.bot.from_ID == javad && checkBox25.Checked == true)
                    {
                        gplink = null;
                        gplink = Telegram.bot.message_text.Substring(7);
                        Telegram.bot.sendMessage.parse_mode = "html";
                        Telegram.bot.sendMessage.reply_to_message(Telegram.bot.chat_id, "<b>لینک گروه با موفقیت تغییر کرد✅</b>", Telegram.bot.message_id);
                    }
                    if(Telegram.bot.message_text.ToLower()=="/link" && checkBox25.Checked == true)
                    {
                        Telegram.bot.sendMessage.parse_mode = "html";
                        Telegram.bot.sendMessage.reply_to_message(Telegram.bot.chat_id, gplink, Telegram.bot.message_id);
                    }
                    if (Telegram.bot.message_text.ToLower() == "/en link")
                    {
                        checkBox25.Checked = true;
                        Telegram.bot.sendMessage.parse_mode = "html";
                        Telegram.bot.sendMessage.reply_to_message(Telegram.bot.chat_id, "<b>نمایش لینک گروه با موفقیت فعال شد✅</b>", Telegram.bot.message_id);
                    }
                    if (Telegram.bot.message_text.ToLower() == "/ds link")
                    {
                        checkBox25.Checked = false;
                        Telegram.bot.sendMessage.parse_mode = "html";
                        Telegram.bot.sendMessage.reply_to_message(Telegram.bot.chat_id, "<b>نمایش لینک گروه با موفقیت غیرفعال شد✅</b>", Telegram.bot.message_id);
                    }
                    if(Telegram.bot.message_text.ToLower()=="/link"&&gplink==null)
                    {
                        Telegram.bot.sendMessage.parse_mode = "html";
                        Telegram.bot.sendMessage.reply_to_message(Telegram.bot.chat_id, "<b>هنوز لینکی ثبت نشده❗️</b>", Telegram.bot.message_id);
                    }
                    if (Telegram.bot.message_text.IndexOf("/srules".ToLower()) == 0 && Telegram.bot.from_ID == javad && checkBox24.Checked == true)
                    {
                        rules = null;
                        rules = Telegram.bot.message_text.Substring(8);
                        Telegram.bot.sendMessage.parse_mode = "html";
                        Telegram.bot.sendMessage.reply_to_message(Telegram.bot.chat_id, "<b>قوانین گروه با موفقیت تغییر کرد✅</b>", Telegram.bot.message_id);
                    }
                    if (Telegram.bot.message_text.ToLower() == "/rules" && checkBox24.Checked == true)
                    {
                        Telegram.bot.sendMessage.parse_mode = "html";
                        Telegram.bot.sendMessage.reply_to_message(Telegram.bot.chat_id,"<b>"+ rules+"</b>", Telegram.bot.message_id);
                    }
                    if (Telegram.bot.message_text.ToLower() == "/en rules")
                    {
                        checkBox24.Checked = true;
                        Telegram.bot.sendMessage.parse_mode = "html";
                        Telegram.bot.sendMessage.reply_to_message(Telegram.bot.chat_id, "<b>قوانین گروه با موفقیت فعال شد✅</b>", Telegram.bot.message_id);
                    }
                    if (Telegram.bot.message_text.ToLower() == "/ds rules")
                    {
                        checkBox24.Checked = false;
                        Telegram.bot.sendMessage.parse_mode = "html";
                        Telegram.bot.sendMessage.reply_to_message(Telegram.bot.chat_id, "<b>قوانین گروه با موفقیت غیرفعال شد✅</b>", Telegram.bot.message_id);
                    }
                    if (Telegram.bot.message_text.ToLower() == "/rules" && rules == null)
                    {
                        Telegram.bot.sendMessage.parse_mode = "html";
                        Telegram.bot.sendMessage.reply_to_message(Telegram.bot.chat_id, "<b>هنوز قوانینی ثبت نشده❗️</b>", Telegram.bot.message_id);
                    }
                    if (Telegram.bot.message_text.ToLower()=="/rules"&&checkBox24.Checked==false)
                    {
                        Telegram.bot.sendMessage.parse_mode = "html";
                        Telegram.bot.sendMessage.reply_to_message(Telegram.bot.chat_id, "<b>متاسفانه نمایش قوانین غیرفعال میباشد😐</b>", Telegram.bot.message_id);
                    }
                    if (Telegram.bot.message_text.ToLower() == "/link" && checkBox25.Checked == false)
                    {
                        Telegram.bot.sendMessage.parse_mode = "html";
                        Telegram.bot.sendMessage.reply_to_message(Telegram.bot.chat_id, "<b>متاسفانه نمایش لینک گروه غیرفعال میباشد😐</b>", Telegram.bot.message_id);
                    }
                    if (Telegram.bot.message_text.IndexOf("/sjoin".ToLower()) == 0 && Telegram.bot.from_ID ==javad&&checkBox22.Checked==true)
                    {
                        join = null;
                        join = Telegram.bot.message_text.Substring(7);
                        Telegram.bot.sendMessage.parse_mode = "html";
                        Telegram.bot.sendMessage.reply_to_message(Telegram.bot.chat_id, "<b>پیام خوش آمد با موفقیت تغییر کرد✅</b>", Telegram.bot.message_id);
                    }
                    if(Telegram.bot.message_text.ToLower()=="/en join")
                    {
                        checkBox22.Checked = true;
                        Telegram.bot.sendMessage.parse_mode = "html";
                        Telegram.bot.sendMessage.reply_to_message(Telegram.bot.chat_id, "<b>پیام خوش آمد با موفقیت فعال شد✅</b>", Telegram.bot.message_id);
                    }
                    if (Telegram.bot.message_text.ToLower() == "/ds join")
                    {
                        checkBox22.Checked = false;
                        Telegram.bot.sendMessage.parse_mode = "html";
                        Telegram.bot.sendMessage.reply_to_message(Telegram.bot.chat_id, "<b>پیام خوش آمد با موفقیت غیرفعال شد✅</b>", Telegram.bot.message_id);
                    }
                    if (Telegram.bot.update.Contains( "new_chat_member")&&checkBox22.Checked==true)
                    {
                        Telegram.bot.sendMessage.parse_mode = "html";
                        Telegram.bot.sendMessage.reply_to_message(Telegram.bot.chat_id,  "<b>" + join + "</b>", Telegram.bot.message_id);
                    }
                    if (Telegram.bot.message_text.IndexOf("/sleft".ToLower()) == 0 && Telegram.bot.from_ID == javad && checkBox23.Checked == true)
                    {
                        left = null;
                        left = Telegram.bot.message_text.Substring(7);
                        Telegram.bot.sendMessage.parse_mode = "html";
                        Telegram.bot.sendMessage.reply_to_message(Telegram.bot.chat_id, "<b>پیام خروج با موفقیت تغییر کرد✅</b>", Telegram.bot.message_id);
                    }
                    if (Telegram.bot.message_text.ToLower() == "/en left")
                    {
                        checkBox23.Checked = true;
                        Telegram.bot.sendMessage.parse_mode = "html";
                        Telegram.bot.sendMessage.reply_to_message(Telegram.bot.chat_id, "<b>پیام خروج با موفقیت فعال شد✅</b>", Telegram.bot.message_id);
                    }
                    if (Telegram.bot.message_text.ToLower() == "/ds left")
                    {
                        checkBox23.Checked = false;
                        Telegram.bot.sendMessage.parse_mode = "html";
                        Telegram.bot.sendMessage.reply_to_message(Telegram.bot.chat_id, "<b>پیام خروج با موفقیت غیرفعال شد✅</b>", Telegram.bot.message_id);
                    }
                    if (Telegram.bot.update.Contains("left_chat_member") && checkBox23.Checked == true)
                    {
                        Telegram.bot.sendMessage.parse_mode = "html";
                        Telegram.bot.sendMessage.reply_to_message(Telegram.bot.chat_id, "<b>" + left + "</b>", Telegram.bot.message_id);
                    }
                    if(Telegram.bot.message_text.ToLower()=="/slock"&&Telegram.bot.from_ID==javad)
                    {
                        Telegram.bot.sendMessage.parse_mode = "html";
                        Telegram.bot.sendMessage.reply_to_message(Telegram.bot.chat_id, "<b>🔹قفل لینک: </b>" + checkBox1.Checked+"\n"+ "<b>🔹قفل تگ: </b>" + checkBox2.Checked+"\n"+ "<b>🔹قفل تصویر: </b>" + checkBox3.Checked+"\n"+ "<b>🔹قفل نام کاربری: </b>" + checkBox4.Checked+"\n"+ "<b>🔹قفل همه: </b>" + checkBox5.Checked+"\n"+ "<b>🔹قفل دستورات: </b>" + checkBox6.Checked+"\n"+ "<b>🔹قفل متن: </b>" + checkBox7.Checked + "\n" + "<b>🔹قفل ربات: </b>" + checkBox8.Checked + "\n" + "<b>🔹قفل فحش: </b>" + checkBox9.Checked + "\n" + "<b>🔹قفل ویدیو: </b>" + checkBox10.Checked + "\n" + "<b>🔹قفل صدا: </b>" + checkBox11.Checked + "\n" + "<b>🔹قفل آهنگ: </b>" + checkBox12.Checked + "\n" + "<b>🔹قفل مخاطب: </b>" + checkBox13.Checked + "\n" + "<b>🔹قفل موقعیت: </b>" + checkBox14.Checked + "\n" + "<b>🔹قفل فروارد: </b>" + checkBox15.Checked + "\n" + "<b>🔹قفل ورود: </b>" + checkBox16.Checked + "\n" + "<b>🔹قفل خروج: </b>" + checkBox17.Checked + "\n" + "<b>🔹قفل ویرایش: </b>" + checkBox18.Checked + "\n" + "<b>🔹قفل استیکر: </b>" + checkBox19.Checked + "\n" + "<b>🔹قفل فایل: </b>" + checkBox20.Checked + "\n" + "<b>🔹قفل بازی: </b>" + checkBox21.Checked, Telegram.bot.message_id);
                    }
                    if (Telegram.bot.message_text.ToLower()=="/more"&&Telegram.bot.from_ID==javad)
                    {
                        Telegram.bot.sendMessage.parse_mode = "html";
                        Telegram.bot.sendMessage.reply_to_message(Telegram.bot.chat_id,"<b>🔸پیام خوش آمد: </b>" +checkBox22.Checked+"\n"+ "<b>🔸پیام خروج: </b>" + checkBox23.Checked + "\n" + "<b>🔸نمایش قوانین: </b>" + checkBox24.Checked + "\n" + "<b>🔸نمایش لینک گروه: </b>" + checkBox25.Checked, Telegram.bot.message_id);
                    }
                    if (Telegram.bot.message_text.ToLower()=="/help"&&Telegram.bot.from_ID==javad)
                    {
                        Telegram.bot.send_inline_keyboard.keyboard_R1_1 = "نمایش دستورات گروه🌟";
                        Telegram.bot.send_inline_keyboard.keyboard_R1_1_callback_data = "help";
                        Telegram.bot.send_inline_keyboard.send(Telegram.bot.chat_id, "لطفا برای نمایش دستورات مدیریت گروه دکمه زیر را لمس کنید‼️");
                    }
                    if (Telegram.bot.data=="help" && Telegram.bot.from_ID == javad)
                    {
                        Telegram.bot.editMessageInlinekeyboard.keyboard_R1_1 = "بستن❌";
                        Telegram.bot.editMessageInlinekeyboard.keyboard_R1_1_callback_data = "close";
                        Telegram.bot.editMessageInlinekeyboard.send(Telegram.bot.chat_id, Telegram.bot.message_id, "درحال ارسال فایل راهنما لطفا اندکی صبر کنید...🕒");
                       Telegram.bot.SendFile.caption = "فایل راهنمای گروه ربات سنیور♥️";
                        Telegram.bot.SendFile.sendFromFile_id(Telegram.bot.chat_id,"BQADAgADcAADi-PoSP4r9eBDbvjjAg");
                    }
                    if (Telegram.bot.data=="close" && Telegram.bot.from_ID == javad)
                    {
                        Telegram.bot.editMessageInlinekeyboard.send(Telegram.bot.chat_id, Telegram.bot.message_id, "راهنمای گروه بسته شد!");
                    }
                    if (Telegram.bot.data == "help"&&Telegram.bot.from_ID!=javad)
                    {
                        Telegram.bot.answerCallbackQuery.send(Telegram.bot.callback_query_id, "متاسفیم ولی شما مدیر ربات نیستید⚠️");
                    }
                    if (Telegram.bot.data == "close" && Telegram.bot.from_ID != javad)
                    {
                        Telegram.bot.answerCallbackQuery.send(Telegram.bot.callback_query_id, "متاسفیم ولی شما مدیر ربات نیستید⚠️");
                    }
                    if (Telegram.bot.message_text.ToLower() == "/kick"&&Telegram.bot.from_ID == javad)
                    {
                        string reply_to_from_id = (Telegram.bot.update.Split(new string[] { @"""reply_to_message"":{""message_id""" }, StringSplitOptions.None)[1].Split('s')[0]).Split(new string[] { @"""from"":{""id"":" }, StringSplitOptions.None)[1].Split(',')[0];
                        Telegram.bot.Administrator_Group.kickChatMember(Telegram.bot.chat_id, reply_to_from_id);
                        Telegram.bot.Administrator_Group.unbanChatMember(Telegram.bot.chat_id, reply_to_from_id);
                        Telegram.bot.sendMessage.parse_mode = "html";
                        Telegram.bot.sendMessage.reply_to_message(Telegram.bot.chat_id, "<b>کاربر از گروه اخراج شد🚫</b>", Telegram.bot.message_id);
                    }
                    if (Telegram.bot.message_text.ToLower() == "/ban"&&Telegram.bot.from_ID == javad)
                    {
                        string reply_to_from_id = (Telegram.bot.update.Split(new string[] { @"""reply_to_message"":{""message_id""" }, StringSplitOptions.None)[1].Split('s')[0]).Split(new string[] { @"""from"":{""id"":" }, StringSplitOptions.None)[1].Split(',')[0];
                        Telegram.bot.Administrator_Group.kickChatMember(Telegram.bot.chat_id, reply_to_from_id);
                        Telegram.bot.sendMessage.parse_mode = "html";
                        Telegram.bot.sendMessage.reply_to_message(Telegram.bot.chat_id, "<b>کاربر از گروه مسدود شد🚫</b>", Telegram.bot.message_id);
                    }
                    if (Telegram.bot.message_text.ToLower() == "/unban" && Telegram.bot.from_ID == javad)
                    {
                        string reply_to_from_id = (Telegram.bot.update.Split(new string[] { @"""reply_to_message"":{""message_id""" }, StringSplitOptions.None)[1].Split('s')[0]).Split(new string[] { @"""from"":{""id"":" }, StringSplitOptions.None)[1].Split(',')[0];
                        Telegram.bot.Administrator_Group.unbanChatMember(Telegram.bot.chat_id, reply_to_from_id);
                        Telegram.bot.sendMessage.parse_mode = "html";
                        Telegram.bot.sendMessage.reply_to_message(Telegram.bot.chat_id, "<b>کاربر رفع مسدودیت شد✅</b>", Telegram.bot.message_id);
                    }
                    string textmessage = "";
                    try
                    {
                  textmessage = (Telegram.bot.update.Split(new string[] { @"""reply_to_message"":{""message_id""" }, StringSplitOptions.None)[1].Split(':')[13]);
                  textmessage = textmessage.Replace('"', ' ');
                  textmessage = textmessage.Replace(',', ' ');
                  textmessage = textmessage.Substring(1);
                  textmessage = textmessage.Replace("entities", "");
                  textmessage = textmessage.TrimEnd();
                    }
                    catch (Exception)
                    {

                    }
                    if ("/pin" == textmessage.ToLower()&&Telegram.bot.from_ID==javad)
                    {
              string messageid;
              string JosonString = Telegram.bot.update.ToString();
              messageid = Telegram.JSON.Read.get_JSONRead(JosonString, "reply_to_message", "message_id");
              Telegram.bot.Administrator_Group.pinChatMessage(Telegram.bot.chat_id, messageid, true);
              Telegram.bot.sendMessage.parse_mode = "html";
              Telegram.bot.sendMessage.reply_to_message(Telegram.bot.chat_id, "<b>پیام با موفقیت سنجاق شد✅</b>", Telegram.bot.message_id);
                    }
                }  
                }
                
            }
    }
}
